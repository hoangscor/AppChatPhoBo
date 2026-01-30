using System.Net;
using System.Net.Sockets;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Drawing;
using System.Reflection;


namespace server
{
    public partial class Form1 : Form
    {
        // ===== Modern UI / Animation =====
        private System.Windows.Forms.Timer _fadeTimer;
        private readonly Dictionary<Control, System.Windows.Forms.Timer> _anim = new();

        private readonly Color _bg = Color.FromArgb(245, 246, 250);      // nền app
        private readonly Color _card = Color.White;                      // nền control
        private readonly Color _primary = Color.FromArgb(13, 110, 253);  // xanh
        private readonly Color _primaryHover = Color.FromArgb(11, 94, 215);
        private readonly Color _success = Color.FromArgb(25, 135, 84);   // xanh lá
        private readonly Color _successHover = Color.FromArgb(20, 108, 67);

        // ===== FRIEND STATUS (bạn thường / bạn thân) =====
        enum FriendLevel { None, Thuong, Than }

        Dictionary<string, FriendLevel> friendLevel = new Dictionary<string, FriendLevel>();
        Dictionary<string, DateTime> privateStartedAt = new Dictionary<string, DateTime>(); // thời điểm bắt đầu nhắn riêng
        HashSet<string> bestNotified = new HashSet<string>(); // để không gửi FRIEND|... nhiều lần

        System.Windows.Forms.Timer friendTimer;

        string serverIp = "192.168.3.110";
        int serverPort = 9999;

        public Form1()
        {
            InitializeComponent();

            pmTimer = new System.Windows.Forms.Timer();
            pmTimer.Interval = 1000; // 1 giây
            pmTimer.Tick += (s, e) =>
            {
                if (!pmRunning) return;
                var elapsed = DateTime.Now - privateStartAt;
                lblPrivateTimer.Text = elapsed.ToString(@"hh\:mm\:ss");
            };
            lblPrivateTimer.Text = "00:00:00"; 
            btnClosePrivate.Enabled = false; // chưa có chat riêng thì phải chịuuuuu

            ApplyModernUi();
            this.Opacity = 0;
            this.Shown += (_, __) => StartFadeIn();


            myName = Prompt("Nhập tên", "Tên của bạn:");
            if (string.IsNullOrWhiteSpace(myName))
            {
                Close();
                return;
            }


            txbName.Text = myName;
            this.Text = myName;

            // hỏi IP/Port server
            serverIp = Prompt("ChatPhoBo", "Nhập IP Server:", "192.168.3.110");
            string p = Prompt("ChatPhoBo", "Nhập Port:", "9999");
            if (!int.TryParse(p, out serverPort)) serverPort = 9999;

            Connect();

            InitFriendTimer(); //khởi tạo timer bạn thân     

            lstUsers.DoubleClick += lstUsers_DoubleClick;

        }
        /// <summary>
        /// gửi tin đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txbMessage.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            string to = "*";
            string text = input;

            // @tenClient noi_dung -> gửi riêng
            if (input.StartsWith("@"))
            {
                int sp = input.IndexOf(' ');
                if (sp > 1)
                {
                    to = input.Substring(1, sp - 1).Trim();
                    text = input.Substring(sp + 1);
                }
            }
            // nếu nhắn riêng mà chưa được accept thì không cho gửi
            if (to != "*" && !acceptedPeers.Contains(to))
            {
                AddMessage($"[SYS] {to} chưa chấp nhận bạn. Hãy double-click {to} trong danh sách Online để gửi yêu cầu.");
                return;
            }


            SendString(server, $"MSG|{to}|{text}");
            AddMessage($"Me -> {to}: {text}");
        }


        IPEndPoint IP;
        Socket server;

        string myName = ""; // tên của client

        HashSet<string> acceptedPeers = new HashSet<string>(); // ai đã accept để nhắn riêng
        string privatePeer = ""; // đang chat riêng với ai (tên)

        DateTime privateStartAt;              // thời điểm bắt đầu chat riêng
        System.Windows.Forms.Timer pmTimer;   // timer cập nhật đồng hồ
        bool pmRunning = false;

        /// <summary>
        /// kết nối tới server
        /// </summary>
        void Connect()
        {
            // IP: địa chỉ của server
            //IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            IP = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try // thử kết nối
            {
                server.Connect(IP); // kết nối tới server
                SendString(server, $"HELLO|{myName}"); // gửi tên lên server



            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // thông báo lỗi
                return; // thoát nếu không kết nối được
            }

            Thread listen = new Thread(Receive); // lắng nghe tin nhắn từ server
            listen.IsBackground = true; // khi đóng form thì luồng này cũng đóng
            listen.Start(); // bắt đầu lắng nghe
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
        void Send()
        {
            if (txbMessage.Text != string.Empty)
                SendString(server, txbMessage.Text);
        }

        /// <summary>
        /// nhận tin
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {
                    string msg = ReceiveString(server);

                    var p = msg.Split('|', 3);

                    // (1) Server gửi danh sách online: SYS|LIST|a,b,c
                    if (p.Length >= 2 && p[0] == "SYS" && p[1] == "LIST")
                    {
                        string csv = (p.Length == 3) ? p[2] : "";
                        UpdateUserList(csv);
                        continue;
                    }
                    /// (1.5) Server báo kết thúc chat riêng: SYS|PMEND|other,seconds
                    /// 
                    if (p.Length >= 2 && p[0] == "SYS" && p[1] == "PMEND")
                    {
                        string payload = (p.Length == 3) ? p[2] : "";
                        // payload dạng: other,seconds
                        var arr = payload.Split(',', 2);
                        string other = arr.Length > 0 ? arr[0].Trim() : "unknown";
                        int seconds = 0;
                        if (arr.Length == 2) int.TryParse(arr[1], out seconds);

                        BeginInvoke(new Action(() =>
                        {
                            AddMessage($"[SYS] Chat riêng với {other} đã kết thúc. Thời gian: {TimeSpan.FromSeconds(seconds):hh\\:mm\\:ss}");

                            // nếu đang mở đúng cuộc chat riêng đó thì đóng UI + dừng timer
                            if (privatePeer == other)
                            {
                                StopPrivateChat(notifyServer: false);
                            }
                            // hủy tư cách bạn thân + hủy quyền nhắn riêng local
                            friendLevel.Remove(other);
                            privateStartedAt.Remove(other);
                            bestNotified.Remove(other);
                            RefreshUserListText();

                            // vì server đã remove allow => client cũng remove để lần sau phải request lại
                            acceptedPeers.Remove(other);

                        }));

                        continue;
                    }

                    // (1.6) Server đồng bộ bạn thân: SYS|BEST|other
                    if (p.Length >= 2 && p[0] == "SYS" && p[1] == "BEST")
                    {
                        string other = (p.Length == 3) ? p[2].Trim() : "";
                        if (!string.IsNullOrWhiteSpace(other))
                        {
                            BeginInvoke(new Action(() =>
                            {
                                friendLevel[other] = FriendLevel.Than;
                                RefreshUserListText();

                                if (privatePeer == other)
                                {
                                    lsvPrivate.Items.Add(new ListViewItem($"[SYS] Bạn đã trở thành bạn thân với {other}!"));
                                    lsvPrivate.EnsureVisible(lsvPrivate.Items.Count - 1);
                                }
                                else
                                {
                                    AddMessage($"[SYS] Bạn đã trở thành bạn thân với {other}! (PM)");
                                }
                            }));
                        }
                        continue;
                    }

                    // (2) Server chuyển yêu cầu nhắn riêng: REQ|fromName
                    if (msg.StartsWith("REQ|"))
                    {
                        string from = msg.Split('|', 2).Length == 2 ? msg.Split('|', 2)[1] : "unknown";

                        // phải show MessageBox trên UI thread
                        BeginInvoke(new Action(() =>
                        {
                            var rs = MessageBox.Show(
                                $"{from} muốn nhắn riêng với bạn. Chấp nhận?",
                                "ChatPhoBo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (rs == DialogResult.Yes)
                            {
                                SendString(server, $"RESP|{from}|ACCEPT");
                                acceptedPeers.Add(from);

                                StartPrivateSession(from);// đánh dấu bắt đầu phiên nhắn riêng
                                StartPrivateChat(from); // tự chọn peer

                                AddMessage($"[SYS] Bạn đã chấp nhận {from}. Bây giờ có thể nhắn riêng.");
                            }
                            else
                            {
                                SendString(server, $"RESP|{from}|DECLINE");
                                AddMessage($"[SYS] Bạn đã từ chối {from}.");
                            }
                        }));

                        continue;
                    }

                    // (3) Server báo kết quả yêu cầu của mình: RESP|other|ACCEPT/DECLINE
                    if (p.Length == 3 && p[0] == "RESP")
                    {
                        string other = p[1];
                        string decision = p[2];

                        if (decision == "ACCEPT")
                        {
                            acceptedPeers.Add(other);

                            BeginInvoke(new Action(() =>
                            {
                                // tự chọn người đó làm privatePeer và bắt đầu đồng hồ
                                StartPrivateChat(other);
                            }));
                            StartPrivateSession(other);
                            AddMessage($"[SYS] {other} đã CHẤP NHẬN. Bạn có thể nhắn riêng bằng @ {other}");
                        }
                        else
                        {
                            AddMessage($"[SYS] {other} đã TỪ CHỐI.");
                        }

                        continue;
                    }

                    // giữ logic cũ
                    if (p.Length >= 2 && p[0] == "SYS")
                    {
                        AddMessage($"[{p[1]}] {(p.Length == 3 ? p[2] : "")}");
                    }
                    else if (p.Length == 3 && p[0] == "FROM")
                    {
                        AddMessage($"{p[1]}: {p[2]}");
                    }
                    else if (p.Length == 3 && p[0] == "PM")
                    {
                        string from = p[1];
                        string text = p[2];

                        // chỉ hiện vào lsvPrivate nếu đang chọn đúng người đó
                        BeginInvoke(new Action(() =>
                        {
                            if (privatePeer == from)
                            {
                                lsvPrivate.Items.Add(new ListViewItem($"{from}: {text}"));
                                lsvPrivate.EnsureVisible(lsvPrivate.Items.Count - 1);
                            }
                            else
                            {
                                // không muốn lẫn chat chung => chỉ báo nhẹ ở chat chung hoặc title
                                // Bạn có thể chọn 1 trong 2 cách:

                                // Cách A: báo ở chat chung (chỉ 1 dòng thông báo)
                                AddMessage($"[PM] {from}: (tin mới) hãy chọn {from} để xem");

                                // Cách B: đổi title form (nếu bạn muốn)
                                // this.Text = $"{myName} (PM mới từ {from})";
                            }
                        }));

                        continue;
                    }

                    else
                    {
                        AddMessage(msg);
                    }


                }
            }
            catch
            {
                Disconnect();
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

            // tự cuộn xuống dòng cuối
            if (lsvMessage.Items.Count > 0)
                lsvMessage.EnsureVisible(lsvMessage.Items.Count - 1);

            // hiệu ứng nháy nhẹ dòng mới
            FlashItem(item);

            // LƯU Ý: bạn đang Clear ở đây => nhận tin cũng bị clear ô nhập
            // Nếu bạn chỉ muốn clear khi nhấn Send, hãy comment dòng dưới:
            txbMessage.Clear();
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

        /// <summary>
        /// đóng kết nối khi đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }
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

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string room = txbRoomId.Text.Trim(); // có thể rỗng
            SendString(server, $"ROOM|{room}");

            if (string.IsNullOrEmpty(room))
                AddMessage("[SYS] Bạn đang ở sảnh chung (không phòng)");
            else
                AddMessage($"[SYS] Bạn đã vào phòng: {room}");
        }
        static string Prompt(string title, string label)
        {
            using Form form = new Form();
            using Label textLabel = new Label();
            using TextBox textBox = new TextBox();
            using Button buttonOk = new Button();
            using Button buttonCancel = new Button();

            form.Text = title;
            textLabel.Text = label;
            textBox.Width = 260;

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

            return form.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : "";
        }
        static string Prompt(string title, string label, string defaultValue)
        {
            string v = Prompt(title, label);
            return string.IsNullOrWhiteSpace(v) ? defaultValue : v;
        }

        private void txbRoomId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem == null) return;

            //string toName = lstUsers.SelectedItem.ToString();
            string toName = ExtractUserName(lstUsers.SelectedItem.ToString());// lấy tên thật


            if (string.IsNullOrWhiteSpace(toName)) return;

            // gửi yêu cầu nhắn riêng tới server
            SendString(server, $"REQ|{toName}");
            AddMessage($"[SYS] Đã gửi yêu cầu nhắn riêng tới {toName}. Chờ họ chấp nhận...");
        }

        // cập nhật danh sách online từ server (csv: a,b,c)
        private void UpdateUserList(string csv)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateUserList), csv);
                return;
            }

            lstUsers.Items.Clear();

            if (string.IsNullOrWhiteSpace(csv)) return;

            var arr = csv.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var raw in arr)
            {
                var n = raw.Trim();
                if (n.Length == 0) continue;
                if (n == myName) continue; // không hiện chính mình
                lstUsers.Items.Add(RenderUser(n));

            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem == null) return;

            string name = ExtractUserName(lstUsers.SelectedItem.ToString()); // lấy tên thật
            if (string.IsNullOrWhiteSpace(name)) return;

            privatePeer = name;
            lblPrivateWith.Text = $"Chat riêng: {privatePeer}";

            // Clear khung chat riêng để thấy rõ đang là cuộc chat với ai
            lsvPrivate.Items.Clear();

            // Nếu chưa accept thì nhắc người dùng
            if (!acceptedPeers.Contains(privatePeer))
            {
                lsvPrivate.Items.Add(new ListViewItem($"[SYS] Chưa được phép nhắn riêng với {privatePeer}. Double-click để gửi yêu cầu."));
            }
        }
        // ui nha 
        // ===== Modern UI helpers =====
        private void ApplyModernUi()
        {
            // Form
            this.BackColor = _bg;
            this.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;

            // giảm giật
            EnableDoubleBuffer(lsvMessage);

            // ListView chat
            lsvMessage.BackColor = _card;
            lsvMessage.ForeColor = Color.FromArgb(33, 37, 41);
            lsvMessage.FullRowSelect = true;
            lsvMessage.HideSelection = false;

            // Textbox message
            txbMessage.BackColor = _card;
            txbMessage.ForeColor = Color.FromArgb(33, 37, 41);

            // Name/Room (nếu có)
            if (txbName != null)
            {
                txbName.ReadOnly = true;
                txbName.BackColor = _card;
            }
            if (txbRoomId != null)
            {
                txbRoomId.BackColor = _card;
            }

            // List users (nếu có)
            if (lstUsers != null)
            {
                lstUsers.BackColor = _card;
                lstUsers.ForeColor = Color.FromArgb(33, 37, 41);
                lstUsers.IntegralHeight = false;
            }

            // Buttons
            StyleButton(btnSend, _primary, _primaryHover);
            if (btnJoinRoom != null) StyleButton(btnJoinRoom, _success, _successHover);
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
            btn.ForeColor = Color.White;

            btn.MouseEnter += (_, __) => AnimateBackColor(btn, hover, 120);
            btn.MouseLeave += (_, __) => AnimateBackColor(btn, normal, 160);
        }

        private void FlashItem(ListViewItem item)
        {
            // nháy nhẹ vàng -> về màu nền listview
            Color from = Color.FromArgb(255, 249, 196);
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

            // stop animation cũ nếu có
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
            // bật DoubleBuffered cho control (ListView không public)
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(c, true, null);
        }

        private void btnSendPrivate_Click(object sender, EventArgs e)
        {
            string text = txbPrivate.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            if (string.IsNullOrWhiteSpace(privatePeer))
            {
                MessageBox.Show("Hãy chọn 1 người trong danh sách Online để nhắn riêng.", "ChatPhoBo");
                return;
            }

            if (!acceptedPeers.Contains(privatePeer))
            {
                lsvPrivate.Items.Add(new ListViewItem($"[SYS] {privatePeer} chưa chấp nhận bạn. Double-click tên để gửi yêu cầu."));
                return;
            }

            SendString(server, $"MSG|{privatePeer}|{text}");

            lsvPrivate.Items.Add(new ListViewItem($"Me -> {privatePeer}: {text}"));
            lsvPrivate.EnsureVisible(lsvPrivate.Items.Count - 1);

            txbPrivate.Clear();
        }

        private void btnClosePrivate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(privatePeer)) return;

            var rs = MessageBox.Show(
                $"Hủy chat riêng với {privatePeer}?",
                "ChatPhoBo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                StopPrivateChat(notifyServer: true);
            }
        }
        /// <summary>
        /// BẤM GIỜ CHAT RIÊNG
        /// </summary>
        /// <param name="peer"></param>
        private void StartPrivateChat(string peer)
        {
            privatePeer = peer;
            lblPrivateWith.Text = $"Chat riêng: {privatePeer}";
            lsvPrivate.Items.Clear();

            privateStartAt = DateTime.Now;
            pmRunning = true;
            pmTimer.Start();

            lblPrivateTimer.Text = "00:00:00";
            btnClosePrivate.Enabled = true;

            lsvPrivate.Items.Add(new ListViewItem($"[SYS] Bắt đầu chat riêng với {privatePeer}."));
            lsvPrivate.EnsureVisible(lsvPrivate.Items.Count - 1);
        }

        private void StopPrivateChat(bool notifyServer)
        {
            if (string.IsNullOrWhiteSpace(privatePeer))
                return;

            pmTimer.Stop();
            pmRunning = false;

            var elapsed = DateTime.Now - privateStartAt;
            int seconds = (int)elapsed.TotalSeconds;

            string peer = privatePeer; // giữ lại trước khi clear

            // HỦY tư cách bạn thân + hủy quyền nhắn riêng local
            friendLevel.Remove(peer);
            privateStartedAt.Remove(peer);
            bestNotified.Remove(peer);
            acceptedPeers.Remove(peer);
            RefreshUserListText();

            // reset UI
            privatePeer = "";
            lblPrivateWith.Text = "Chat riêng: (chưa chọn)";
            lblPrivateTimer.Text = "00:00:00";
            btnClosePrivate.Enabled = false;

            lsvPrivate.Items.Clear();
            txbPrivate.Clear();

            // báo server (nếu user bấm X)
            if (notifyServer)
            {
                SendString(server, $"PMEND|{peer}|{seconds}");
            }
        }
        /// <summary>
        /// Phần của bạn thân
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        // Lấy tên thật từ item hiển thị (vd: "Hoang (bạn thân)" -> "Hoang")
        private string ExtractUserName(string display)
        {
            if (string.IsNullOrWhiteSpace(display)) return "";
            int k = display.IndexOf(" (");
            return (k >= 0 ? display.Substring(0, k) : display).Trim();
        }

        // Render lại cách hiển thị tên trong lstUsers
        private string RenderUser(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return name;

            if (!friendLevel.TryGetValue(name, out var lv)) lv = FriendLevel.None;

            if (lv == FriendLevel.Thuong) return $"{name} (bạn thường)";
            if (lv == FriendLevel.Than) return $"{name} (bạn thân)";
            return name;
        }

        // Gọi sau khi thay đổi friendLevel để cập nhật lstUsers
        private void RefreshUserListText()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshUserListText));
                return;
            }

            // Lưu lại danh sách tên thật đang có
            var names = new List<string>();
            foreach (var it in lstUsers.Items)
                names.Add(ExtractUserName(it.ToString()));

            lstUsers.Items.Clear();
            foreach (var n in names)
                lstUsers.Items.Add(RenderUser(n));
        }

        // Bắt đầu “phiên nhắn riêng” với peer => hiện bạn thường + chạy timer đếm 10s
        private void StartPrivateSession(string peer)
        {
            if (string.IsNullOrWhiteSpace(peer)) return;

            // BẮT BUỘC: đưa về UI thread để WinForms Timer chạy đúng
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(StartPrivateSession), peer);
                return;
            }

            // vừa accept => mặc định là "bạn thường"
            friendLevel[peer] = FriendLevel.Thuong;

            // đánh dấu thời điểm bắt đầu
            privateStartedAt[peer] = DateTime.Now;

            RefreshUserListText();

            // bật timer
            friendTimer?.Start();
        }

        // Khi kết thúc chat riêng (nếu bạn có nút X đóng chat riêng, thì gọi hàm này)
        private void StopPrivateSession(string peer)
        {
            if (string.IsNullOrWhiteSpace(peer)) return;

            privateStartedAt.Remove(peer);

            // nếu không còn session nào đang chạy => tắt timer
            if (privateStartedAt.Count == 0)
                friendTimer?.Stop();
        }

        // Khởi tạo timer (gọi trong constructor)
        private void InitFriendTimer()
        {
            friendTimer = new System.Windows.Forms.Timer();
            friendTimer.Interval = 500; // 0.5s tick cho mượt
            friendTimer.Tick += (_, __) =>
            {
                // kiểm tra tất cả peer đang nhắn riêng
                var toPromote = new List<string>();

                foreach (var kv in privateStartedAt)
                {
                    string peer = kv.Key;
                    var start = kv.Value;
                    var elapsed = DateTime.Now - start;

                    // > 10s thì lên bạn thân
                    if (elapsed.TotalSeconds >= 10)
                        toPromote.Add(peer);
                }

                foreach (var peer in toPromote)
                {
                    // đổi trạng thái
                    friendLevel[peer] = FriendLevel.Than;
                    privateStartedAt.Remove(peer);

                    RefreshUserListText();

                    // thông báo lên server 1 lần
                    if (!bestNotified.Contains(peer))
                    {
                        bestNotified.Add(peer);
                        SendString(server, $"FRIEND|{peer}|BEST");
                    }

                    // THÔNG BÁO: ưu tiên hiện trong khung chat riêng nếu đang chat với peer
                    if (privatePeer == peer)
                    {
                        lsvPrivate.Items.Add(new ListViewItem($"[SYS] Bạn đã trở thành bạn thân với {peer}!"));
                        lsvPrivate.EnsureVisible(lsvPrivate.Items.Count - 1);
                    }
                    else
                    {
                        AddMessage($"[SYS] Bạn đã trở thành bạn thân với {peer}! (chọn {peer} để xem PM)");
                    }
                }

                if (privateStartedAt.Count == 0)
                    friendTimer.Stop();
            };
        }

    }

}
