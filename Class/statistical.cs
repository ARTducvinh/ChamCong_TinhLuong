namespace ChamCong_TinhLuong.Class
{
    public class statistical
    {
        public int MaThongKe { get; set; }        // Mã thống kê (Primary Key)
        public int Thang { get; set; }            // Tháng
        public int Nam { get; set; }              // Năm
        public int TongSoNhanVien { get; set; }   // Tổng số nhân viên
        public int TongSoNgayDiLam { get; set; }  // Tổng số ngày đi làm
        public decimal TongLuongTrenThang { get; set; }  // Tổng lương trên tháng
        public decimal TongKhoanKhauTru { get; set; }    // Tổng các khoản khấu trừ
        public decimal TongKhoanThuong { get; set; }     // Tổng các khoản thưởng
        public DateTime NgayCapNhat { get; set; }  // Ngày cập nhật dữ liệu

        // Constructor mặc định
        public statistical() { }

        // Constructor đầy đủ thông tin
        public statistical(int maThongKe, int thang, int nam, int tongSoNhanVien, int tongSoNgayDiLam,decimal tongLuongTrenThang, decimal tongKhoanKhauTru, decimal tongKhoanThuong, DateTime ngayCapNhat)
        {
            MaThongKe = maThongKe;
            Thang = thang;
            Nam = nam;
            TongSoNhanVien = tongSoNhanVien;
            TongSoNgayDiLam = tongSoNgayDiLam;
            TongLuongTrenThang = tongLuongTrenThang;
            TongKhoanKhauTru = tongKhoanKhauTru;
            TongKhoanThuong = tongKhoanThuong;
            NgayCapNhat = ngayCapNhat;
        }
    }
}
