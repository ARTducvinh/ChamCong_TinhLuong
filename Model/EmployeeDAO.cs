using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model
{
    public class EmployeeDAO
    {
        private Connect db = new Connect();

        // Thêm nhân viên mới
        public bool AddEmployee(Employee emp)
        {
            string query = "INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, CCCD, ChucVu, NgayBatDauLam) " +
                           "VALUES (@HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SoDienThoai, @Email, @CCCD, @ChucVu, @NgayBatDauLam)";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@HoTen", emp.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", emp.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", emp.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", emp.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", emp.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@CCCD", emp.CCCD);
                cmd.Parameters.AddWithValue("@ChucVu", emp.ChucVu);
                cmd.Parameters.AddWithValue("@NgayBatDauLam", emp.NgayBatDauLam);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật thông tin nhân viên
        public bool UpdateEmployee(Employee emp)
        {
            string query = "UPDATE NhanVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, " +
                           "DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, CCCD = @CCCD, ChucVu = @ChucVu, NgayBatDauLam = @NgayBatDauLam " +
                           "WHERE MaNhanVien = @MaNhanVien";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaNhanVien", emp.MaNhanVien);
                cmd.Parameters.AddWithValue("@HoTen", emp.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", emp.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", emp.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", emp.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", emp.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@CCCD", emp.CCCD);
                cmd.Parameters.AddWithValue("@ChucVu", emp.ChucVu);
                cmd.Parameters.AddWithValue("@NgayBatDauLam", emp.NgayBatDauLam);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa nhân viên theo ID
        public bool DeleteEmployee(int maNhanVien)
        {
            string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm nhân viên theo Tên hoặc Số điện thoại
        public List<Employee> SearchEmployees(string hoTen, string soDienThoai)
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT * FROM NhanVien WHERE HoTen LIKE @HoTen OR SoDienThoai LIKE @SoDienThoai";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return employees;

                cmd.Parameters.AddWithValue("@HoTen", "%" + hoTen + "%");
                cmd.Parameters.AddWithValue("@SoDienThoai", "%" + soDienThoai + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            MaNhanVien = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            GioiTinh = reader.GetString(2),
                            NgaySinh = reader.GetDateTime(3),
                            DiaChi = reader.GetString(4),
                            SoDienThoai = reader.GetString(5),
                            Email = reader.GetString(6),
                            CCCD = reader.GetString(7),
                            ChucVu = reader.GetString(8),
                            NgayBatDauLam = reader.GetDateTime(9)
                        };
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }

        // Lấy danh sách tất cả nhân viên
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT * FROM NhanVien";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return employees;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            MaNhanVien = reader.GetInt32(0),  // Mã nhân viên
                            HoTen = reader.GetString(1),     // Họ tên
                            GioiTinh = reader.GetString(2),  // Giới tính
                            NgaySinh = reader.GetDateTime(3), // Ngày sinh

                            DiaChi = reader.IsDBNull(4) ? null : reader.GetString(4), // Địa chỉ (cho phép null)
                            SoDienThoai = reader.IsDBNull(5) ? null : reader.GetString(5), // Số điện thoại (cho phép null)
                            Email = reader.IsDBNull(6) ? null : reader.GetString(6), // Email (cho phép null)
                            ChucVu = reader.GetString(7), // Chức vụ
                            CCCD = reader.IsDBNull(8) ? null : reader.GetString(8), // CCCD (cho phép null)
                            NgayBatDauLam = reader.GetDateTime(9), // Ngày bắt đầu làm việc

                            SoNgayDaLam = reader.GetInt32(10), // Số ngày đã đi làm
                            SoNgayNghi = reader.GetInt32(11) // Số ngày nghỉ
                        };

                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }
    }
}
