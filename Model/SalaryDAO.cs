using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model
{
    public class SalaryDAO
    {
        private Connect db = new Connect();

        // Thêm bảng lương mới
        public bool AddSalary(Salary salary)
        {
            string query = "INSERT INTO LuongNhanVien (MaNhanVien, HoTen, ChucVu, SoNgayDiLam, LuongCoBan, SoTienThuong, SoTienKhauTru, TongLuong, Thang, Nam) " +
                           "VALUES (@MaNhanVien, @HoTen, @ChucVu, @SoNgayDiLam, @LuongCoBan, @SoTienThuong, @SoTienKhauTru, @TongLuong, @Thang, @Nam)";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaNhanVien", salary.MaNhanVien);
                cmd.Parameters.AddWithValue("@HoTen", salary.HoTen);
                cmd.Parameters.AddWithValue("@ChucVu", salary.ChucVu);
                cmd.Parameters.AddWithValue("@SoNgayDiLam", salary.SoNgayDiLam);
                cmd.Parameters.AddWithValue("@LuongCoBan", salary.LuongCoBan);
                cmd.Parameters.AddWithValue("@SoTienThuong", salary.SoTienThuong);
                cmd.Parameters.AddWithValue("@SoTienKhauTru", salary.SoTienKhauTru);
                cmd.Parameters.AddWithValue("@TongLuong", salary.TongLuong);
                cmd.Parameters.AddWithValue("@Thang", salary.Thang);
                cmd.Parameters.AddWithValue("@Nam", salary.Nam);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy danh sách tất cả bảng lương
        public List<Salary> GetAllSalaries()
        {
            List<Salary> salaries = new List<Salary>();
            string query = "SELECT * FROM LuongNhanVien";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return salaries;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salaries.Add(new Salary
                        {
                            MaLuong = reader.GetInt32(0),
                            MaNhanVien = reader.GetInt32(1),
                            HoTen = reader.GetString(2),
                            ChucVu = reader.GetString(3),
                            SoNgayDiLam = reader.GetInt32(4),
                            LuongCoBan = reader.GetDecimal(5),
                            SoTienThuong = reader.GetDecimal(6),
                            SoTienKhauTru = reader.GetDecimal(7),
                            TongLuong = reader.GetDecimal(8),
                            Thang = reader.GetInt32(9),
                            Nam = reader.GetInt32(10)
                        });
                    }
                }
            }
            return salaries;
        }

        // Tìm bảng lương theo mã
        public Salary GetSalaryById(int maLuong)
        {
            string query = "SELECT * FROM LuongNhanVien WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@MaLuong", maLuong);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Salary
                        {
                            MaLuong = reader.GetInt32(0),
                            MaNhanVien = reader.GetInt32(1),
                            HoTen = reader.GetString(2),
                            ChucVu = reader.GetString(3),
                            SoNgayDiLam = reader.GetInt32(4),
                            LuongCoBan = reader.GetDecimal(5),
                            SoTienThuong = reader.GetDecimal(6),
                            SoTienKhauTru = reader.GetDecimal(7),
                            TongLuong = reader.GetDecimal(8),
                            Thang = reader.GetInt32(9),
                            Nam = reader.GetInt32(10)
                        };
                    }
                }
            }
            return null;
        }

        // Cập nhật bảng lương
        public bool UpdateSalary(Salary salary)
        {
            string query = "UPDATE LuongNhanVien SET HoTen = @HoTen, ChucVu = @ChucVu, SoNgayDiLam = @SoNgayDiLam, " +
                           "LuongCoBan = @LuongCoBan, SoTienThuong = @SoTienThuong, SoTienKhauTru = @SoTienKhauTru, " +
                           "TongLuong = @TongLuong, Thang = @Thang, Nam = @Nam WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLuong", salary.MaLuong);
                cmd.Parameters.AddWithValue("@HoTen", salary.HoTen);
                cmd.Parameters.AddWithValue("@ChucVu", salary.ChucVu);
                cmd.Parameters.AddWithValue("@SoNgayDiLam", salary.SoNgayDiLam);
                cmd.Parameters.AddWithValue("@LuongCoBan", salary.LuongCoBan);
                cmd.Parameters.AddWithValue("@SoTienThuong", salary.SoTienThuong);
                cmd.Parameters.AddWithValue("@SoTienKhauTru", salary.SoTienKhauTru);
                cmd.Parameters.AddWithValue("@TongLuong", salary.TongLuong);
                cmd.Parameters.AddWithValue("@Thang", salary.Thang);
                cmd.Parameters.AddWithValue("@Nam", salary.Nam);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa bảng lương theo mã
        public bool DeleteSalary(int maLuong)
        {
            string query = "DELETE FROM LuongNhanVien WHERE MaLuong = @MaLuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy bảng lương của nhân viên theo tháng và năm
        public List<Salary> GetSalariesByMonth(int thang, int nam)
        {
            List<Salary> salaries = new List<Salary>();
            string query = "SELECT * FROM LuongNhanVien WHERE Thang = @Thang AND Nam = @Nam";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return salaries;

                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salaries.Add(new Salary
                        {
                            MaLuong = reader.GetInt32(0),
                            MaNhanVien = reader.GetInt32(1),
                            HoTen = reader.GetString(2),
                            ChucVu = reader.GetString(3),
                            SoNgayDiLam = reader.GetInt32(4),
                            LuongCoBan = reader.GetDecimal(5),
                            SoTienThuong = reader.GetDecimal(6),
                            SoTienKhauTru = reader.GetDecimal(7),
                            TongLuong = reader.GetDecimal(8),
                            Thang = reader.GetInt32(9),
                            Nam = reader.GetInt32(10)
                        });
                    }
                }
            }
            return salaries;
        }

        // Kiểm tra xem nhân viên đã có bảng lương trong tháng này chưa
        public Salary GetSalaryByEmployeeAndMonth(int maNhanVien, int thang, int nam)
        {
            string query = "SELECT * FROM LuongNhanVien WHERE MaNhanVien = @MaNhanVien AND Thang = @Thang AND Nam = @Nam";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Salary
                        {
                            MaLuong = reader.GetInt32(0),
                            MaNhanVien = reader.GetInt32(1),
                            HoTen = reader.GetString(2),
                            ChucVu = reader.GetString(3),
                            SoNgayDiLam = reader.GetInt32(4),
                            LuongCoBan = reader.GetDecimal(5),
                            SoTienThuong = reader.GetDecimal(6),
                            SoTienKhauTru = reader.GetDecimal(7),
                            TongLuong = reader.GetDecimal(8),
                            Thang = reader.GetInt32(9),
                            Nam = reader.GetInt32(10)
                        };
                    }
                }
            }
            return null;
        }
    }
}
