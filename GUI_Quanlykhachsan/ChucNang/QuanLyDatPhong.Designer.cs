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
            this.btnDatphong = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SoDoPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDatphong
            // 
            this.btnDatphong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDatphong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDatphong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDatphong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDatphong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDatphong.ForeColor = System.Drawing.Color.White;
            this.btnDatphong.Location = new System.Drawing.Point(13, 503);
            this.btnDatphong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDatphong.Name = "btnDatphong";
            this.btnDatphong.Size = new System.Drawing.Size(135, 37);
            this.btnDatphong.TabIndex = 4;
            this.btnDatphong.Text = "Đặt phòng";
            this.btnDatphong.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(32)))), ((int)(((byte)(65)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(6)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(819, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(173, 551);
            this.guna2GradientPanel1.TabIndex = 5;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btnDatphong);
            this.guna2GroupBox1.Controls.Add(this.guna2GradientPanel1);
            this.guna2GroupBox1.Controls.Add(this.button1);
            this.guna2GroupBox1.Controls.Add(this.SoDoPhong);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(-2, -1);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(992, 551);
            this.guna2GroupBox1.TabIndex = 6;
            this.guna2GroupBox1.Text = "Quản lý phòng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SoDoPhong
            // 
            this.SoDoPhong.AutoScroll = true;
            this.SoDoPhong.Location = new System.Drawing.Point(13, 43);
            this.SoDoPhong.Name = "SoDoPhong";
            this.SoDoPhong.Size = new System.Drawing.Size(800, 455);
            this.SoDoPhong.TabIndex = 0;
            // 
            // QuanLyDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(990, 550);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QuanLyDatPhong";
            this.Text = "QuanLyDatPhong";
            this.Load += new System.EventHandler(this.QuanLyDatPhong_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnDatphong;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel SoDoPhong;
    }
}