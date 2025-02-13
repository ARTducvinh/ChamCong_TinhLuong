namespace ChamCong_TinhLuong
{
    partial class UpdateEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChucVu = new ComboBox();
            NgayBatDauLam = new DateTimePicker();
            NgaySInh = new DateTimePicker();
            GioiTinh = new ComboBox();
            CCCD = new TextBox();
            Email = new TextBox();
            SoDienThoai = new TextBox();
            DiaChi = new TextBox();
            HoTen = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // ChucVu
            // 
            ChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ChucVu.Items.AddRange(new object[] { "Giám đốc", "Trưởng phòng", "Nhân viên", "Thực tập sinh" });
            ChucVu.Location = new Point(534, 79);
            ChucVu.Name = "ChucVu";
            ChucVu.Size = new Size(259, 28);
            ChucVu.TabIndex = 37;
            // 
            // NgayBatDauLam
            // 
            NgayBatDauLam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NgayBatDauLam.Location = new Point(534, 205);
            NgayBatDauLam.Name = "NgayBatDauLam";
            NgayBatDauLam.Size = new Size(259, 27);
            NgayBatDauLam.TabIndex = 20;
            // 
            // NgaySInh
            // 
            NgaySInh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NgaySInh.Location = new Point(111, 141);
            NgaySInh.Name = "NgaySInh";
            NgaySInh.Size = new Size(262, 27);
            NgaySInh.TabIndex = 21;
            // 
            // GioiTinh
            // 
            GioiTinh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            GioiTinh.Location = new Point(114, 79);
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Size = new Size(259, 28);
            GioiTinh.TabIndex = 22;
            // 
            // CCCD
            // 
            CCCD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CCCD.Location = new Point(534, 141);
            CCCD.Name = "CCCD";
            CCCD.Size = new Size(259, 27);
            CCCD.TabIndex = 23;
            // 
            // Email
            // 
            Email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Email.Location = new Point(534, 21);
            Email.Name = "Email";
            Email.Size = new Size(259, 27);
            Email.TabIndex = 24;
            // 
            // SoDienThoai
            // 
            SoDienThoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SoDienThoai.Location = new Point(114, 270);
            SoDienThoai.Name = "SoDienThoai";
            SoDienThoai.Size = new Size(259, 27);
            SoDienThoai.TabIndex = 25;
            // 
            // DiaChi
            // 
            DiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DiaChi.Location = new Point(114, 207);
            DiaChi.Name = "DiaChi";
            DiaChi.Size = new Size(259, 27);
            DiaChi.TabIndex = 26;
            // 
            // HoTen
            // 
            HoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HoTen.Location = new Point(114, 21);
            HoTen.Name = "HoTen";
            HoTen.Size = new Size(259, 27);
            HoTen.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(386, 141);
            label9.Name = "label9";
            label9.Size = new Size(92, 20);
            label9.TabIndex = 28;
            label9.Text = "Số căn cước:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(386, 79);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 29;
            label8.Text = "Chức vụ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(386, 21);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 30;
            label7.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(386, 207);
            label6.Name = "label6";
            label6.Size = new Size(131, 20);
            label6.TabIndex = 31;
            label6.Text = "Ngày bắt đầu làm:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 277);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 32;
            label5.Text = "Số điện thoại:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 207);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 33;
            label4.Text = "Địa chỉ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 141);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 34;
            label3.Text = "Ngày sinh:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 79);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 35;
            label2.Text = "Giới tính:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 36;
            label1.Text = "Họ và Tên:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(329, 385);
            button1.Name = "button1";
            button1.Size = new Size(143, 44);
            button1.TabIndex = 19;
            button1.Text = "Sửa thông tin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UpdateEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChucVu);
            Controls.Add(NgayBatDauLam);
            Controls.Add(NgaySInh);
            Controls.Add(GioiTinh);
            Controls.Add(CCCD);
            Controls.Add(Email);
            Controls.Add(SoDienThoai);
            Controls.Add(DiaChi);
            Controls.Add(HoTen);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "UpdateEmployee";
            Text = "UpdateEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ChucVu;
        private DateTimePicker NgayBatDauLam;
        private DateTimePicker NgaySInh;
        private ComboBox GioiTinh;
        private TextBox CCCD;
        private TextBox Email;
        private TextBox SoDienThoai;
        private TextBox DiaChi;
        private TextBox HoTen;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}