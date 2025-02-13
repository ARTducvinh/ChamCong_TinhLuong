using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Deductions : Form
    {
        private DeductionDAO deductionDAO = new DeductionDAO();

        public Deductions()
        {
            InitializeComponent();
            LoadData(); // Gọi hàm LoadData khi khởi động form
        }

        // Hàm tải dữ liệu vào DataGridView
        private void LoadData()
        {
            List<Deduction> deductions = deductionDAO.GetAllDeductions();
            dataGridView.DataSource = deductions;

            // Định dạng DataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;

            // Ẩn cột ID (nếu không cần hiển thị)
            if (dataGridView.Columns["MaLoaiKhauTru"] != null)
            {
                dataGridView.Columns["MaLoaiKhauTru"].Visible = false;
            }

            // Cập nhật tiêu đề các cột
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns["TenLoaiKhauTru"].HeaderText = "Tên loại khấu trừ";
                dataGridView.Columns["SoTienMacDinh"].HeaderText = "Số tiền mặc định";
                dataGridView.Columns["MoTa"].HeaderText = "Mô tả";
            }
        }

        // Xử lý khi nhấn nút thêm khấu trừ
        private void Add_Deduction_Click(object sender, EventArgs e)
        {
            Add_Deduction form = new Add_Deduction();
            form.ShowDialog();
            LoadData(); // Reload dữ liệu sau khi thêm
        }

        // Xử lý khi nhấn nút sửa khấu trừ

        private void Update_Deduction_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                int maLoaiKhauTru = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["MaLoaiKhauTru"].Value);
                string tenLoaiKhauTru = dataGridView.SelectedRows[0].Cells["TenLoaiKhauTru"].Value.ToString();
                decimal soTienMacDinh = Convert.ToDecimal(dataGridView.SelectedRows[0].Cells["SoTienMacDinh"].Value);
                string moTa = dataGridView.SelectedRows[0].Cells["MoTa"].Value?.ToString(); // Kiểm tra null

                // Debug để kiểm tra giá trị lấy ra
                Debug.WriteLine($"Mã: {maLoaiKhauTru}, Tên: {tenLoaiKhauTru}, Số tiền: {soTienMacDinh}, Mô tả: {moTa}");

                // Tạo đối tượng Deduction từ dữ liệu được chọn
                Deduction selectedDeduction = new Deduction(maLoaiKhauTru, tenLoaiKhauTru, soTienMacDinh, moTa);

                // Gọi form sửa với đối tượng đã chọn
                Update_Deduction form = new Update_Deduction(selectedDeduction);
                form.ShowDialog();

                LoadData(); // Reload dữ liệu sau khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoản khấu trừ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Xử lý khi nhấn nút xóa khấu trừ
        private void Delete_Deduction_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int maLoaiKhauTru = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["MaLoaiKhauTru"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoản khấu trừ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (deductionDAO.DeleteDeduction(maLoaiKhauTru))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Reload dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoản khấu trừ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
