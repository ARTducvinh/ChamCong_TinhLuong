using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Statistical : Form
    {
        private StatisticalDAO statisticalDAO = new StatisticalDAO(); // DAO để thao tác với dữ liệu

        public Statistical()
        {
            InitializeComponent();
            LoadStatisticalData(); // Tự động tải dữ liệu khi form mở
            this.Resize += new EventHandler(Statistical_Resize);
        }

        private void LoadStatisticalData()
        {
            // 1. Tự động thêm thống kê cho tháng hiện tại nếu chưa có
            statisticalDAO.InsertOrUpdateStatistical();

            // 2. Lấy danh sách thống kê từ CSDL
            List<statistical> statistics = statisticalDAO.GetAllStatistical();

            // 3. Hiển thị dữ liệu trên DataGridView
            dataGridView1.DataSource = statistics;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();

        }

        private void Statistical_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size(this.ClientSize.Width - 50, this.ClientSize.Height - 150);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy mốc thời gian từ textBox1
            string input = textBox1.Text.Trim();

            if (DateTime.TryParse(input, out DateTime selectedDate))
            {
                int thang = selectedDate.Month;
                int nam = selectedDate.Year;

                // Lấy dữ liệu thống kê của tháng/năm cụ thể
                statistical stat = statisticalDAO.GetStatisticalByMonth(thang, nam);

                if (stat != null)
                {
                    List<statistical> singleStatList = new List<statistical> { stat };
                    dataGridView1.DataSource = singleStatList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu cho thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thời gian đúng định dạng (VD: 01-2025)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show(); // Mở lại Home
            this.Close(); // Đóng form hiện tại
        }
    }
}
