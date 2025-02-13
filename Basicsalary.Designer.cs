namespace ChamCong_TinhLuong
{
    partial class Basicsalary
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 213);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(697, 225);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(51, 12);
            button1.Name = "button1";
            button1.Size = new Size(137, 62);
            button1.TabIndex = 1;
            button1.Text = "Thêm lương và chức vụ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(328, 12);
            button2.Name = "button2";
            button2.Size = new Size(137, 62);
            button2.TabIndex = 2;
            button2.Text = "Sửa thông tin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(611, 12);
            button3.Name = "button3";
            button3.Size = new Size(137, 62);
            button3.TabIndex = 3;
            button3.Text = "Xoá lương và chức vụ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 113);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Chức vụ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 159);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 5;
            label2.Text = "Lương cơ bản của tháng:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(244, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(504, 27);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(244, 156);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(504, 27);
            textBox2.TabIndex = 7;
            // 
            // Basicsalary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Basicsalary";
            Text = "Bảng lương cơ bản";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}