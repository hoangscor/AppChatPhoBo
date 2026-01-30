//using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Drawing;



namespace Server
{
    public partial class Form1 : Form
    {
        string bindIp = "26.202.195.142"; // đợi ip
        int bindPort = 9999;

        // ===== Modern UI / Animation (Pastel Blue) =====
        private System.Windows.Forms.Timer _fadeTimer;
        private readonly Dictionary<Control, System.Windows.Forms.Timer> _anim = new();

        private readonly Color _bg = Color.FromArgb(244, 248, 255);        // nền xanh nhạt
        private readonly Color _card = Color.White;                         // nền control
        private readonly Color _primary = Color.FromArgb(168, 210, 255);     // pastel blue (normal)
        private readonly Color _primaryHover = Color.FromArgb(140, 195, 255); // pastel blue (hover)
        private readonly Color _text = Color.FromArgb(33, 37, 41);


        public Form1()
        {

            InitializeComponent();

            this.AcceptButton = null;
            txbMessage.KeyDown += txbMessage_KeyDown;


            ApplyModernUi();
            this.Opacity = 0;
            this.Shown += (_, __) => StartFadeIn();

            // hỏi IP/Port khi mở server
            bindIp = Prompt("ChatPhoBo Server", "Nhập IP bind (26.202.195.142 = tất cả):", "26.202.195.142");
            string p = Prompt("ChatPhoBo Server", "Nhập Port:", "9999");
            if (!int.TryParse(p, out bindPort)) bindPort = 9999;

            Connect();
        }
        /// <summary>
        /// đóng kết nối
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect(); // đóng kết nối
        }
        /// <summary>
        /// gửi tin cho tất cả server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = txbMessage.Text;
            if (string.IsNullOrWhiteSpace(text)) return;

            // Gửi cho tất cả client theo format client hiểu
            Broadcast($"FROM|Server|{text}");

            // Log trên server
            AddMessage($"Server: {text}");
            txbMessage.Clear();

        }

        private void txbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;  // không xuống dòng
                btnSend.PerformClick();     // gọi gửi
            }
            // Shift+Enter => cho xuống dòng (nếu txbMessage.Multiline = true)
        }


        IPEndPoint IP;
        Socket server;
        List<Socket> clientList; // danh sách client kết nối tới server

        readonly object _lock = new object();
        Dictionary<Socket, string> socketToName = new Dictionary<Socket, string>(); // lưu tên người dùng theo socket
        Dictionary<string, Socket> nameToSocket = new Dictionary<string, Socket>();
        Dictionary<Socket, string> socketToRoom = new Dictionary<Socket, string>(); // lưu phòng theo socket
        Dictionary<string, HashSet<string>> allow = new Dictionary<string, HashSet<string>>();
        // allow[A] chứa danh sách người A được phép nhắn riêng (đã accept)
        HashSet<string> bestPairs = new HashSet<string>(); // tránh log trùng


        /// <summary>
        /// kết nối tới server
        /// </summary>
        void Connect()
        {
            clientList = new List<Socket>();
            // IP: địa chỉ của server

            IPAddress ipAddr;
            if (!IPAddress.TryParse(bindIp, out ipAddr))
                ipAddr = IPAddress.Any;

            IP = new IPEndPoint(ipAddr, bindPort);


            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IP); // gán địa chỉ ip
            server.Listen(100); // đợi 100 đứa trong hàng chờ

            Thread Listen = new Thread(() =>
            {
                try // kết nối n thằng client 1 thằng đóng lại ?
                {
                    while (true)
                    {


                        Socket client = server.Accept();

                        // nhận HELLO|name
                        string hello = ReceiveString(client);
                        string name = "client_" + Guid.NewGuid().ToString("N").Substring(0, 4);

                        var p = hello.Split('|', 2);
                        if (p.Length == 2 && p[0] == "HELLO" && !string.IsNullOrWhiteSpace(p[1]))
                            name = p[1].Trim();

                        string room = ""; // mặc định sảnh chung

                        lock (_lock)
                        {
                            clientList.Add(client);
                            socketToName[client] = name;
                            nameToSocket[name] = client;
                            socketToRoom[client] = room;

                            if (!allow.ContainsKey(name)) allow[name] = new HashSet<string>();

                        }

                        // báo JOIN chỉ cho những người trong cùng room (room="" là sảnh)
                        AddMessage($"[SYS] {name} đã kết nối (room='{room}')");

                        BroadcastRoom(room, $"SYS|JOIN|{name}");
                        UpdateUserLists(); // cập nhật danh sách user cho tất cả

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);




                        //string room = ""; // mặc định sảnh chung
                        //lock (_lock)
                        //{
                        //    clientList.Add(client);
                        //    socketToName[client] = name;
                        //    nameToSocket[name] = client;
                        //    socketToRoom[client] = room;
                        //}

                        // báo JOIN chỉ trong đúng room của nó (room rỗng => sảnh)


                    }
                }
                catch
                {
                    //IP = new IPEndPoint(IPAddress.Any, 9999); // đợi ip
                    //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                } // xử lý khi n thằng client đóng kết nối
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        /// <summary>
        /// Đóng kết nối hiện thời
        /// </summary>
        void Disconnect()
        {
            try { server?.Close(); } catch { }
        }

        /// <summary>
        /// gửi tin
        /// </summary>
        void Send(Socket client)
        {
            if (!string.IsNullOrEmpty(txbMessage.Text))
                SendString(client, txbMessage.Text);
        }

        /// <summary>
        /// nhận tin
        /// </summary>
        void Receive(object obj)
        {
            Socket client = (Socket)obj;

            try
            {
                while (true)
                {
                    string msg = ReceiveString(client);

                    // ====== (1) Đổi phòng: ROOM|roomId ======
                    if (msg.StartsWith("ROOM|"))
                    {
                        string newRoom = msg.Substring(5).Trim(); // có thể rỗng => sảnh

                        string name;
                        string oldRoom;

                        lock (_lock)
                        {
                            name = socketToName.TryGetValue(client, out var n) ? n : "unknown";
                            oldRoom = socketToRoom.TryGetValue(client, out var r) ? r : "";
                            socketToRoom[client] = newRoom;
                        }

                        if (oldRoom != newRoom)
                        {
                            BroadcastRoom(oldRoom, $"SYS|LEAVE|{name}");
                            BroadcastRoom(newRoom, $"SYS|JOIN|{name}");
                            AddMessage($"[SYS] {name} chuyển phòng: '{oldRoom}' -> '{newRoom}'");

                        }

                        UpdateUserLists();

                        continue; // xử lý xong đổi phòng thì quay lại nhận tiếp
                    }

                    if (msg.StartsWith("REQ|"))
                    {
                        string toName = msg.Substring(4).Trim();

                        string fromName;
                        string reqFromRoom;
                        lock (_lock)
                        {
                            fromName = socketToName.TryGetValue(client, out var n) ? n : "unknown";
                            reqFromRoom = socketToRoom.TryGetValue(client, out var r) ? r : "";
                        }

                        Socket target = null;
                        string targetRoom = "";
                        lock (_lock)
                        {
                            nameToSocket.TryGetValue(toName, out target);
                            if (target != null) socketToRoom.TryGetValue(target, out targetRoom);
                        }

                        if (target == null)
                        {
                            SendString(client, $"SYS|WARN|{toName} không online");
                        }
                        else if (targetRoom != reqFromRoom)
                        {
                            SendString(client, $"SYS|WARN|{toName} không cùng phòng");
                        }
                        else
                        {
                            SendString(target, $"REQ|{fromName}");
                            SendString(client, $"SYS|INFO|Đã gửi yêu cầu tới {toName}");
                            AddMessage($"[REQ] {fromName} yêu cầu nhắn riêng với {toName} (room='{reqFromRoom}')");

                        }

                        continue;
                    }

                    if (msg.StartsWith("RESP|"))
                    {
                        var q = msg.Split('|', 3);
                        if (q.Length < 3) continue;

                        string requesterName = q[1];
                        string decision = q[2]; // ACCEPT / DECLINE

                        string responderName;
                        lock (_lock)
                            responderName = socketToName.TryGetValue(client, out var n) ? n : "unknown";

                        Socket requester = null;
                        lock (_lock) nameToSocket.TryGetValue(requesterName, out requester);

                        if (requester == null)
                        {
                            SendString(client, $"SYS|WARN|{requesterName} không online");
                            continue;
                        }

                        // báo kết quả cho người đã gửi yêu cầu
                        SendString(requester, $"RESP|{responderName}|{decision}");
                        AddMessage($"[RESP] {responderName} -> {requesterName}: {decision}");

                        // nếu accept => cho phép nhắn riêng 2 chiều
                        if (decision == "ACCEPT")
                        {
                            lock (_lock)
                            {
                                if (!allow.ContainsKey(responderName)) allow[responderName] = new HashSet<string>();
                                if (!allow.ContainsKey(requesterName)) allow[requesterName] = new HashSet<string>();

                                allow[responderName].Add(requesterName);
                                allow[requesterName].Add(responderName);
                                AddMessage($"[PM-READY] {responderName} <-> {requesterName} đã được phép nhắn riêng");

                            }
                        }

                        continue;
                    }
                    /// ====== (3) Kết thúc chat riêng: PMEND|toName|seconds ======
                    if (msg.StartsWith("PMEND|"))
                    {
                        // PMEND|toName|seconds
                        var q = msg.Split('|', 3);
                        if (q.Length < 3) continue;

                        string toName = q[1].Trim();
                        int seconds = 0;
                        int.TryParse(q[2], out seconds);

                        string fromName;
                        lock (_lock)
                            fromName = socketToName.TryGetValue(client, out var n) ? n : "unknown";

                        // log trên server
                        AddMessage($"[PMEND] {fromName} kết thúc chat riêng với {toName} - {TimeSpan.FromSeconds(seconds):hh\\:mm\\:ss}");

                        // (tuỳ chọn) hủy quyền nhắn riêng 2 chiều
                        lock (_lock)
                        {
                            if (allow.TryGetValue(fromName, out var s1)) s1.Remove(toName);
                            if (allow.TryGetValue(toName, out var s2)) s2.Remove(fromName);
                        }

                        // gửi thông báo cho cả 2 phía (dùng SYS|PMEND|other,seconds để không phá Split('|',3) bên client)
                        Socket target = null;
                        lock (_lock) nameToSocket.TryGetValue(toName, out target);

                        try { SendString(client, $"SYS|PMEND|{toName},{seconds}"); } catch { }
                        if (target != null)
                        {
                            try { SendString(target, $"SYS|PMEND|{fromName},{seconds}"); } catch { }
                        }

                        continue;
                    }


                    /// ====== (4) Yêu cầu bạn thân: BFRIEND|other ======
                    // ====== (FRIEND) Client báo đã thành bạn thân ======
                    if (msg.StartsWith("FRIEND|"))
                    {
                        var f = msg.Split('|', 3);
                        if (f.Length == 3)
                        {
                            string other = f[1].Trim();
                            string tag = f[2].Trim(); // BEST

                            string fromName;
                            string roomFrom;
                            lock (_lock)
                            {
                                fromName = socketToName.TryGetValue(client, out var n) ? n : "unknown";
                                roomFrom = socketToRoom.TryGetValue(client, out var r) ? r : "";
                            }

                            // chỉ chấp nhận nếu 2 bên đang allow (đã accept)
                            bool ok = false;
                            lock (_lock)
                            {
                                ok = allow.TryGetValue(fromName, out var set) && set.Contains(other);
                            }

                            if (ok && tag == "BEST")
                            {
                                // tạo key theo thứ tự abc để tránh trùng A|B và B|A
                                string a = fromName, b = other;

                                // gửi đồng bộ về cả 2 client để cả 2 đều hiện "bạn thân"
                                Socket otherSock = null;
                                lock (_lock) nameToSocket.TryGetValue(other, out otherSock);

                                try { SendString(client, $"SYS|BEST|{other}"); } catch { }
                                if (otherSock != null)
                                {
                                    try { SendString(otherSock, $"SYS|BEST|{fromName}"); } catch { }
                                }


                                string key = string.CompareOrdinal(a, b) < 0 ? $"{a}|{b}" : $"{b}|{a}";

                                lock (_lock)
                                {
                                    if (!bestPairs.Contains(key))
                                    {
                                        bestPairs.Add(key);
                                        AddMessage($"[SYS] {a} và {b} đã trở thành bạn thân");
                                    }
                                }
                            }
                        }

                        continue;
                    }


                    // ====== (2) Tin nhắn: MSG|to|text ======
                    var p = msg.Split('|', 3);
                    if (p.Length < 3 || p[0] != "MSG") continue;

                    string to = p[1];
                    string text = p[2];

                    string from;
                    string fromRoom;

                    lock (_lock)
                    {
                        from = socketToName.TryGetValue(client, out var n) ? n : "unknown";
                        fromRoom = socketToRoom.TryGetValue(client, out var r) ? r : "";
                    }

                    // Broadcast trong phòng
                    if (to == "*")
                    {
                        BroadcastRoom(fromRoom, $"FROM|{from}|{text}");
                    }
                    else
                    {
                        // gửi riêng nhưng phải cùng phòng
                        Socket target = null;
                        string targetRoom = "";

                        lock (_lock)
                        {
                            nameToSocket.TryGetValue(to, out target);
                            if (target != null)
                                socketToRoom.TryGetValue(target, out targetRoom);
                        }

                        if (target == null)
                        {
                            SendString(client, $"SYS|WARN|{to} không online");
                        }
                        else if (targetRoom != fromRoom)
                        {
                            SendString(client, $"SYS|WARN|{to} không cùng phòng");
                        }
                        else
                        {
                            bool ok = false;
                            lock (_lock)
                                ok = allow.TryGetValue(from, out var set) && set.Contains(to);

                            if (!ok)
                            {
                                SendString(client, $"SYS|WARN|{to} chưa chấp nhận bạn");
                                continue;
                            }

                            SendString(target, $"PM|{from}|{text}"); // phòng là FORM riêng là PM


                        }
                    }

                    if (to == "*")
                        AddMessage($"[ROOM:{fromRoom}] {from}: {text}");
                    else
                        AddMessage($"[PM][ROOM:{fromRoom}] {from} -> {to}: {text}");

                }
            }
            catch
            {
                string name = null;
                string room = "";

                lock (_lock)
                {
                    if (socketToName.TryGetValue(client, out var n))
                    {
                        name = n;
                        socketToName.Remove(client);
                        nameToSocket.Remove(n);
                    }

                    socketToRoom.TryGetValue(client, out room);
                    socketToRoom.Remove(client);

                    clientList.Remove(client);
                }

                try { client.Close(); } catch { }

                if (name != null)
                    BroadcastRoom(room, $"SYS|LEAVE|{name}");
                    AddMessage($"[SYS] {name} đã ngắt kết nối (room='{room}')");
                if (name != null)
                {
                    lock (_lock)
                    {
                        allow.Remove(name);
                    }
                }
                UpdateUserLists();

            }
        }

        /// <summary>
        /// add message vào khung chat
        /// </summary>
        /// <param name="s"></param>
        void AddMessage(string s)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(AddMessage), s);
                return;
            }

            var item = new ListViewItem() { Text = s };
            lsvMessage.Items.Add(item);

            // tự cuộn xuống cuối
            if (lsvMessage.Items.Count > 0)
                lsvMessage.EnsureVisible(lsvMessage.Items.Count - 1);

            // nháy nhẹ dòng mới
            FlashItem(item);
        }

        /// <summary>
        /// phân mảnh
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //byte[] Serialize(object obj)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    BinaryFormatter formatter = new BinaryFormatter(); // phân tích

        //    formatter.Serialize(stream, obj); // phân mảnh

        //    return stream.ToArray(); // trả về mảng byte 0101
        //}
        /// <summary>
        /// gom mảnh lại
        /// </summary>
        /// <returns></returns>
        //object Deserialize(byte[] data)
        //{
        //    MemoryStream stream = new MemoryStream(data);
        //    BinaryFormatter formatter = new BinaryFormatter(); // phân tích

        //    return formatter.Deserialize(stream); // gom mảnh
        //}
        static void SendString(Socket s, string text)
        {
            byte[] payload = Encoding.UTF8.GetBytes(text);
            byte[] len = BitConverter.GetBytes(payload.Length); // 4 bytes độ dài
            s.Send(len);
            s.Send(payload);
        }

        static string ReceiveString(Socket s)
        {
            byte[] lenBuf = ReceiveExact(s, 4);
            int len = BitConverter.ToInt32(lenBuf, 0);
            byte[] payload = ReceiveExact(s, len);
            return Encoding.UTF8.GetString(payload);
        }

        static byte[] ReceiveExact(Socket s, int size)
        {
            byte[] buffer = new byte[size];
            int read = 0;
            while (read < size)
            {
                int n = s.Receive(buffer, read, size - read, SocketFlags.None);
                if (n == 0) throw new SocketException(); // mất kết nối
                read += n;
            }
            return buffer;
        }
        void Broadcast(string payload)
        {
            Socket[] snapshot;
            lock (_lock) snapshot = clientList.ToArray();

            foreach (var c in snapshot)
            {
                try { SendString(c, payload); } catch { }
            }
        }

        void SendTo(string toName, string payload)
        {
            Socket target = null;
            lock (_lock)
                nameToSocket.TryGetValue(toName, out target);

            if (target != null)
            {
                try { SendString(target, payload); } catch { }
            }
            else
            {
                AddMessage($"[WARN] {toName} không online");
            }
        }
        void BroadcastRoom(string roomId, string payload)
        {
            Socket[] snapshot;
            lock (_lock) snapshot = clientList.ToArray();

            foreach (var c in snapshot)
            {
                string r = "";
                lock (_lock)
                    socketToRoom.TryGetValue(c, out r);

                if (r == roomId)
                {
                    try { SendString(c, payload); } catch { }
                }
            }
        }
        // them prompt
        static string Prompt(string title, string label, string defaultValue)
        {
            using Form form = new Form();
            using Label textLabel = new Label();
            using TextBox textBox = new TextBox();
            using Button buttonOk = new Button();
            using Button buttonCancel = new Button();

            form.Text = title;
            textLabel.Text = label;
            textBox.Width = 260;
            textBox.Text = defaultValue;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            textLabel.SetBounds(10, 10, 280, 20);
            textBox.SetBounds(10, 35, 280, 25);
            buttonOk.SetBounds(130, 70, 75, 25);
            buttonCancel.SetBounds(215, 70, 75, 25);

            form.ClientSize = new Size(300, 110);
            form.Controls.AddRange(new Control[] { textLabel, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : defaultValue;
        }
        void SendUserList(Socket c)
        {
            string room = "";
            List<string> names = new List<string>();

            lock (_lock)
            {
                socketToRoom.TryGetValue(c, out room);

                foreach (var s in clientList)
                {
                    string r = "";
                    socketToRoom.TryGetValue(s, out r);

                    if (r == room && socketToName.TryGetValue(s, out var n))
                        names.Add(n);
                }
            }

            SendString(c, $"SYS|LIST|{string.Join(",", names)}");
        }

        void UpdateUserLists()
        {
            Socket[] snapshot;
            lock (_lock) snapshot = clientList.ToArray();

            foreach (var c in snapshot)
            {
                try { SendUserList(c); } catch { }
            }
        }

        private void lsvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ===== Modern UI helpers (Server) =====
        private void ApplyModernUi()
        {
            // Form
            this.BackColor = _bg;
            this.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ChatPhoBo Server";

            // giảm giật
            EnableDoubleBuffer(lsvMessage);

            // ListView log
            lsvMessage.BackColor = _card;
            lsvMessage.ForeColor = _text;
            lsvMessage.FullRowSelect = true;
            lsvMessage.HideSelection = false;

            // Textbox message
            txbMessage.BackColor = _card;
            txbMessage.ForeColor = _text;

            // Button send: pastel blue
            StyleButton(btnSend, _primary, _primaryHover);
        }

        private void StartFadeIn()
        {
            _fadeTimer?.Stop();
            _fadeTimer?.Dispose();

            this.Opacity = 0;
            _fadeTimer = new System.Windows.Forms.Timer { Interval = 15 };
            _fadeTimer.Tick += (_, __) =>
            {
                this.Opacity += 0.08;
                if (this.Opacity >= 1)
                {
                    this.Opacity = 1;
                    _fadeTimer.Stop();
                    _fadeTimer.Dispose();
                }
            };
            _fadeTimer.Start();
        }

        private void StyleButton(Button btn, Color normal, Color hover)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = normal;
            btn.ForeColor = Color.FromArgb(15, 30, 60); // chữ xanh đậm cho hợp pastel

            btn.MouseEnter += (_, __) => AnimateBackColor(btn, hover, 120);
            btn.MouseLeave += (_, __) => AnimateBackColor(btn, normal, 160);
        }

        private void FlashItem(ListViewItem item)
        {
            // nháy nhẹ xanh rất nhạt -> về nền listview
            Color from = Color.FromArgb(225, 240, 255);
            Color to = lsvMessage.BackColor;

            item.BackColor = from;

            int steps = 12;
            int cur = 0;

            var t = new System.Windows.Forms.Timer { Interval = 25 };
            t.Tick += (_, __) =>
            {
                cur++;
                double k = cur / (double)steps;
                item.BackColor = Lerp(from, to, k);

                if (cur >= steps)
                {
                    item.BackColor = to;
                    t.Stop();
                    t.Dispose();
                }
            };
            t.Start();
        }

        private void AnimateBackColor(Control c, Color target, int durationMs)
        {
            if (c == null) return;

            if (_anim.TryGetValue(c, out var old))
            {
                old.Stop();
                old.Dispose();
                _anim.Remove(c);
            }

            Color start = c.BackColor;
            int interval = 15;
            int steps = Math.Max(1, durationMs / interval);
            int cur = 0;

            var t = new System.Windows.Forms.Timer { Interval = interval };
            _anim[c] = t;

            t.Tick += (_, __) =>
            {
                cur++;
                double k = cur / (double)steps;
                c.BackColor = Lerp(start, target, k);

                if (cur >= steps)
                {
                    c.BackColor = target;
                    t.Stop();
                    t.Dispose();
                    _anim.Remove(c);
                }
            };

            t.Start();
        }

        private static Color Lerp(Color a, Color b, double t)
        {
            t = Math.Max(0, Math.Min(1, t));
            int r = (int)(a.R + (b.R - a.R) * t);
            int g = (int)(a.G + (b.G - a.G) * t);
            int bl = (int)(a.B + (b.B - a.B) * t);
            return Color.FromArgb(r, g, bl);
        }

        private static void EnableDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(c, true, null);
        }

    }

}
