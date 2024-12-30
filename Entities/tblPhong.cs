
using System;
using System.Text;
namespace AppCode.Entities 
{
    public class EtblPhong
    {
        public EtblPhong()
        {
        }

        public EtblPhong(string vMaPhong, string vTenPhong, string vLoaiPhong, int vGia )
        {
            this.MaPhong = vMaPhong;
            this.TenPhong = vTenPhong;
            this.LoaiPhong = vLoaiPhong;
            this.Gia = vGia;
            //this.DaDangKy = vDaDangKy;   // Trạng thái Đã Đăng Ký
            //this.DaNhanPhong = vDaNhanPhong;  // Trạng thái Đã Nhận Phòng
        }

        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public int Gia { get; set; }
        //public bool DaDangKy { get; set; }  // Trạng thái Đã Đăng Ký
        //public bool DaNhanPhong { get; set; }  // Trạng thái Đã Nhận Phòng
    }

}