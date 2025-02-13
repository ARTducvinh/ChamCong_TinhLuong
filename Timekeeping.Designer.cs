namespace ChamCong_TinhLuong
{
    partial class Timekeeping
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
            CheckIn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.Location = new Point(-2, -2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(49, 32);
            btnBack.TabIndex = 6;
            btnBack.Text = "←";
            btnBack.Click += btnBack_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(41, 412);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập họ và tên hoặc số điện thoại để tìm kiếm";
            textBox1.Size = new Size(710, 27);
            textBox1.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(41, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(710, 297);
            dataGridView1.TabIndex = 10;
            // 
            // button3
            // 
            button3.Location = new Point(454, 26);
            button3.Name = "button3";
            button3.Size = new Size(214, 52);
            button3.TabIndex = 9;
            button3.Text = "Xem lịch làm việc";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CheckIn
            // 
            CheckIn.Location = new Point(146, 26);
            CheckIn.Name = "CheckIn";
            CheckIn.Size = new Size(192, 52);
            CheckIn.TabIndex = 7;
            CheckIn.Text = "Chấm công hằng ngày";
            CheckIn.UseVisualStyleBackColor = true;
            CheckIn.Click += CheckIn_Click;
            // 
            // Timekeeping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(CheckIn);
            Name = "Timekeeping";
            Text = "Quản lý chấm công và lịch làm việc";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button CheckIn;
    }
}