using System.Drawing;
using System.Windows.Forms;
namespace kütüphaneSistemi
{
    partial class kullaniciPanel
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
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
            dgvKitaplar.Location = new Point(0, 0);
            dgvKitaplar.Name = "dgvKitaplar";
            dgvKitaplar.RowHeadersWidth = 51;
            dgvKitaplar.Size = new Size(1052, 900);
            dgvKitaplar.TabIndex = 0;
            // 
            // btnOduncAl
            // 
            btnOduncAl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOduncAl.Location = new Point(3, 490);
            btnOduncAl.Name = "btnOduncAl";
            btnOduncAl.Size = new Size(100, 30);
            btnOduncAl.TabIndex = 1;
            btnOduncAl.Text = "Ödünç Al";
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
            tabControl1.Size = new Size(737, 561);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(btnOduncAl);
            tabPage1.Controls.Add(dgvKitaplar);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(729, 528);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kitaplar";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(292, 488);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(165, 490);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 3;
            label1.Text = "🔍Kitap Ara:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(569, 446);
            button1.Name = "button1";
            button1.Size = new Size(105, 37);
            button1.TabIndex = 2;
            button1.Text = "Çıkış Yap";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvOduncAlinanlar);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(729, 528);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ödünç Alınanlar";
            // 
            // dgvOduncAlinanlar
            // 
            dgvOduncAlinanlar.BackgroundColor = SystemColors.ActiveBorder;
            dgvOduncAlinanlar.ColumnHeadersHeight = 29;
            dgvOduncAlinanlar.Dock = DockStyle.Left;
            dgvOduncAlinanlar.Location = new Point(0, 0);
            dgvOduncAlinanlar.Name = "dgvOduncAlinanlar";
            dgvOduncAlinanlar.RowHeadersWidth = 51;
            dgvOduncAlinanlar.Size = new Size(677, 900);
            dgvOduncAlinanlar.TabIndex = 0;
            // 
            // kullaniciPanel
            // 
            BackColor = Color.White;
            ClientSize = new Size(737, 561);
            Controls.Add(tabControl1);
            Name = "kullaniciPanel";
            Text = "Kütüphane Sistemi";
            WindowState = FormWindowState.Maximized;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKitaplar).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
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
        private Button button1;
        private TextBox textBox1;
        private Label label1;
    }
}