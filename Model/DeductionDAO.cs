using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChamCong_TinhLuong.Model

{
    internal class DeductionDAO
    {
        private Connect db = new Connect();

        // Thêm loại khấu trừ mới
        public bool AddDeduction(Deduction deduction)
        {
            string query = "INSERT INTO LoaiKhauTru (TenLoaiKhauTru, SoTienMacDinh, MoTa) " +
                           "VALUES (@TenLoaiKhauTru, @SoTienMacDinh, @MoTa)";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@TenLoaiKhauTru", deduction.TenLoaiKhauTru);
                cmd.Parameters.AddWithValue("@SoTienMacDinh", deduction.SoTienMacDinh);
                cmd.Parameters.AddWithValue("@MoTa", (object)deduction.MoTa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật thông tin loại khấu trừ
        public bool UpdateDeduction(Deduction deduction)
        {
            string query = "UPDATE LoaiKhauTru SET TenLoaiKhauTru = @TenLoaiKhauTru, " +
                           "SoTienMacDinh = @SoTienMacDinh, MoTa = @MoTa " +
                           "WHERE MaLoaiKhauTru = @MaLoaiKhauTru";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLoaiKhauTru", deduction.MaLoaiKhauTru);
                cmd.Parameters.AddWithValue("@TenLoaiKhauTru", deduction.TenLoaiKhauTru);
                cmd.Parameters.AddWithValue("@SoTienMacDinh", deduction.SoTienMacDinh);
                cmd.Parameters.AddWithValue("@MoTa", (object)deduction.MoTa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa loại khấu trừ theo mã
        public bool DeleteDeduction(int maLoaiKhauTru)
        {
            string query = "DELETE FROM LoaiKhauTru WHERE MaLoaiKhauTru = @MaLoaiKhauTru";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return false;

                cmd.Parameters.AddWithValue("@MaLoaiKhauTru", maLoaiKhauTru);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm loại khấu trừ theo mã
        public Deduction GetDeductionById(int maLoaiKhauTru)
        {
            string query = "SELECT * FROM LoaiKhauTru WHERE MaLoaiKhauTru = @MaLoaiKhauTru";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return null;

                cmd.Parameters.AddWithValue("@MaLoaiKhauTru", maLoaiKhauTru);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Deduction
                        {
                            MaLoaiKhauTru = reader.GetInt32(0),
                            TenLoaiKhauTru = reader.GetString(1),
                            SoTienMacDinh = reader.GetDecimal(2),
                            MoTa = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

        // Lấy danh sách tất cả loại khấu trừ
        public List<Deduction> GetAllDeductions()
        {
            List<Deduction> deductions = new List<Deduction>();
            string query = "SELECT * FROM LoaiKhauTru";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return deductions;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        deductions.Add(new Deduction
                        {
                            MaLoaiKhauTru = reader.GetInt32(0),
                            TenLoaiKhauTru = reader.GetString(1),
                            SoTienMacDinh = reader.GetDecimal(2),
                            MoTa = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }
            return deductions;
        }

        // Lấy tổng tiền khấu trừ của nhân viên theo tháng và năm hiện tại
        public decimal GetTotalDeductionByEmployee()
        {
            string query = "SELECT SUM(SoTienMacDinh) FROM LoaiKhauTru";

            using (SqlCommand cmd = db.CreateCommand(query))
            {
                if (cmd == null) return 0;

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }


    }
}
