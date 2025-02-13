using System;

namespace ChamCong_TinhLuong.Class
{
    public class BasicSalary
    {
        public int MaLuong { get; set; }         // Mã lương (PK)
        public string ChucVu { get; set; }       // Chức vụ
        public decimal LuongThang { get; set; }  // Lương theo tháng
        public decimal LuongNgay { get; set; }   // Lương theo ngày

        // Constructor không tham số
        public BasicSalary() { }

        // Constructor có tham số
        public BasicSalary(int maLuong, string chucVu, decimal luongThang)
        {
            MaLuong = maLuong;
            ChucVu = chucVu;
            LuongThang = luongThang;
            LuongNgay = luongThang / 22; // Tự động tính lương theo ngày
        }
    }
}
