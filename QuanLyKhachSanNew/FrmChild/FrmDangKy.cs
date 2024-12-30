﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AppCode.Business;
using AppCode.Entities;



namespace QuanLyKhachSanNew.FrmChild
{
    public partial class FrmDangKy : DevExpress.XtraEditors.XtraForm
    {
        private Boolean ttDK = false;
        private Boolean dangKy = true;

        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblNhanVien' table. You can move, or remove it, as needed.
            this.tblNhanVienTableAdapter.Fill(this.quanLyKhachSanDataSet.tblNhanVien);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblDichVu' table. You can move, or remove it, as needed.
            this.tblDichVuTableAdapter.Fill(this.quanLyKhachSanDataSet.tblDichVu);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblPhong' table. You can move, or remove it, as needed.
            this.tblPhongTableAdapter.Fill(this.quanLyKhachSanDataSet.tblPhong);
            load_Data();
        }

        private void load_Group()
        {
            // Check Dang Ky
            if (ttDK)
            {
                gcDangKy2.Enabled = true;
            }
            else
            {
                gcDangKy2.Enabled = false;
            }
            // Check thong tin va dang ky dich vu
            if (dangKy)
            {
                gcDangKy1.Enabled = true;
                gcDKDV.Enabled = false;
                gcDKPhong.Enabled = false;
            }
            else
            {
                gcDangKy1.Enabled = false;
                gcDKDV.Enabled = true;
                gcDKPhong.Enabled = true;
            }

        }

        private void load_Data()
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblKhachHang' table. You can move, or remove it, as needed.
            this.tblKhachHangTableAdapter.Fill(this.quanLyKhachSanDataSet.tblKhachHang);

        }

        private void lueMaKhach_EditValueChanged(object sender, EventArgs e)
        {
            String maKhach = lueMaKhach.Text.ToString();
            EtblKhachHang khach;
            khach = BtblKhachHang.SelectByID(maKhach);
            lueTenKhach.Text = khach.HoDem + " " + khach.Ten;
            lueCMND.Text = khach.CMND;
            // Moi lan chon se tat group2 di
            ttDK = false;
            load_Group();
        }

        private void ceTuDongNhapMDK_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnKiemTraDK_CheckedChanged(object sender, EventArgs e)
        {
            String maKhach = lueMaKhach.Text.ToString().Trim();
            if (maKhach != "")
            {
                ttDK = true;
                load_Group();
            }
            else
            {
                ttDK = false;
                load_Group();
            }
        }


        private void tblThem_CheckedChanged(object sender, EventArgs e)
        {
            String maDK = teMaDK.Text.ToString().Trim(); // Lấy giá trị từ ô nhập mã đăng ký

            // Kiểm tra nếu mã đăng ký bị để trống
            if (string.IsNullOrEmpty(maDK))
            {
                MessageBox.Show("Mã đăng ký không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String maKhach = lueMaKhach.Text.ToString();
            DateTime ngayDangKy = dtpNgayDangKy.DateTime;

            // Kiểm tra và xử lý các trường khác nếu cần
            int soNguoi;
            if (!int.TryParse(teSoNguoi.Text.ToString().Trim(), out soNguoi))
            {
                MessageBox.Show("Số người phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dữ liệu mặc định
            String nghiChu = "Không Có";
            String maPhong = null;
            int tienDat = 0;
            Nullable<DateTime> dateNull = null;

            // Tạo đối tượng đăng ký và thêm mới
            EtblDangKy dangky = new EtblDangKy(maDK, maKhach, maPhong, ngayDangKy, dateNull, dateNull, tienDat, soNguoi, nghiChu);

            try
            {
                BtblDangKy.Insert(dangky); // Gọi phương thức thêm mới
                MessageBox.Show("Đã thêm thông tin đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                // Sau khi thêm, chuyển sang trạng thái khác nếu cần
                dangKy = false;
                load_Group();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {

            String maDK = teMaDK.Text.ToString().Trim();
            String maKhach = lueMaKhach.Text.ToString();
            DateTime ngayDangKy = dtpNgayDangKy.DateTime;
            int soNguoi = int.Parse(teSoNguoi.Text.ToString().Trim());
            //Du Lieu chua Co khai bao Null
            String nghiChu = "Không Có";
            String maPhong = lueMaPhong.Text.ToString();
            int tienDat = 0;
            Nullable<DateTime> dateNull = null;

            EtblDangKy dangky = new EtblDangKy(maDK, maKhach, maPhong, ngayDangKy, dateNull, dateNull, tienDat, soNguoi, nghiChu);
            //BtblPhong.UpdateStatus(maPhong, true, false);
            BtblDangKy.Update(dangky);
            MessageBox.Show("Đã Thêm Phòng Thành Công");

        }

        private void btnChinhSua_CheckedChanged(object sender, EventArgs e)
        {
            dangKy = true;
            load_Group();
        }

        private void btnLuu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String maDK = teMaDK.Text.ToString().Trim();
                String maKhach = lueMaKhach.Text.ToString();
                DateTime ngayDangKy = dtpNgayDangKy.DateTime;

                // Sử dụng TryParse để kiểm tra và chuyển đổi giá trị số
                int soNguoi;
                if (!int.TryParse(teSoNguoi.Text.ToString().Trim(), out soNguoi))
                {
                    MessageBox.Show("Số người phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Dữ liệu chưa có khai báo null
                String nghiChu = "Không Có";
                String maPhong = lueMaPhong.Text.ToString();
                int tienDat = 0;
                Nullable<DateTime> dateNull = null;

                // Khởi tạo đối tượng và cập nhật
                EtblDangKy dangky = new EtblDangKy(maDK, maKhach, maPhong, ngayDangKy, dateNull, dateNull, tienDat, soNguoi, nghiChu);
                BtblDangKy.Update(dangky);

                // Reset trạng thái
                dangKy = false;
                load_Group();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkButton2_CheckedChanged(object sender, EventArgs e)
        {
            String maDK = teMaDK.Text.ToString();
            String maDV = lueMaDV.Text.ToString();
            int soLuong = Int32.Parse(teSoLuong.Text.ToString());
            String maNV = lueMaNV.Text.ToString();
            DateTime ngaySD = dtpNgaySD.DateTime;

            EtblSDDV sddv = new EtblSDDV(maDK,maDV,maNV,ngaySD,soLuong);
            BtblSDDV.Insert(sddv);
            MessageBox.Show("Thêm Dịch Vụ Thành Công");

            dangKy = false;
            load_Group();
        }

        private void btnThemKhach_CheckedChanged(object sender, EventArgs e)
        {
            FrmChild.FrmQLKhachHang khachHang = new FrmChild.FrmQLKhachHang();
            khachHang.ShowDialog();
        }

        private void lblNgaySD_Click(object sender, EventArgs e)
        {

        }

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void lblMaNV_Click(object sender, EventArgs e)
        {

        }

        private void lblMaDV_Click(object sender, EventArgs e)
        {

        }

        private void lueMaDV_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void teSoLuong_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgaySD_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lueMaNV_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}