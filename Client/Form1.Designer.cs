namespace server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lsvMessage = new ListView();
            txbMessage = new TextBox();
            btnSend = new Button();
            txbName = new TextBox();
            txbRoomId = new TextBox();
            btnJoinRoom = new Button();
            lblTen = new Label();
            lblRoom = new Label();
            lstUsers = new ListBox();
            lblPrivateWith = new Label();
            lsvPrivate = new ListView();
            txbPrivate = new TextBox();
            btnSendPrivate = new Button();
            lblPrivateTimer = new Label();
            btnClosePrivate = new Button();
            pnlLeftSidebar = new Panel();
            pnlClientLogo = new Panel();
            pnlUserInfo = new Panel();
            lblMyIp = new Label();
            lblTitle = new Label();
            pnlRightSidebar = new Panel();
            pnlPrivateChat = new Panel();
            pnlUserList = new Panel();
            pnlScanner = new Panel();
            lblOnlineUsers = new Label();
            pnlMainChat = new Panel();
            pnlChatBoxBorder = new Panel();
            pnlInputArea = new Panel();
            animTimer = new System.Windows.Forms.Timer(components);
            pnlLeftSidebar.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            pnlRightSidebar.SuspendLayout();
            pnlPrivateChat.SuspendLayout();
            pnlUserList.SuspendLayout();
            pnlMainChat.SuspendLayout();
            pnlChatBoxBorder.SuspendLayout();
            pnlInputArea.SuspendLayout();
            SuspendLayout();
            // 
            // lsvMessage
            // 
            lsvMessage.BackColor = Color.FromArgb(10, 10, 15);
            lsvMessage.BorderStyle = BorderStyle.None;
            lsvMessage.Dock = DockStyle.Fill;
            lsvMessage.Font = new Font("Consolas", 11F);
            lsvMessage.ForeColor = Color.Cyan;
            lsvMessage.Location = new Point(2, 2);
            lsvMessage.Name = "lsvMessage";
            lsvMessage.Size = new Size(805, 556);
            lsvMessage.TabIndex = 0;
            lsvMessage.UseCompatibleStateImageBehavior = false;
            lsvMessage.View = View.List;
            // 
            // txbMessage
            // 
            txbMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txbMessage.BackColor = Color.FromArgb(30, 30, 40);
            txbMessage.BorderStyle = BorderStyle.FixedSingle;
            txbMessage.Font = new Font("Consolas", 12F);
            txbMessage.ForeColor = Color.White;
            txbMessage.Location = new Point(0, 5);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(680, 48);
            txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.BackColor = Color.Cyan;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btnSend.ForeColor = Color.Black;
            btnSend.Location = new Point(690, 5);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(119, 48);
            btnSend.TabIndex = 2;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txbName
            // 
            txbName.BackColor = Color.FromArgb(30, 30, 35);
            txbName.BorderStyle = BorderStyle.FixedSingle;
            txbName.Font = new Font("Consolas", 10F);
            txbName.ForeColor = Color.Lime;
            txbName.Location = new Point(8, 30);
            txbName.Name = "txbName";
            txbName.ReadOnly = true;
            txbName.Size = new Size(170, 27);
            txbName.TabIndex = 3;
            // 
            // txbRoomId
            // 
            txbRoomId.BackColor = Color.FromArgb(40, 40, 50);
            txbRoomId.BorderStyle = BorderStyle.FixedSingle;
            txbRoomId.Font = new Font("Consolas", 11F, FontStyle.Bold);
            txbRoomId.ForeColor = Color.Cyan;
            txbRoomId.Location = new Point(8, 90);
            txbRoomId.Name = "txbRoomId";
            txbRoomId.Size = new Size(170, 29);
            txbRoomId.TabIndex = 4;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.BackColor = Color.FromArgb(0, 100, 200);
            btnJoinRoom.FlatStyle = FlatStyle.Flat;
            btnJoinRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnJoinRoom.ForeColor = Color.White;
            btnJoinRoom.Location = new Point(8, 130);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(170, 35);
            btnJoinRoom.TabIndex = 5;
            btnJoinRoom.Text = "CONNECT ROOM";
            btnJoinRoom.UseVisualStyleBackColor = false;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTen.ForeColor = Color.Silver;
            lblTen.Location = new Point(5, 10);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(74, 20);
            lblTen.TabIndex = 6;
            lblTen.Text = "YOUR ID:";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoom.ForeColor = Color.Silver;
            lblRoom.Location = new Point(5, 70);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(104, 20);
            lblRoom.TabIndex = 7;
            lblRoom.Text = "CHANNEL ID:";
            // 
            // lstUsers
            // 
            lstUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstUsers.BackColor = Color.Black;
            lstUsers.BorderStyle = BorderStyle.FixedSingle;
            lstUsers.Font = new Font("Consolas", 10F);
            lstUsers.ForeColor = Color.White;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(10, 45);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(380, 242);
            lstUsers.TabIndex = 8;
            lstUsers.SelectedIndexChanged += lstUsers_SelectedIndexChanged;
            // 
            // lblPrivateWith
            // 
            lblPrivateWith.AutoSize = true;
            lblPrivateWith.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblPrivateWith.ForeColor = Color.Magenta;
            lblPrivateWith.Location = new Point(10, 10);
            lblPrivateWith.Name = "lblPrivateWith";
            lblPrivateWith.Size = new Size(200, 22);
            lblPrivateWith.TabIndex = 9;
            lblPrivateWith.Text = "SECURE CHANNEL: ???";
            // 
            // lsvPrivate
            // 
            lsvPrivate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvPrivate.BackColor = Color.FromArgb(10, 10, 15);
            lsvPrivate.BorderStyle = BorderStyle.None;
            lsvPrivate.Font = new Font("Consolas", 10F);
            lsvPrivate.ForeColor = Color.Magenta;
            lsvPrivate.FullRowSelect = true;
            lsvPrivate.Location = new Point(10, 40);
            lsvPrivate.Name = "lsvPrivate";
            lsvPrivate.Size = new Size(380, 250);
            lsvPrivate.TabIndex = 10;
            lsvPrivate.UseCompatibleStateImageBehavior = false;
            lsvPrivate.View = View.List;
            // 
            // txbPrivate
            // 
            txbPrivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txbPrivate.BackColor = Color.FromArgb(50, 50, 60);
            txbPrivate.BorderStyle = BorderStyle.FixedSingle;
            txbPrivate.Font = new Font("Consolas", 10F);
            txbPrivate.ForeColor = Color.White;
            txbPrivate.Location = new Point(10, 305);
            txbPrivate.Multiline = true;
            txbPrivate.Name = "txbPrivate";
            txbPrivate.Size = new Size(300, 35);
            txbPrivate.TabIndex = 11;
            // 
            // btnSendPrivate
            // 
            btnSendPrivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendPrivate.BackColor = Color.Magenta;
            btnSendPrivate.FlatStyle = FlatStyle.Flat;
            btnSendPrivate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendPrivate.ForeColor = Color.White;
            btnSendPrivate.Location = new Point(315, 305);
            btnSendPrivate.Name = "btnSendPrivate";
            btnSendPrivate.Size = new Size(75, 35);
            btnSendPrivate.TabIndex = 12;
            btnSendPrivate.Text = "SEND";
            btnSendPrivate.UseVisualStyleBackColor = false;
            btnSendPrivate.Click += btnSendPrivate_Click;
            // 
            // lblPrivateTimer
            // 
            lblPrivateTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrivateTimer.AutoSize = true;
            lblPrivateTimer.ForeColor = Color.Gray;
            lblPrivateTimer.Location = new Point(260, 12);
            lblPrivateTimer.Name = "lblPrivateTimer";
            lblPrivateTimer.Size = new Size(63, 20);
            lblPrivateTimer.TabIndex = 13;
            lblPrivateTimer.Text = "00:00:00";
            // 
            // btnClosePrivate
            // 
            btnClosePrivate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClosePrivate.BackColor = Color.Red;
            btnClosePrivate.FlatStyle = FlatStyle.Flat;
            btnClosePrivate.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnClosePrivate.ForeColor = Color.White;
            btnClosePrivate.Location = new Point(350, 5);
            btnClosePrivate.Name = "btnClosePrivate";
            btnClosePrivate.Size = new Size(40, 25);
            btnClosePrivate.TabIndex = 14;
            btnClosePrivate.Text = "X";
            btnClosePrivate.UseVisualStyleBackColor = false;
            btnClosePrivate.Click += btnClosePrivate_Click;
            // 
            // pnlLeftSidebar
            // 
            pnlLeftSidebar.BackColor = Color.FromArgb(20, 20, 25);
            pnlLeftSidebar.Controls.Add(pnlClientLogo);
            pnlLeftSidebar.Controls.Add(pnlUserInfo);
            pnlLeftSidebar.Controls.Add(lblTitle);
            pnlLeftSidebar.Dock = DockStyle.Left;
            pnlLeftSidebar.Location = new Point(0, 0);
            pnlLeftSidebar.Name = "pnlLeftSidebar";
            pnlLeftSidebar.Size = new Size(220, 648);
            pnlLeftSidebar.TabIndex = 20;
            // 
            // pnlClientLogo
            // 
            pnlClientLogo.Location = new Point(12, 330);
            pnlClientLogo.Name = "pnlClientLogo";
            pnlClientLogo.Size = new Size(190, 190);
            pnlClientLogo.TabIndex = 2;
            pnlClientLogo.Paint += pnlClientLogo_Paint;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlUserInfo.Controls.Add(lblTen);
            pnlUserInfo.Controls.Add(txbName);
            pnlUserInfo.Controls.Add(lblRoom);
            pnlUserInfo.Controls.Add(txbRoomId);
            pnlUserInfo.Controls.Add(btnJoinRoom);
            pnlUserInfo.Controls.Add(lblMyIp);
            pnlUserInfo.Location = new Point(12, 70);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(202, 240);
            pnlUserInfo.TabIndex = 1;
            // 
            // lblMyIp
            // 
            lblMyIp.AutoSize = true;
            lblMyIp.Font = new Font("Consolas", 9F);
            lblMyIp.ForeColor = Color.Cyan;
            lblMyIp.Location = new Point(5, 180);
            lblMyIp.Name = "lblMyIp";
            lblMyIp.Size = new Size(120, 18);
            lblMyIp.TabIndex = 8;
            lblMyIp.Text = "SERVER IP: ...";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Consolas", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Cyan;
            lblTitle.Location = new Point(12, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(179, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CLIENT_TERM";
            // 
            // pnlRightSidebar
            // 
            pnlRightSidebar.BackColor = Color.FromArgb(25, 25, 30);
            pnlRightSidebar.Controls.Add(pnlPrivateChat);
            pnlRightSidebar.Controls.Add(pnlUserList);
            pnlRightSidebar.Dock = DockStyle.Right;
            pnlRightSidebar.Location = new Point(1049, 0);
            pnlRightSidebar.Name = "pnlRightSidebar";
            pnlRightSidebar.Size = new Size(400, 648);
            pnlRightSidebar.TabIndex = 21;
            pnlRightSidebar.Paint += pnlRightSidebar_Paint;
            // 
            // pnlPrivateChat
            // 
            pnlPrivateChat.BackColor = Color.FromArgb(35, 35, 45);
            pnlPrivateChat.Controls.Add(lblPrivateWith);
            pnlPrivateChat.Controls.Add(lblPrivateTimer);
            pnlPrivateChat.Controls.Add(btnClosePrivate);
            pnlPrivateChat.Controls.Add(lsvPrivate);
            pnlPrivateChat.Controls.Add(txbPrivate);
            pnlPrivateChat.Controls.Add(btnSendPrivate);
            pnlPrivateChat.Dock = DockStyle.Fill;
            pnlPrivateChat.Location = new Point(0, 300);
            pnlPrivateChat.Name = "pnlPrivateChat";
            pnlPrivateChat.Padding = new Padding(10);
            pnlPrivateChat.Size = new Size(400, 348);
            pnlPrivateChat.TabIndex = 1;
            // 
            // pnlUserList
            // 
            pnlUserList.Controls.Add(pnlScanner);
            pnlUserList.Controls.Add(lblOnlineUsers);
            pnlUserList.Controls.Add(lstUsers);
            pnlUserList.Dock = DockStyle.Top;
            pnlUserList.Location = new Point(0, 0);
            pnlUserList.Name = "pnlUserList";
            pnlUserList.Size = new Size(400, 300);
            pnlUserList.TabIndex = 0;
            // 
            // pnlScanner
            // 
            pnlScanner.BackColor = Color.FromArgb(0, 255, 0);
            pnlScanner.Location = new Point(10, 45);
            pnlScanner.Name = "pnlScanner";
            pnlScanner.Size = new Size(380, 2);
            pnlScanner.TabIndex = 10;
            // 
            // lblOnlineUsers
            // 
            lblOnlineUsers.AutoSize = true;
            lblOnlineUsers.Font = new Font("Consolas", 12F, FontStyle.Bold);
            lblOnlineUsers.ForeColor = Color.Lime;
            lblOnlineUsers.Location = new Point(10, 15);
            lblOnlineUsers.Name = "lblOnlineUsers";
            lblOnlineUsers.Size = new Size(153, 23);
            lblOnlineUsers.TabIndex = 9;
            lblOnlineUsers.Text = "ONLINE AGENTS";
            // 
            // pnlMainChat
            // 
            pnlMainChat.BackColor = Color.Black;
            pnlMainChat.Controls.Add(pnlChatBoxBorder);
            pnlMainChat.Controls.Add(pnlInputArea);
            pnlMainChat.Dock = DockStyle.Fill;
            pnlMainChat.Location = new Point(220, 0);
            pnlMainChat.Name = "pnlMainChat";
            pnlMainChat.Padding = new Padding(10);
            pnlMainChat.Size = new Size(829, 648);
            pnlMainChat.TabIndex = 22;
            pnlMainChat.Paint += pnlMainChat_Paint;
            // 
            // pnlChatBoxBorder
            // 
            pnlChatBoxBorder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChatBoxBorder.BackColor = Color.Cyan;
            pnlChatBoxBorder.Controls.Add(lsvMessage);
            pnlChatBoxBorder.Location = new Point(10, 10);
            pnlChatBoxBorder.Name = "pnlChatBoxBorder";
            pnlChatBoxBorder.Padding = new Padding(2);
            pnlChatBoxBorder.Size = new Size(809, 560);
            pnlChatBoxBorder.TabIndex = 3;
            // 
            // pnlInputArea
            // 
            pnlInputArea.Controls.Add(txbMessage);
            pnlInputArea.Controls.Add(btnSend);
            pnlInputArea.Dock = DockStyle.Bottom;
            pnlInputArea.Location = new Point(10, 580);
            pnlInputArea.Name = "pnlInputArea";
            pnlInputArea.Size = new Size(809, 58);
            pnlInputArea.TabIndex = 4;
            // 
            // animTimer
            // 
            animTimer.Enabled = true;
            animTimer.Interval = 50;
            animTimer.Tick += animTimer_Tick;
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1449, 648);
            Controls.Add(pnlMainChat);
            Controls.Add(pnlRightSidebar);
            Controls.Add(pnlLeftSidebar);
            Name = "Form1";
            Text = "ChatPhoBo - Client Terminal";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            pnlLeftSidebar.ResumeLayout(false);
            pnlLeftSidebar.PerformLayout();
            pnlUserInfo.ResumeLayout(false);
            pnlUserInfo.PerformLayout();
            pnlRightSidebar.ResumeLayout(false);
            pnlPrivateChat.ResumeLayout(false);
            pnlPrivateChat.PerformLayout();
            pnlUserList.ResumeLayout(false);
            pnlUserList.PerformLayout();
            pnlMainChat.ResumeLayout(false);
            pnlChatBoxBorder.ResumeLayout(false);
            pnlInputArea.ResumeLayout(false);
            pnlInputArea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Controls Gốc (Giữ nguyên)
        private System.Windows.Forms.ListView lsvMessage;
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbRoomId;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblPrivateWith;
        private System.Windows.Forms.ListView lsvPrivate;
        private System.Windows.Forms.TextBox txbPrivate;
        private System.Windows.Forms.Button btnSendPrivate;
        private System.Windows.Forms.Label lblPrivateTimer;
        private System.Windows.Forms.Button btnClosePrivate;

        // Controls Mới (Trang trí)
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.Panel pnlRightSidebar;
        private System.Windows.Forms.Panel pnlMainChat;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlUserList;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.Panel pnlPrivateChat;
        private System.Windows.Forms.Panel pnlChatBoxBorder;
        private System.Windows.Forms.Panel pnlInputArea;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.Panel pnlScanner; // Thanh quét
        private System.Windows.Forms.Label lblMyIp; // Hiển thị IP
        private System.Windows.Forms.Panel pnlClientLogo; // Logo xoay

        // ===== LOGIC ANIMATION (NHÚNG TRỰC TIẾP) =====
        private int _tick = 0;
        private bool _tickDir = true;
        private System.Random _rnd = new System.Random();
        private System.Collections.Generic.List<System.Drawing.PointF> _particles = new System.Collections.Generic.List<System.Drawing.PointF>();
        private int _scanY = 0;
        private bool _scanDown = true;
        private float _clientLogoAngle = 0;
        private System.Collections.Generic.List<int> _rainDrops = new System.Collections.Generic.List<int>();

        private void animTimer_Tick(object sender, System.EventArgs e)
        {
            // Sync IP Display
            if (this.lblMyIp.Text != "SERVER IP: " + this.serverIp)
                this.lblMyIp.Text = "SERVER IP: " + this.serverIp;

            // 1. Neon Breathing (Màu Cyan)
            if (_tickDir) { _tick += 3; if (_tick >= 255) _tickDir = false; }
            else { _tick -= 3; if (_tick <= 100) _tickDir = true; }

            System.Drawing.Color neon = System.Drawing.Color.FromArgb(0, _tick, 255);
            this.pnlChatBoxBorder.BackColor = neon;
            this.lblTitle.ForeColor = neon;

            // 2. Glitch Title
            if (_rnd.Next(0, 80) == 1)
            {
                this.lblTitle.Location = new System.Drawing.Point(12 + _rnd.Next(-2, 3), 20 + _rnd.Next(-1, 2));
                this.lblTitle.ForeColor = System.Drawing.Color.Magenta;
            }
            else
            {
                this.lblTitle.Location = new System.Drawing.Point(12, 20);
                this.lblTitle.ForeColor = neon;
            }

            // 3. Update User Count
            int userCount = this.lstUsers.Items.Count;
            this.lblOnlineUsers.Text = $"ONLINE AGENTS [{userCount}]";

            // 4. Scanner Bar Animation
            if (_scanDown)
            {
                _scanY += 2;
                if (_scanY > this.lstUsers.Height) _scanDown = false;
            }
            else
            {
                _scanY -= 2;
                if (_scanY < 0) _scanDown = true;
            }
            this.pnlScanner.Top = this.lstUsers.Top + _scanY;

            // 5. Update Particles
            this.pnlMainChat.Invalidate();

            // 6. Rotate Logo
            _clientLogoAngle += 3;
            if (_clientLogoAngle >= 360) _clientLogoAngle = 0;
            this.pnlClientLogo.Invalidate();

            // 7. Update Digital Rain
            this.pnlRightSidebar.Invalidate();
        }

        private void pnlMainChat_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Vẽ hạt bụi nền (Scanlines mờ)
            if (_particles.Count < 30)
                _particles.Add(new System.Drawing.PointF(_rnd.Next(this.pnlMainChat.Width), _rnd.Next(this.pnlMainChat.Height)));

            using (System.Drawing.Pen scanPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(10, 0, 255, 255)))
            {
                for (int y = 0; y < this.pnlMainChat.Height; y += 4) e.Graphics.DrawLine(scanPen, 0, y, this.pnlMainChat.Width, y);
            }

            using (System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(30, 255, 255, 255)))
            {
                for (int i = 0; i < _particles.Count; i++)
                {
                    var p = _particles[i];
                    e.Graphics.FillEllipse(b, p.X, p.Y, 2, 2);
                    p.Y -= 0.5f;
                    if (p.Y < 0) p.Y = this.pnlMainChat.Height;
                    _particles[i] = p;
                }
            }
        }

        private void pnlClientLogo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(this.pnlClientLogo.Width / 2, this.pnlClientLogo.Height / 2);
            e.Graphics.RotateTransform(_clientLogoAngle);

            // Vẽ một hình lục giác xoay hoặc icon đơn giản
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Cyan, 3);
            e.Graphics.DrawEllipse(pen, -40, -40, 80, 80); // Vòng tròn ngoài
            e.Graphics.DrawRectangle(pen, -25, -25, 50, 50); // Hình vuông trong xoay theo

            // Vẽ tâm
            e.Graphics.FillEllipse(System.Drawing.Brushes.Magenta, -5, -5, 10, 10);
        }

        private void pnlRightSidebar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Hiệu ứng mưa số (Digital Rain)
            int cols = this.pnlRightSidebar.Width / 15;
            if (_rainDrops.Count != cols)
            {
                _rainDrops.Clear();
                for (int i = 0; i < cols; i++) _rainDrops.Add(_rnd.Next(this.pnlRightSidebar.Height));
            }

            System.Drawing.Font f = new System.Drawing.Font("Arial", 7);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(40, 0, 255, 255)); // Mờ

            for (int i = 0; i < _rainDrops.Count; i++)
            {
                char c = (char)_rnd.Next(48, 58); // Số 0-9
                e.Graphics.DrawString(c.ToString(), f, b, i * 15, _rainDrops[i]);

                if (_rainDrops[i] > this.pnlRightSidebar.Height || _rnd.Next(20) > 18) _rainDrops[i] = 0;
                else _rainDrops[i] += 5;
            }
        }
    }
}