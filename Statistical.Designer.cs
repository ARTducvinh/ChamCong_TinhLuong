namespace ChamCong_TinhLuong
{
    partial class Statistical
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.Location = new Point(1, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(50, 32);
            btnBack.TabIndex = 20;
            btnBack.Text = "←";
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1290, 478);
            dataGridView1.TabIndex = 24;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(301, 46);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập mốc thời gian để tìm kiếm (VD: 01-01-2025)";
            textBox1.Size = new Size(767, 27);
            textBox1.TabIndex = 25;
            // 
            // Statistical
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 612);
            Controls.Add(textBox1);
            Controls.Add(btnBack);
            Controls.Add(dataGridView1);
            Name = "Statistical";
            Text = "Statistical";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private DataGridView dataGridView1;
        private TextBox textBox1;
    }
}