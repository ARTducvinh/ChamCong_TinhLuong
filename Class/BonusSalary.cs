using System;

namespace ChamCong_TinhLuong.Class
{
    public class BonusSalary
    {
        public int MaThuong { get; set; }         // Mã thưởng (PK)
        public string TenThuong { get; set; }     // Tên khoản thưởng
        public decimal SoTienThuong { get; set; } // Số tiền thưởng
        public string MoTa { get; set; }         // Mô tả về khoản thưởng

        // Constructor không tham số
        public BonusSalary() { }

        // Constructor có tham số
        public BonusSalary(int maThuong, string tenThuong, decimal soTienThuong, string moTa)
        {
            MaThuong = maThuong;
            TenThuong = tenThuong;
            SoTienThuong = soTienThuong;
            MoTa = moTa;
        }
    }
}
