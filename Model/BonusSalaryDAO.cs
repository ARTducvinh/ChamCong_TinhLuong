using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model
{
    public class BonusSalaryDAO
    {
        private Connect db = new Connect();

        // Thêm khoản thưởng mới
        public bool AddBonusSalary(BonusSalary bonus)
        {
            string query = "INSERT INTO LoaiThuong (TenThuong, SoTienThuong, MoTa) " +
                           "VALUES (@TenThuong, @SoTienThuong, @MoTa)";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@TenThuong", bonus.TenThuong);
                cmd.Parameters.AddWithValue("@SoTienThuong", bonus.SoTienThuong);
                cmd.Parameters.AddWithValue("@MoTa", (object)bonus.MoTa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật khoản thưởng
        public bool UpdateBonusSalary(BonusSalary bonus)
        {
            string query = "UPDATE LoaiThuong SET TenThuong = @TenThuong, SoTienThuong = @SoTienThuong, MoTa = @MoTa " +
                           "WHERE MaThuong = @MaThuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaThuong", bonus.MaThuong);
                cmd.Parameters.AddWithValue("@TenThuong", bonus.TenThuong);
                cmd.Parameters.AddWithValue("@SoTienThuong", bonus.SoTienThuong);
                cmd.Parameters.AddWithValue("@MoTa", (object)bonus.MoTa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa khoản thưởng theo mã
        public bool DeleteBonusSalary(int maThuong)
        {
            string query = "DELETE FROM LoaiThuong WHERE MaThuong = @MaThuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaThuong", maThuong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy danh sách tất cả các khoản thưởng
        public List<BonusSalary> GetAllBonusSalaries()
        {
            List<BonusSalary> bonuses = new List<BonusSalary>();
            string query = "SELECT * FROM LoaiThuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return bonuses;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bonuses.Add(new BonusSalary
                        {
                            MaThuong = reader.GetInt32(0),
                            TenThuong = reader.GetString(1),
                            SoTienThuong = reader.GetDecimal(2),
                            MoTa = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }
            return bonuses;
        }

        // Tìm khoản thưởng theo mã
        public BonusSalary GetBonusSalaryById(int maThuong)
        {
            string query = "SELECT * FROM LoaiThuong WHERE MaThuong = @MaThuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@MaThuong", maThuong);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BonusSalary
                        {
                            MaThuong = reader.GetInt32(0),
                            TenThuong = reader.GetString(1),
                            SoTienThuong = reader.GetDecimal(2),
                            MoTa = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

        // Lấy khoản thưởng theo tên
        public BonusSalary GetBonusByName(string tenThuong)
        {
            string query = "SELECT MaThuong, TenThuong, SoTienThuong, MoTa FROM LoaiThuong WHERE TenThuong = @TenThuong";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@TenThuong", tenThuong);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BonusSalary
                        {
                            MaThuong = reader.GetInt32(0),
                            TenThuong = reader.GetString(1),
                            SoTienThuong = reader.GetDecimal(2),
                            MoTa = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

    }
}
