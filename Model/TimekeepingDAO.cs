using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChamCong_TinhLuong.Model
{
    public class TimekeepingDAO
    {
        private Connect db = new Connect();

        // Chấm công hằng ngày
        public bool CheckIn(int maNhanVien)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                db.OpenConnection();

                // Kiểm tra xem nhân viên đã chấm công hôm nay chưa
                string checkQuery = "SELECT COUNT(*) FROM ChamCong WHERE MaNhanVien = @MaNhanVien AND Ngay = @Ngay";
                SqlCommand checkCmd = db.CreateCommand(checkQuery);
                checkCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                checkCmd.Parameters.AddWithValue("@Ngay", today);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Nhân viên đã được chấm công hôm nay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Thêm bản ghi chấm công mới
                string insertQuery = "INSERT INTO ChamCong (MaNhanVien, Ngay, TrangThai) VALUES (@MaNhanVien, @Ngay, 'Đã chấm công')";
                SqlCommand insertCmd = db.CreateCommand(insertQuery);
                insertCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                insertCmd.Parameters.AddWithValue("@Ngay", today);
                insertCmd.ExecuteNonQuery();

                // Cập nhật số ngày làm việc
                string updateQuery = "UPDATE NhanVien SET SoNgayDaLam = SoNgayDaLam + 1 WHERE MaNhanVien = @MaNhanVien";
                SqlCommand updateCmd = db.CreateCommand(updateQuery);
                updateCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                updateCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chấm công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public bool CheckOut(int maNhanVien, DateTime ngayChamCong)
        {
            string ngay = ngayChamCong.ToString("yyyy-MM-dd");

            try
            {
                db.OpenConnection();

                // Kiểm tra xem nhân viên có chấm công vào ngày này không
                string checkQuery = "SELECT COUNT(*) FROM ChamCong WHERE MaNhanVien = @MaNhanVien AND Ngay = @Ngay";
                SqlCommand checkCmd = db.CreateCommand(checkQuery);
                checkCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                checkCmd.Parameters.AddWithValue("@Ngay", ngay);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show($"Nhân viên chưa chấm công vào ngày {ngayChamCong:dd/MM/yyyy}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Xóa bản ghi chấm công của ngày cụ thể
                string deleteQuery = "DELETE FROM ChamCong WHERE MaNhanVien = @MaNhanVien AND Ngay = @Ngay";
                SqlCommand deleteCmd = db.CreateCommand(deleteQuery);
                deleteCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                deleteCmd.Parameters.AddWithValue("@Ngay", ngay);
                deleteCmd.ExecuteNonQuery();

                // Cập nhật số ngày làm việc
                string updateQuery = "UPDATE NhanVien SET SoNgayDaLam = SoNgayDaLam - 1 WHERE MaNhanVien = @MaNhanVien";
                SqlCommand updateCmd = db.CreateCommand(updateQuery);
                updateCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                updateCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi bỏ chấm công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Lấy danh sách các ngày đã chấm công của một nhân viên
        public List<DateTime> GetWorkDays(int maNhanVien)
        {
            List<DateTime> workDays = new List<DateTime>();
            string query = "SELECT Ngay FROM ChamCong WHERE MaNhanVien = @MaNhanVien AND TrangThai = 'Đã chấm công'";

            try
            {
                db.OpenConnection();
                SqlCommand cmd = db.CreateCommand(query);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        workDays.Add(reader.GetDateTime(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy ngày làm việc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return workDays;
        }

        // Lấy danh sách chấm công của tất cả nhân viên
        public List<timeKP> GetAllTimekeeping()
        {
            List<timeKP> list = new List<timeKP>();
            string query = @"
                SELECT n.MaNhanVien, n.HoTen, n.SoDienThoai, n.SoNgayDaLam, n.SoNgayNghi, 
                       CASE WHEN c.Ngay IS NULL THEN 'Chưa chấm' ELSE 'Đã chấm công' END AS TrangThai
                FROM NhanVien n
                LEFT JOIN ChamCong c ON n.MaNhanVien = c.MaNhanVien AND c.Ngay = CAST(GETDATE() AS DATE)";

            try
            {
                db.OpenConnection();
                SqlCommand cmd = db.CreateCommand(query);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new timeKP
                        {
                            MaNhanVien = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            SoDienThoai = reader.GetString(2),
                            SoNgayDaLam = reader.GetInt32(3),
                            SoNgayNghi = reader.GetInt32(4),
                            TrangThai = reader.GetString(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy danh sách chấm công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return list;
        }

        public bool CheckIn(int maNhanVien, DateTime ngayChamCong)
        {
            string ngay = ngayChamCong.ToString("yyyy-MM-dd");

            try
            {
                db.OpenConnection();

                // Kiểm tra xem nhân viên đã chấm công vào ngày này chưa
                string checkQuery = "SELECT COUNT(*) FROM ChamCong WHERE MaNhanVien = @MaNhanVien AND Ngay = @Ngay";
                SqlCommand checkCmd = db.CreateCommand(checkQuery);
                checkCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                checkCmd.Parameters.AddWithValue("@Ngay", ngay);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show($"Nhân viên đã được chấm công vào ngày {ngayChamCong:dd/MM/yyyy}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Thêm bản ghi chấm công mới
                string insertQuery = "INSERT INTO ChamCong (MaNhanVien, Ngay, TrangThai) VALUES (@MaNhanVien, @Ngay, 'Đã chấm công')";
                SqlCommand insertCmd = db.CreateCommand(insertQuery);
                insertCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                insertCmd.Parameters.AddWithValue("@Ngay", ngay);
                insertCmd.ExecuteNonQuery();

                // Cập nhật số ngày làm việc
                string updateQuery = "UPDATE NhanVien SET SoNgayDaLam = SoNgayDaLam + 1 WHERE MaNhanVien = @MaNhanVien";
                SqlCommand updateCmd = db.CreateCommand(updateQuery);
                updateCmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                updateCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chấm công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public List<WorkSchedule> GetWorkSchedule(int maNhanVien)
        {
            List<WorkSchedule> workSchedule = new List<WorkSchedule>();
            string query = @"
        SELECT c.Ngay, c.TrangThai
        FROM ChamCong c
        WHERE c.MaNhanVien = @MaNhanVien
        ORDER BY c.Ngay DESC";

            try
            {
                db.OpenConnection();
                SqlCommand cmd = db.CreateCommand(query);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workSchedule.Add(new WorkSchedule
                        {
                            Ngay = reader.GetDateTime(0),
                            TrangThai = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy lịch làm việc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return workSchedule;
        }


    }
}
