namespace MuaBanNhaDat
{
    partial class FindHouseOnPrice
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
            this.gianha_text = new System.Windows.Forms.TextBox();
            this.tim_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelProductList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.thongbao_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gianha_text
            // 
            this.gianha_text.Location = new System.Drawing.Point(268, 90);
            this.gianha_text.Margin = new System.Windows.Forms.Padding(1);
            this.gianha_text.Name = "gianha_text";
            this.gianha_text.Size = new System.Drawing.Size(313, 22);
            this.gianha_text.TabIndex = 1;
            this.gianha_text.Text = "Nhập giá nhà cần tìm kiếm";
            // 
            // tim_btn
            // 
            this.tim_btn.Location = new System.Drawing.Point(585, 90);
            this.tim_btn.Margin = new System.Windows.Forms.Padding(1);
            this.tim_btn.Name = "tim_btn";
            this.tim_btn.Size = new System.Drawing.Size(80, 27);
            this.tim_btn.TabIndex = 2;
            this.tim_btn.Text = "Tìm";
            this.tim_btn.UseVisualStyleBackColor = true;
            this.tim_btn.Click += new System.EventHandler(this.tim_btn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "TÌM KIẾM NHÀ DỰA TRÊN GIÁ BÁN";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panelProductList);
            this.groupBox1.Location = new System.Drawing.Point(16, 140);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(903, 448);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các nhà thỏa mãn điều kiện";
            // 
            // panelProductList
            // 
            this.panelProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProductList.AutoScroll = true;
            this.panelProductList.Location = new System.Drawing.Point(8, 23);
            this.panelProductList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelProductList.Name = "panelProductList";
            this.panelProductList.Size = new System.Drawing.Size(887, 417);
            this.panelProductList.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(16, 848);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 28);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // thongbao_label
            // 
            this.thongbao_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.thongbao_label.AutoSize = true;
            this.thongbao_label.Location = new System.Drawing.Point(548, 592);
            this.thongbao_label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.thongbao_label.Name = "thongbao_label";
            this.thongbao_label.Size = new System.Drawing.Size(46, 17);
            this.thongbao_label.TabIndex = 0;
            this.thongbao_label.Text = "label1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 592);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Số lượng nhà thỏa điều kiện là: ";
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(265, 119);
            this.error_label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 17);
            this.error_label.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 40;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FindHouseOnPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(935, 622);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thongbao_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tim_btn);
            this.Controls.Add(this.gianha_text);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FindHouseOnPrice";
            this.Text = "FindHouseOnPrice";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox gianha_text;
        private System.Windows.Forms.Button tim_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel panelProductList;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label thongbao_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.Button button1;
    }
}