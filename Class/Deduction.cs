using System;

namespace ChamCong_TinhLuong.Class
{
    public class Deduction
    {
        public int MaLoaiKhauTru { get; set; }       // Mã loại khấu trừ (PK)
        public string TenLoaiKhauTru { get; set; }   // Tên loại khấu trừ
        public decimal SoTienMacDinh { get; set; }   // Số tiền mặc định bị khấu trừ
        public string MoTa { get; set; }            // Mô tả về loại khấu trừ

        // Constructor không tham số
        public Deduction() { }

        // Constructor có tham số
        public Deduction(int maLoaiKhauTru, string tenLoaiKhauTru, decimal soTienMacDinh, string moTa)
        {
            MaLoaiKhauTru = maLoaiKhauTru;
            TenLoaiKhauTru = tenLoaiKhauTru;
            SoTienMacDinh = soTienMacDinh;
            MoTa = moTa;
        }
    }
}
