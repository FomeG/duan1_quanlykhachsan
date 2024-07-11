namespace GUI_Quanlykhachsan.ChucNang
{
    partial class QuanLyDatPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyDatPhong));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SoDoPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.ThongkeTEXT = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.Controls.Add(this.ThongkeTEXT);
            this.guna2GradientPanel1.Controls.Add(this.guna2GradientButton1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(65)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(6)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(819, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(171, 550);
            this.guna2GradientPanel1.TabIndex = 5;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.BorderRadius = 12;
            this.guna2GroupBox1.Controls.Add(this.guna2GradientPanel1);
            this.guna2GroupBox1.Controls.Add(this.SoDoPhong);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(990, 550);
            this.guna2GroupBox1.TabIndex = 6;
            this.guna2GroupBox1.Text = "Quản lý phòng";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.AutoRoundedCorners = true;
            this.guna2GradientButton1.BorderRadius = 17;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2GradientButton1.Image")));
            this.guna2GradientButton1.Location = new System.Drawing.Point(3, 502);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(165, 36);
            this.guna2GradientButton1.TabIndex = 6;
            this.guna2GradientButton1.Text = "Tải lại";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // SoDoPhong
            // 
            this.SoDoPhong.AutoScroll = true;
            this.SoDoPhong.Location = new System.Drawing.Point(8, 43);
            this.SoDoPhong.Name = "SoDoPhong";
            this.SoDoPhong.Size = new System.Drawing.Size(805, 495);
            this.SoDoPhong.TabIndex = 0;
            this.SoDoPhong.Paint += new System.Windows.Forms.PaintEventHandler(this.SoDoPhong_Paint);
            // 
            // ThongkeTEXT
            // 
            this.ThongkeTEXT.AutoEllipsis = true;
            this.ThongkeTEXT.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThongkeTEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThongkeTEXT.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongkeTEXT.ForeColor = System.Drawing.Color.White;
            this.ThongkeTEXT.Location = new System.Drawing.Point(0, 0);
            this.ThongkeTEXT.Name = "ThongkeTEXT";
            this.ThongkeTEXT.Size = new System.Drawing.Size(171, 40);
            this.ThongkeTEXT.TabIndex = 7;
            this.ThongkeTEXT.Text = "Thống kê";
            this.ThongkeTEXT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // QuanLyDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(990, 550);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyDatPhong";
            this.Text = "QuanLyDatPhong";
            this.Load += new System.EventHandler(this.QuanLyDatPhong_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.FlowLayoutPanel SoDoPhong;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Bunifu.Framework.UI.BunifuCustomLabel ThongkeTEXT;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}