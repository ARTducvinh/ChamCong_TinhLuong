namespace ChamCong_TinhLuong
{
    partial class Bonus_Salary
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(43, 12);
            button1.Name = "button1";
            button1.Size = new Size(105, 42);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(330, 12);
            button2.Name = "button2";
            button2.Size = new Size(101, 42);
            button2.TabIndex = 1;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(638, 12);
            button3.Name = "button3";
            button3.Size = new Size(103, 42);
            button3.TabIndex = 2;
            button3.Text = "Xoá";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 83);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 3;
            label1.Text = "Tên khoản thưởng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 130);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 4;
            label2.Text = "Số tiền Thưởng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 172);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 5;
            label3.Text = "Mô tả :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(201, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(540, 27);
            textBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 249);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 189);
            dataGridView1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(201, 130);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(540, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(201, 172);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(540, 52);
            textBox3.TabIndex = 9;
            // 
            // Bonus_Salary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Bonus_Salary";
            Text = "Bonus_Salary";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}