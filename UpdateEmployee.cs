using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChamCong_TinhLuong
{
    public partial class UpdateEmployee : Form
    {
        private int employeeID; // ID nhân viên đang sửa
        private BasicSalaryDAO basicSalaryDAO = new BasicSalaryDAO(); // DAO để lấy danh sách chức vụ
        private EmployeeDAO employeeDAO = new EmployeeDAO();

        public UpdateEmployee(int id, string hoTen, string gioiTinh, string ngaySinh,
                      string diaChi, string soDienThoai, string email, string cccd,
                      string chucVu, string ngayBatDauLam)
        {
            InitializeComponent();
            employeeID = id;

            // Tải danh sách chức vụ từ database
            LoadChucVu();

            // Đổ dữ liệu từ bảng vào các trường nhập
            HoTen.Text = hoTen;
            GioiTinh.SelectedItem = gioiTinh; // Chỉnh sửa ComboBox giới tính
            NgaySInh.Value = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy", null);
            DiaChi.Text = diaChi;
            SoDienThoai.Text = soDienThoai;
            Email.Text = email;
            CCCD.Text = chucVu;  // Đúng vị trí gán số CCCD
            ChucVu.SelectedItem = cccd; // Đúng vị trí gán chức vụ
            NgayBatDauLam.Value = DateTime.ParseExact(ngayBatDauLam, "dd/MM/yyyy", null);
        }

        private void LoadChucVu()
        {
            try
            {
                List<string> chucVuList = basicSalaryDAO.GetChucVuList(); // Lấy danh sách chức vụ từ bảng lương cơ bản
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
                Employee updatedEmployee = new Employee(employeeID, hoTen, gioiTinh, ngaySinh, diaChi, soDienThoai, email, cccd, chucVu, ngayBatDauLam);

                // Gọi DAO để cập nhật nhân viên trong database
                bool success = employeeDAO.UpdateEmployee(updatedEmployee);

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
