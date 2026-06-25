namespace kütüphaneSistemi
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvKitaplar = new DataGridView();
            btnOduncAl = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dgvOduncAlinanlar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOduncAlinanlar).BeginInit();
            SuspendLayout();
            // 
            // dgvKitaplar
            // 
            dgvKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKitaplar.Location = new Point(3, 3);
            dgvKitaplar.Name = "dgvKitaplar";
            dgvKitaplar.RowHeadersWidth = 51;
            dgvKitaplar.Size = new Size(632, 429);
            dgvKitaplar.TabIndex = 0;
            // 
            // btnOduncAl
            // 
            btnOduncAl.Location = new Point(50, 270);
            btnOduncAl.Name = "btnOduncAl";
            btnOduncAl.Size = new Size(100, 30);
            btnOduncAl.TabIndex = 1;
            btnOduncAl.Text = "Ödünç Al";
            btnOduncAl.UseVisualStyleBackColor = true;
            btnOduncAl.Click += btnOduncAl_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(646, 468);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnOduncAl);
            tabPage1.Controls.Add(dgvKitaplar);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(638, 435);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kitaplar";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvOduncAlinanlar);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(638, 435);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ödünç Alınanlar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvOduncAlinanlar
            // 
            dgvOduncAlinanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOduncAlinanlar.Location = new Point(187, 141);
            dgvOduncAlinanlar.Name = "dgvOduncAlinanlar";
            dgvOduncAlinanlar.RowHeadersWidth = 51;
            dgvOduncAlinanlar.Size = new Size(300, 188);
            dgvOduncAlinanlar.TabIndex = 0;
            // 
            // Form2
            // 
            ClientSize = new Size(646, 468);
            Controls.Add(tabControl1);
            Name = "Form2";
            Text = "Kütüphane Sistemi";
            WindowState = FormWindowState.Maximized;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOduncAlinanlar).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnOduncAl; // Sadece bir tane!
        private System.Windows.Forms.DataGridView dgvKitaplar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvOduncAlinanlar;
    }
}