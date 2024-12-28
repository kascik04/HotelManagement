
using System;
using System.Text;
namespace AppCode.Entities 
{
	public class EtblDichVu
	{
		public EtblDichVu()
		{
		}
		public EtblDichVu(string vMaDV, string vTenDV, int vGiaTien)
		{
			this.MaDV = vMaDV;
			this.TenDV = vTenDV;
			this.GiaTien = vGiaTien;
		}
		public string MaDV
		{ get;set; }
		public string TenDV
		{ get;set; }
		public int GiaTien
		{ get;set; }
	}
}