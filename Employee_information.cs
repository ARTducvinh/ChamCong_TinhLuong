using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;
using System.Diagnostics;

namespace ChamCong_TinhLuong
{
    public partial class Employee_information : Form
    {
        private EmployeeDAO employeeDAO = new EmployeeDAO(); // DAO để lấy dữ liệu
        private int selectedEmployeeID = -1; // Lưu ID của nhân viên được chọn
        private DataTable employeeTable;

        public Employee_information()
        {
            InitializeComponent();
            LoadEmployeeData(); // Gọi hàm load dữ liệu khi form khởi động
            dataGridView1.CellClick += DataGridView1_CellClick; // Xử lý chọn hàng trong DataGridView
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        // Hàm load dữ liệu nhân viên vào DataGridView
        private void LoadEmployeeData()
        {
            try
            {
                List<Employee> employees = employeeDAO.GetAllEmployees();
                employeeTable = new DataTable();

                employeeTable.Columns.Add("Mã NV");
                employeeTable.Columns.Add("Họ và Tên");
                employeeTable.Columns.Add("Giới Tính");
                employeeTable.Columns.Add("Ngày Sinh");
                employeeTable.Columns.Add("Địa Chỉ");
                employeeTable.Columns.Add("Số Điện Thoại");
                employeeTable.Columns.Add("Email");
                employeeTable.Columns.Add("CCCD");
                employeeTable.Columns.Add("Chức Vụ");
                employeeTable.Columns.Add("Ngày Bắt Đầu");

                foreach (var emp in employees)
                {
                    employeeTable.Rows.Add(emp.MaNhanVien, emp.HoTen, emp.GioiTinh, emp.NgaySinh.ToString("dd/MM/yyyy"),
                                           emp.DiaChi, emp.SoDienThoai, emp.Email, emp.CCCD, emp.ChucVu,
                                           emp.NgayBatDauLam.ToString("dd/MM/yyyy"));
                }

                dataGridView1.DataSource = employeeTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi nhập vào ô tìm kiếm
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim().ToLower();
            if (employeeTable == null) return;

            // Lọc dữ liệu theo Tên hoặc Số Điện Thoại
            var filteredRows = employeeTable.AsEnumerable()
                .Where(row => row["Họ và Tên"].ToString().ToLower().Contains(searchValue) ||
                              row["Số Điện Thoại"].ToString().Contains(searchValue));

            // Cập nhật DataGridView với dữ liệu lọc
            if (filteredRows.Any())
                dataGridView1.DataSource = filteredRows.CopyToDataTable();
            else
                dataGridView1.DataSource = employeeTable.Clone(); // Hiển thị bảng rỗng nếu không tìm thấy kết quả
        }

        // Xử lý sự kiện khi click vào hàng trong DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề
            {
                selectedEmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        // Nút "Thêm nhân viên"
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployeeForm = new AddEmployee();
            addEmployeeForm.ShowDialog(); // Hiển thị form thêm nhân viên
            LoadEmployeeData(); // Reload dữ liệu sau khi thêm
        }

        //Nút "Sửa thông tin"
        // Nút "Sửa thông tin"
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) // Kiểm tra nếu không có dòng nào được chọn
            {
                MessageBox.Show("Không có nhân viên nào được chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dataGridView1.CurrentRow;

            // Lấy dữ liệu từ hàng đã chọn
            string hoTen = row.Cells["Họ và Tên"].Value?.ToString() ?? "";
            string gioiTinh = row.Cells["Giới Tính"].Value?.ToString() ?? "";
            string ngaySinhText = row.Cells["Ngày Sinh"].Value?.ToString() ?? "";
            string diaChi = row.Cells["Địa Chỉ"].Value?.ToString() ?? "";
            string soDienThoai = row.Cells["Số Điện Thoại"].Value?.ToString() ?? "";
            string email = row.Cells["Email"].Value?.ToString() ?? "";
            string cccd = row.Cells["CCCD"].Value?.ToString() ?? "";
            string chucVu = row.Cells["Chức Vụ"].Value?.ToString() ?? "";
            string ngayBatDauLamText = row.Cells["Ngày Bắt Đầu"].Value?.ToString() ?? "";

            // Kiểm tra nếu dữ liệu trống
            if (string.IsNullOrWhiteSpace(ngaySinhText) || string.IsNullOrWhiteSpace(ngayBatDauLamText))
            {
                MessageBox.Show("Ngày sinh hoặc ngày bắt đầu làm bị trống. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chuyển đổi định dạng ngày với nhiều kiểu khác nhau
            DateTime parsedNgaySinh, parsedNgayBatDauLam;
            string[] formats = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "d/M/yyyy", "M/d/yyyy" };

            if (!DateTime.TryParseExact(ngaySinhText, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedNgaySinh))
            {
                MessageBox.Show($"Ngày sinh '{ngaySinhText}' không hợp lệ! Vui lòng nhập đúng định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParseExact(ngayBatDauLamText, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedNgayBatDauLam))
            {
                MessageBox.Show($"Ngày bắt đầu làm '{ngayBatDauLamText}' không hợp lệ! Vui lòng nhập đúng định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form sửa với dữ liệu đã chọn
            UpdateEmployee editForm = new UpdateEmployee(selectedEmployeeID, hoTen, gioiTinh, parsedNgaySinh.ToString("dd/MM/yyyy"),
                                                         diaChi, soDienThoai, email, cccd, chucVu, parsedNgayBatDauLam.ToString("dd/MM/yyyy"));
            editForm.ShowDialog();
            LoadEmployeeData(); // Cập nhật lại danh sách nhân viên sau khi sửa
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (selectedEmployeeID == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool success = employeeDAO.DeleteEmployee(selectedEmployeeID);
                if (success)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData(); // Cập nhật lại danh sách nhân viên
                    selectedEmployeeID = -1;
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
