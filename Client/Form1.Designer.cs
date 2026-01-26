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
            SuspendLayout();
            // 
            // lsvMessage
            // 
            lsvMessage.Location = new Point(38, 23);
            lsvMessage.Name = "lsvMessage";
            lsvMessage.Size = new Size(733, 341);
            lsvMessage.TabIndex = 0;
            lsvMessage.UseCompatibleStateImageBehavior = false;
            lsvMessage.View = View.List;
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(38, 382);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(630, 56);
            txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.ActiveCaption;
            btnSend.Location = new Point(677, 382);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 56);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txbName
            // 
            txbName.Location = new Point(777, 23);
            txbName.Name = "txbName";
            txbName.ReadOnly = true;
            txbName.Size = new Size(125, 27);
            txbName.TabIndex = 3;
            // 
            // txbRoomId
            // 
            txbRoomId.Location = new Point(777, 65);
            txbRoomId.Name = "txbRoomId";
            txbRoomId.Size = new Size(125, 27);
            txbRoomId.TabIndex = 4;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.BackColor = SystemColors.AppWorkspace;
            btnJoinRoom.Location = new Point(795, 114);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(94, 29);
            btnJoinRoom.TabIndex = 5;
            btnJoinRoom.Text = "Vào phòng";
            btnJoinRoom.UseVisualStyleBackColor = false;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 495);
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
    }
}
