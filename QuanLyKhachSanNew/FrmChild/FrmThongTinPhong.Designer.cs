namespace QuanLyKhachSanNew.FrmChild
{
    partial class FrmThongTinPhong
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
            this.lblMaPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblTenPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnCane = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.Appearance.Options.UseFont = true;
            this.lblMaPhong.Location = new System.Drawing.Point(26, 37);
            this.lblMaPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(201, 29);
            this.lblMaPhong.TabIndex = 0;
            this.lblMaPhong.Text = "Mã Phòng: MP01";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPhong.Appearance.Options.UseFont = true;
            this.lblTenPhong.Location = new System.Drawing.Point(26, 89);
            this.lblTenPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(204, 29);
            this.lblTenPhong.TabIndex = 1;
            this.lblTenPhong.Text = "Tên Phòng: TP01";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiPhong.Appearance.Options.UseFont = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(26, 145);
            this.lblLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(193, 29);
            this.lblLoaiPhong.TabIndex = 2;
            this.lblLoaiPhong.Text = "Loại Phòng: VIP";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Appearance.Options.UseFont = true;
            this.lblTrangThai.Location = new System.Drawing.Point(26, 202);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(213, 29);
            this.lblTrangThai.TabIndex = 3;
            this.lblTrangThai.Text = "Trạng Thái: Trống";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(26, 270);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnCane
            // 
            this.btnCane.Location = new System.Drawing.Point(176, 270);
            this.btnCane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCane.Name = "btnCane";
            this.btnCane.TabIndex = 5;
            this.btnCane.Text = "Thoát";
            this.btnCane.Click += new System.EventHandler(this.btnCane_Click);
            // 
            // FrmThongTinPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 353);
            this.Controls.Add(this.btnCane);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.lblMaPhong);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmThongTinPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Phòng";
            this.Load += new System.EventHandler(this.FrmThongTinPhong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMaPhong;
        private DevExpress.XtraEditors.LabelControl lblTenPhong;
        private DevExpress.XtraEditors.LabelControl lblLoaiPhong;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnCane;
    }
}