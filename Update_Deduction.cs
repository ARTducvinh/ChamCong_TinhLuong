using System;
using System.Windows.Forms;
using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;

namespace ChamCong_TinhLuong
{
    public partial class Update_Deduction : Form
    {
        private Deduction currentDeduction; // Biến lưu trữ khoản khấu trừ đang chỉnh sửa
        private DeductionDAO deductionDAO = new DeductionDAO();

        // Constructor nhận đối tượng Deduction từ form Deductions
        public Update_Deduction(Deduction deduction)
        {
            InitializeComponent();
            currentDeduction = deduction;
            LoadDeductionData(); // Hiển thị dữ liệu lên form
        }

        // Hiển thị dữ liệu khoản khấu trừ lên form
        private void LoadDeductionData()
        {
            textBox1.Text = currentDeduction.TenLoaiKhauTru;
            textBox3.Text = currentDeduction.SoTienMacDinh.ToString();
            textBox2.Text = currentDeduction.MoTa;
        }

        // Xử lý sự kiện nhấn nút "Sửa thông tin khoản khấu trừ"

        private void btn_Update_Deduction_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu mới từ form
                string tenLoaiKhauTru = textBox1.Text.Trim();
                string soTienMacDinhStr = textBox3.Text.Trim();
                string moTa = textBox2.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenLoaiKhauTru) || string.IsNullOrEmpty(soTienMacDinhStr))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi số tiền khấu trừ
                if (!decimal.TryParse(soTienMacDinhStr, out decimal soTienMacDinh) || soTienMacDinh < 0)
                {
                    MessageBox.Show("Số tiền khấu trừ phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật dữ liệu trong đối tượng
                currentDeduction.TenLoaiKhauTru = tenLoaiKhauTru;
                currentDeduction.SoTienMacDinh = soTienMacDinh;
                currentDeduction.MoTa = moTa;

                // Gọi DAO để cập nhật vào CSDL
                if (deductionDAO.UpdateDeduction(currentDeduction))
                {
                    MessageBox.Show("Cập nhật khoản khấu trừ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật khoản khấu trừ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
