namespace MuaBanNhaDat
{
    partial class NVQLQLTTCNV
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNvql = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.nbLuong = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvChuaCapNhat = new System.Windows.Forms.DataGridView();
            this.MA_NV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_NV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAMVIEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDaCapNhat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nbLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaCapNhat)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaCapNhat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(189, 240);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(119, 44);
            this.btnUpdate.TabIndex = 37;
            this.btnUpdate.Text = "Lưu cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Lương cập nhật cho mã NV trên";
            // 
            // txtMaNv
            // 
            this.txtMaNv.Location = new System.Drawing.Point(23, 170);
            this.txtMaNv.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNv.Name = "txtMaNv";
            this.txtMaNv.Size = new System.Drawing.Size(460, 22);
            this.txtMaNv.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Vui lòng nhập mã NV bạn muốn cập nhật lương (nếu có)";
            // 
            // txtMaNvql
            // 
            this.txtMaNvql.Location = new System.Drawing.Point(23, 127);
            this.txtMaNvql.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNvql.Name = "txtMaNvql";
            this.txtMaNvql.Size = new System.Drawing.Size(460, 22);
            this.txtMaNvql.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Vui lòng nhập chính xác mã MANVQL của bạn";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Location = new System.Drawing.Point(120, 11);
            this.lblUserInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserInfo.Size = new System.Drawing.Size(361, 28);
            this.lblUserInfo.TabIndex = 38;
            this.lblUserInfo.Text = "Xin chào";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 11);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 28);
            this.btnBack.TabIndex = 39;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // nbLuong
            // 
            this.nbLuong.Location = new System.Drawing.Point(23, 215);
            this.nbLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nbLuong.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nbLuong.Name = "nbLuong";
            this.nbLuong.Size = new System.Drawing.Size(461, 22);
            this.nbLuong.TabIndex = 40;
            this.nbLuong.ThousandsSeparator = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChuaCapNhat);
            this.groupBox1.Location = new System.Drawing.Point(23, 289);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(459, 138);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thông tin của các nhân viên này quản lý (chưa cập nhật)";
            // 
            // dgvChuaCapNhat
            // 
            this.dgvChuaCapNhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuaCapNhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MA_NV,
            this.TEN_NV,
            this.LUONG,
            this.LAMVIEC});
            this.dgvChuaCapNhat.Location = new System.Drawing.Point(8, 23);
            this.dgvChuaCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvChuaCapNhat.Name = "dgvChuaCapNhat";
            this.dgvChuaCapNhat.RowHeadersWidth = 51;
            this.dgvChuaCapNhat.Size = new System.Drawing.Size(443, 107);
            this.dgvChuaCapNhat.TabIndex = 0;
            // 
            // MA_NV
            // 
            this.MA_NV.DataPropertyName = "MA_NV";
            this.MA_NV.HeaderText = "Mã nhân viên";
            this.MA_NV.MinimumWidth = 6;
            this.MA_NV.Name = "MA_NV";
            this.MA_NV.Width = 125;
            // 
            // TEN_NV
            // 
            this.TEN_NV.DataPropertyName = "TEN_NV";
            this.TEN_NV.HeaderText = "Tên nhân viên";
            this.TEN_NV.MinimumWidth = 6;
            this.TEN_NV.Name = "TEN_NV";
            this.TEN_NV.Width = 125;
            // 
            // LUONG
            // 
            this.LUONG.DataPropertyName = "LUONG";
            this.LUONG.HeaderText = "Lương";
            this.LUONG.MinimumWidth = 6;
            this.LUONG.Name = "LUONG";
            this.LUONG.Width = 125;
            // 
            // LAMVIEC
            // 
            this.LAMVIEC.DataPropertyName = "LAMVIEC";
            this.LAMVIEC.HeaderText = "Làm việc";
            this.LAMVIEC.MinimumWidth = 6;
            this.LAMVIEC.Name = "LAMVIEC";
            this.LAMVIEC.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDaCapNhat);
            this.groupBox2.Location = new System.Drawing.Point(23, 434);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(459, 138);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thông tin của các nhân viên này quản lý (đã cập nhật)";
            // 
            // dgvDaCapNhat
            // 
            this.dgvDaCapNhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaCapNhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvDaCapNhat.Location = new System.Drawing.Point(8, 23);
            this.dgvDaCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDaCapNhat.Name = "dgvDaCapNhat";
            this.dgvDaCapNhat.RowHeadersWidth = 51;
            this.dgvDaCapNhat.Size = new System.Drawing.Size(443, 102);
            this.dgvDaCapNhat.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MA_NV";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã nhân viên";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TEN_NV";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên nhân viên";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LUONG";
            this.dataGridViewTextBoxColumn3.HeaderText = "Lương";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LAMVIEC";
            this.dataGridViewTextBoxColumn4.HeaderText = "Làm việc";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // NVQLQLTTCNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(497, 575);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nbLuong);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaNv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaNvql);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "NVQLQLTTCNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NVQLQLTTCNV";
            ((System.ComponentModel.ISupportInitialize)(this.nbLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaCapNhat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaCapNhat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNvql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.NumericUpDown nbLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvChuaCapNhat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MA_NV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_NV;
        private System.Windows.Forms.DataGridViewTextBoxColumn LUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAMVIEC;
        private System.Windows.Forms.DataGridView dgvDaCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}