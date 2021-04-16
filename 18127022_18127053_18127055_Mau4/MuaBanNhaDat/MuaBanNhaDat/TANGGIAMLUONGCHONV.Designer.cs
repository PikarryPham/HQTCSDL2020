namespace MuaBanNhaDat
{
    partial class TANGGIAMLUONGCHONV
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.capnhat_btn = new System.Windows.Forms.Button();
            this.txtMANV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bonustxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updateluong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 42;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 29);
            this.label2.TabIndex = 41;
            this.label2.Text = "TĂNG/GIẢM LƯƠNG CHO NHÂN VIÊN";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // capnhat_btn
            // 
            this.capnhat_btn.Location = new System.Drawing.Point(333, 278);
            this.capnhat_btn.Margin = new System.Windows.Forms.Padding(1);
            this.capnhat_btn.Name = "capnhat_btn";
            this.capnhat_btn.Size = new System.Drawing.Size(142, 43);
            this.capnhat_btn.TabIndex = 43;
            this.capnhat_btn.Text = "Cập nhật";
            this.capnhat_btn.UseVisualStyleBackColor = true;
            this.capnhat_btn.Click += new System.EventHandler(this.Capnhat_btn_Click);
            // 
            // txtMANV
            // 
            this.txtMANV.Location = new System.Drawing.Point(68, 142);
            this.txtMANV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(679, 22);
            this.txtMANV.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nhập mã NV muốn t.hiện chức năng";
            // 
            // bonustxt
            // 
            this.bonustxt.Location = new System.Drawing.Point(68, 217);
            this.bonustxt.Margin = new System.Windows.Forms.Padding(4);
            this.bonustxt.Name = "bonustxt";
            this.bonustxt.Size = new System.Drawing.Size(679, 22);
            this.bonustxt.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Tiền bonus thêm nếu có. Mặc định là 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Lương của NV đó sau khi t.hiện chức năng là";
            // 
            // updateluong
            // 
            this.updateluong.AutoSize = true;
            this.updateluong.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.updateluong.Location = new System.Drawing.Point(425, 362);
            this.updateluong.Name = "updateluong";
            this.updateluong.Size = new System.Drawing.Size(0, 17);
            this.updateluong.TabIndex = 49;
            // 
            // TANGGIAMLUONGCHONV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateluong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bonustxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMANV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.capnhat_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Name = "TANGGIAMLUONGCHONV";
            this.Text = "TANGGIAMLUONGCHONV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button capnhat_btn;
        private System.Windows.Forms.TextBox txtMANV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bonustxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label updateluong;
    }
}