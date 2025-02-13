using ChamCong_TinhLuong.Class;
using ChamCong_TinhLuong.Model;
using System;
using System.Windows.Forms;

namespace ChamCong_TinhLuong
{
    public partial class Add_Deduction : Form
    {
        private DeductionDAO deductionDAO = new DeductionDAO();

        public Add_Deduction()
        {
            InitializeComponent();
        }

        private void btn_Add_Deduction_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
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

                // Tạo đối tượng Deduction
                Deduction deduction = new Deduction(0, tenLoaiKhauTru, soTienMacDinh, moTa);

                // Gọi DAO để thêm vào CSDL
                if (deductionDAO.AddDeduction(deduction))
                {
                    MessageBox.Show("Thêm loại khấu trừ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm loại khấu trừ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
