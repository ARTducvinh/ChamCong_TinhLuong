using ChamCong_TinhLuong.Model;
using ChamCong_TinhLuong.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamCong_TinhLuong
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            LoadDashboardData();
            UpdateCurrentDate();
        }

        // Lấy dữ liệu thống kê của tháng hiện tại và hiển thị lên các label
        public void LoadDashboardData()
        {
            StatisticalDAO statisticalDAO = new StatisticalDAO();
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            // Lấy dữ liệu thống kê của tháng hiện tại từ database
            statistical currentStat = statisticalDAO.GetStatisticalByMonth(currentMonth, currentYear);

            if (currentStat != null)
            {
                lblTotalEmployees.Text = $"Tổng số Nhân viên: {currentStat.TongSoNhanVien}";
                lblTotalDays.Text = $"Tổng số ngày đã chấm công: {currentStat.TongSoNgayDiLam}";
                lblTotalSalary.Text = $"Tổng lương của tháng cần chi trả: {currentStat.TongLuongTrenThang:N0} VNĐ";  
            }
            else
            {
                // Nếu không có dữ liệu, hiển thị thông báo mặc định
                lblTotalEmployees.Text = "Tổng số Nhân viên: Không có dữ liệu";
                lblTotalDays.Text = "Tổng số ngày đã chấm công: Không có dữ liệu";
                lblTotalSalary.Text = "Tổng lương của tháng cần chi trả: Không có dữ liệu";
            }
        }

        // Xử lý khi mở form mới
        private void OpenNewForm(Form form)
        {
            this.Hide(); // Đóng Home ngay khi mở form mới
            form.Show();
        }


        private void UpdateCurrentDate()
        {
            DateTime now = DateTime.Now;
            lblCurrentDate.Text = $"Ngày: {now.Day}";
            lblCurrentMonth.Text = $"Tháng: {now.Month}";
            lblCurrentYear.Text = $"Năm: {now.Year}";
        }


        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Employee_information());
        }

        private void quảnLýChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Timekeeping());
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(new payroll());
        }

        private void cácKhoảnKhấuTrừToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Deductions());
        }

        private void báoCáoVàThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Statistical());
        }
    }
}
