namespace ChamCong_TinhLuong
{
    partial class Update_Deduction
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_Update_Deduction = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(243, 98);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(474, 27);
            textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(243, 159);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(474, 171);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(243, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(474, 27);
            textBox1.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 162);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 10;
            label3.Text = "Mô tả khoản khấu trừ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 98);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 9;
            label2.Text = "Số tiền mặc định:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 38);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 8;
            label1.Text = "Tên khoản khấu trừ:";
            // 
            // btn_Update_Deduction
            // 
            btn_Update_Deduction.Location = new Point(337, 374);
            btn_Update_Deduction.Name = "btn_Update_Deduction";
            btn_Update_Deduction.Size = new Size(132, 51);
            btn_Update_Deduction.TabIndex = 7;
            btn_Update_Deduction.Text = "Sửa thông tin khoản khấu trừ";
            btn_Update_Deduction.UseVisualStyleBackColor = true;
            btn_Update_Deduction.Click += btn_Update_Deduction_Click_1;
            // 
            // Update_Deduction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Update_Deduction);
            Name = "Update_Deduction";
            Text = "Sửa thông tin khoản khấu trừ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_Update_Deduction;
    }
}