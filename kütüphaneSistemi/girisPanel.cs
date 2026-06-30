using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace kütüphaneSistemi
{
    public partial class girisPanel : Form
    {
        // Form2 ile aynı olan ana renk tonu
        private Color anaMavi = Color.FromArgb(46, 82, 114);

        public girisPanel()
        {
            InitializeComponent();
            Form1_Load(this, EventArgs.Empty); // Tasarımı hemen uygula
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form Arka Planı
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Text = "Kütüphane Giriş";

            // Label ve Font ayarları
            label1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciEmail = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // 1. Admin Kontrolü
            if (kullaniciEmail == "admin" && sifre == "admin123")
            {
                adminPanel adminForm = new adminPanel();
                adminForm.Show();
                this.Hide();
                return;
            }

            // 2. Veritabanı Kullanıcı Kontrolü
            using (var con = KutuphaneVeri.Baglan())
            {
                con.Open();
                string sql = "SELECT KullaniciID, AdSoyad FROM Kullanicilar WHERE Email = @email AND Sifre = @sifre AND Durum = 1";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@email", kullaniciEmail);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) // Kullanıcı bulunduysa
                {
                    // BURAYA TAŞIDIK: dr değişkeni artık hazır ve dolu
                    AktifKullanici.ID = Convert.ToInt32(dr["KullaniciID"]);
                    AktifKullanici.Ad = dr["AdSoyad"].ToString();

                    MessageBox.Show("Hoş geldiniz, " + AktifKullanici.Ad);

                    kullaniciPanel userForm = new kullaniciPanel();
                    userForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı giriş veya hesabınız henüz onaylanmamış!");
                }
                dr.Close(); // Veri okuyucuyu kapatmayı unutma
            }
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            // Üye Ol formunu oluştur ve göster
            uyeOlForm uyeOl = new uyeOlForm();
            uyeOl.Show(); // veya ShowDialog(); (Eğer bu form açıkken diğerine tıklanmasını istemiyorsan)
        }
    }
}