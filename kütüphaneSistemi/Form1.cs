using System;
using System.Drawing;
using System.Windows.Forms;

namespace kütüphaneSistemi
{
    public partial class Form1 : Form
    {
        // Form2 ile aynı olan ana renk tonu
        private Color anaMavi = Color.FromArgb(46, 82, 114);

        public Form1()
        {
            InitializeComponent();
            Form1_Load(this, EventArgs.Empty); // Tasarımı hemen uygula
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form Arka Planı
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Text = "Kütüphane Giriş";

            // Butonu Form2 ile uyumlu hale getir
            btnGiris.BackColor = anaMavi;
            btnGiris.ForeColor = Color.White;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnGiris.Size = new Size(120, 40); // Biraz daha genişletelim

            // Label ve Font ayarları
            label1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim() == "admin" && txtSifre.Text.Trim() == "1234")
            {
                Form2 anaEkran = new Form2();
                anaEkran.FormClosed += (s, args) => Application.Exit();
                anaEkran.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear();
            }
        }
    }
}