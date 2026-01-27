//using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;


namespace Server
{
    public partial class Form1 : Form
    {
        string bindIp = "0.0.0.0"; // 0.0.0.0 = lắng nghe mọi IP
        int bindPort = 9999;
        public Form1()
        {
            
            InitializeComponent();

            // hỏi IP/Port khi mở server
            bindIp = Prompt("ChatPhoBo Server", "Nhập IP bind (0.0.0.0 = tất cả):", "0.0.0.0");
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
            Disconnect();
        }
        /// <summary>
        /// gửi tin cho tất cả server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage(txbMessage.Text);
            txbMessage.Clear();

        }

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList; // danh sách client kết nối tới server

        readonly object _lock = new object();
        Dictionary<Socket, string> socketToName = new Dictionary<Socket, string>(); // lưu tên người dùng theo socket
        Dictionary<string, Socket> nameToSocket = new Dictionary<string, Socket>();
        Dictionary<Socket, string> socketToRoom = new Dictionary<Socket, string>(); // lưu phòng theo socket


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

            Thread Listen = new Thread(() => {
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
                        }

                        // báo JOIN chỉ cho những người trong cùng room (room="" là sảnh)
                        BroadcastRoom(room, $"SYS|JOIN|{name}");

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
                catch {
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
                        }

                        continue; // xử lý xong đổi phòng thì quay lại nhận tiếp
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
                            SendString(target, $"FROM|{from}|{text}");
                        }
                    }

                    AddMessage($"[{from}@{fromRoom} -> {to}] {text}");
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
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
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

    }
}
