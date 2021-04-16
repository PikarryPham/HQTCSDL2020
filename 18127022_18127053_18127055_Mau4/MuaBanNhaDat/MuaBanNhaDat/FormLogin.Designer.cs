namespace MuaBanNhaDat
{
    partial class FormLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.user_text = new System.Windows.Forms.TextBox();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chunha_radio = new System.Windows.Forms.RadioButton();
            this.khachhang_radio = new System.Windows.Forms.RadioButton();
            this.nhanvien_radio = new System.Windows.Forms.RadioButton();
            this.nvql_radio = new System.Windows.Forms.RadioButton();
            this.ttk_btn = new System.Windows.Forms.Button();
            this.dangnhap_btn = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.user_error = new System.Windows.Forms.Label();
            this.pass_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // user_text
            // 
            this.user_text.Location = new System.Drawing.Point(16, 44);
            this.user_text.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.user_text.Name = "user_text";
            this.user_text.Size = new System.Drawing.Size(272, 20);
            this.user_text.TabIndex = 3;
            // 
            // pass_text
            // 
            this.pass_text.Location = new System.Drawing.Point(16, 90);
            this.pass_text.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(272, 20);
            this.pass_text.TabIndex = 5;
            this.pass_text.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // chunha_radio
            // 
            this.chunha_radio.AutoSize = true;
            this.chunha_radio.Location = new System.Drawing.Point(16, 122);
            this.chunha_radio.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chunha_radio.Name = "chunha_radio";
            this.chunha_radio.Size = new System.Drawing.Size(74, 17);
            this.chunha_radio.TabIndex = 6;
            this.chunha_radio.TabStop = true;
            this.chunha_radio.Text = "CHỦ NHÀ";
            this.chunha_radio.UseVisualStyleBackColor = true;
            // 
            // khachhang_radio
            // 
            this.khachhang_radio.AutoSize = true;
            this.khachhang_radio.Location = new System.Drawing.Point(220, 122);
            this.khachhang_radio.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.khachhang_radio.Name = "khachhang_radio";
            this.khachhang_radio.Size = new System.Drawing.Size(96, 17);
            this.khachhang_radio.TabIndex = 7;
            this.khachhang_radio.TabStop = true;
            this.khachhang_radio.Text = "KHÁCH HÀNG";
            this.khachhang_radio.UseVisualStyleBackColor = true;
            // 
            // nhanvien_radio
            // 
            this.nhanvien_radio.AutoSize = true;
            this.nhanvien_radio.Location = new System.Drawing.Point(220, 162);
            this.nhanvien_radio.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.nhanvien_radio.Name = "nhanvien_radio";
            this.nhanvien_radio.Size = new System.Drawing.Size(84, 17);
            this.nhanvien_radio.TabIndex = 8;
            this.nhanvien_radio.TabStop = true;
            this.nhanvien_radio.Text = "NHÂN VIÊN";
            this.nhanvien_radio.UseVisualStyleBackColor = true;
            // 
            // nvql_radio
            // 
            this.nvql_radio.AutoSize = true;
            this.nvql_radio.Location = new System.Drawing.Point(16, 162);
            this.nvql_radio.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.nvql_radio.Name = "nvql_radio";
            this.nvql_radio.Size = new System.Drawing.Size(134, 17);
            this.nvql_radio.TabIndex = 9;
            this.nvql_radio.TabStop = true;
            this.nvql_radio.Text = "NHÂN VIÊN QUẢN LÝ";
            this.nvql_radio.UseVisualStyleBackColor = true;
            // 
            // ttk_btn
            // 
            this.ttk_btn.AutoSize = true;
            this.ttk_btn.Location = new System.Drawing.Point(175, 195);
            this.ttk_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ttk_btn.Name = "ttk_btn";
            this.ttk_btn.Size = new System.Drawing.Size(83, 29);
            this.ttk_btn.TabIndex = 10;
            this.ttk_btn.Text = "Tạo tài khoản";
            this.ttk_btn.UseVisualStyleBackColor = true;
            this.ttk_btn.Click += new System.EventHandler(this.ttk_btn_Click);
            // 
            // dangnhap_btn
            // 
            this.dangnhap_btn.Location = new System.Drawing.Point(67, 195);
            this.dangnhap_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dangnhap_btn.Name = "dangnhap_btn";
            this.dangnhap_btn.Size = new System.Drawing.Size(71, 29);
            this.dangnhap_btn.TabIndex = 11;
            this.dangnhap_btn.Text = "Đăng nhập";
            this.dangnhap_btn.UseVisualStyleBackColor = true;
            this.dangnhap_btn.Click += new System.EventHandler(this.dangnhap_btn_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(139, 232);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 12;
            // 
            // user_error
            // 
            this.user_error.AutoSize = true;
            this.user_error.Location = new System.Drawing.Point(17, 60);
            this.user_error.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.user_error.Name = "user_error";
            this.user_error.Size = new System.Drawing.Size(0, 13);
            this.user_error.TabIndex = 13;
            // 
            // pass_error
            // 
            this.pass_error.AutoSize = true;
            this.pass_error.Location = new System.Drawing.Point(17, 107);
            this.pass_error.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pass_error.Name = "pass_error";
            this.pass_error.Size = new System.Drawing.Size(0, 13);
            this.pass_error.TabIndex = 14;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(321, 252);
            this.Controls.Add(this.pass_error);
            this.Controls.Add(this.user_error);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dangnhap_btn);
            this.Controls.Add(this.ttk_btn);
            this.Controls.Add(this.nvql_radio);
            this.Controls.Add(this.nhanvien_radio);
            this.Controls.Add(this.khachhang_radio);
            this.Controls.Add(this.chunha_radio);
            this.Controls.Add(this.pass_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.user_text);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_text;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton chunha_radio;
        private System.Windows.Forms.RadioButton khachhang_radio;
        private System.Windows.Forms.RadioButton nhanvien_radio;
        private System.Windows.Forms.RadioButton nvql_radio;
        private System.Windows.Forms.Button ttk_btn;
        private System.Windows.Forms.Button dangnhap_btn;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label user_error;
        private System.Windows.Forms.Label pass_error;
    }
}

