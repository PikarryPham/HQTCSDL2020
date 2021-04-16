namespace MuaBanNhaDat
{
    partial class KHDashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.opt1_btn = new System.Windows.Forms.Button();
            this.opt2_btn = new System.Windows.Forms.Button();
            this.opt3_btn = new System.Windows.Forms.Button();
            this.timnha_btn = new System.Windows.Forms.Button();
            this.opt5_btn = new System.Windows.Forms.Button();
            this.opt6_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "CÀI ĐẶT CỦA KHÁCH HÀNG";
            // 
            // opt1_btn
            // 
            this.opt1_btn.Location = new System.Drawing.Point(9, 82);
            this.opt1_btn.Margin = new System.Windows.Forms.Padding(1);
            this.opt1_btn.Name = "opt1_btn";
            this.opt1_btn.Size = new System.Drawing.Size(323, 33);
            this.opt1_btn.TabIndex = 2;
            this.opt1_btn.Text = "Chỉnh sửa thông tin cá nhân";
            this.opt1_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opt1_btn.UseVisualStyleBackColor = true;
            // 
            // opt2_btn
            // 
            this.opt2_btn.Location = new System.Drawing.Point(9, 137);
            this.opt2_btn.Margin = new System.Windows.Forms.Padding(1);
            this.opt2_btn.Name = "opt2_btn";
            this.opt2_btn.Size = new System.Drawing.Size(323, 33);
            this.opt2_btn.TabIndex = 3;
            this.opt2_btn.Text = "Quản lý danh sách những nhà đã xem/bình luận";
            this.opt2_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opt2_btn.UseVisualStyleBackColor = true;
            // 
            // opt3_btn
            // 
            this.opt3_btn.Location = new System.Drawing.Point(9, 190);
            this.opt3_btn.Margin = new System.Windows.Forms.Padding(1);
            this.opt3_btn.Name = "opt3_btn";
            this.opt3_btn.Size = new System.Drawing.Size(323, 33);
            this.opt3_btn.TabIndex = 4;
            this.opt3_btn.Text = "Quản lý thông tin của các hợp đồng";
            this.opt3_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opt3_btn.UseVisualStyleBackColor = true;
            // 
            // timnha_btn
            // 
            this.timnha_btn.Location = new System.Drawing.Point(9, 241);
            this.timnha_btn.Margin = new System.Windows.Forms.Padding(1);
            this.timnha_btn.Name = "timnha_btn";
            this.timnha_btn.Size = new System.Drawing.Size(323, 33);
            this.timnha_btn.TabIndex = 5;
            this.timnha_btn.Text = "Tìm nhà";
            this.timnha_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timnha_btn.UseVisualStyleBackColor = true;
            this.timnha_btn.Click += new System.EventHandler(this.timnha_btn_Click);
            // 
            // opt5_btn
            // 
            this.opt5_btn.Location = new System.Drawing.Point(9, 295);
            this.opt5_btn.Margin = new System.Windows.Forms.Padding(1);
            this.opt5_btn.Name = "opt5_btn";
            this.opt5_btn.Size = new System.Drawing.Size(323, 33);
            this.opt5_btn.TabIndex = 6;
            this.opt5_btn.Text = "Xem thông tin cá nhân";
            this.opt5_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opt5_btn.UseVisualStyleBackColor = true;
            // 
            // opt6_btn
            // 
            this.opt6_btn.Location = new System.Drawing.Point(9, 347);
            this.opt6_btn.Margin = new System.Windows.Forms.Padding(1);
            this.opt6_btn.Name = "opt6_btn";
            this.opt6_btn.Size = new System.Drawing.Size(323, 33);
            this.opt6_btn.TabIndex = 7;
            this.opt6_btn.Text = "Đăng xuất";
            this.opt6_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opt6_btn.UseVisualStyleBackColor = true;
            this.opt6_btn.Click += new System.EventHandler(this.Opt6_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.ForeColor = System.Drawing.Color.Blue;
            this.back_btn.Location = new System.Drawing.Point(231, 399);
            this.back_btn.Margin = new System.Windows.Forms.Padding(1);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(100, 31);
            this.back_btn.TabIndex = 8;
            this.back_btn.Text = "Về trang chủ";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // KHDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(340, 447);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.opt6_btn);
            this.Controls.Add(this.opt5_btn);
            this.Controls.Add(this.timnha_btn);
            this.Controls.Add(this.opt3_btn);
            this.Controls.Add(this.opt2_btn);
            this.Controls.Add(this.opt1_btn);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "KHDashboard";
            this.Text = "KHDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button opt1_btn;
        private System.Windows.Forms.Button opt2_btn;
        private System.Windows.Forms.Button opt3_btn;
        private System.Windows.Forms.Button timnha_btn;
        private System.Windows.Forms.Button opt5_btn;
        private System.Windows.Forms.Button opt6_btn;
        private System.Windows.Forms.Button back_btn;
    }
}