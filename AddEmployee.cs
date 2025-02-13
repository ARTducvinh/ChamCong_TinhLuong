using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class AddEmployee : Form
    {
        private EmployeeDAO employeeDAO = new EmployeeDAO(); // DAO để xử lý CSDL
        private BasicSalaryDAO salaryDAO = new BasicSalaryDAO(); // DAO để lấy chức vụ từ bảng lương cơ bản

        public AddEmployee()
        {
            InitializeComponent();
            LoadChucVu(); // Gọi hàm tải danh sách chức vụ khi khởi động form
        }

        private void LoadChucVu()
        {
            try
            {
                List<string> chucVuList = salaryDAO.GetChucVuList(); // Lấy danh sách chức vụ từ bảng lương cơ bản
                ChucVu.DataSource = chucVuList; // Đổ dữ liệu vào ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chức vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string hoTen = HoTen.Text.Trim();
                string gioiTinh = GioiTinh.Text.Trim();
                DateTime ngaySinh = NgaySInh.Value;
                string diaChi = DiaChi.Text.Trim();
                string soDienThoai = SoDienThoai.Text.Trim();
                string email = Email.Text.Trim();
                string cccd = CCCD.Text.Trim();
                string chucVu = ChucVu.SelectedItem?.ToString() ?? ""; // Lấy chức vụ từ ComboBox
                DateTime ngayBatDauLam = NgayBatDauLam.Value;

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(soDienThoai) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(cccd) || string.IsNullOrWhiteSpace(chucVu))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng Employee
                Employee newEmployee = new Employee(0, hoTen, gioiTinh, ngaySinh, diaChi, soDienThoai, email, cccd, chucVu, ngayBatDauLam);

                // Gọi DAO để thêm nhân viên vào database
                bool success = employeeDAO.AddEmployee(newEmployee);

                if (success)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
