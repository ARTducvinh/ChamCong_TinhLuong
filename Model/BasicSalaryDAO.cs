using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model
{
    public class BasicSalaryDAO
    {
        private Connect db = new Connect();

        // Thêm mức lương mới
        public bool AddBasicSalary(BasicSalary salary)
        {
            string query = "INSERT INTO LuongCoBan (ChucVu, LuongThang) " +
                           "VALUES (@ChucVu, @LuongThang)";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@ChucVu", salary.ChucVu);
                cmd.Parameters.AddWithValue("@LuongThang", salary.LuongThang);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật mức lương
        public bool UpdateBasicSalary(BasicSalary salary)
        {
            string query = "UPDATE LuongCoBan SET ChucVu = @ChucVu, LuongThang = @LuongThang " +
                           "WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLuong", salary.MaLuong);
                cmd.Parameters.AddWithValue("@ChucVu", salary.ChucVu);
                cmd.Parameters.AddWithValue("@LuongThang", salary.LuongThang);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa mức lương theo mã
        public bool DeleteBasicSalary(int maLuong)
        {
            string query = "DELETE FROM LuongCoBan WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy danh sách tất cả các mức lương
        public List<BasicSalary> GetAllBasicSalaries()
        {
            List<BasicSalary> salaries = new List<BasicSalary>();
            string query = "SELECT MaLuong, ChucVu, LuongThang, LuongThang / 22 AS LuongNgay FROM LuongCoBan";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return salaries;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salaries.Add(new BasicSalary
                        {
                            MaLuong = reader.GetInt32(0),
                            ChucVu = reader.GetString(1),
                            LuongThang = reader.GetDecimal(2),
                            LuongNgay = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return salaries;
        }

        // Tìm mức lương theo mã
        public BasicSalary GetBasicSalaryById(int maLuong)
        {
            string query = "SELECT MaLuong, ChucVu, LuongThang, LuongThang / 22 AS LuongNgay FROM LuongCoBan WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@MaLuong", maLuong);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BasicSalary
                        {
                            MaLuong = reader.GetInt32(0),
                            ChucVu = reader.GetString(1),
                            LuongThang = reader.GetDecimal(2),
                            LuongNgay = reader.GetDecimal(3)
                        };
                    }
                }
            }
            return null;
        }

        public List<string> GetChucVuList()
        {
            List<string> chucVuList = new List<string>();
            string query = "SELECT DISTINCT ChucVu FROM LuongCoBan";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return chucVuList;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chucVuList.Add(reader.GetString(0)); // Lấy giá trị từ cột ChucVu
                    }
                }
            }
            return chucVuList;
        }

        // Lấy mức lương cơ bản theo chức vụ
        public BasicSalary GetBasicSalaryByPosition(string chucVu)
        {
            string query = "SELECT MaLuong, ChucVu, LuongThang, LuongThang / 22 AS LuongNgay FROM LuongCoBan WHERE ChucVu = @ChucVu";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@ChucVu", chucVu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BasicSalary
                        {
                            MaLuong = reader.GetInt32(0),
                            ChucVu = reader.GetString(1),
                            LuongThang = reader.GetDecimal(2),
                            LuongNgay = reader.GetDecimal(3)
                        };
                    }
                }
            }
            return null;
        }

    }
}
