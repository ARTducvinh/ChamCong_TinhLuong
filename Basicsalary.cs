using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Basicsalary : Form
    {
        private BasicSalaryDAO salaryDAO = new BasicSalaryDAO();
        private int selectedMaLuong = -1; // Lưu mã lương đang chọn

        public Basicsalary()
        {
            InitializeComponent();
            LoadData(); // Gọi hàm LoadData khi khởi động form
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; // Gán sự kiện khi chọn dòng
        }

        // 📌 Hàm tải dữ liệu vào DataGridView
        private void LoadData()
        {
            List<BasicSalary> salaries = salaryDAO.GetAllBasicSalaries();
            dataGridView1.DataSource = salaries;

            // Định dạng DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Ẩn cột ID (nếu không cần hiển thị)
            if (dataGridView1.Columns["MaLuong"] != null)
            {
                dataGridView1.Columns["MaLuong"].Visible = false;
            }

            // Cập nhật tiêu đề các cột
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["ChucVu"].HeaderText = "Chức vụ";
                dataGridView1.Columns["LuongThang"].HeaderText = "Lương cơ bản tháng";
                dataGridView1.Columns["LuongNgay"].HeaderText = "Lương cơ bản ngày";
            }
        }

        // 📌 Sự kiện chọn dòng trong DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                selectedMaLuong = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaLuong"].Value);
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["ChucVu"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["LuongThang"].Value.ToString();
            }
        }

        // 📌 Xử lý sự kiện thêm lương cơ bản
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string chucVu = textBox1.Text.Trim();
                string luongThangStr = textBox2.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(chucVu) || string.IsNullOrEmpty(luongThangStr))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi lương tháng
                if (!decimal.TryParse(luongThangStr, out decimal luongThang) || luongThang < 0)
                {
                    MessageBox.Show("Lương cơ bản phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng BasicSalary
                BasicSalary salary = new BasicSalary(0, chucVu, luongThang);

                // Gọi DAO để thêm vào CSDL
                if (salaryDAO.AddBasicSalary(salary))
                {
                    MessageBox.Show("Thêm lương cơ bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload dữ liệu sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm lương cơ bản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 📌 Xử lý sự kiện sửa lương cơ bản
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedMaLuong == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy dữ liệu từ form
                string chucVu = textBox1.Text.Trim();
                string luongThangStr = textBox2.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(chucVu) || string.IsNullOrEmpty(luongThangStr))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi lương tháng
                if (!decimal.TryParse(luongThangStr, out decimal luongThang) || luongThang < 0)
                {
                    MessageBox.Show("Lương cơ bản phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật đối tượng BasicSalary
                BasicSalary salary = new BasicSalary(selectedMaLuong, chucVu, luongThang);

                // Gọi DAO để cập nhật
                if (salaryDAO.UpdateBasicSalary(salary))
                {
                    MessageBox.Show("Cập nhật lương cơ bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload dữ liệu sau khi sửa
                }
                else
                {
                    MessageBox.Show("Cập nhật lương cơ bản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 📌 Xử lý sự kiện xóa lương cơ bản
        private void button3_Click(object sender, EventArgs e)
        { 
            if (selectedMaLuong == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mức lương này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (salaryDAO.DeleteBasicSalary(selectedMaLuong))
                    {
                        MessageBox.Show("Xóa lương cơ bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Reload dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa lương cơ bản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
