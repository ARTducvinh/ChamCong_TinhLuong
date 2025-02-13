namespace ChamCong_TinhLuong
{
    partial class AddEmployee
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            HoTen = new TextBox();
            DiaChi = new TextBox();
            SoDienThoai = new TextBox();
            Email = new TextBox();
            CCCD = new TextBox();
            GioiTinh = new ComboBox();
            NgaySInh = new DateTimePicker();
            NgayBatDauLam = new DateTimePicker();
            ChucVu = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(331, 393);
            button1.Name = "button1";
            button1.Size = new Size(143, 44);
            button1.TabIndex = 0;
            button1.Text = "Thêm nhân viên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 29);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 17;
            label1.Text = "Họ và Tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 87);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 16;
            label2.Text = "Giới tính:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 149);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 15;
            label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 215);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 14;
            label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 285);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 13;
            label5.Text = "Số điện thoại:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(388, 215);
            label6.Name = "label6";
            label6.Size = new Size(131, 20);
            label6.TabIndex = 12;
            label6.Text = "Ngày bắt đầu làm:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(388, 29);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 11;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(388, 87);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 10;
            label8.Text = "Chức vụ:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(388, 149);
            label9.Name = "label9";
            label9.Size = new Size(92, 20);
            label9.TabIndex = 9;
            label9.Text = "Số căn cước:";
            // 
            // HoTen
            // 
            HoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HoTen.Location = new Point(116, 29);
            HoTen.Name = "HoTen";
            HoTen.Size = new Size(259, 27);
            HoTen.TabIndex = 8;
            // 
            // DiaChi
            // 
            DiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DiaChi.Location = new Point(116, 215);
            DiaChi.Name = "DiaChi";
            DiaChi.Size = new Size(259, 27);
            DiaChi.TabIndex = 7;
            // 
            // SoDienThoai
            // 
            SoDienThoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SoDienThoai.Location = new Point(116, 278);
            SoDienThoai.Name = "SoDienThoai";
            SoDienThoai.Size = new Size(259, 27);
            SoDienThoai.TabIndex = 6;
            // 
            // Email
            // 
            Email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Email.Location = new Point(536, 29);
            Email.Name = "Email";
            Email.Size = new Size(259, 27);
            Email.TabIndex = 5;
            // 
            // CCCD
            // 
            CCCD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CCCD.Location = new Point(536, 149);
            CCCD.Name = "CCCD";
            CCCD.Size = new Size(259, 27);
            CCCD.TabIndex = 3;
            // 
            // GioiTinh
            // 
            GioiTinh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            GioiTinh.Location = new Point(116, 87);
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Size = new Size(259, 28);
            GioiTinh.TabIndex = 2;
            // 
            // NgaySInh
            // 
            NgaySInh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NgaySInh.Location = new Point(113, 149);
            NgaySInh.Name = "NgaySInh";
            NgaySInh.Size = new Size(262, 27);
            NgaySInh.TabIndex = 1;
            // 
            // NgayBatDauLam
            // 
            NgayBatDauLam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NgayBatDauLam.Location = new Point(536, 213);
            NgayBatDauLam.Name = "NgayBatDauLam";
            NgayBatDauLam.Size = new Size(259, 27);
            NgayBatDauLam.TabIndex = 0;
            // 
            // ChucVu
            // 
            ChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ChucVu.Items.AddRange(new object[] { "Giám đốc", "Trưởng phòng", "Nhân viên", "Thực tập sinh" });
            ChucVu.Location = new Point(536, 87);
            ChucVu.Name = "ChucVu";
            ChucVu.Size = new Size(259, 28);
            ChucVu.TabIndex = 18;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 449);
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
            Name = "AddEmployee";
            Text = "AddEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox HoTen;
        private TextBox DiaChi;
        private TextBox SoDienThoai;
        private TextBox Email;
        private TextBox CCCD;
        private ComboBox GioiTinh;
        private DateTimePicker NgaySInh;
        private DateTimePicker NgayBatDauLam;
        private ComboBox ChucVu;
    }
}