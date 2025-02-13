namespace ChamCong_TinhLuong.Class
{
    public class timeKP
    {
        public int MaNhanVien { get; set; }      // Mã nhân viên
        public string HoTen { get; set; }        // Họ và tên
        public string SoDienThoai { get; set; }  // Số điện thoại
        public int SoNgayDaLam { get; set; }     // Số ngày đã làm
        public int SoNgayNghi { get; set; }      // Số ngày nghỉ
        public string TrangThai { get; set; }    // Trạng thái đi làm hôm nay

        // Constructor mặc định
        public timeKP() { }

        // Constructor khởi tạo
        public timeKP(int maNhanVien, string hoTen, string soDienThoai, int soNgayDaLam, int soNgayNghi, string trangThai)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            SoNgayDaLam = soNgayDaLam;
            SoNgayNghi = soNgayNghi;
            TrangThai = trangThai;
        }
    }
}
