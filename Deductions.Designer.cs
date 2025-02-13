namespace ChamCong_TinhLuong
{
    partial class Deductions
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
            dataGridView = new DataGridView();
            Delete_Deduction = new Button();
            Update_Deduction = new Button();
            Add_Deduction = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.Location = new Point(-1, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(50, 32);
            btnBack.TabIndex = 13;
            btnBack.Text = "←";
            btnBack.Click += btnBack_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 414);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên khoản khấu trừ để tìm kiếm";
            textBox1.Size = new Size(710, 27);
            textBox1.TabIndex = 19;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(43, 96);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(710, 297);
            dataGridView.TabIndex = 17;
            // 
            // Delete_Deduction
            // 
            Delete_Deduction.Location = new Point(599, 38);
            Delete_Deduction.Name = "Delete_Deduction";
            Delete_Deduction.Size = new Size(154, 39);
            Delete_Deduction.TabIndex = 16;
            Delete_Deduction.Text = "Xoá khoản khấu trừ";
            Delete_Deduction.UseVisualStyleBackColor = true;
            Delete_Deduction.Click += Delete_Deduction_Click;
            // 
            // Update_Deduction
            // 
            Update_Deduction.Location = new Point(315, 38);
            Update_Deduction.Name = "Update_Deduction";
            Update_Deduction.Size = new Size(189, 39);
            Update_Deduction.TabIndex = 15;
            Update_Deduction.Text = "Sửa khoản khấu trừ";
            Update_Deduction.UseVisualStyleBackColor = true;
            Update_Deduction.Click += Update_Deduction_Click;
            // 
            // Add_Deduction
            // 
            Add_Deduction.Location = new Point(43, 38);
            Add_Deduction.Name = "Add_Deduction";
            Add_Deduction.Size = new Size(181, 39);
            Add_Deduction.TabIndex = 14;
            Add_Deduction.Text = "Thêm khoản khấu trừ";
            Add_Deduction.UseVisualStyleBackColor = true;
            Add_Deduction.Click += Add_Deduction_Click;
            // 
            // Deductions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 457);
            Controls.Add(btnBack);
            Controls.Add(textBox1);
            Controls.Add(dataGridView);
            Controls.Add(Delete_Deduction);
            Controls.Add(Update_Deduction);
            Controls.Add(Add_Deduction);
            Name = "Deductions";
            Text = "Deductions";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private TextBox textBox1;
        private DataGridView dataGridView;
        private Button Delete_Deduction;
        private Button Update_Deduction;
        private Button Add_Deduction;
    }
}