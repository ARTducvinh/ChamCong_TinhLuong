using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChamCong_TinhLuong
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTotalEmployees;
        private Label lblTotalDays;
        private Label lblTotalSalary;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            lblTotalEmployees = new Label();
            lblTotalDays = new Label();
            lblTotalSalary = new Label();
            menuStrip1 = new MenuStrip();
            quảnLýNhânViênToolStripMenuItem = new ToolStripMenuItem();
            quảnLýChấmCôngToolStripMenuItem = new ToolStripMenuItem();
            tínhLươngToolStripMenuItem = new ToolStripMenuItem();
            cácKhoảnKhấuTrừToolStripMenuItem = new ToolStripMenuItem();
            báoCáoVàThốngKêToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            lblCurrentDate = new Label();
            lblCurrentMonth = new Label();
            lblCurrentYear = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTotalEmployees
            // 
            lblTotalEmployees.AutoSize = true;
            lblTotalEmployees.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotalEmployees.Location = new Point(435, 79);
            lblTotalEmployees.Name = "lblTotalEmployees";
            lblTotalEmployees.Size = new Size(117, 24);
            lblTotalEmployees.TabIndex = 1;
            lblTotalEmployees.Text = "Nhân viên: ";
            // 
            // lblTotalDays
            // 
            lblTotalDays.AutoSize = true;
            lblTotalDays.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotalDays.Location = new Point(435, 303);
            lblTotalDays.Name = "lblTotalDays";
            lblTotalDays.Size = new Size(362, 24);
            lblTotalDays.TabIndex = 2;
            lblTotalDays.Text = "Số ngày làm việc tiêu chuẩn: 22 ngày";
            // 
            // lblTotalSalary
            // 
            lblTotalSalary.AutoSize = true;
            lblTotalSalary.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotalSalary.ForeColor = Color.Green;
            lblTotalSalary.Location = new Point(435, 186);
            lblTotalSalary.Name = "lblTotalSalary";
            lblTotalSalary.Size = new Size(129, 24);
            lblTotalSalary.TabIndex = 3;
            lblTotalSalary.Text = "Tổng lương:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { quảnLýNhânViênToolStripMenuItem, quảnLýChấmCôngToolStripMenuItem, tínhLươngToolStripMenuItem, cácKhoảnKhấuTrừToolStripMenuItem, báoCáoVàThốngKêToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(871, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            quảnLýNhânViênToolStripMenuItem.Size = new Size(147, 24);
            quảnLýNhânViênToolStripMenuItem.Text = "Quản Lý Nhân Viên";
            quảnLýNhânViênToolStripMenuItem.Click += quảnLýNhânViênToolStripMenuItem_Click;
            // 
            // quảnLýChấmCôngToolStripMenuItem
            // 
            quảnLýChấmCôngToolStripMenuItem.Name = "quảnLýChấmCôngToolStripMenuItem";
            quảnLýChấmCôngToolStripMenuItem.Size = new Size(156, 24);
            quảnLýChấmCôngToolStripMenuItem.Text = "Quản Lý Chấm Công";
            quảnLýChấmCôngToolStripMenuItem.Click += quảnLýChấmCôngToolStripMenuItem_Click;
            // 
            // tínhLươngToolStripMenuItem
            // 
            tínhLươngToolStripMenuItem.Name = "tínhLươngToolStripMenuItem";
            tínhLươngToolStripMenuItem.Size = new Size(199, 24);
            tínhLươngToolStripMenuItem.Text = "Tính toán lương và thưởng";
            tínhLươngToolStripMenuItem.Click += tínhLươngToolStripMenuItem_Click;
            // 
            // cácKhoảnKhấuTrừToolStripMenuItem
            // 
            cácKhoảnKhấuTrừToolStripMenuItem.Name = "cácKhoảnKhấuTrừToolStripMenuItem";
            cácKhoảnKhấuTrừToolStripMenuItem.Size = new Size(149, 24);
            cácKhoảnKhấuTrừToolStripMenuItem.Text = "Các khoản khấu trừ";
            cácKhoảnKhấuTrừToolStripMenuItem.Click += cácKhoảnKhấuTrừToolStripMenuItem_Click;
            // 
            // báoCáoVàThốngKêToolStripMenuItem
            // 
            báoCáoVàThốngKêToolStripMenuItem.Name = "báoCáoVàThốngKêToolStripMenuItem";
            báoCáoVàThốngKêToolStripMenuItem.Size = new Size(158, 24);
            báoCáoVàThốngKêToolStripMenuItem.Text = "Báo cáo và thống kê";
            báoCáoVàThốngKêToolStripMenuItem.Click += báoCáoVàThốngKêToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(24, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(362, 383);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lblCurrentDate
            // 
            lblCurrentDate.AutoSize = true;
            lblCurrentDate.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblCurrentDate.Location = new Point(435, 438);
            lblCurrentDate.Name = "lblCurrentDate";
            lblCurrentDate.Size = new Size(85, 24);
            lblCurrentDate.TabIndex = 9;
            lblCurrentDate.Text = "Ngày: --";
            // 
            // lblCurrentMonth
            // 
            lblCurrentMonth.AutoSize = true;
            lblCurrentMonth.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblCurrentMonth.Location = new Point(556, 438);
            lblCurrentMonth.Name = "lblCurrentMonth";
            lblCurrentMonth.Size = new Size(97, 24);
            lblCurrentMonth.TabIndex = 10;
            lblCurrentMonth.Text = "Tháng: --";
            // 
            // lblCurrentYear
            // 
            lblCurrentYear.AutoSize = true;
            lblCurrentYear.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblCurrentYear.Location = new Point(691, 438);
            lblCurrentYear.Name = "lblCurrentYear";
            lblCurrentYear.Size = new Size(79, 24);
            lblCurrentYear.TabIndex = 11;
            lblCurrentYear.Text = "Năm: --";
            // 
            // Home
            // 
            ClientSize = new Size(871, 518);
            Controls.Add(lblCurrentDate);
            Controls.Add(lblCurrentMonth);
            Controls.Add(lblCurrentYear);
            Controls.Add(pictureBox1);
            Controls.Add(lblTotalEmployees);
            Controls.Add(lblTotalDays);
            Controls.Add(lblTotalSalary);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Chấm Công & Tính Lương";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentDate;
        private Label lblCurrentMonth;
        private Label lblCurrentYear;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private ToolStripMenuItem quảnLýChấmCôngToolStripMenuItem;
        private ToolStripMenuItem tínhLươngToolStripMenuItem;
        private ToolStripMenuItem báoCáoVàThốngKêToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem cácKhoảnKhấuTrừToolStripMenuItem;
    }
}
