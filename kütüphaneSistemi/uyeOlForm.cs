using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kütüphaneSistemi
{
    public partial class uyeOlForm : Form
    {
        public uyeOlForm()
        {
            InitializeComponent();
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            // Hatalı giriş kontrolü
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            using (var con = KutuphaneVeri.Baglan())
            {
                con.Open();

                // Adminin eklediği kullanıcıyı bul
                string kontrolSorgusu = "SELECT KullaniciID FROM Kullanicilar WHERE Email = @email AND Durum = 0";
                MySqlCommand cmdKontrol = new MySqlCommand(kontrolSorgusu, con);
                cmdKontrol.Parameters.AddWithValue("@email", txtEmail.Text);

                if (cmdKontrol.ExecuteScalar() != null)
                {
                    // Şifreyi kaydet ve durumu 1 yap
                    string guncelleSorgusu = "UPDATE Kullanicilar SET Sifre = @sifre, Durum = 1 WHERE Email = @email";
                    MySqlCommand cmdGuncelle = new MySqlCommand(guncelleSorgusu, con);
                    cmdGuncelle.Parameters.AddWithValue("@sifre", txtSifre.Text);
                    cmdGuncelle.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmdGuncelle.ExecuteNonQuery();

                    MessageBox.Show("Üyeliğiniz başarıyla tamamlandı!");
                    this.Close(); // Formu kapat, kullanıcı giriş ekranına dönsün
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı veya şifrenizi zaten belirlemişsiniz.");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            girisPanel girisEkrani = new girisPanel();
            girisEkrani.Show();

            // Üye ol formunu kapat
            this.Close();
        }
    }
}
