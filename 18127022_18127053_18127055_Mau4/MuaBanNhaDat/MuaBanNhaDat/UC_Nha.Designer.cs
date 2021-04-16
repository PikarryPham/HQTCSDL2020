namespace MuaBanNhaDat
{
    partial class UC_Nha
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
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.Location = new System.Drawing.Point(20, 42);
            this.lblProductInfo.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(215, 37);
            this.lblProductInfo.TabIndex = 1;
            this.lblProductInfo.Text = "Thông tin nhà";
            // 
            // UC_Nha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblProductInfo);
            this.Name = "UC_Nha";
            this.Size = new System.Drawing.Size(647, 691);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductInfo;
    }
}
