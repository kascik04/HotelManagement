using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppCode.Connection;

namespace AppCode.DataAccess
{
    public abstract class SqlHelper
    {
        private static Hashtable parasCache = Hashtable.Synchronized(new Hashtable());
            
        public static void ExecuteNonQuery(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(ConnectionString.Text);
            try
            {
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while executing the SQL command.", ex);
            }
        }

        public static DataTable ExecuteData(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(ConnectionString.Text);
            try
            {
                DataTable dattTopic = new DataTable();
                SqlDataAdapter dataTopic = new SqlDataAdapter(cmdCommand);
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                cmdCommand.ExecuteNonQuery();
                dataTopic.Fill(dattTopic);
                cmdCommand.Parameters.Clear();
                if (connect.State == ConnectionState.Open) connect.Close();
                return dattTopic;
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while executing the SQL command.", ex);
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmdCommand = new SqlCommand();
            SqlConnection connect = new SqlConnection(ConnectionString.Text);
            try
            {
                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);
                SqlDataReader datrDataReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
                cmdCommand.Parameters.Clear();
                return datrDataReader;
            }
            catch (SqlException ex)
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                    SqlConnection.ClearPool(connect);
                }
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while executing the SQL command.", ex);
            }
        }

        private static void PrepareCommand(SqlCommand cmdCommand, SqlConnection connConnection, SqlTransaction trasTransaction, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)
        {
            if (connConnection.State != ConnectionState.Open)
            {
                connConnection.Open();
            }
            cmdCommand.Connection = connConnection;
            cmdCommand.CommandText = cmdCommandString;
            if (trasTransaction != null)
            {
                cmdCommand.Transaction = trasTransaction;
            }

            cmdCommand.CommandType = cmdCommandType;
            if (cmdParameters != null)
            {
                foreach (SqlParameter para in cmdParameters)
                {
                    cmdCommand.Parameters.Add(para);
                }
            }
        }

        public static void PrepareCommand(SqlCommand cmdCommand, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)
        {
            cmdCommand.Parameters.Clear();
            cmdCommand.CommandType = cmdCommandType;
            cmdCommand.CommandText = cmdCommandString;
            if (cmdParameters != null)
                foreach (SqlParameter para in cmdParameters)
                    cmdCommand.Parameters.Add(para);
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParameters)
        {
            parasCache[cacheKey] = cmdParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parasCache[cacheKey];

            if (cachedParms == null)
            {
                return null;
            }
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }

        public static void CheckPrimaryKeys(string value)
        {
            if (string.IsNullOrEmpty(value))
            {   
                throw new ArgumentException("Tham số 'value' không được null hoặc rỗng.", nameof(value));
            }

            var tablesAndColumns = new (string TableName, string ColumnName)[]
            {
        ("tblPhong", "MaPhong"),
        ("tblKhachHang", "MaKhach"),
        ("tblChucVu", "MaChucVu"),
        ("tblThanhToan", "MaThanhToan"),
        ("tblDichVu", "MaDV"),
        ("tblNhanVien", "MaNhanVien")
            };

            foreach (var table in tablesAndColumns)
            {
                bool exists = IsPrimaryKeyExists(table.TableName, table.ColumnName, value);
                Console.WriteLine($"Bảng: {table.TableName}, Cột: {table.ColumnName}, Tồn tại: {exists}");
            }
        }


        public static bool IsPrimaryKeyExists(string tableName, string columnName, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("MaPhong không được trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (SqlConnection connect = new SqlConnection(ConnectionString.Text))
            {
                string query = $"SELECT COUNT(1) FROM dbo.{tableName} WHERE {columnName} = @Value";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@Value", value);

                connect.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }



    }
}
