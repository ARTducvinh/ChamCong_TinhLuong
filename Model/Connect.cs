using System;
using System.Data;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model
{
    public class Connect
    {
        private string connectionStr = @"Data Source=VINH;Initial Catalog=QuanLyTinhLuong;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;

        public void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionStr);
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlCommand CreateCommand(string query)
        {
            try
            {
                OpenConnection();
                return new SqlCommand(query, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo SqlCommand: " + ex.Message);
                return null;
            }
        }
    }
}
