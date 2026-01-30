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
            this.components = new System.ComponentModel.Container();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbRoomId = new System.Windows.Forms.TextBox();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblPrivateWith = new System.Windows.Forms.Label();
            this.lsvPrivate = new System.Windows.Forms.ListView();
            this.txbPrivate = new System.Windows.Forms.TextBox();
            this.btnSendPrivate = new System.Windows.Forms.Button();
            this.lblPrivateTimer = new System.Windows.Forms.Label();
            this.btnClosePrivate = new System.Windows.Forms.Button();

            // --- NEW CONTAINERS ---
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.pnlClientLogo = new System.Windows.Forms.Panel(); // [NEW] Panel Icon Xoay
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblMyIp = new System.Windows.Forms.Label(); // [NEW] Hien IP
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRightSidebar = new System.Windows.Forms.Panel();
            this.pnlPrivateChat = new System.Windows.Forms.Panel();
            this.pnlUserList = new System.Windows.Forms.Panel();
            this.pnlScanner = new System.Windows.Forms.Panel(); // [NEW] Thanh quet
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.pnlMainChat = new System.Windows.Forms.Panel();
            this.pnlChatBoxBorder = new System.Windows.Forms.Panel();
            this.pnlInputArea = new System.Windows.Forms.Panel();
            this.animTimer = new System.Windows.Forms.Timer(this.components);

            this.pnlLeftSidebar.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlRightSidebar.SuspendLayout();
            this.pnlPrivateChat.SuspendLayout();
            this.pnlUserList.SuspendLayout();
            this.pnlMainChat.SuspendLayout();
            this.pnlChatBoxBorder.SuspendLayout();
            this.pnlInputArea.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlLeftSidebar (Cột Trái)
            // 
            this.pnlLeftSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.pnlLeftSidebar.Controls.Add(this.pnlClientLogo);
            this.pnlLeftSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlLeftSidebar.Controls.Add(this.lblTitle);
            this.pnlLeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(220, 648);
            this.pnlLeftSidebar.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CLIENT_TERM";
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserInfo.Controls.Add(this.lblTen);
            this.pnlUserInfo.Controls.Add(this.txbName);
            this.pnlUserInfo.Controls.Add(this.lblRoom);
            this.pnlUserInfo.Controls.Add(this.txbRoomId);
            this.pnlUserInfo.Controls.Add(this.btnJoinRoom);
            this.pnlUserInfo.Controls.Add(this.lblMyIp);
            this.pnlUserInfo.Location = new System.Drawing.Point(12, 70);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(190, 240);
            this.pnlUserInfo.TabIndex = 1;
            // 
            // pnlClientLogo
            // 
            // [NEW] Panel vẽ icon xoay
            this.pnlClientLogo.Location = new System.Drawing.Point(12, 330);
            this.pnlClientLogo.Name = "pnlClientLogo";
            this.pnlClientLogo.Size = new System.Drawing.Size(190, 190);
            this.pnlClientLogo.TabIndex = 2;
            this.pnlClientLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClientLogo_Paint);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTen.ForeColor = System.Drawing.Color.Silver;
            this.lblTen.Location = new System.Drawing.Point(5, 10);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(65, 15);
            this.lblTen.TabIndex = 6;
            this.lblTen.Text = "YOUR ID:";
            // 
            // txbName
            // 
            this.txbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.txbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbName.ForeColor = System.Drawing.Color.Lime;
            this.txbName.Font = new System.Drawing.Font("Consolas", 10F);
            this.txbName.Location = new System.Drawing.Point(8, 30);
            this.txbName.Name = "txbName";
            this.txbName.ReadOnly = true;
            this.txbName.Size = new System.Drawing.Size(170, 23);
            this.txbName.TabIndex = 3;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoom.ForeColor = System.Drawing.Color.Silver;
            this.lblRoom.Location = new System.Drawing.Point(5, 70);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(95, 15);
            this.lblRoom.TabIndex = 7;
            this.lblRoom.Text = "CHANNEL ID:";
            // 
            // txbRoomId
            // 
            this.txbRoomId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.txbRoomId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRoomId.ForeColor = System.Drawing.Color.Cyan;
            this.txbRoomId.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.txbRoomId.Location = new System.Drawing.Point(8, 90);
            this.txbRoomId.Name = "txbRoomId";
            this.txbRoomId.Size = new System.Drawing.Size(170, 25);
            this.txbRoomId.TabIndex = 4;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnJoinRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnJoinRoom.ForeColor = System.Drawing.Color.White;
            this.btnJoinRoom.Location = new System.Drawing.Point(8, 130);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(170, 35);
            this.btnJoinRoom.TabIndex = 5;
            this.btnJoinRoom.Text = "CONNECT ROOM";
            this.btnJoinRoom.UseVisualStyleBackColor = false;
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
            // 
            // lblMyIp
            // 
            this.lblMyIp.AutoSize = true;
            this.lblMyIp.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblMyIp.ForeColor = System.Drawing.Color.Cyan;
            this.lblMyIp.Location = new System.Drawing.Point(5, 180);
            this.lblMyIp.Name = "lblMyIp";
            this.lblMyIp.Size = new System.Drawing.Size(119, 14);
            this.lblMyIp.TabIndex = 8;
            this.lblMyIp.Text = "SERVER IP: ...";
            // 
            // pnlRightSidebar (Cột Phải)
            // 
            this.pnlRightSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.pnlRightSidebar.Controls.Add(this.pnlPrivateChat);
            this.pnlRightSidebar.Controls.Add(this.pnlUserList);
            this.pnlRightSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightSidebar.Location = new System.Drawing.Point(1049, 0);
            this.pnlRightSidebar.Name = "pnlRightSidebar";
            this.pnlRightSidebar.Size = new System.Drawing.Size(400, 648);
            this.pnlRightSidebar.TabIndex = 21;
            this.pnlRightSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRightSidebar_Paint); // Vẽ mưa số
            // 
            // pnlUserList
            // 
            this.pnlUserList.Controls.Add(this.pnlScanner);
            this.pnlUserList.Controls.Add(this.lblOnlineUsers);
            this.pnlUserList.Controls.Add(this.lstUsers);
            this.pnlUserList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserList.Location = new System.Drawing.Point(0, 0);
            this.pnlUserList.Name = "pnlUserList";
            this.pnlUserList.Size = new System.Drawing.Size(400, 300);
            this.pnlUserList.TabIndex = 0;
            // 
            // lblOnlineUsers
            // 
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblOnlineUsers.ForeColor = System.Drawing.Color.Lime;
            this.lblOnlineUsers.Location = new System.Drawing.Point(10, 15);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(135, 19);
            this.lblOnlineUsers.Text = "ONLINE AGENTS";
            this.lblOnlineUsers.TabIndex = 9;
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.BackColor = System.Drawing.Color.Black;
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUsers.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstUsers.ForeColor = System.Drawing.Color.White;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(10, 45);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(380, 242);
            this.lstUsers.TabIndex = 8;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // pnlScanner
            // 
            // [NEW]: Thanh quét hiệu ứng
            this.pnlScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))); // Màu xanh lá
            this.pnlScanner.Location = new System.Drawing.Point(10, 45);
            this.pnlScanner.Name = "pnlScanner";
            this.pnlScanner.Size = new System.Drawing.Size(380, 2); // Mỏng
            this.pnlScanner.TabIndex = 10;
            // 
            // pnlPrivateChat
            // 
            this.pnlPrivateChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.pnlPrivateChat.Controls.Add(this.lblPrivateWith);
            this.pnlPrivateChat.Controls.Add(this.lblPrivateTimer);
            this.pnlPrivateChat.Controls.Add(this.btnClosePrivate);
            this.pnlPrivateChat.Controls.Add(this.lsvPrivate);
            this.pnlPrivateChat.Controls.Add(this.txbPrivate);
            this.pnlPrivateChat.Controls.Add(this.btnSendPrivate);
            this.pnlPrivateChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrivateChat.Location = new System.Drawing.Point(0, 300);
            this.pnlPrivateChat.Name = "pnlPrivateChat";
            this.pnlPrivateChat.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPrivateChat.Size = new System.Drawing.Size(400, 348);
            this.pnlPrivateChat.TabIndex = 1;
            // 
            // lblPrivateWith
            // 
            this.lblPrivateWith.AutoSize = true;
            this.lblPrivateWith.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrivateWith.ForeColor = System.Drawing.Color.Magenta;
            this.lblPrivateWith.Location = new System.Drawing.Point(10, 10);
            this.lblPrivateWith.Name = "lblPrivateWith";
            this.lblPrivateWith.Size = new System.Drawing.Size(168, 18);
            this.lblPrivateWith.TabIndex = 9;
            this.lblPrivateWith.Text = "SECURE CHANNEL: ???";
            // 
            // lblPrivateTimer
            // 
            this.lblPrivateTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrivateTimer.AutoSize = true;
            this.lblPrivateTimer.ForeColor = System.Drawing.Color.Gray;
            this.lblPrivateTimer.Location = new System.Drawing.Point(260, 12);
            this.lblPrivateTimer.Name = "lblPrivateTimer";
            this.lblPrivateTimer.Size = new System.Drawing.Size(63, 20);
            this.lblPrivateTimer.TabIndex = 13;
            this.lblPrivateTimer.Text = "00:00:00";
            // 
            // btnClosePrivate
            // 
            this.btnClosePrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosePrivate.BackColor = System.Drawing.Color.Red;
            this.btnClosePrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosePrivate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnClosePrivate.ForeColor = System.Drawing.Color.White;
            this.btnClosePrivate.Location = new System.Drawing.Point(350, 5);
            this.btnClosePrivate.Name = "btnClosePrivate";
            this.btnClosePrivate.Size = new System.Drawing.Size(40, 25);
            this.btnClosePrivate.TabIndex = 14;
            this.btnClosePrivate.Text = "X";
            this.btnClosePrivate.UseVisualStyleBackColor = false;
            this.btnClosePrivate.Click += new System.EventHandler(this.btnClosePrivate_Click);
            // 
            // lsvPrivate
            // 
            this.lsvPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvPrivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.lsvPrivate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvPrivate.Font = new System.Drawing.Font("Consolas", 10F);
            this.lsvPrivate.ForeColor = System.Drawing.Color.Magenta;
            this.lsvPrivate.FullRowSelect = true;
            this.lsvPrivate.Location = new System.Drawing.Point(10, 40);
            this.lsvPrivate.Name = "lsvPrivate";
            this.lsvPrivate.Size = new System.Drawing.Size(380, 250);
            this.lsvPrivate.TabIndex = 10;
            this.lsvPrivate.UseCompatibleStateImageBehavior = false;
            this.lsvPrivate.View = System.Windows.Forms.View.List;
            // 
            // txbPrivate
            // 
            this.txbPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txbPrivate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPrivate.Font = new System.Drawing.Font("Consolas", 10F);
            this.txbPrivate.ForeColor = System.Drawing.Color.White;
            this.txbPrivate.Location = new System.Drawing.Point(10, 305);
            this.txbPrivate.Multiline = true;
            this.txbPrivate.Name = "txbPrivate";
            this.txbPrivate.Size = new System.Drawing.Size(300, 35);
            this.txbPrivate.TabIndex = 11;
            // 
            // btnSendPrivate
            // 
            this.btnSendPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendPrivate.BackColor = System.Drawing.Color.Magenta;
            this.btnSendPrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendPrivate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendPrivate.ForeColor = System.Drawing.Color.White;
            this.btnSendPrivate.Location = new System.Drawing.Point(315, 305);
            this.btnSendPrivate.Name = "btnSendPrivate";
            this.btnSendPrivate.Size = new System.Drawing.Size(75, 35);
            this.btnSendPrivate.TabIndex = 12;
            this.btnSendPrivate.Text = "SEND";
            this.btnSendPrivate.UseVisualStyleBackColor = false;
            this.btnSendPrivate.Click += new System.EventHandler(this.btnSendPrivate_Click);
            // 
            // pnlMainChat (Khu vực giữa)
            // 
            this.pnlMainChat.BackColor = System.Drawing.Color.Black;
            this.pnlMainChat.Controls.Add(this.pnlChatBoxBorder);
            this.pnlMainChat.Controls.Add(this.pnlInputArea);
            this.pnlMainChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainChat.Location = new System.Drawing.Point(220, 0);
            this.pnlMainChat.Name = "pnlMainChat";
            this.pnlMainChat.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainChat.Size = new System.Drawing.Size(829, 648);
            this.pnlMainChat.TabIndex = 22;
            this.pnlMainChat.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainChat_Paint);
            // 
            // pnlChatBoxBorder (Viền Neon cho khung chat)
            // 
            this.pnlChatBoxBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChatBoxBorder.BackColor = System.Drawing.Color.Cyan;
            this.pnlChatBoxBorder.Controls.Add(this.lsvMessage);
            this.pnlChatBoxBorder.Location = new System.Drawing.Point(10, 10);
            this.pnlChatBoxBorder.Name = "pnlChatBoxBorder";
            this.pnlChatBoxBorder.Padding = new System.Windows.Forms.Padding(2);
            this.pnlChatBoxBorder.Size = new System.Drawing.Size(809, 560);
            this.pnlChatBoxBorder.TabIndex = 3;
            // 
            // lsvMessage
            // 
            this.lsvMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.lsvMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvMessage.Font = new System.Drawing.Font("Consolas", 11F);
            this.lsvMessage.ForeColor = System.Drawing.Color.Cyan;
            this.lsvMessage.Location = new System.Drawing.Point(2, 2);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(805, 556);
            this.lsvMessage.TabIndex = 0;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.List;
            // 
            // pnlInputArea
            // 
            this.pnlInputArea.Controls.Add(this.txbMessage);
            this.pnlInputArea.Controls.Add(this.btnSend);
            this.pnlInputArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInputArea.Location = new System.Drawing.Point(10, 580);
            this.pnlInputArea.Name = "pnlInputArea";
            this.pnlInputArea.Size = new System.Drawing.Size(809, 58);
            this.pnlInputArea.TabIndex = 4;
            // 
            // txbMessage
            // 
            this.txbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.txbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMessage.Font = new System.Drawing.Font("Consolas", 12F);
            this.txbMessage.ForeColor = System.Drawing.Color.White;
            this.txbMessage.Location = new System.Drawing.Point(0, 5);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(680, 48);
            this.txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Cyan;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(690, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 48);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // animTimer
            // 
            this.animTimer.Enabled = true;
            this.animTimer.Interval = 50;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1449, 648);
            // Controls chính: 3 Panel lớn
            this.Controls.Add(this.pnlMainChat);
            this.Controls.Add(this.pnlRightSidebar);
            this.Controls.Add(this.pnlLeftSidebar);
            this.Name = "Form1";
            this.Text = "ChatPhoBo - Client Terminal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);

            this.pnlLeftSidebar.ResumeLayout(false);
            this.pnlLeftSidebar.PerformLayout();
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            this.pnlRightSidebar.ResumeLayout(false);
            this.pnlPrivateChat.ResumeLayout(false);
            this.pnlPrivateChat.PerformLayout();
            this.pnlUserList.ResumeLayout(false);
            this.pnlUserList.PerformLayout();
            this.pnlMainChat.ResumeLayout(false);
            this.pnlChatBoxBorder.ResumeLayout(false);
            this.pnlInputArea.ResumeLayout(false);
            this.pnlInputArea.PerformLayout();
            this.ResumeLayout(false);
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