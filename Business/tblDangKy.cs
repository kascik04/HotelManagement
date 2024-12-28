﻿
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AppCode.Entities;
using AppCode.DataAccess;
using System.Windows.Forms;
namespace AppCode.Business
{
	public class BtblDangKy
	{
//---------------------------------------------------------------------------------------------------------//
		public static DataTable SelectAll()
		{
			DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "tblDangKy_SelectAll", null);
			return all;
		}
		public static DataTable SelectTop(string Top ,string Where,string Order)
		{
			SqlParameter[] pr = new SqlParameter[3];
			pr[0] = new SqlParameter(@"Top", Top);
			pr[1] = new SqlParameter(@"Where", Where);
			pr[2] = new SqlParameter(@"Order", Order);
			DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "tblDangKy_SelectTop", pr);
			return all;
		}
		public static EtblDangKy SelectByID(string MaDK)
		{
			EtblDangKy OtblDangKy = new EtblDangKy();
			SqlParameter[] pr = new SqlParameter[1];
			pr[0] = new SqlParameter(@"MaDK", MaDK);
			IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "tblDangKy_SelectByID", pr);
			if (idr.Read())
				OtblDangKy = GetOnetblDangKy(idr);
			idr.Close();
			idr.Dispose();
			return OtblDangKy;
		}
		public static bool TestByID(string MaDK)
		{
			SqlParameter[] pr = new SqlParameter[1];
			pr[0] = new SqlParameter(@"MaDK",MaDK);
			pr[0].Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"tblDangKy_TestByID", pr);
			return Convert.ToBoolean(pr[0].Value);
		}
		public static DataTable SelectPage(int CurrentPage, int PageSize, out int RowCount)
		{
			SqlParameter[] pr = new SqlParameter[3];
			pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
			pr[1] = new SqlParameter(@"PageSize", PageSize);
			pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
			pr[2].Direction = ParameterDirection.Output;
			DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "tblDangKy_SelectPage", pr);
			RowCount = Convert.ToInt32(pr[2].Value);
			return all;
		}
        //---------------------------------------------------------------------------------------------------------//


        public static void Insert(EtblDangKy OtblDangKy)
        {
            // Validate date ranges
            if (OtblDangKy.NgayDangKy < new DateTime(1753, 1, 1) || OtblDangKy.NgayDangKy > new DateTime(9999, 12, 31))
            {
                MessageBox.Show("Ngày đăng ký phải nằm trong khoảng từ 1/1/1753 đến 31/12/9999.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OtblDangKy.NgayDen.HasValue && (OtblDangKy.NgayDen < new DateTime(1753, 1, 1) || OtblDangKy.NgayDen > new DateTime(9999, 12, 31)))
            {
                MessageBox.Show("Ngày đến phải nằm trong khoảng từ 1/1/1753 đến 31/12/9999.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OtblDangKy.NgayDi.HasValue && (OtblDangKy.NgayDi < new DateTime(1753, 1, 1) || OtblDangKy.NgayDi > new DateTime(9999, 12, 31)))
            {
                MessageBox.Show("Ngày đi phải nằm trong khoảng từ 1/1/1753 đến 31/12/9999.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SqlHelper.IsPrimaryKeyExists("tblDangKy", "MaDK", OtblDangKy.MaDK))
            {
                SqlParameter[] pr = new SqlParameter[9];
                pr[0] = new SqlParameter(@"MaDK", OtblDangKy.MaDK);
                pr[1] = new SqlParameter(@"MaKhach", OtblDangKy.MaKhach);
                pr[2] = new SqlParameter(@"MaPhong", OtblDangKy.MaPhong);
                pr[3] = new SqlParameter(@"NgayDangKy", OtblDangKy.NgayDangKy);
                pr[4] = new SqlParameter(@"NgayDen", OtblDangKy.NgayDen);
                pr[5] = new SqlParameter(@"NgayDi", OtblDangKy.NgayDi);
                pr[6] = new SqlParameter(@"TienDat", OtblDangKy.TienDat);
                pr[7] = new SqlParameter(@"SoNguoi", OtblDangKy.SoNguoi);
                pr[8] = new SqlParameter(@"NgiChu", OtblDangKy.NgiChu);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "tblDangKy_Insert", pr);
            }
            else
            {
                // Handle duplicate key scenario
                MessageBox.Show("Thông tin bị trùng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public static void Update(EtblDangKy OtblDangKy)
        {
            if (OtblDangKy == null || OtblDangKy.MaPhong == null)
            {
                MessageBox.Show("OtblDangKy or MaPhong is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem MaPhong có tồn tại trong bảng tblPhong hay không
            if (!SqlHelper.IsPrimaryKeyExists("tblPhong", "MaPhong", OtblDangKy.MaPhong))
            {
                MessageBox.Show($"MaPhong '{OtblDangKy.MaPhong.ToString()}' không tồn tại trong bảng tblPhong.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter(@"MaDK", OtblDangKy.MaDK);
            pr[1] = new SqlParameter(@"MaKhach", OtblDangKy.MaKhach);
            pr[2] = new SqlParameter(@"MaPhong", OtblDangKy.MaPhong);
            pr[3] = new SqlParameter(@"NgayDangKy", OtblDangKy.NgayDangKy);
            pr[4] = new SqlParameter(@"NgayDen", OtblDangKy.NgayDen);
            pr[5] = new SqlParameter(@"NgayDi", OtblDangKy.NgayDi);
            pr[6] = new SqlParameter(@"TienDat", OtblDangKy.TienDat);
            pr[7] = new SqlParameter(@"SoNguoi", OtblDangKy.SoNguoi);
            pr[8] = new SqlParameter(@"NgiChu", OtblDangKy.NgiChu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "tblDangKy_Update", pr);
        }
        public static void Delete(string MaDK)
		{
			SqlParameter[] pr = new SqlParameter[1];
			pr[0] = new SqlParameter(@"MaDK", MaDK);
			SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "tblDangKy_Delete", pr);		}
//---------------------------------------------------------------------------------------------------------//
		 private static EtblDangKy GetOnetblDangKy(IDataReader idr)
		{
			EtblDangKy OtblDangKy = new EtblDangKy();
				if (idr["MaDK"] != DBNull.Value)
					OtblDangKy.MaDK = (string)idr["MaDK"];
				if (idr["MaKhach"] != DBNull.Value)
					OtblDangKy.MaKhach = (string)idr["MaKhach"];
				if (idr["MaPhong"] != DBNull.Value)
					OtblDangKy.MaPhong = (string)idr["MaPhong"];
				if (idr["NgayDangKy"] != DBNull.Value)
					OtblDangKy.NgayDangKy = (DateTime)idr["NgayDangKy"];
				if (idr["NgayDen"] != DBNull.Value)
					OtblDangKy.NgayDen = (DateTime)idr["NgayDen"];
				if (idr["NgayDi"] != DBNull.Value)
					OtblDangKy.NgayDi = (DateTime)idr["NgayDi"];
				if (idr["TienDat"] != DBNull.Value)
					OtblDangKy.TienDat = (int)idr["TienDat"];
				if (idr["SoNguoi"] != DBNull.Value)
					OtblDangKy.SoNguoi = (int)idr["SoNguoi"];
				if (idr["NgiChu"] != DBNull.Value)
					OtblDangKy.NgiChu = (string)idr["NgiChu"];
			return OtblDangKy;
		}
//---------------------------------------------------------------------------------------------------------//
		public static List<EtblDangKy> ListAll()
		{
		List<EtblDangKy> list = new List<EtblDangKy>();
			IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "tblDangKy_SelectAll", null);
			while (idr.Read())
				list.Add(GetOnetblDangKy(idr));
			if (idr.IsClosed == false)
			{
				idr.Close();
				idr.Dispose();
			}
			return list;
		}
		public static List<EtblDangKy> ListTop(string Top ,string Where,string Order)
		{
			SqlParameter[] pr = new SqlParameter[3];
			pr[0] = new SqlParameter(@"Top", Top);
			pr[1] = new SqlParameter(@"Where", Where);
			pr[2] = new SqlParameter(@"Order", Order);
			List<EtblDangKy> list = new List<EtblDangKy>();
			IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "tblDangKy_SelectTop", pr);
			while (idr.Read())
				list.Add(GetOnetblDangKy(idr));
			if (idr.IsClosed == false)
			{
				idr.Close();
				idr.Dispose();
			}
			return list;
		}
		public static List<EtblDangKy> ListPage(int CurrentPage, int PageSize, out int RowCount)
		{
			SqlParameter[] pr = new SqlParameter[3];
			pr[0] = new SqlParameter(@"CurrentPage", CurrentPage);
			pr[1] = new SqlParameter(@"PageSize", PageSize);
			pr[2] = new SqlParameter(@"RowCount", SqlDbType.Int);
			pr[2].Direction = ParameterDirection.Output;
			List<EtblDangKy> list = new List<EtblDangKy>();
			IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "tblDangKy_SelectPage", pr);
			while (idr.Read())
				list.Add(GetOnetblDangKy(idr));
			if (idr.IsClosed == false)
			{
				idr.Close();
				idr.Dispose();
			}
			RowCount = Convert.ToInt32(pr[2].Value);
			return list;
		}
	}
}