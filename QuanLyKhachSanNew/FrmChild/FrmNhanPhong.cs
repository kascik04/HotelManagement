using System;
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
    public partial class FrmNhanPhong : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhanPhong()
        {
            InitializeComponent();
        }

        private void FrmNhanPhong_Load(object sender, EventArgs e)
        {
            load_GridView();
        }

        private void load_GridView()
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblDichVu' table. You can move, or remove it, as needed.
            this.tblDichVuTableAdapter.Fill(this.quanLyKhachSanDataSet.tblDichVu);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblNhanVien' table. You can move, or remove it, as needed.
            this.tblNhanVienTableAdapter.Fill(this.quanLyKhachSanDataSet.tblNhanVien);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblSDDV' table. You can move, or remove it, as needed.
            this.tblSDDVTableAdapter.Fill(this.quanLyKhachSanDataSet.tblSDDV);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblPhong' table. You can move, or remove it, as needed.
            this.tblPhongTableAdapter.Fill(this.quanLyKhachSanDataSet.tblPhong);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblKhachHang' table. You can move, or remove it, as needed.
            this.tblKhachHangTableAdapter.Fill(this.quanLyKhachSanDataSet.tblKhachHang);
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.tblDangKy' table. You can move, or remove it, as needed.
            this.tblDangKyTableAdapter.Fill(this.quanLyKhachSanDataSet.tblDangKy);

        }

        private void lueMaDK_EditValueChanged(object sender, EventArgs e)
        {
            String maDK = lueMaDK.Text.ToString();
            EtblDangKy tblDangKy = BtblDangKy.SelectByID(maDK);
            //Lay du lieu tu bang khach
            EtblKhachHang tblKhach = BtblKhachHang.SelectByID(tblDangKy.MaKhach);   
            lueTenKhach.Text = tblKhach.HoDem + " " + tblKhach.Ten;
            lueMaKhach.Text = tblKhach.MaKhach;
            lueCMND.Text = tblKhach.CMND;
            lueSoLuong.Text = tblDangKy.SoNguoi.ToString();
        }

        private void lueMaKhach_EditValueChanged(object sender, EventArgs e)
        {
            String maKhach = lueMaKhach.Text.ToString();
            //Lay du lieu tu bang khach
            EtblKhachHang tblKhach = BtblKhachHang.SelectByID(maKhach);
            lueTenKhach.Text = tblKhach.HoDem + " " + tblKhach.Ten;
            lueMaKhach.Text = tblKhach.MaKhach;
            lueCMND.Text = tblKhach.CMND;
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(lueMaDK.Text) ||
                string.IsNullOrWhiteSpace(lueMaKhach.Text) ||
                string.IsNullOrWhiteSpace(lueTenKhach.Text) ||
                string.IsNullOrWhiteSpace(lueCMND.Text) ||
                dtpNgayDen.EditValue == null ||
                string.IsNullOrWhiteSpace(lueSoLuong.Text) ||
                string.IsNullOrWhiteSpace(teTienDat.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin: Mã đăng ký, Mã khách, Tên, CMND, Ngày đến, Số người, Đặt cọc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu và thực hiện logic
            String maDK = lueMaDK.Text.ToString();
            EtblDangKy tblDangKy = BtblDangKy.SelectByID(maDK);
            tblDangKy.MaPhong = null;
            tblDangKy.NgayDen = dtpNgayDen.DateTime;

            int tienDat;
            if (int.TryParse(teTienDat.Text.ToString(), out tienDat))
            {
                tblDangKy.TienDat = tienDat;
            }
            else
            {
                MessageBox.Show("Số tiền đặt cọc không hợp lệ. Vui lòng nhập số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BtblDangKy.Update(tblDangKy);
            gcDatPhong.Enabled = true;
            gcDangKyDV.Enabled = true;
            gcNhanPhong.Enabled = false;

            MessageBox.Show("Nhận phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(lueMaDK.Text) || string.IsNullOrWhiteSpace(lueMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin: Mã đăng ký và Mã phòng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu và thực hiện logic
            String maDK = lueMaDK.Text.ToString();
            EtblDangKy tblDangKy = BtblDangKy.SelectByID(maDK);
            tblDangKy.MaPhong = lueMaPhong.Text.ToString().Trim();
            tblDangKy.NgiChu = teNghiChu.Text.ToString().Trim();
            tblDangKy.NgayDen = dtpNgayDen.DateTime;

            BtblDangKy.Update(tblDangKy);
            MessageBox.Show("Thêm phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDangKy_CheckedChanged(object sender, EventArgs e)
        {
            String maDK = lueMaDK.Text.ToString();
            String maDV = lueMaDV.Text.ToString();
            int soLuong = Int32.Parse(teSoLuong.Text.ToString());
            String maNV = lueMaNV.Text.ToString();
            DateTime ngaySD = dtpNgaySD.DateTime;

            EtblSDDV sddv = new EtblSDDV(maDK, maDV, maNV, ngaySD, soLuong);
            BtblSDDV.Insert(sddv);
            MessageBox.Show("Thêm Dịch Vụ Thành Công.");
        }

        private void lueMaDV_EditValueChanged(object sender, EventArgs e)
        {
            EtblDichVu dv = new EtblDichVu();
            dv = BtblDichVu.SelectByID(lueMaDV.Text.ToString());
            lueTenDichVu.Text = dv.TenDV.ToString();
        }
    }
}