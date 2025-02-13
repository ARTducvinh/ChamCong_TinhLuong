using System;

namespace ChamCong_TinhLuong.Class
{
    public class Salary
    {
        public int MaLuong { get; set; }         // Mã lương (PK)
        public int MaNhanVien { get; set; }      // Mã nhân viên (FK)
        public string HoTen { get; set; }        // Tên nhân viên
        public string ChucVu { get; set; }       // Chức vụ của nhân viên
        public int SoNgayDiLam { get; set; }     // Số ngày đi làm

        public decimal LuongCoBan { get; set; }  // Lương cơ bản
        public decimal SoTienThuong { get; set; } // Tổng tiền thưởng
        public decimal SoTienKhauTru { get; set; } // Tổng tiền khấu trừ
        public decimal TongLuong { get; set; }    // Tổng lương nhận được

        public int Thang { get; set; }           // Tháng tính lương
        public int Nam { get; set; }             // Năm tính lương

        // Constructor không tham số
        public Salary() { }

        // Constructor có tham số
        public Salary(int maLuong, int maNhanVien, string hoTen, string chucVu, int soNgayDiLam,
                      decimal luongCoBan, decimal soTienThuong, decimal soTienKhauTru, decimal tongLuong,
                      int thang, int nam)
        {
            MaLuong = maLuong;
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            ChucVu = chucVu;
            SoNgayDiLam = soNgayDiLam;
            LuongCoBan = luongCoBan;
            SoTienThuong = soTienThuong;
            SoTienKhauTru = soTienKhauTru;
            TongLuong = tongLuong;
            Thang = thang;
            Nam = nam;
        }
    }
}
