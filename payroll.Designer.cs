namespace ChamCong_TinhLuong
{
    partial class payroll
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
            btnBack = new Button();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.Location = new Point(2, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(47, 30);
            btnBack.TabIndex = 13;
            btnBack.Text = "←";
            btnBack.Click += btnBack_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 569);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên để tìm kiếm nhân viên";
            textBox1.Size = new Size(710, 27);
            textBox1.TabIndex = 19;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1042, 469);
            dataGridView1.TabIndex = 17;
            // 
            // button3
            // 
            button3.Location = new Point(842, 36);
            button3.Name = "button3";
            button3.Size = new Size(215, 39);
            button3.TabIndex = 16;
            button3.Text = "Danh sách các khoản thưởng";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(94, 36);
            button1.Name = "button1";
            button1.Size = new Size(168, 39);
            button1.TabIndex = 14;
            button1.Text = "Tính lương tháng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(472, 36);
            button2.Name = "button2";
            button2.Size = new Size(168, 39);
            button2.TabIndex = 20;
            button2.Text = "Bảng lương cơ bản";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // payroll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 608);
            Controls.Add(button2);
            Controls.Add(btnBack);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button1);
            Name = "payroll";
            Text = "Tính toán lương và thưởng";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button1;
        private Button button2;
    }
}