using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using kütüphaneSistemi;
namespace kütüphaneSistemi
{
    public partial class adminPanel : Form
    {
        List<Kitap> kitaplar = new List<Kitap>();

        public adminPanel()
        {
            InitializeComponent();
        }

        public class Kullanici
        {
            public string AdSoyad { get; set; }
            public string Email { get; set; }
        }
        List<Kullanici> kullanicilar = new List<Kullanici>();
        private void adminPanel_Load(object sender, EventArgs e)
        {
            TemayiUygula();

            // Kitaplar tablosu
            dgvAdminKitaplar.DataSource = KutuphaneVeri.TumKitaplar;

            // Kullanıcılar tablosu
            dgvKullanicilar.DataSource = kullanicilar;
        }

        private void TemayiUygula()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Hem kitaplar hem de kullanıcılar tablosunu boya
            foreach (DataGridView dgv in new[] { dgvAdminKitaplar, dgvKullanicilar })
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.EnableHeadersVisualStyles = false;
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
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }

                // Eğer kontrolün kendi içinde de başka kontroller varsa (Panel, GroupBox gibi), oraya da gir
                if (ctrl.HasChildren)
                {
                    BoyaliKontrolleriBul(ctrl);
                }
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
            // 1. KİTAP ADI VE YAZAR KONTROLÜ (Sadece rakam girilmesini engelle)
            if (txtKitapAdi.Text.Length > 0 && txtKitapAdi.Text.All(char.IsDigit))
            {
                MessageBox.Show("Kitap adı sadece rakamlardan oluşamaz!");
                return;
            }

            if (txtYazar.Text.Length > 0 && txtYazar.Text.All(char.IsDigit))
            {
                MessageBox.Show("Yazar adı sadece rakamlardan oluşamaz!");
                return;
            }

            if (txtTur.Text.Length > 0 && txtTur.Text.All(char.IsDigit))
            {
                MessageBox.Show("Tür adı sadece rakamlardan oluşamaz!");
                return;
            }

            // 2. SAYISAL ALANLARIN KONTROLÜ (Harf girilmesini engelle)
            int stok, sayfa, yil;
            if (!int.TryParse(txtStok.Text, out stok) ||
                !int.TryParse(txtSayfa.Text, out sayfa) ||
                !int.TryParse(txtYil.Text, out yil))
            {
                MessageBox.Show("Stok, Sayfa ve Yıl alanlarına sadece sayı girebilirsiniz!");
                return;
            }

            // 3. KAYDETME İŞLEMİ (Her şey kontrol edildi, artık güvenle ekle)
            Kitap yeniKitap = new Kitap
            {
                Ad = txtKitapAdi.Text,
                Yazar = txtYazar.Text,
                ISBN = txtISBN.Text,
                YayinYili = yil,
                Sayfa = sayfa,
                Tur = txtTur.Text,
                Stok = stok
            };

            KutuphaneVeri.TumKitaplar.Add(yeniKitap);

            // 4. TABLOYU GÜNCELLE
            dgvAdminKitaplar.DataSource = null;
            dgvAdminKitaplar.DataSource = KutuphaneVeri.TumKitaplar;

            MessageBox.Show("Kitap başarıyla eklendi!");
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            // 1. Önce bir satırın seçili olup olmadığını kontrol et
            if (dgvAdminKitaplar.CurrentRow != null)
            {
                // 2. Kullanıcıdan onay al (Yanlışlıkla silmeyi engelle)
                DialogResult onay = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?",
                                                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (onay == DialogResult.Yes)
                {
                    // 3. Seçili satırdaki veriyi al
                    Kitap seciliKitap = (Kitap)dgvAdminKitaplar.CurrentRow.DataBoundItem;

                    // 4. Listeden o kitabı kaldır
                    kitaplar.Remove(seciliKitap);

                    // 5. Tabloyu tazeleyerek silineni ekrandan kaldır
                    dgvAdminKitaplar.DataSource = null;
                    dgvAdminKitaplar.DataSource = kitaplar;

                    MessageBox.Show("Kitap başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kitap seçin.");
            }
        }

        private void dgvAdminKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
            if (dgvAdminKitaplar.SelectedRows.Count > 0)
            {
                int seciliIndex = dgvAdminKitaplar.SelectedRows[0].Index;

                // DEĞİŞİKLİK BURADA: Ortak havuzdaki veriyi güncelliyoruz
                KutuphaneVeri.TumKitaplar[seciliIndex].Ad = txtKitapAdi.Text;
                KutuphaneVeri.TumKitaplar[seciliIndex].Yazar = txtYazar.Text;
                KutuphaneVeri.TumKitaplar[seciliIndex].ISBN = txtISBN.Text;
                KutuphaneVeri.TumKitaplar[seciliIndex].YayinYili = int.Parse(txtYil.Text);
                KutuphaneVeri.TumKitaplar[seciliIndex].Sayfa = int.Parse(txtSayfa.Text);
                KutuphaneVeri.TumKitaplar[seciliIndex].Tur = txtTur.Text;
                KutuphaneVeri.TumKitaplar[seciliIndex].Stok = int.Parse(txtStok.Text);

                // Tabloyu tekrar tazeliyoruz
                dgvAdminKitaplar.DataSource = null;
                dgvAdminKitaplar.DataSource = KutuphaneVeri.TumKitaplar;

                MessageBox.Show("Kitap bilgileri güncellendi!");
            }
        }

        private void dgvKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydett_Click(object sender, EventArgs e)
        {
            // 1. BOŞLUK KONTROLÜ: Alanlar boşsa işlemi durdur
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen Ad Soyad ve Email alanlarını doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi burada kes
            }

            // 2. KAYIT İŞLEMİ
            Kullanici yeniKullanici = new Kullanici
            {
                AdSoyad = txtKullaniciAdi.Text,
                Email = txtEmail.Text
            };

            kullanicilar.Add(yeniKullanici);

            // 3. TABLOYU GÜNCELLE
            dgvKullanicilar.DataSource = null;
            dgvKullanicilar.DataSource = kullanicilar;

            // 4. TEMİZLEME: Kayıttan sonra kutuları boşalt ve odaklan
            txtKullaniciAdi.Clear();
            txtEmail.Clear();
            txtKullaniciAdi.Focus();

            MessageBox.Show("Kullanıcı başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Clear();
            txtEmail.Clear();

            // İmleci tekrar en başa odakla (Kullanıcı hemen yazmaya başlayabilsin)
            txtKullaniciAdi.Focus();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            // 1. KONTROL: Tabloda seçili bir satır var mı?
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                // 2. ONAY: Kullanıcıdan emin olup olmadığını sor
                DialogResult onay = MessageBox.Show("Seçili kullanıcıyı silmek istediğinize emin misiniz?",
                                                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (onay == DialogResult.Yes)
                {
                    // 3. SİLME İŞLEMİ
                    // Seçili olan satırdaki veriyi al
                    Kullanici seciliKullanici = (Kullanici)dgvKullanicilar.SelectedRows[0].DataBoundItem;

                    // Listeden çıkart
                    kullanicilar.Remove(seciliKullanici);

                    // 4. TABLOYU GÜNCELLE
                    dgvKullanicilar.DataSource = null;
                    dgvKullanicilar.DataSource = kullanicilar;

                    // 5. TEMİZLEME: Kutuları boşalt
                    txtKullaniciAdi.Clear();
                    txtEmail.Clear();

                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Satır seçilmediyse kullanıcıya uyar
                MessageBox.Show("Lütfen silmek için listeden bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {
            // Eğer tabloda seçili bir satır varsa
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                // Seçili olan satırı al
                DataGridViewRow row = dgvKullanicilar.SelectedRows[0];

                // "DataBoundItem" kullanarak seçili satırın içindeki "Kullanici" nesnesine ulaş
                if (row.DataBoundItem is Kullanici seciliKullanici)
                {
                    // Verileri TextBox'lara aktar
                    txtKullaniciAdi.Text = seciliKullanici.AdSoyad;
                    txtEmail.Text = seciliKullanici.Email;
                }
            }
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            // 1. KONTROL: Seçili satır var mı?
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                // 2. KONTROL: Boş güncelleme yapmasın diye (Validation)
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Lütfen boş alan bırakmayın!");
                    return;
                }

                // 3. İNDEKSİ BUL: Seçili olan satırın listedeki yerini al
                int seciliIndex = dgvKullanicilar.SelectedRows[0].Index;

                // 4. GÜNCELLE: Listedeki veriyi değiştir
                kullanicilar[seciliIndex].AdSoyad = txtKullaniciAdi.Text;
                kullanicilar[seciliIndex].Email = txtEmail.Text;

                // 5. TABLOYU TAZELE: Değişikliklerin ekrana yansıması için
                dgvKullanicilar.DataSource = null;
                dgvKullanicilar.DataSource = kullanicilar;

                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi!");
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.");
            }
        }
    }
}

