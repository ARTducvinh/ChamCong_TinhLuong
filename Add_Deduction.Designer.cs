namespace ChamCong_TinhLuong
{
    partial class Add_Deduction
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
            btn_Add_Deduction = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // btn_Add_Deduction
            // 
            btn_Add_Deduction.Location = new Point(340, 390);
            btn_Add_Deduction.Name = "btn_Add_Deduction";
            btn_Add_Deduction.Size = new Size(115, 48);
            btn_Add_Deduction.TabIndex = 0;
            btn_Add_Deduction.Text = "Thêm khoản khấu trừ";
            btn_Add_Deduction.UseVisualStyleBackColor = true;
            btn_Add_Deduction.Click += btn_Add_Deduction_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 51);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên khoản khấu trừ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 111);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 2;
            label2.Text = "Số tiền mặc định:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 175);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 3;
            label3.Text = "Mô tả khoản khấu trừ:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(474, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(246, 172);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(474, 171);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(246, 111);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(474, 27);
            textBox3.TabIndex = 6;
            // 
            // Add_Deduction
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
            Controls.Add(btn_Add_Deduction);
            Name = "Add_Deduction";
            Text = "Thêm khoản khấu trừ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Add_Deduction;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}