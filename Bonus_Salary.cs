using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Bonus_Salary : Form
    {
        private BonusSalaryDAO bonusSalaryDAO = new BonusSalaryDAO();
        private int selectedMaThuong = -1; // Lưu mã thưởng đang chọn

        public Bonus_Salary()
        {
            InitializeComponent();
            LoadData(); // Gọi hàm LoadData khi khởi động form
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; // Gán sự kiện khi chọn dòng
        }

        // 📌 Hàm tải dữ liệu vào DataGridView
        private void LoadData()
        {
            List<BonusSalary> bonuses = bonusSalaryDAO.GetAllBonusSalaries();
            dataGridView1.DataSource = bonuses;

            // Định dạng DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Ẩn cột ID (nếu không cần hiển thị)
            if (dataGridView1.Columns["MaThuong"] != null)
            {
                dataGridView1.Columns["MaThuong"].Visible = false;
            }

            // Cập nhật tiêu đề các cột
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["TenThuong"].HeaderText = "Tên thưởng";
                dataGridView1.Columns["SoTienThuong"].HeaderText = "Số tiền thưởng";
                dataGridView1.Columns["MoTa"].HeaderText = "Mô tả";
            }
        }

        // 📌 Sự kiện chọn dòng trong DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                selectedMaThuong = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaThuong"].Value);
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["TenThuong"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["SoTienThuong"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["MoTa"].Value.ToString();
            }
        }

        // 📌 Xử lý sự kiện thêm khoản thưởng
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string tenThuong = textBox1.Text.Trim();
                string soTienThuongStr = textBox2.Text.Trim();
                string moTa = textBox3.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenThuong) || string.IsNullOrEmpty(soTienThuongStr))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi số tiền thưởng
                if (!decimal.TryParse(soTienThuongStr, out decimal soTienThuong) || soTienThuong < 0)
                {
                    MessageBox.Show("Số tiền thưởng phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng BonusSalary
                BonusSalary bonus = new BonusSalary(0, tenThuong, soTienThuong, moTa);

                // Gọi DAO để thêm vào CSDL
                if (bonusSalaryDAO.AddBonusSalary(bonus))
                {
                    MessageBox.Show("Thêm khoản thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload dữ liệu sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm khoản thưởng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 📌 Xử lý sự kiện sửa khoản thưởng
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedMaThuong == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy dữ liệu từ form
                string tenThuong = textBox1.Text.Trim();
                string soTienThuongStr = textBox2.Text.Trim();
                string moTa = textBox3.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenThuong) || string.IsNullOrEmpty(soTienThuongStr))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi số tiền thưởng
                if (!decimal.TryParse(soTienThuongStr, out decimal soTienThuong) || soTienThuong < 0)
                {
                    MessageBox.Show("Số tiền thưởng phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật đối tượng BonusSalary
                BonusSalary bonus = new BonusSalary(selectedMaThuong, tenThuong, soTienThuong, moTa);

                // Gọi DAO để cập nhật
                if (bonusSalaryDAO.UpdateBonusSalary(bonus))
                {
                    MessageBox.Show("Cập nhật khoản thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload dữ liệu sau khi sửa
                }
                else
                {
                    MessageBox.Show("Cập nhật khoản thưởng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 📌 Xử lý sự kiện xóa khoản thưởng
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedMaThuong == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoản thưởng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bonusSalaryDAO.DeleteBonusSalary(selectedMaThuong))
                    {
                        MessageBox.Show("Xóa khoản thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Reload dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa khoản thưởng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
