using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamCong_TinhLuong.Class
{
    public class Employee
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CCCD { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayBatDauLam { get; set; }
        public int SoNgayDaLam { get; set; }     // Số ngày đã đi làm trong tháng
        public int SoNgayNghi { get; set; }      // Số ngày nghỉ trong tháng

        // Constructor không tham số
        public Employee() { }

        // Constructor có tham số
        public Employee(int maNhanVien, string hoTen, string gioiTinh, DateTime ngaySinh,
                        string diaChi, string soDienThoai, string email, string cccd,
                        string chucVu, DateTime ngayBatDauLam)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            CCCD = cccd;
            ChucVu = chucVu;
            NgayBatDauLam = ngayBatDauLam;
        }
        public Employee(int maNhanVien, string hoTen, string gioiTinh, DateTime ngaySinh,
                        string diaChi, string soDienThoai, string email, string cccd,
                        string chucVu, DateTime ngayBatDauLam, int soNgayDaLam, int soNgayNghi)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            CCCD = cccd;
            ChucVu = chucVu;
            NgayBatDauLam = ngayBatDauLam;
            SoNgayDaLam = soNgayDaLam;
            SoNgayNghi = soNgayNghi;
        }
    }

}
