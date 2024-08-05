namespace GUI_Quanlykhachsan.ChucNang.ADMIN
{
    partial class TaiChinh
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.datePickerEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.datePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.gview1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new LiveCharts.WinForms.CartesianChart();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tonghd = new System.Windows.Forms.Label();
            this.tongdt = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gview1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.BorderRadius = 12;
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.Controls.Add(this.groupBox1);
            this.guna2GroupBox1.Controls.Add(this.guna2GradientButton2);
            this.guna2GroupBox1.Controls.Add(this.guna2GradientButton1);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.datePickerEnd);
            this.guna2GroupBox1.Controls.Add(this.datePickerStart);
            this.guna2GroupBox1.Controls.Add(this.gview1);
            this.guna2GroupBox1.Controls.Add(this.chart1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(990, 550);
            this.guna2GroupBox1.TabIndex = 2;
            this.guna2GroupBox1.Text = "Báo cáo thống kê";
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.BorderRadius = 10;
            this.datePickerEnd.Checked = true;
            this.datePickerEnd.FillColor = System.Drawing.Color.White;
            this.datePickerEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePickerEnd.Location = new System.Drawing.Point(778, 155);
            this.datePickerEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePickerEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(200, 36);
            this.datePickerEnd.TabIndex = 3;
            this.datePickerEnd.Value = new System.DateTime(2024, 8, 5, 8, 0, 11, 835);
            // 
            // datePickerStart
            // 
            this.datePickerStart.BorderRadius = 10;
            this.datePickerStart.Checked = true;
            this.datePickerStart.FillColor = System.Drawing.Color.White;
            this.datePickerStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePickerStart.Location = new System.Drawing.Point(778, 89);
            this.datePickerStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePickerStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(200, 36);
            this.datePickerStart.TabIndex = 3;
            this.datePickerStart.Value = new System.DateTime(2024, 8, 5, 8, 0, 11, 835);
            // 
            // gview1
            // 
            this.gview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gview1.Enabled = false;
            this.gview1.Location = new System.Drawing.Point(12, 523);
            this.gview1.MultiSelect = false;
            this.gview1.Name = "gview1";
            this.gview1.ReadOnly = true;
            this.gview1.Size = new System.Drawing.Size(11, 15);
            this.gview1.TabIndex = 1;
            this.gview1.Visible = false;
            // 
            // chart1
            // 
            this.chart1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Location = new System.Drawing.Point(21, 61);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(747, 477);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "S";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(774, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(774, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến:";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BorderRadius = 10;
            this.guna2GradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(787, 197);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(180, 45);
            this.guna2GradientButton1.TabIndex = 6;
            this.guna2GradientButton1.Text = "Kiểm tra";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.BorderRadius = 10;
            this.guna2GradientButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientButton2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientButton2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientButton2.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.guna2GradientButton2.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.Location = new System.Drawing.Point(787, 493);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(180, 45);
            this.guna2GradientButton2.TabIndex = 6;
            this.guna2GradientButton2.Text = "Tải lại";
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tongdt);
            this.groupBox1.Controls.Add(this.tonghd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(778, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng hoá đơn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng doanh thu:";
            // 
            // tonghd
            // 
            this.tonghd.AutoSize = true;
            this.tonghd.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tonghd.Location = new System.Drawing.Point(6, 47);
            this.tonghd.Name = "tonghd";
            this.tonghd.Size = new System.Drawing.Size(128, 22);
            this.tonghd.TabIndex = 0;
            this.tonghd.Text = "Tổng hoá đơn:";
            // 
            // tongdt
            // 
            this.tongdt.AutoSize = true;
            this.tongdt.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongdt.Location = new System.Drawing.Point(6, 137);
            this.tongdt.Name = "tongdt";
            this.tongdt.Size = new System.Drawing.Size(128, 22);
            this.tongdt.TabIndex = 0;
            this.tongdt.Text = "Tổng hoá đơn:";
            // 
            // TaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(990, 550);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaiChinh";
            this.Text = "TaiChinh";
            this.Load += new System.EventHandler(this.TaiChinh_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gview1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.DataGridView gview1;
        private LiveCharts.WinForms.CartesianChart chart1;
        private Guna.UI2.WinForms.Guna2DateTimePicker datePickerEnd;
        private Guna.UI2.WinForms.Guna2DateTimePicker datePickerStart;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tongdt;
        private System.Windows.Forms.Label tonghd;
    }
}