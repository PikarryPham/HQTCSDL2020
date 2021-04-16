namespace MuaBanNhaDat
{
    partial class CreateAccountOption
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
            this.nv_btn = new System.Windows.Forms.Button();
            this.kh_btn = new System.Windows.Forms.Button();
            this.cn_btn = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nv_btn
            // 
            this.nv_btn.Location = new System.Drawing.Point(156, 44);
            this.nv_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.nv_btn.Name = "nv_btn";
            this.nv_btn.Size = new System.Drawing.Size(139, 82);
            this.nv_btn.TabIndex = 0;
            this.nv_btn.Text = "NHÂN VIÊN";
            this.nv_btn.UseVisualStyleBackColor = true;
            this.nv_btn.Click += new System.EventHandler(this.nv_btn_Click);
            // 
            // kh_btn
            // 
            this.kh_btn.Location = new System.Drawing.Point(16, 155);
            this.kh_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.kh_btn.Name = "kh_btn";
            this.kh_btn.Size = new System.Drawing.Size(139, 82);
            this.kh_btn.TabIndex = 1;
            this.kh_btn.Text = "KHÁCH HÀNG";
            this.kh_btn.UseVisualStyleBackColor = true;
            this.kh_btn.Click += new System.EventHandler(this.kh_btn_Click);
            // 
            // cn_btn
            // 
            this.cn_btn.Location = new System.Drawing.Point(293, 155);
            this.cn_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cn_btn.Name = "cn_btn";
            this.cn_btn.Size = new System.Drawing.Size(139, 82);
            this.cn_btn.TabIndex = 2;
            this.cn_btn.Text = "CHỦ NHÀ";
            this.cn_btn.UseVisualStyleBackColor = true;
            this.cn_btn.Click += new System.EventHandler(this.cn_btn_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 28);
            this.btnBack.TabIndex = 40;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // CreateAccountOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(450, 310);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cn_btn);
            this.Controls.Add(this.kh_btn);
            this.Controls.Add(this.nv_btn);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "CreateAccountOption";
            this.Text = "CreateAccountOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nv_btn;
        private System.Windows.Forms.Button kh_btn;
        private System.Windows.Forms.Button cn_btn;
        private System.Windows.Forms.Button btnBack;
    }
}