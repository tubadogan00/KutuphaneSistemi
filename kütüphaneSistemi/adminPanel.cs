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

            OnayBekleyenleriGetir();
            OduncListesiniGetir();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            if (dgvAdminKitaplar.SelectedRows.Count == 0) return;

            int seciliID = Convert.ToInt32(dgvAdminKitaplar.SelectedRows[0].Cells["KitapID"].Value);

            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();

                    // 1. KONTROL: Kitap şu an ödünçte mi?
                    string kontrolAktif = "SELECT COUNT(*) FROM OduncKitaplar WHERE KitapID = @id AND TeslimTarihi IS NULL";
                    MySqlCommand cmdAktif = new MySqlCommand(kontrolAktif, con);
                    cmdAktif.Parameters.AddWithValue("@id", seciliID);

                    if (Convert.ToInt32(cmdAktif.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Bu kitap şu an bir üyede görünüyor! Silebilmek için önce teslim almalısınız.",
                                        "İşlem Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. KONTROL: Kitabın geçmiş kayıtları var mı?
                    string kontrolGecmis = "SELECT COUNT(*) FROM OduncKitaplar WHERE KitapID = @id";
                    MySqlCommand cmdGecmis = new MySqlCommand(kontrolGecmis, con);
                    cmdGecmis.Parameters.AddWithValue("@id", seciliID);

                    if (Convert.ToInt32(cmdGecmis.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Bu kitap geçmişte ödünç verildiği için silinemez.",
                                        "Kayıt Bütünlüğü Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 3. EĞER HİÇBİR KAYIT YOKSA SİL
                    DialogResult onay = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?",
                                                        "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (onay == DialogResult.Yes)
                    {
                        string silSorgu = "DELETE FROM Kitaplar WHERE KitapID = @id";
                        MySqlCommand cmdSil = new MySqlCommand(silSorgu, con);
                        cmdSil.Parameters.AddWithValue("@id", seciliID);
                        cmdSil.ExecuteNonQuery();
                        MessageBox.Show("Kitap başarıyla silindi.");
                        KitaplariGetir();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
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
                    // Admin kullanıcı eklerken Durum'u 0 olarak atar
                    string sorgu = "INSERT INTO Kullanicilar (AdSoyad, Email, Durum) VALUES (@ad, @email, 0)";
                    MySqlCommand cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.ExecuteNonQuery(); // Komutu çalıştır

                    MessageBox.Show("Kullanıcı veritabanına kaydedildi!");
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

                    dgvAdminKitaplar.DataSource = null;
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
                    dt.DefaultView.RowFilter = string.Format("AdSoyad LIKE '%{0}%'", filtre);
                }
            }
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
                girisPanel girisEkrani = new girisPanel();

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
        private void OduncListesiniGetir()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    // JOIN ile 3 tabloyu birleştiriyoruz, böylece ID değil isimler görünüyor
                    string sorgu = @"SELECT O.OduncID, K.AdSoyad, Kit.Ad AS KitapAdi, O.VerilisTarihi 
                 FROM OduncKitaplar O
                 JOIN Kullanicilar K ON O.KullaniciID = K.KullaniciID
                 JOIN Kitaplar Kit ON O.KitapID = Kit.KitapID
                 WHERE O.OnayDurumu = 0";

                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOduncTakip.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }
        private void OnayBekleyenleriGetir()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    string sorgu = @"SELECT o.OduncID, o.KitapID, k.Ad AS KitapAdi, u.AdSoyad AS KullaniciAdi, o.VerilisTarihi 
                             FROM OduncKitaplar o
                             INNER JOIN Kitaplar k ON o.KitapID = k.KitapID
                             INNER JOIN Kullanicilar u ON o.KullaniciID = u.KullaniciID
                             WHERE o.OnayDurumu = 0";

                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Eğer DataGridView ismin yanlışsa burada hata verir.
                    if (dgvOnayBekleyenler != null)
                    {
                        dgvOnayBekleyenler.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("dgvOnayBekleyenler isimli tablo formda bulunamadı!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata alırsan uygulama kapanmaz, hata penceresi açılır
                MessageBox.Show("Hata detayı: " + ex.Message);
            }
        }

        // 2. Aktif ödünçte olanları (Durum 1) getiren metot
        private void AktifOduncleriGetir()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();
                    string sorgu = @"SELECT O.OduncID, O.KitapID, K.AdSoyad, Kit.Ad AS KitapAdi, O.VerilisTarihi 
                             FROM OduncKitaplar O
                             JOIN Kullanicilar K ON O.KullaniciID = K.KullaniciID
                             JOIN Kitaplar Kit ON O.KitapID = Kit.KitapID
                             WHERE O.OnayDurumu = 1";

                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Buraya dikkat: Eğer dgvOduncTakip boş geliyorsa 
                    // veritabanında OnayDurumu = 1 olan kayıt yok demektir.
                    dgvOduncTakip.DataSource = dt;

                    // Debug için kaç kayıt geldiğini görelim:
                    Console.WriteLine("Aktif ödünç sayısı: " + dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aktifler listelenirken hata: " + ex.Message);
            }
        }

        private void adminPanel_Activated(object sender, EventArgs e)
        {
            // Admin paneli her ekrana geldiğinde listeyi tazele
            OnayBekleyenleriGetir();
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            if (dgvOduncTakip.SelectedRows.Count == 0) return;

            int oduncID = Convert.ToInt32(dgvOduncTakip.SelectedRows[0].Cells["OduncID"].Value);
            int kitapID = Convert.ToInt32(dgvOduncTakip.SelectedRows[0].Cells["KitapID"].Value);

            using (var con = KutuphaneVeri.Baglan())
            {
                con.Open();
                // 1. Ödünç tablosundan sil (veya Durum=2 yap)
                string sqlIade = "DELETE FROM OduncKitaplar WHERE OduncID = @id";
                // 2. Stok artır
                string sqlStok = "UPDATE Kitaplar SET Stok = Stok + 1 WHERE KitapID = @kitapid";

                MySqlCommand cmd1 = new MySqlCommand(sqlIade, con);
                cmd1.Parameters.AddWithValue("@id", oduncID);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(sqlStok, con);
                cmd2.Parameters.AddWithValue("@kitapid", kitapID);
                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Kitap teslim alındı ve stok güncellendi.");
            AktifOduncleriGetir(); // Listeyi yenile
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (dgvOnayBekleyenler.SelectedRows.Count == 0) return;

            int oduncID = Convert.ToInt32(dgvOnayBekleyenler.SelectedRows[0].Cells["OduncID"].Value);
            int kitapID = Convert.ToInt32(dgvOnayBekleyenler.SelectedRows[0].Cells["KitapID"].Value);

            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();

                    // 1. Durumu güncelle
                    string sqlOnay = "UPDATE OduncKitaplar SET OnayDurumu = 1 WHERE OduncID = @id";
                    MySqlCommand cmd1 = new MySqlCommand(sqlOnay, con);
                    cmd1.Parameters.AddWithValue("@id", oduncID);
                    int sonuc1 = cmd1.ExecuteNonQuery();

                    // 2. Stok düş
                    string sqlStok = "UPDATE Kitaplar SET Stok = Stok - 1 WHERE KitapID = @kitapid";
                    MySqlCommand cmd2 = new MySqlCommand(sqlStok, con);
                    cmd2.Parameters.AddWithValue("@kitapid", kitapID);
                    int sonuc2 = cmd2.ExecuteNonQuery();

                    if (sonuc1 > 0)
                    {
                        MessageBox.Show("Veritabanı güncellendi! Onaylandı.");
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı güncellenemedi, sorgu hata vermiş olabilir.");
                    }
                }

                // Listeleri tazele
                OnayBekleyenleriGetir();
                AktifOduncleriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA OLUŞTU: " + ex.Message);
            }
        }
        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (dgvOnayBekleyenler.SelectedRows.Count == 0) return;

            int oduncID = Convert.ToInt32(dgvOnayBekleyenler.SelectedRows[0].Cells["OduncID"].Value);

            using (var con = KutuphaneVeri.Baglan())
            {
                con.Open();
                string sqlRed = "DELETE FROM OduncKitaplar WHERE OduncID = @id";

                MySqlCommand cmd = new MySqlCommand(sqlRed, con);
                cmd.Parameters.AddWithValue("@id", oduncID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("İstek reddedildi.");
            OnayBekleyenleriGetir();
        }

        private void txtOduncArama_TextChanged(object sender, EventArgs e)
        {
            // dgvOduncTakip'in veri kaynağını al
            if (dgvOduncTakip.DataSource is DataTable dt)
            {
                string filtre = txtOduncArama.Text.Replace("'", "''");

                if (string.IsNullOrWhiteSpace(filtre) || filtre == "İsim giriniz...")
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    string filterExpression = string.Format("AdSoyad LIKE '%{0}%' OR KitapAdi LIKE '%{0}%'", filtre);
                    dt.DefaultView.RowFilter = filterExpression;
                }
            }
        }
    }
}

