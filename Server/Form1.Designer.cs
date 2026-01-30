namespace Server
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnSwitchMode = new System.Windows.Forms.Button();
            this.pnlLogoContainer = new System.Windows.Forms.Panel();
            this.pnlLogoDraw = new System.Windows.Forms.Panel();
            this.lblPortVal = new System.Windows.Forms.Label();
            this.lblPortLabel = new System.Windows.Forms.Label();
            this.lblIpVal = new System.Windows.Forms.Label();
            this.lblIpLabel = new System.Windows.Forms.Label();
            this.lblUptimeVal = new System.Windows.Forms.Label();
            this.lblUptimeLabel = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlTitleContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.pnlInputGlow = new System.Windows.Forms.Panel();
            this.pnlToast = new System.Windows.Forms.Panel();
            this.lblToastText = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.pnlGlowBorder = new System.Windows.Forms.Panel();
            this.lblWatermark = new System.Windows.Forms.Label();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlLogoContainer.SuspendLayout();
            this.pnlTitleContainer.SuspendLayout();
            this.pnlMainArea.SuspendLayout();
            this.pnlInputGlow.SuspendLayout();
            this.pnlToast.SuspendLayout();
            this.pnlGlowBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(630, 426);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 46);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txbMessage
            // 
            this.txbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.txbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMessage.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbMessage.ForeColor = System.Drawing.Color.White;
            this.txbMessage.Location = new System.Drawing.Point(2, 2);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(566, 42);
            this.txbMessage.TabIndex = 4;
            this.txbMessage.Enter += new System.EventHandler(this.txbMessage_Enter);
            this.txbMessage.Leave += new System.EventHandler(this.txbMessage_Leave);
            // 
            // lsvMessage
            // 
            this.lsvMessage.BackColor = System.Drawing.Color.Black;
            this.lsvMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvMessage.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lsvMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.lsvMessage.Location = new System.Drawing.Point(2, 2);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(718, 386);
            this.lsvMessage.TabIndex = 3;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.List;
            this.lsvMessage.SelectedIndexChanged += new System.EventHandler(this.lsvMessage_SelectedIndexChanged);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.pnlSidebar.Controls.Add(this.btnSwitchMode);
            this.pnlSidebar.Controls.Add(this.pnlLogoContainer);
            this.pnlSidebar.Controls.Add(this.lblPortVal);
            this.pnlSidebar.Controls.Add(this.lblPortLabel);
            this.pnlSidebar.Controls.Add(this.lblIpVal);
            this.pnlSidebar.Controls.Add(this.lblIpLabel);
            this.pnlSidebar.Controls.Add(this.lblUptimeVal);
            this.pnlSidebar.Controls.Add(this.lblUptimeLabel);
            this.pnlSidebar.Controls.Add(this.pnlSeparator);
            this.pnlSidebar.Controls.Add(this.pnlTitleContainer);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 484);
            this.pnlSidebar.TabIndex = 6;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // btnSwitchMode
            // 
            this.btnSwitchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSwitchMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchMode.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSwitchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchMode.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSwitchMode.ForeColor = System.Drawing.Color.White;
            this.btnSwitchMode.Location = new System.Drawing.Point(12, 440);
            this.btnSwitchMode.Name = "btnSwitchMode";
            this.btnSwitchMode.Size = new System.Drawing.Size(170, 32);
            this.btnSwitchMode.TabIndex = 6;
            this.btnSwitchMode.Text = "SWITCH MODE";
            this.btnSwitchMode.UseVisualStyleBackColor = false;
            this.btnSwitchMode.Click += new System.EventHandler(this.btnSwitchMode_Click);
            // 
            // pnlLogoContainer
            // 
            this.pnlLogoContainer.Controls.Add(this.pnlLogoDraw);
            this.pnlLogoContainer.Location = new System.Drawing.Point(12, 12);
            this.pnlLogoContainer.Name = "pnlLogoContainer";
            this.pnlLogoContainer.Size = new System.Drawing.Size(170, 150);
            this.pnlLogoContainer.TabIndex = 5;
            // 
            // pnlLogoDraw
            // 
            this.pnlLogoDraw.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogoDraw.Location = new System.Drawing.Point(10, 10);
            this.pnlLogoDraw.Name = "pnlLogoDraw";
            this.pnlLogoDraw.Size = new System.Drawing.Size(150, 130);
            this.pnlLogoDraw.TabIndex = 0;
            this.pnlLogoDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogoDraw_Paint);
            // 
            // lblPortVal
            // 
            this.lblPortVal.AutoSize = true;
            this.lblPortVal.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPortVal.ForeColor = System.Drawing.Color.Cyan;
            this.lblPortVal.Location = new System.Drawing.Point(18, 375);
            this.lblPortVal.Name = "lblPortVal";
            this.lblPortVal.Size = new System.Drawing.Size(50, 22);
            this.lblPortVal.TabIndex = 8;
            this.lblPortVal.Text = "...";
            // 
            // lblPortLabel
            // 
            this.lblPortLabel.AutoSize = true;
            this.lblPortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPortLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPortLabel.Location = new System.Drawing.Point(18, 355);
            this.lblPortLabel.Name = "lblPortLabel";
            this.lblPortLabel.Size = new System.Drawing.Size(59, 20);
            this.lblPortLabel.TabIndex = 7;
            this.lblPortLabel.Text = "[PORT]";
            // 
            // lblIpVal
            // 
            this.lblIpVal.AutoSize = true;
            this.lblIpVal.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIpVal.ForeColor = System.Drawing.Color.Cyan;
            this.lblIpVal.Location = new System.Drawing.Point(18, 315);
            this.lblIpVal.Name = "lblIpVal";
            this.lblIpVal.Size = new System.Drawing.Size(90, 22);
            this.lblIpVal.TabIndex = 6;
            this.lblIpVal.Text = "...";
            // 
            // lblIpLabel
            // 
            this.lblIpLabel.AutoSize = true;
            this.lblIpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIpLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblIpLabel.Location = new System.Drawing.Point(18, 295);
            this.lblIpLabel.Name = "lblIpLabel";
            this.lblIpLabel.Size = new System.Drawing.Size(102, 20);
            this.lblIpLabel.TabIndex = 5;
            this.lblIpLabel.Text = "[IP ADDRESS]";
            // 
            // lblUptimeVal
            // 
            this.lblUptimeVal.AutoSize = true;
            this.lblUptimeVal.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUptimeVal.ForeColor = System.Drawing.Color.Lime;
            this.lblUptimeVal.Location = new System.Drawing.Point(18, 255);
            this.lblUptimeVal.Name = "lblUptimeVal";
            this.lblUptimeVal.Size = new System.Drawing.Size(116, 27);
            this.lblUptimeVal.TabIndex = 4;
            this.lblUptimeVal.Text = "00:00:00";
            // 
            // lblUptimeLabel
            // 
            this.lblUptimeLabel.AutoSize = true;
            this.lblUptimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUptimeLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUptimeLabel.Location = new System.Drawing.Point(18, 227);
            this.lblUptimeLabel.Name = "lblUptimeLabel";
            this.lblUptimeLabel.Size = new System.Drawing.Size(118, 20);
            this.lblUptimeLabel.TabIndex = 3;
            this.lblUptimeLabel.Text = "[ACTIVE TIME]";
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlSeparator.Location = new System.Drawing.Point(18, 213);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(160, 2);
            this.pnlSeparator.TabIndex = 1;
            // 
            // pnlTitleContainer
            // 
            this.pnlTitleContainer.Controls.Add(this.lblTitle);
            this.pnlTitleContainer.Location = new System.Drawing.Point(0, 168);
            this.pnlTitleContainer.Name = "pnlTitleContainer";
            this.pnlTitleContainer.Size = new System.Drawing.Size(200, 40);
            this.pnlTitleContainer.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hi Mr.Server";
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.BackColor = System.Drawing.Color.Black;
            this.pnlMainArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainArea.Controls.Add(this.pnlInputGlow);
            this.pnlMainArea.Controls.Add(this.pnlToast);
            this.pnlMainArea.Controls.Add(this.lblPrompt);
            this.pnlMainArea.Controls.Add(this.pnlGlowBorder);
            this.pnlMainArea.Controls.Add(this.btnSend);
            this.pnlMainArea.Controls.Add(this.lblWatermark);
            this.pnlMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainArea.Location = new System.Drawing.Point(200, 0);
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Size = new System.Drawing.Size(762, 484);
            this.pnlMainArea.TabIndex = 7;
            this.pnlMainArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainArea_Paint);
            // 
            // pnlInputGlow
            // 
            this.pnlInputGlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInputGlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlInputGlow.Controls.Add(this.txbMessage);
            this.pnlInputGlow.Location = new System.Drawing.Point(54, 426);
            this.pnlInputGlow.Name = "pnlInputGlow";
            this.pnlInputGlow.Padding = new System.Windows.Forms.Padding(2);
            this.pnlInputGlow.Size = new System.Drawing.Size(570, 46);
            this.pnlInputGlow.TabIndex = 10;
            // 
            // pnlToast
            // 
            this.pnlToast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.pnlToast.Controls.Add(this.lblToastText);
            this.pnlToast.Location = new System.Drawing.Point(542, 12);
            this.pnlToast.Name = "pnlToast";
            this.pnlToast.Size = new System.Drawing.Size(208, 40);
            this.pnlToast.TabIndex = 9;
            this.pnlToast.Visible = false;
            // 
            // lblToastText
            // 
            this.lblToastText.AutoSize = true;
            this.lblToastText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblToastText.ForeColor = System.Drawing.Color.White;
            this.lblToastText.Location = new System.Drawing.Point(10, 10);
            this.lblToastText.Name = "lblToastText";
            this.lblToastText.Size = new System.Drawing.Size(168, 18);
            this.lblToastText.TabIndex = 0;
            this.lblToastText.Text = "System Check: OK...";
            // 
            // lblPrompt
            // 
            this.lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblPrompt.Location = new System.Drawing.Point(6, 432);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(45, 33);
            this.lblPrompt.TabIndex = 8;
            this.lblPrompt.Text = ">>";
            // 
            // pnlGlowBorder
            // 
            this.pnlGlowBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGlowBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlGlowBorder.Controls.Add(this.lsvMessage);
            this.pnlGlowBorder.Location = new System.Drawing.Point(18, 18);
            this.pnlGlowBorder.Name = "pnlGlowBorder";
            this.pnlGlowBorder.Padding = new System.Windows.Forms.Padding(2);
            this.pnlGlowBorder.Size = new System.Drawing.Size(722, 390);
            this.pnlGlowBorder.TabIndex = 7;
            // 
            // lblWatermark
            // 
            this.lblWatermark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWatermark.AutoSize = true;
            this.lblWatermark.BackColor = System.Drawing.Color.Transparent;
            this.lblWatermark.Font = new System.Drawing.Font("Impact", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWatermark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblWatermark.Location = new System.Drawing.Point(150, 120);
            this.lblWatermark.Name = "lblWatermark";
            this.lblWatermark.Size = new System.Drawing.Size(465, 145);
            this.lblWatermark.TabIndex = 6;
            this.lblWatermark.Text = "SECURE";
            this.lblWatermark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // animTimer
            // 
            this.animTimer.Enabled = true;
            this.animTimer.Interval = 50;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 484);
            this.Controls.Add(this.pnlMainArea);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Form1";
            this.Text = "Server Command Center";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlLogoContainer.ResumeLayout(false);
            this.pnlTitleContainer.ResumeLayout(false);
            this.pnlTitleContainer.PerformLayout();
            this.pnlMainArea.ResumeLayout(false);
            this.pnlMainArea.PerformLayout();
            this.pnlInputGlow.ResumeLayout(false);
            this.pnlInputGlow.PerformLayout();
            this.pnlToast.ResumeLayout(false);
            this.pnlToast.PerformLayout();
            this.pnlGlowBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ===== BIẾN LOGIC (STATE) =====
        private int _colorTick = 0;
        private bool _colorDir = true;
        private float _logoAngle = 0f;
        private System.DateTime _startTime = System.DateTime.Now;
        private System.Random _rnd = new System.Random();
        private int _blinkTick = 0;
        private bool _isCyberMode = true; // Biến trạng thái Mode

        // Items cho hiệu ứng Particles & Matrix
        private System.Collections.Generic.List<System.Drawing.PointF> _particles = new System.Collections.Generic.List<System.Drawing.PointF>();
        private System.Collections.Generic.List<int> _matrixDrops = new System.Collections.Generic.List<int>();
        private int _toastTimer = 0;

        // ===== TIMER ANIMATION =====
        private void animTimer_Tick(object sender, System.EventArgs e)
        {
            // Sync IP/Port visual (from Form1.cs instance variables)
            // Note: In partial classes, we can access private members of the other part.
            // bindIp and bindPort are defined in Form1.cs
            if (this.lblIpVal.Text != this.bindIp) this.lblIpVal.Text = this.bindIp;
            if (this.lblPortVal.Text != this.bindPort.ToString()) this.lblPortVal.Text = this.bindPort.ToString();

            if (!_isCyberMode) return; // Nếu là Simple Mode thì dừng hiệu ứng nặng

            // 1. Hiệu ứng thở (Breathing Neon)
            if (_colorDir) { _colorTick += 5; if (_colorTick >= 255) _colorDir = false; }
            else { _colorTick -= 5; if (_colorTick <= 100) _colorDir = true; }

            System.Drawing.Color neonColor = System.Drawing.Color.FromArgb(0, _colorTick, 255);
            // Chỉ cập nhật màu viền nếu không đang nhập liệu (khi nhập liệu sẽ có màu focus riêng)
            if (!this.txbMessage.Focused) this.pnlInputGlow.BackColor = neonColor;

            this.pnlGlowBorder.BackColor = neonColor;
            this.pnlSeparator.BackColor = neonColor;
            this.lblPrompt.ForeColor = neonColor;
            this.lsvMessage.ForeColor = neonColor;

            // 2. Glitch Title
            if (_rnd.Next(0, 50) == 1)
            {
                this.lblTitle.Location = new System.Drawing.Point(18 + _rnd.Next(-3, 4), 6 + _rnd.Next(-2, 3));
                this.lblTitle.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.lblTitle.Location = new System.Drawing.Point(18, 6);
                this.lblTitle.ForeColor = System.Drawing.Color.White;
            }

            // 3. Blinking Cursor
            _blinkTick++;
            if (_blinkTick > 10)
            {
                this.lblPrompt.Visible = !this.lblPrompt.Visible;
                _blinkTick = 0;
            }

            // 4. Đồng hồ Uptime (Màu Lime siêu sáng)
            System.TimeSpan uptime = System.DateTime.Now - _startTime;
            this.lblUptimeVal.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", uptime.Hours, uptime.Minutes, uptime.Seconds);
            this.lblUptimeVal.ForeColor = System.Drawing.Color.Lime; // Đảm bảo luôn xanh

            // 5. Xoay logo
            _logoAngle += 5;
            if (_logoAngle >= 360) _logoAngle = 0;
            this.pnlLogoDraw.Invalidate();

            // 6. Matrix & Particles Update
            this.pnlSidebar.Invalidate();
            this.pnlMainArea.Invalidate();

            // 7. Toast Notification
            if (_rnd.Next(0, 200) == 1 && !this.pnlToast.Visible)
            {
                this.pnlToast.Visible = true;
                _toastTimer = 50;
                this.lblToastText.Text = "System Scan: OK...";
            }
            if (this.pnlToast.Visible)
            {
                _toastTimer--;
                if (_toastTimer <= 0) this.pnlToast.Visible = false;
            }
        }

        // ===== XỬ LÝ FOCUS Ô NHẬP LIỆU (HIỆU ỨNG RÕ ĐẸP) =====
        private void txbMessage_Enter(object sender, System.EventArgs e)
        {
            if (_isCyberMode)
            {
                // Khi click vào: Viền chuyển màu Hồng Tím (Active), Nền sáng hơn chút (Xám đen) để rõ chữ
                this.pnlInputGlow.BackColor = System.Drawing.Color.Magenta;
                this.txbMessage.BackColor = System.Drawing.Color.FromArgb(40, 40, 50); // Nền sáng hơn
                this.txbMessage.ForeColor = System.Drawing.Color.White; // Chữ trắng rõ
            }
        }

        private void txbMessage_Leave(object sender, System.EventArgs e)
        {
            if (_isCyberMode)
            {
                // Khi bỏ ra: Trả về màu nền tối thui cho ngầu
                this.txbMessage.BackColor = System.Drawing.Color.FromArgb(20, 20, 25);
                this.txbMessage.ForeColor = System.Drawing.Color.White;
            }
        }

        // ===== SWITCH MODE =====
        private void btnSwitchMode_Click(object sender, System.EventArgs e)
        {
            _isCyberMode = !_isCyberMode;

            if (_isCyberMode)
            {
                // -- BẬT CYBER MODE --
                this.animTimer.Start();
                this.BackColor = System.Drawing.Color.Black;
                this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 15, 20);
                this.pnlMainArea.BackColor = System.Drawing.Color.Black;

                this.pnlGlowBorder.Visible = true;
                this.pnlInputGlow.Visible = true;
                this.pnlInputGlow.BackColor = System.Drawing.Color.Cyan;
                this.pnlSeparator.Visible = true;
                this.lblWatermark.Visible = true;
                this.lblPrompt.Visible = true;
                this.lblIpVal.Visible = true;
                this.lblPortVal.Visible = true;
                this.lblIpLabel.Visible = true;
                this.lblPortLabel.Visible = true;

                this.lsvMessage.BackColor = System.Drawing.Color.Black;

                // Style ô nhập liệu Cyber
                this.txbMessage.BackColor = System.Drawing.Color.FromArgb(20, 20, 25);
                this.txbMessage.ForeColor = System.Drawing.Color.White;
                this.txbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;

                this.lblUptimeVal.ForeColor = System.Drawing.Color.Lime; // Reset màu xanh lá sáng
                this.lblIpVal.ForeColor = System.Drawing.Color.Cyan;
                this.lblPortVal.ForeColor = System.Drawing.Color.Cyan;

                this.btnSend.BackColor = System.Drawing.Color.Cyan;
                this.btnSend.ForeColor = System.Drawing.Color.Black;
                this.btnSwitchMode.Text = "SWITCH TO NORMAL";
            }
            else
            {
                // -- BẬT NORMAL MODE (Đơn giản, nhẹ nhàng) --
                this.animTimer.Stop(); // Dừng hiệu ứng

                // Màu sáng sủa
                System.Drawing.Color lightGray = System.Drawing.Color.FromArgb(240, 240, 240);
                this.BackColor = lightGray;
                this.pnlSidebar.BackColor = System.Drawing.Color.White;
                this.pnlMainArea.BackColor = lightGray;

                // Ẩn các chi tiết rườm rà
                this.pnlGlowBorder.BackColor = System.Drawing.Color.White;
                this.pnlInputGlow.BackColor = System.Drawing.Color.DarkGray; // Viền thường
                this.pnlSeparator.BackColor = System.Drawing.Color.LightGray;
                this.lblWatermark.Visible = false;
                this.lblPrompt.Visible = false;
                this.pnlToast.Visible = false;

                // Các label IP/Port vẫn hiện nhưng đổi màu chữ đen
                this.lblIpVal.ForeColor = System.Drawing.Color.Black;
                this.lblPortVal.ForeColor = System.Drawing.Color.Black;
                this.lblIpLabel.ForeColor = System.Drawing.Color.Gray;
                this.lblPortLabel.ForeColor = System.Drawing.Color.Gray;

                // Reset màu controls
                this.lsvMessage.BackColor = System.Drawing.Color.White;
                this.lsvMessage.ForeColor = System.Drawing.Color.Black;

                // Style ô nhập liệu Normal
                this.txbMessage.BackColor = System.Drawing.Color.White;
                this.txbMessage.ForeColor = System.Drawing.Color.Black;
                this.txbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;

                this.lblTitle.ForeColor = System.Drawing.Color.Black;
                this.lblTitle.Location = new System.Drawing.Point(18, 6);
                this.lblUptimeLabel.ForeColor = System.Drawing.Color.Gray;
                this.lblUptimeVal.ForeColor = System.Drawing.Color.Black;

                this.btnSend.BackColor = System.Drawing.Color.LightGray;
                this.btnSend.ForeColor = System.Drawing.Color.Black;

                this.btnSwitchMode.Text = "SWITCH TO CYBER";
                this.pnlLogoDraw.Invalidate();
                this.pnlSidebar.Invalidate();
                this.pnlMainArea.Invalidate();
            }
        }

        // ===== VẼ LOGO =====
        private void pnlLogoDraw_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(this.pnlLogoDraw.Width / 2, this.pnlLogoDraw.Height / 2);
            if (_isCyberMode) e.Graphics.RotateTransform(_logoAngle);

            System.Drawing.Font logoFont = new System.Drawing.Font("Segoe UI Emoji", 48, System.Drawing.FontStyle.Regular);
            System.Drawing.SizeF size = e.Graphics.MeasureString("☢️", logoFont);

            System.Drawing.Brush brush = _isCyberMode ? System.Drawing.Brushes.Cyan : System.Drawing.Brushes.Black;
            e.Graphics.DrawString("☢️", logoFont, brush, -(size.Width / 2) - 5, -(size.Height / 2) - 5);
        }

        // ===== VẼ MATRIX RAIN (Mục 5 - Trên Sidebar) =====
        private void pnlSidebar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!_isCyberMode) return;

            // Khởi tạo drops
            int cols = this.pnlSidebar.Width / 10;
            if (_matrixDrops.Count != cols)
            {
                _matrixDrops.Clear();
                for (int i = 0; i < cols; i++) _matrixDrops.Add(_rnd.Next(this.pnlSidebar.Height));
            }

            System.Drawing.Font mFont = new System.Drawing.Font("Arial", 8);
            System.Drawing.Brush mBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(50, 0, 255, 0)); // Mờ

            for (int i = 0; i < _matrixDrops.Count; i++)
            {
                // Vẽ ký tự ngẫu nhiên
                char c = (char)_rnd.Next(33, 126);
                e.Graphics.DrawString(c.ToString(), mFont, mBrush, i * 10, _matrixDrops[i]);

                // Cho rơi xuống
                if (_matrixDrops[i] > this.pnlSidebar.Height || _rnd.Next(20) > 18) _matrixDrops[i] = 0;
                else _matrixDrops[i] += 10;
            }
        }

        // ===== VẼ PARTICLES (Mục 9 - Trên MainArea) =====
        private void pnlMainArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!_isCyberMode) return;

            // Khởi tạo particles
            if (_particles.Count < 20)
            {
                _particles.Add(new System.Drawing.PointF(_rnd.Next(this.pnlMainArea.Width), _rnd.Next(this.pnlMainArea.Height)));
            }

            // Vẽ các đốm sáng mờ 20%
            using (System.Drawing.Brush pBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(50, 255, 255, 255))) // Alpha 50 ~ 20%
            {
                for (int i = 0; i < _particles.Count; i++)
                {
                    var p = _particles[i];
                    e.Graphics.FillEllipse(pBrush, p.X, p.Y, 4, 4);

                    // Di chuyển ngẫu nhiên
                    p.Y -= 1 + (float)_rnd.NextDouble(); // Bay lên
                    if (p.Y < 0) p.Y = this.pnlMainArea.Height;
                    _particles[i] = p; // Cập nhật lại struct
                }
            }
        }

        // Controls chính
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.ListView lsvMessage;
        private System.Drawing.Size serverSize;

        // Controls trang trí & chức năng mới
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnSwitchMode; // Nút chuyển mode
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlMainArea;
        private System.Windows.Forms.Label lblWatermark;
        private System.Windows.Forms.Panel pnlGlowBorder;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblUptimeLabel;
        private System.Windows.Forms.Label lblUptimeVal;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.Panel pnlLogoContainer;
        private System.Windows.Forms.Panel pnlLogoDraw;
        private System.Windows.Forms.Panel pnlTitleContainer;
        private System.Windows.Forms.Panel pnlToast;
        private System.Windows.Forms.Label lblToastText;
        private System.Windows.Forms.Panel pnlInputGlow; // Thêm panel glow cho ô nhập

        // Thêm Labels IP và Port
        private System.Windows.Forms.Label lblIpLabel;
        private System.Windows.Forms.Label lblIpVal;
        private System.Windows.Forms.Label lblPortLabel;
        private System.Windows.Forms.Label lblPortVal;
    }
}