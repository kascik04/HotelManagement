
using System;
using System.Text;
namespace AppCode.Entities 
{
	public class EtblSDDV
	{
		public EtblSDDV()
		{
		}
		public EtblSDDV(string vMaDK, string vMaDV, string vMaNV, DateTime vNgaySuDung, int vSoLuong)
		{
			this.MaDK = vMaDK;
			this.MaDV = vMaDV;
			this.MaNV = vMaNV;
			this.NgaySuDung = vNgaySuDung;
			this.SoLuong = vSoLuong;
		}
		public string MaDK
		{ get;set; }
		public string MaDV
		{ get;set; }
		public string MaNV
		{ get;set; }
		public DateTime NgaySuDung
		{ get;set; }
		public int SoLuong
		{ get;set; }
	}
}