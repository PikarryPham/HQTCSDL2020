namespace MuaBanNhaDat
{
    partial class ChinhSuaThongTinNha
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.cbbLoaiNha = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nbGiaBan = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKhuVuc = new System.Windows.Forms.TextBox();
            this.txtDuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThanhPho = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.nbSoLuongPhong = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbbMaNha = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuongPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(105, 473);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 36);
            this.btnUpdate.TabIndex = 37;
            this.btnUpdate.Text = "Lưu cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Loại nhà";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Location = new System.Drawing.Point(90, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserInfo.Size = new System.Drawing.Size(197, 23);
            this.lblUserInfo.TabIndex = 38;
            this.lblUserInfo.Text = "Xin chào";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 23);
            this.btnBack.TabIndex = 39;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cbbLoaiNha
            // 
            this.cbbLoaiNha.FormattingEnabled = true;
            this.cbbLoaiNha.Location = new System.Drawing.Point(12, 100);
            this.cbbLoaiNha.Name = "cbbLoaiNha";
            this.cbbLoaiNha.Size = new System.Drawing.Size(275, 21);
            this.cbbLoaiNha.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Tình trạng nhà";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(12, 140);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(275, 20);
            this.txtTinhTrang.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Giá bán";
            // 
            // nbGiaBan
            // 
            this.nbGiaBan.Location = new System.Drawing.Point(12, 179);
            this.nbGiaBan.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nbGiaBan.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nbGiaBan.Name = "nbGiaBan";
            this.nbGiaBan.Size = new System.Drawing.Size(275, 20);
            this.nbGiaBan.TabIndex = 45;
            this.nbGiaBan.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Khu vực";
            // 
            // txtKhuVuc
            // 
            this.txtKhuVuc.Location = new System.Drawing.Point(12, 218);
            this.txtKhuVuc.Name = "txtKhuVuc";
            this.txtKhuVuc.Size = new System.Drawing.Size(275, 20);
            this.txtKhuVuc.TabIndex = 47;
            // 
            // txtDuong
            // 
            this.txtDuong.Location = new System.Drawing.Point(12, 257);
            this.txtDuong.Name = "txtDuong";
            this.txtDuong.Size = new System.Drawing.Size(275, 20);
            this.txtDuong.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Đường";
            // 
            // txtQuan
            // 
            this.txtQuan.Location = new System.Drawing.Point(12, 295);
            this.txtQuan.Name = "txtQuan";
            this.txtQuan.Size = new System.Drawing.Size(275, 20);
            this.txtQuan.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 279);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Quận";
            // 
            // txtThanhPho
            // 
            this.txtThanhPho.Location = new System.Drawing.Point(12, 335);
            this.txtThanhPho.Name = "txtThanhPho";
            this.txtThanhPho.Size = new System.Drawing.Size(275, 20);
            this.txtThanhPho.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 319);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Thành phố";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 356);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Ngày hết hạn";
            // 
            // dtNgayHetHan
            // 
            this.dtNgayHetHan.CustomFormat = "dd/MM/yyyy";
            this.dtNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayHetHan.Location = new System.Drawing.Point(12, 372);
            this.dtNgayHetHan.Name = "dtNgayHetHan";
            this.dtNgayHetHan.Size = new System.Drawing.Size(275, 20);
            this.dtNgayHetHan.TabIndex = 56;
            // 
            // nbSoLuongPhong
            // 
            this.nbSoLuongPhong.Location = new System.Drawing.Point(12, 409);
            this.nbSoLuongPhong.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nbSoLuongPhong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbSoLuongPhong.Name = "nbSoLuongPhong";
            this.nbSoLuongPhong.Size = new System.Drawing.Size(275, 20);
            this.nbSoLuongPhong.TabIndex = 58;
            this.nbSoLuongPhong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 393);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Số lượng phòng";
            // 
            // cbbChiNhanh
            // 
            this.cbbChiNhanh.FormattingEnabled = true;
            this.cbbChiNhanh.Location = new System.Drawing.Point(13, 448);
            this.cbbChiNhanh.Name = "cbbChiNhanh";
            this.cbbChiNhanh.Size = new System.Drawing.Size(275, 21);
            this.cbbChiNhanh.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 432);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Chi nhánh";
            // 
            // cbbMaNha
            // 
            this.cbbMaNha.FormattingEnabled = true;
            this.cbbMaNha.Location = new System.Drawing.Point(12, 60);
            this.cbbMaNha.Name = "cbbMaNha";
            this.cbbMaNha.Size = new System.Drawing.Size(275, 21);
            this.cbbMaNha.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Mã nhà";
            // 
            // ChinhSuaThongTinNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(299, 515);
            this.Controls.Add(this.cbbMaNha);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbbChiNhanh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nbSoLuongPhong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtNgayHetHan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtThanhPho);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQuan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKhuVuc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nbGiaBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTinhTrang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbLoaiNha);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ChinhSuaThongTinNha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChinhSuaThongTinNha";
            ((System.ComponentModel.ISupportInitialize)(this.nbGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuongPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbbLoaiNha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbGiaBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKhuVuc;
        private System.Windows.Forms.TextBox txtDuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThanhPho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtNgayHetHan;
        private System.Windows.Forms.NumericUpDown nbSoLuongPhong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbChiNhanh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbbMaNha;
        private System.Windows.Forms.Label label11;
    }
}