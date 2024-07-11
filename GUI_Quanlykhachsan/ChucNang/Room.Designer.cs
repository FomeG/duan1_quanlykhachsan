namespace GUI_Quanlykhachsan.ChucNang
{
    partial class trangthaiphong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.roomname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDat = new Guna.UI2.WinForms.Guna2GradientButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // roomname
            // 
            this.roomname.AutoSize = true;
            this.roomname.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomname.ForeColor = System.Drawing.Color.Black;
            this.roomname.Location = new System.Drawing.Point(3, 10);
            this.roomname.Name = "roomname";
            this.roomname.Size = new System.Drawing.Size(64, 28);
            this.roomname.TabIndex = 0;
            this.roomname.Text = "{ten}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "{tenkh}";
            // 
            // btnDat
            // 
            this.btnDat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDat.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDat.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDat.ForeColor = System.Drawing.Color.White;
            this.btnDat.Location = new System.Drawing.Point(0, 57);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(78, 27);
            this.btnDat.TabIndex = 2;
            this.btnDat.Text = "Đặt phòng";
            this.btnDat.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // trangthaiphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roomname);
            this.MaximumSize = new System.Drawing.Size(78, 84);
            this.Name = "trangthaiphong";
            this.Size = new System.Drawing.Size(78, 84);
            this.Load += new System.EventHandler(this.Room_Load);
            this.Click += new System.EventHandler(this.Room_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label roomname;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientButton btnDat;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
