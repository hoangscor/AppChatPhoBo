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
            SuspendLayout();
            // 
            // lsvMessage
            // 
            lsvMessage.Location = new Point(38, 67);
            lsvMessage.Name = "lsvMessage";
            lsvMessage.Size = new Size(733, 297);
            lsvMessage.TabIndex = 0;
            lsvMessage.UseCompatibleStateImageBehavior = false;
            lsvMessage.View = View.List;
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(38, 382);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(630, 77);
            txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.ActiveCaption;
            btnSend.Location = new Point(677, 396);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 56);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txbName
            // 
            txbName.Location = new Point(777, 67);
            txbName.Name = "txbName";
            txbName.ReadOnly = true;
            txbName.Size = new Size(125, 27);
            txbName.TabIndex = 3;
            txbName.TextChanged += txbName_TextChanged;
            // 
            // txbRoomId
            // 
            txbRoomId.Location = new Point(777, 120);
            txbRoomId.Name = "txbRoomId";
            txbRoomId.Size = new Size(125, 27);
            txbRoomId.TabIndex = 4;
            txbRoomId.TextChanged += txbRoomId_TextChanged;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.BackColor = SystemColors.AppWorkspace;
            btnJoinRoom.Location = new Point(795, 153);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(94, 29);
            btnJoinRoom.TabIndex = 5;
            btnJoinRoom.Text = "Vào phòng";
            btnJoinRoom.UseVisualStyleBackColor = false;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(777, 44);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(39, 20);
            lblTen.TabIndex = 6;
            lblTen.Text = "Tên: ";
            lblTen.Click += label1_Click;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(777, 97);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(118, 20);
            lblRoom.TabIndex = 7;
            lblRoom.Text = "Nhập ID phòng: ";
            // 
            // lstUsers
            // 
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(953, 67);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(336, 144);
            lstUsers.TabIndex = 8;
            lstUsers.SelectedIndexChanged += lstUsers_SelectedIndexChanged;
            // 
            // lblPrivateWith
            // 
            lblPrivateWith.AutoSize = true;
            lblPrivateWith.Location = new Point(953, 242);
            lblPrivateWith.Name = "lblPrivateWith";
            lblPrivateWith.Size = new Size(162, 20);
            lblPrivateWith.TabIndex = 9;
            lblPrivateWith.Text = "Chat riêng: (chưa chọn)";
            // 
            // lsvPrivate
            // 
            lsvPrivate.FullRowSelect = true;
            lsvPrivate.Location = new Point(953, 265);
            lsvPrivate.Name = "lsvPrivate";
            lsvPrivate.Size = new Size(336, 130);
            lsvPrivate.TabIndex = 10;
            lsvPrivate.UseCompatibleStateImageBehavior = false;
            lsvPrivate.View = View.List;
            // 
            // txbPrivate
            // 
            txbPrivate.Location = new Point(953, 411);
            txbPrivate.Multiline = true;
            txbPrivate.Name = "txbPrivate";
            txbPrivate.Size = new Size(256, 41);
            txbPrivate.TabIndex = 11;
            // 
            // btnSendPrivate
            // 
            btnSendPrivate.Location = new Point(1215, 411);
            btnSendPrivate.Name = "btnSendPrivate";
            btnSendPrivate.Size = new Size(74, 41);
            btnSendPrivate.TabIndex = 12;
            btnSendPrivate.Text = "Send";
            btnSendPrivate.UseVisualStyleBackColor = true;
            btnSendPrivate.Click += btnSendPrivate_Click;
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1449, 648);
            Controls.Add(btnSendPrivate);
            Controls.Add(txbPrivate);
            Controls.Add(lsvPrivate);
            Controls.Add(lblPrivateWith);
            Controls.Add(lstUsers);
            Controls.Add(lblRoom);
            Controls.Add(lblTen);
            Controls.Add(btnJoinRoom);
            Controls.Add(txbRoomId);
            Controls.Add(txbName);
            Controls.Add(btnSend);
            Controls.Add(txbMessage);
            Controls.Add(lsvMessage);
            Name = "Form1";
            Text = "client";
            TransparencyKey = Color.Maroon;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lsvMessage;
        private TextBox txbMessage;
        private Button btnSend;
        private Size serverSize;
        private TextBox txbName;
        private TextBox txbRoomId;
        private Button btnJoinRoom;
        private Label lblTen;
        private Label lblRoom;
        private ListBox lstUsers;
        private Label lblPrivateWith;
        private ListView lsvPrivate;
        private TextBox txbPrivate;
        private Button btnSendPrivate;
    }
}
