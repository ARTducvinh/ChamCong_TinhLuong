using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ChamCong_TinhLuong.Class;

namespace ChamCong_TinhLuong.Model
{
    public class StatisticalDAO
    {
        private Connect db = new Connect();

        // Thêm một bản ghi thống kê tháng mới
        public bool InsertOrUpdateStatistical()
        {
            string checkQuery = "SELECT COUNT(*) FROM ThongKe WHERE Thang = MONTH(GETDATE()) AND Nam = YEAR(GETDATE())";

            try
            {
                db.OpenConnection();
                SqlCommand checkCmd = db.CreateCommand(checkQuery);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu đã có thống kê, cập nhật lại dữ liệu
                    string updateQuery = @"
            UPDATE ThongKe
            SET TongSoNhanVien = (SELECT COUNT(DISTINCT nv.MaNhanVien) FROM NhanVien nv),
                TongSoNgayDiLam = (SELECT SUM(lnv.SoNgayDiLam) FROM LuongNhanVien lnv),
                TongLuongTrenThang = (SELECT SUM(lnv.TongLuong) FROM LuongNhanVien lnv),
                TongKhoanKhauTru = (SELECT SUM(lnv.SoTienKhauTru) FROM LuongNhanVien lnv),
                TongKhoanThuong = (SELECT SUM(lnv.SoTienThuong) FROM LuongNhanVien lnv),
                NgayCapNhat = GETDATE()
            WHERE Thang = MONTH(GETDATE()) AND Nam = YEAR(GETDATE())";

                    SqlCommand updateCmd = db.CreateCommand(updateQuery);
                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                else
                {
                    // Nếu chưa có thống kê, thêm mới
                    string insertQuery = @"
            INSERT INTO ThongKe (Thang, Nam, TongSoNhanVien, TongSoNgayDiLam, TongLuongTrenThang, TongKhoanKhauTru, TongKhoanThuong, NgayCapNhat)
            SELECT 
                MONTH(GETDATE()), YEAR(GETDATE()),
                COUNT(DISTINCT nv.MaNhanVien),
                SUM(lnv.SoNgayDiLam),
                SUM(lnv.TongLuong),
                SUM(lnv.SoTienKhauTru),
                SUM(lnv.SoTienThuong),
                GETDATE()
            FROM NhanVien nv
            LEFT JOIN LuongNhanVien lnv ON nv.MaNhanVien = lnv.MaNhanVien";

                    SqlCommand insertCmd = db.CreateCommand(insertQuery);
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thống kê: " + ex.Message);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }


        // Lấy danh sách toàn bộ các thống kê
        public List<statistical> GetAllStatistical()
        {
            List<statistical> list = new List<statistical>();
            string query = "SELECT MaThongKe, Thang, Nam, TongSoNhanVien, TongSoNgayDiLam, TongLuongTrenThang, TongKhoanKhauTru, TongKhoanThuong, NgayCapNhat FROM ThongKe ORDER BY Nam DESC, Thang DESC";

            try
            {
                db.OpenConnection();
                SqlCommand cmd = db.CreateCommand(query);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new statistical
                        {
                            MaThongKe = reader.GetInt32(0),
                            Thang = reader.GetInt32(1),
                            Nam = reader.GetInt32(2),
                            TongSoNhanVien = reader.GetInt32(3),
                            TongSoNgayDiLam = reader.GetInt32(4),
                            TongLuongTrenThang = reader.GetDecimal(5),
                            TongKhoanKhauTru = reader.GetDecimal(6),
                            TongKhoanThuong = reader.GetDecimal(7),
                            NgayCapNhat = reader.GetDateTime(8)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thống kê: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return list;
        }


        // Lấy dữ liệu thống kê theo tháng và năm cụ thể
        public statistical GetStatisticalByMonth(int thang, int nam)
        {
            statistical statistical = null;
            string query = "SELECT MaThongKe, Thang, Nam, TongSoNhanVien, TongSoNgayDiLam, TongLuongTrenThang, TongKhoanKhauTru, TongKhoanThuong, NgayCapNhat FROM ThongKe WHERE Thang = @Thang AND Nam = @Nam";

            try
            {
                db.OpenConnection();
                SqlCommand cmd = db.CreateCommand(query);
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statistical = new statistical
                        {
                            MaThongKe = reader.GetInt32(0),
                            Thang = reader.GetInt32(1),
                            Nam = reader.GetInt32(2),
                            TongSoNhanVien = reader.GetInt32(3),
                            TongSoNgayDiLam = reader.GetInt32(4),
                            TongLuongTrenThang = reader.GetDecimal(5),
                            TongKhoanKhauTru = reader.GetDecimal(6),
                            TongKhoanThuong = reader.GetDecimal(7),
                            NgayCapNhat = reader.GetDateTime(8)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thống kê tháng " + thang + "/" + nam + ": " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return statistical;
        }

    }
}
