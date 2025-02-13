using System;

namespace ChamCong_TinhLuong.Class
{
    public class WorkSchedule
    {
        public DateTime Ngay { get; set; }      // Ngày làm việc
        public string TrangThai { get; set; }   // Trạng thái chấm công

        // Constructor mặc định
        public WorkSchedule() { }

        // Constructor đầy đủ tham số
        public WorkSchedule(DateTime ngay, string trangThai)
        {
            Ngay = ngay;
            TrangThai = trangThai;
        }
    }
}
