using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Timekeeping : Form
    {
        private TimekeepingDAO timekeepingDAO = new TimekeepingDAO();
        private int selectedMaNhanVien = -1; // Giá trị mặc định nếu chưa chọn nhân viên nào


        public Timekeeping()
        {
            InitializeComponent();
            LoadDataGridView();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void LoadDataGridView()
        {
            List<timeKP> timekeepingList = timekeepingDAO.GetAllTimekeeping();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = timekeepingList;

            // Định danh các cột cho dataGridView
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Họ và Tên";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns["SoNgayDaLam"].HeaderText = "Số Ngày Đi Làm";
            dataGridView1.Columns["SoNgayNghi"].HeaderText = "Số Ngày Nghỉ";
            dataGridView1.Columns["TrangThai"].HeaderText = "Trạng Thái Hôm Nay";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedMaNhanVien = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNhanVien"].Value);
                Debug.WriteLine(selectedMaNhanVien);
            }
        }


        private void CheckIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedMaNhanVien = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNhanVien"].Value);

                bool result = timekeepingDAO.CheckIn(selectedMaNhanVien);

                if (result)
                {
                    MessageBox.Show("Chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView(); // Cập nhật lại bảng sau khi chấm công
                }
                else
                {
                    MessageBox.Show("Chấm công thất bại hoặc nhân viên đã được chấm công hôm nay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chấm công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedMaNhanVien == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xem lịch làm việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Work_schedule workScheduleForm = new Work_schedule(selectedMaNhanVien);
            workScheduleForm.Show();
            this.Close(); // Đóng form hiện tại
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show(); // Mở lại Home
            this.Close(); // Đóng form hiện tại
        }
    }
}
