using kütüphaneSistemi;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace kütüphaneSistemi
{
    public partial class adminPanel : Form
    {

        public adminPanel()
        {
            InitializeComponent();

            txtArama.Enter += txtArama_Enter;
            txtArama.Leave += txtArama_Leave;

            // Başlangıç durumu
            txtArama.Text = "İsim giriniz...";
            txtArama.ForeColor = Color.Gray;
        }
        private void adminPanel_Load(object sender, EventArgs e)
        {
            TemayiUygula();

            KitaplariGetir();
            KullanicilariGetir();
        }

        private void TemayiUygula()

        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            foreach (DataGridView dgv in new[] { dgvAdminKitaplar, dgvKullanicilar })
            {
                dgv.BorderStyle = BorderStyle.None;

                dgv.BackgroundColor = Color.White;

                dgv.GridColor = Color.Gainsboro;

                dgv.EnableHeadersVisualStyles = false;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);

                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgv.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

                dgv.ColumnHeadersHeight = 40;

                dgv.RowTemplate.Height = 34;

                dgv.DefaultCellStyle.Font =
                    new Font("Segoe UI", 10);

                dgv.DefaultCellStyle.SelectionBackColor =
                    Color.FromArgb(176, 224, 230);

                dgv.DefaultCellStyle.SelectionForeColor =
                    Color.Black;

                dgv.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(248, 250, 252);

                dgv.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgv.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgv.MultiSelect = false;

                dgv.RowHeadersVisible = false;
            }

            BoyaliKontrolleriBul(this);
        }

        // Panellerin içine giren "akıllı" arama metodu
        private void BoyaliKontrolleriBul(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(100, 149, 237);

                    btn.ForeColor = Color.White;

                    btn.FlatStyle = FlatStyle.Flat;

                    btn.FlatAppearance.BorderSize = 0;

                    btn.Cursor = Cursors.Hand;

                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    btn.Height = 38;

                    btn.Width = 150;

                    btn.MouseEnter += (s, e) =>
                    {
                        btn.BackColor =
                            Color.FromArgb(65, 105, 225);
                    };

                    btn.MouseLeave += (s, e) =>
                    {
                        btn.BackColor =
                            Color.FromArgb(100, 149, 237);
                    };
                }

                if (ctrl is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 10);

                    txt.BorderStyle = BorderStyle.FixedSingle;

                    txt.BackColor = Color.White;
                }

                if (ctrl.HasChildren)
                    BoyaliKontrolleriBul(ctrl);
            }
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtISBN.Clear();
            txtYil.Clear();
            txtSayfa.Clear();
            txtTur.Clear();
            txtStok.Clear();
            txtKitapAdi.Focus(); // İmleci en başa getir
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Kontrollerini yap (Zaten yazmıştın, onlar kalsın)
            int stok, sayfa, yil;
            if (!int.TryParse(txtStok.Text, out stok) || !int.TryParse(txtSayfa.Text, out sayfa) || !int.TryParse(txtYil.Text, out yil))
            {
                MessageBox.Show("Sayısal alanları kontrol ediniz!");
                return;
            }

            // 2. Veritabanına Kaydet
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    // ID kısmını 'AUTO_INCREMENT' olduğu için yazmıyoruz, MySQL onu otomatik hallediyor
                    string sorgu = "INSERT INTO Kitaplar (Ad, Yazar, ISBN, YayinYili, Sayfa, Tur, Stok) VALUES (@ad, @yazar, @isbn, @yil, @sayfa, @tur, @stok)";

                    MySqlCommand cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", txtKitapAdi.Text);
                    cmd.Parameters.AddWithValue("@yazar", txtYazar.Text);
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
                    cmd.Parameters.AddWithValue("@yil", yil);
                    cmd.Parameters.AddWithValue("@sayfa", sayfa);
                    cmd.Parameters.AddWithValue("@tur", txtTur.Text);
                    cmd.Parameters.AddWithValue("@stok", stok);

                    cmd.ExecuteNonQuery(); // Veritabanına gönder

                    MessageBox.Show("Kitap veritabanına başarıyla eklendi!");

                    // 3. Tabloyu Tazelemeyi unutma!
                    KitaplariGetir();

                    // 4. Kutuları temizle
                    txtKitapAdi.Clear();
                    txtYazar.Clear();
                    // ... (diğer temizleme işlemlerin)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            // 1. Seçili satır var mı kontrol et
            if (dgvAdminKitaplar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kitap seçin.");
                return;
            }

            // 2. Kullanıcıdan onay al
            DialogResult onay = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?",
                                                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // 3. Seçili satırdaki KitapID'yi al
                    int seciliID = Convert.ToInt32(dgvAdminKitaplar.SelectedRows[0].Cells["KitapID"].Value);

                    using (var con = KutuphaneVeri.Baglan())
                    {
                        con.Open();
                        // 4. Veritabanından silme sorgusu (DELETE)
                        string sorgu = "DELETE FROM Kitaplar WHERE KitapID = @id";

                        MySqlCommand cmd = new MySqlCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@id", seciliID);

                        cmd.ExecuteNonQuery(); // Komutu çalıştır

                        MessageBox.Show("Kitap veritabanından silindi.");

                        // 5. Tabloyu tazele
                        KitaplariGetir();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);
                }
            }
        }
        private void dgvAdminKitaplar_SelectionChanged(object sender, EventArgs e)
        {
            // Eğer seçili bir satır varsa
            if (dgvAdminKitaplar.SelectedRows.Count > 0)
            {
                // Seçili olan satırı al
                DataGridViewRow row = dgvAdminKitaplar.SelectedRows[0];

                // Kutucuklara verileri aktar (Tasarımındaki textbox isimleri farklıysa düzelt!)
                txtKitapAdi.Text = row.Cells["Ad"].Value?.ToString() ?? "";
                txtYazar.Text = row.Cells["Yazar"].Value?.ToString() ?? "";
                txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";
                txtYil.Text = row.Cells["YayinYili"].Value?.ToString() ?? "";
                txtSayfa.Text = row.Cells["Sayfa"].Value?.ToString() ?? "";
                txtTur.Text = row.Cells["Tur"].Value?.ToString() ?? "";
                txtStok.Text = row.Cells["Stok"].Value?.ToString() ?? "";
            }
        }

        private void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            // 1. Seçili satır var mı kontrol et
            if (dgvAdminKitaplar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir kitap seçin.");
                return;
            }

            // 2. Seçili satırdaki KitapID değerini al
            // Not: DataGridView'da KitapID sütununun görünür olduğundan emin ol
            int seciliID = Convert.ToInt32(dgvAdminKitaplar.SelectedRows[0].Cells["KitapID"].Value);

            // 3. Veritabanında güncelleme yap
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    string sorgu = "UPDATE Kitaplar SET Ad=@ad, Yazar=@yazar, ISBN=@isbn, YayinYili=@yil, Sayfa=@sayfa, Tur=@tur, Stok=@stok WHERE KitapID=@id";

                    MySqlCommand cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", txtKitapAdi.Text);
                    cmd.Parameters.AddWithValue("@yazar", txtYazar.Text);
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
                    cmd.Parameters.AddWithValue("@yil", int.Parse(txtYil.Text));
                    cmd.Parameters.AddWithValue("@sayfa", int.Parse(txtSayfa.Text));
                    cmd.Parameters.AddWithValue("@tur", txtTur.Text);
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@id", seciliID);

                    cmd.ExecuteNonQuery(); // Veritabanında güncelle

                    MessageBox.Show("Kitap başarıyla güncellendi!");

                    // 4. Tabloyu tazeleyerek değişiklikleri yansıt
                    KitaplariGetir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
            }
        }
        private void btnKaydett_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen boş alan bırakmayın!");
                return;
            }

            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    // Parametreli sorgu kullanarak SQL Injection saldırılarını engelliyoruz (Güvenli yöntem)
                    string sorgu = "INSERT INTO Kullanicilar (AdSoyad, Email) VALUES (@ad, @email)";
                    MySqlCommand cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.ExecuteNonQuery(); // Komutu çalıştır

                    MessageBox.Show("Kullanıcı veritabanına kaydedildi!");

                    // Tabloyu tazele ki yeni kayıt hemen görünsün
                    KullanicilariGetir();

                    txtKullaniciAdi.Clear();
                    txtEmail.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Clear();
            txtEmail.Clear();

            // İmleci tekrar en başa odakla (Kullanıcı hemen yazmaya başlayabilsin)
            txtKullaniciAdi.Focus();
        }
        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin!");
                return;
            }

            DialogResult onay = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // DataGridView'daki ID sütununu al (Sütun ismin 'KullaniciID' olmalı)
                    int seciliID = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);

                    using (var con = KutuphaneVeri.Baglan())
                    {
                        con.Open();
                        string sorgu = "DELETE FROM Kullanicilar WHERE KullaniciID = @id";
                        MySqlCommand cmd = new MySqlCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@id", seciliID);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kullanıcı silindi.");
                        KullanicilariGetir(); // Tabloyu yenile
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKullanicilar.SelectedRows[0];
                // Sütun isimlerinin veritabanındakiyle aynı olduğundan emin ol (Örn: "AdSoyad", "Email")
                txtKullaniciAdi.Text = row.Cells["AdSoyad"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
            }
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            int seciliID = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);

            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    string sorgu = "UPDATE Kullanicilar SET AdSoyad=@ad, Email=@email WHERE KullaniciID=@id";
                    MySqlCommand cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@id", seciliID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı güncellendi!");
                    KullanicilariGetir(); // Tabloyu yenile
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void KitaplariGetir()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan()) // Yeni oluşturduğumuz sınıfı kullan
                {
                    con.Open();
                    string sorgu = "SELECT * FROM Kitaplar";
                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAdminKitaplar.DataSource = dt; // Tabloyu güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void KullanicilariGetir()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    string sorgu = "SELECT * FROM Kullanicilar";
                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Verileri tabloya aktar
                    dgvKullanicilar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar getirilirken hata oluştu: " + ex.Message);
            }
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (dgvKullanicilar.DataSource is DataTable dt)
            {
                string filtre = txtArama.Text.Replace("'", "''"); // Tırnak işaretini güvenli hale getir

                if (string.IsNullOrWhiteSpace(filtre))
                {
                    dt.DefaultView.RowFilter = ""; // Arama boşsa tüm verileri göster
                }
                else
                {
                    // İstersen sadece AdSoyad değil, KullaniciAdi gibi başka alanlarda da aratabilirsin:
                    dt.DefaultView.RowFilter = string.Format("AdSoyad LIKE '%{0}%'", filtre);
                }
            }
        }

        private void txtArama_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıya onay soralım
            DialogResult secim = MessageBox.Show("Giriş ekranına dönmek istediğinize emin misiniz?",
                                                 "Çıkış Onayı",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (secim == DialogResult.Yes)
            {
                // 1. Giriş formunu (Form1) oluştur
                Form1 girisEkrani = new Form1();

                // 2. Giriş formunu göster
                girisEkrani.Show();

                // 3. Mevcut Admin Panelini kapat
                this.Close();
            }
        }

        private void txtArama_Enter(object sender, EventArgs e)
        {
            if (txtArama.Text == "İsim giriniz...")
            {
                txtArama.Text = "";
                txtArama.ForeColor = Color.Black; // Yazı rengini normale çevir
            }
        }

        private void txtArama_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArama.Text))
            {
                txtArama.Text = "İsim giriniz...";
                txtArama.ForeColor = Color.Gray; // Yazıyı gri yap
            }
        }
    }
}

