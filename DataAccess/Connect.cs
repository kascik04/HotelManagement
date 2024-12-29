
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
namespace AppCode.Connection
{
	public static class ConnectionString
	{
   		// Connect string for application
		private static string strconnection = @"Data Source=DA-LENOVO;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
		// Connect string for website
		//private static string strconnection =  ConfigurationManager.ConnectionStrings["AutoNetCoderConnectionString"].ToString();
		public static string Text
		{
			get { return strconnection; }
			set { strconnection = value; }
		}
	}
}