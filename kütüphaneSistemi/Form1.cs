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
            // Giriş kutularındaki bilgileri alalım
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // 1. Admin Kontrolü
            if (kullaniciAdi == "admin" && sifre == "admin123")
            {
                adminPanel adminForm = new adminPanel();
                adminForm.Show();
                this.Hide(); // Giriş formunu gizle
            }
            // 2. Normal Kullanıcı Kontrolü
            else if (kullaniciAdi == "user" && sifre == "user123")
            {
                Form2 userForm = new Form2(); // Form2'yi kullanıcı paneli olarak açıyoruz
                userForm.Show();
                this.Hide();
            }
            // 3. Hatalı Giriş
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }
}