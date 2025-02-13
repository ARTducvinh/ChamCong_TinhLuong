using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class payroll : Form
    {
        private SalaryDAO salaryDAO = new SalaryDAO();
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        private BonusSalaryDAO bonusSalaryDAO = new BonusSalaryDAO();
        private DeductionDAO deductionDAO = new DeductionDAO();
        private BasicSalaryDAO basicSalaryDAO = new BasicSalaryDAO();

        public payroll()
        {
            InitializeComponent();
            LoadData(); // Gọi hàm LoadData khi khởi động form
        }

        // 📌 Hàm tải dữ liệu lương vào DataGridView
        private void LoadData()
        {
            List<Salary> salaries = salaryDAO.GetAllSalaries();
            dataGridView1.DataSource = salaries;

            // Định dạng DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }


        // 📌 Xử lý khi nhấn nút "Bảng lương cơ bản"
        private void button2_Click(object sender, EventArgs e)
        {
            Basicsalary form = new Basicsalary();
            form.ShowDialog();
        }

        // 📌 Xử lý khi nhấn nút "Danh sách các khoản thưởng"
        private void button3_Click(object sender, EventArgs e)
        {
            Bonus_Salary form = new Bonus_Salary();
            form.ShowDialog();
        }

        //xử lí tính lương
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác định tháng và năm hiện tại
                int thang = DateTime.Now.Month;
                int nam = DateTime.Now.Year;

                // Lấy danh sách nhân viên
                List<Employee> employees = employeeDAO.GetAllEmployees();
                int countSuccess = 0; // Biến đếm số bản ghi lương được thêm thành công

                Debug.WriteLine($"📌 Tổng số nhân viên: {employees.Count}");

                foreach (var employee in employees)
                {
                    Debug.WriteLine($"🔄 Đang xử lý nhân viên: {employee.MaNhanVien} - {employee.HoTen}, Chức vụ: {employee.ChucVu}");

                    // Bước 1: Lấy số ngày đi làm & số ngày nghỉ
                    int soNgayDiLam = employee.SoNgayDaLam;
                    int soNgayNghi = employee.SoNgayNghi;
                    Debug.WriteLine($"📌 Số ngày đi làm: {soNgayDiLam}, Số ngày nghỉ: {soNgayNghi}");

                    // Bước 2: Lấy mức lương cơ bản theo chức vụ
                    BasicSalary basicSalary = basicSalaryDAO.GetBasicSalaryByPosition(employee.ChucVu);
                    if (basicSalary == null)
                    {
                        Debug.WriteLine($"❌ Không tìm thấy lương cơ bản cho chức vụ: {employee.ChucVu}");
                        continue;
                    }

                    decimal luongNgay = basicSalary.LuongThang / 22;
                    decimal luongCoBan = soNgayDiLam * luongNgay;
                    Debug.WriteLine($"💰 Lương tháng: {basicSalary.LuongThang}, Lương ngày: {luongNgay}, Lương cơ bản: {luongCoBan}");

                    // Bước 3: Lấy thông tin khoản thưởng
                    decimal soTienThuong = 0;

                    BonusSalary thuongChuyenCan = bonusSalaryDAO.GetBonusByName("Thưởng chuyên cần");
                    if (soNgayDiLam >= 22 && thuongChuyenCan != null)
                    {
                        soTienThuong += thuongChuyenCan.SoTienThuong;
                        Debug.WriteLine($"✅ Thưởng chuyên cần: {thuongChuyenCan.SoTienThuong}");
                    }

                    BonusSalary thuongPhuCap = bonusSalaryDAO.GetBonusByName("Phụ cấp mặc định");
                    if (thuongPhuCap != null)
                    {
                        soTienThuong += thuongPhuCap.SoTienThuong;
                        Debug.WriteLine($"✅ Thưởng phụ cấp: {thuongPhuCap.SoTienThuong}");
                    }

                    BonusSalary thuongNgayNghi = bonusSalaryDAO.GetBonusByName("Thưởng ngày nghỉ");
                    if (thuongNgayNghi != null)
                    {
                        soTienThuong += soNgayNghi * thuongNgayNghi.SoTienThuong;
                        Debug.WriteLine($"✅ Thưởng ngày nghỉ ({soNgayNghi} ngày): {soNgayNghi * thuongNgayNghi.SoTienThuong}");
                    }

                    // Bước 4: Lấy tổng tiền khấu trừ của nhân viên
                    decimal soTienKhauTru = deductionDAO.GetTotalDeductionByEmployee();
                    Debug.WriteLine($"💸 Tổng tiền khấu trừ: {soTienKhauTru}");

                    // Bước 5: Tính tổng lương thực nhận
                    decimal tongLuong = luongCoBan + soTienThuong - soTienKhauTru;
                    Debug.WriteLine($"🤑 Tổng lương thực nhận: {tongLuong}");

                    // Bước 6: Tạo đối tượng Salary
                    Salary salary = new Salary(
                        0, employee.MaNhanVien, employee.HoTen, employee.ChucVu,
                        soNgayDiLam, luongCoBan, soTienThuong, soTienKhauTru, tongLuong, thang, nam
                    );

                    // Bước 7: Kiểm tra nếu đã tồn tại lương của nhân viên trong tháng này
                    Salary existingSalary = salaryDAO.GetSalaryByEmployeeAndMonth(employee.MaNhanVien, thang, nam);
                    bool success = false;

                    if (existingSalary != null)
                    {
                        salary.MaLuong = existingSalary.MaLuong;
                        success = salaryDAO.UpdateSalary(salary);
                        Debug.WriteLine($"🔄 Cập nhật lương cho {employee.HoTen}: {tongLuong}");
                    }
                    else
                    {
                        success = salaryDAO.AddSalary(salary);
                        Debug.WriteLine($"✅ Thêm mới lương cho {employee.HoTen}: {tongLuong}");
                    }

                    if (success)
                    {
                        countSuccess++;
                    }
                    else
                    {
                        Debug.WriteLine($"⚠️ Không thể ghi lương cho {employee.HoTen}!");
                    }
                }

                if (countSuccess > 0)
                {
                    MessageBox.Show($"Đã tính lương tháng thành công cho {countSuccess} nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload dữ liệu sau khi tính lương
                }
                else
                {
                    MessageBox.Show("Không có bảng lương nào được ghi lại! Vui lòng kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Lỗi: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
