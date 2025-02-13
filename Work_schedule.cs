using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;
using System.Diagnostics;

namespace ChamCong_TinhLuong
{
    public partial class Work_schedule : Form
    {
        private int selectedMaNhanVien;
        private TimekeepingDAO timekeepingDAO = new TimekeepingDAO();

        public Work_schedule(int maNhanVien)
        {
            InitializeComponent();
            selectedMaNhanVien = maNhanVien;
            LoadWorkSchedule();
        }

        private void LoadWorkSchedule()
        {
            List<WorkSchedule> workSchedule = timekeepingDAO.GetWorkSchedule(selectedMaNhanVien);

            // Lấy ngày đầu tháng và số ngày trong tháng
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            int totalDays = DateTime.DaysInMonth(today.Year, today.Month); // Tổng số ngày trong tháng

            // Chuyển đổi dữ liệu sang DataTable để hiển thị trên DataGridView
            DataTable table = new DataTable();
            table.Columns.Add("Ngày", typeof(string)); // Hiển thị ngày đúng định dạng
            table.Columns.Add("Thứ", typeof(string));
            table.Columns.Add("Trạng thái", typeof(string));

            for (int i = 1; i <= totalDays; i++)
            {
                DateTime date = new DateTime(today.Year, today.Month, i); // Ngày trong tháng
                string dayOfWeek = CultureInfo.GetCultureInfo("vi-VN").DateTimeFormat.GetDayName(date.DayOfWeek);

                // Tìm ngày này trong danh sách chấm công từ database
                WorkSchedule existingRecord = workSchedule.FirstOrDefault(ws => ws.Ngay.Date.Equals(date.Date));

                string statusIcon;
                if (existingRecord != null)
                {
                    // Nếu có dữ liệu chấm công, hiển thị theo trạng thái trong database
                    statusIcon = existingRecord.TrangThai;
                }
                else
                {
                    // Nếu là Thứ 7 hoặc Chủ Nhật -> Nghỉ
                    if (dayOfWeek == "Thứ Bảy" || dayOfWeek == "Chủ Nhật")
                    {
                        statusIcon = "❌ Nghỉ";
                    }
                    else
                    {
                        // Nếu ngày trong quá khứ -> Nghỉ, nếu ngày tương lai -> Sẽ làm
                        statusIcon = date < today ? "❌ Nghỉ" : "🟡 Sẽ làm";
                    }
                }

                table.Rows.Add(date.ToString("dd/MM/yyyy"), dayOfWeek, statusIcon);
            }

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = table;

            // Cập nhật tiêu đề cột
            dataGridView1.Columns["Ngày"].HeaderText = "Ngày";
            dataGridView1.Columns["Thứ"].HeaderText = "Thứ";
            dataGridView1.Columns["Trạng thái"].HeaderText = "Trạng thái";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy ngày được chọn từ DataGridView
                DateTime selectedDate = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells["Ngày"].Value.ToString(), "dd/MM/yyyy", null);

                // Gọi hàm CheckIn để chấm công lại
                bool result = timekeepingDAO.CheckIn(selectedMaNhanVien, selectedDate);

                if (result)
                {
                    MessageBox.Show($"Chấm công lại thành công cho ngày {selectedDate:dd/MM/yyyy}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWorkSchedule(); // Cập nhật lại bảng sau khi chấm công
                }
                else
                {
                    MessageBox.Show($"Không thể chấm công lại cho ngày {selectedDate:dd/MM/yyyy}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ngày để chấm công lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy ngày được chọn từ DataGridView
                DateTime selectedDate = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells["Ngày"].Value.ToString(), "dd/MM/yyyy", null);

                // Gọi hàm CheckOut để xóa chấm công
                bool result = timekeepingDAO.CheckOut(selectedMaNhanVien, selectedDate);

                if (result)
                {
                    MessageBox.Show($"Bỏ chấm công thành công cho ngày {selectedDate:dd/MM/yyyy}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWorkSchedule(); // Cập nhật lại bảng sau khi bỏ chấm công
                }
                else
                {
                    MessageBox.Show($"Không thể bỏ chấm công cho ngày {selectedDate:dd/MM/yyyy}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ngày để bỏ chấm công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
