using System.Net;
using System.Net.Sockets;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace server
{
    public partial class Form1 : Form
    {
        string serverIp = "192.168.3.110";
        int serverPort = 9999;

        public Form1()
        {
            InitializeComponent();

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
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear(); // chỉ clear khi nhấn send thôi
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

            string toName = lstUsers.SelectedItem.ToString();
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
                lstUsers.Items.Add(n);
            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
