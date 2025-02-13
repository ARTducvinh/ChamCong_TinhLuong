namespace ChamCong_TinhLuong
{
    partial class Employee_information
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
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(45, 35);
            button1.Name = "button1";
            button1.Size = new Size(127, 39);
            button1.TabIndex = 6;
            button1.Text = "Thêm nhân viên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(332, 35);
            button2.Name = "button2";
            button2.Size = new Size(127, 39);
            button2.TabIndex = 5;
            button2.Text = "Sửa thông tin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(616, 35);
            button3.Name = "button3";
            button3.Size = new Size(127, 39);
            button3.TabIndex = 4;
            button3.Text = "Xoá nhân viên";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(45, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 287);
            dataGridView1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(45, 408);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập họ tên hoặc số điện thoại để tìm kiếm";
            textBox1.Size = new Size(698, 27);
            textBox1.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.Location = new Point(-1, -1);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(47, 30);
            btnBack.TabIndex = 0;
            btnBack.Text = "←";
            btnBack.Click += btnBack_Click;
            // 
            // Employee_information
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Employee_information";
            Text = "Quản lý thông tin nhân viên";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBack;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private TextBox textBox1;
    }
}