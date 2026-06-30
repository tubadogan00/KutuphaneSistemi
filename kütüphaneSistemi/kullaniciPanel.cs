using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace kütüphaneSistemi
{

    [System.ComponentModel.DesignerCategory("Form")]
    public partial class kullaniciPanel : Form
    {


        public kullaniciPanel()
        {
            InitializeComponent();

            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            textBox1.Text = "Kitap giriniz..."; // Burayı düzelttik
            textBox1.ForeColor = Color.Gray;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TemayiUygula();

            // 1. Sütunları BİR KEZ burada tanımla (yoksa)
            if (dgvOduncAlinanlar.Columns.Count == 0)
            {
                dgvOduncAlinanlar.Columns.Add("KitapAdi", "Kitap Adı");
                dgvOduncAlinanlar.Columns.Add("ISBN", "ISBN");
                dgvOduncAlinanlar.Columns.Add("AlisTarihi", "Alınma Tarihi");
                dgvOduncAlinanlar.Columns.Add("TeslimTarihi", "Teslim Tarihi");
            }

            KitaplariGetirVeGoster();
            OduncAlinanlariGetir(); // Veritabanından verileri çek ve dgv'ye bas
        }
        private void OduncAlinanlariGetir()
{
    try
    {
        using (var con = KutuphaneVeri.Baglan())
        {
            con.Open();
                    string sorgu = @"SELECT k.Ad, k.ISBN, o.VerilisTarihi, o.TeslimTarihi 
                             FROM OduncKitaplar o 
                             INNER JOIN Kitaplar k ON o.KitapID = k.KitapID 
                             WHERE o.KullaniciID = @kid";

                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // SADECE SATIRLARI TEMİZLE
            dgvOduncAlinanlar.Rows.Clear(); 
            
            foreach (DataRow row in dt.Rows)
            {
                dgvOduncAlinanlar.Rows.Add(row["Ad"], row["ISBN"],
                    Convert.ToDateTime(row["VerilisTarihi"]).ToString("dd.MM.yyyy"),
                    Convert.ToDateTime(row["TeslimTarihi"]).ToString("dd.MM.yyyy"));
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ödünç listesi yüklenirken hata: " + ex.Message);
    }
}

        private void KitaplariGetirVeGoster()
        {
            try
            {
                using (var con = KutuphaneVeri.Baglan()) // Ortak bağlantı sınıfın
                {
                    con.Open();
                    string sorgu = "SELECT * FROM Kitaplar";
                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKitaplar.DataSource = dt; // Artık veritabanından gelen tabloyu kullanıyoruz
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar yüklenirken hata: " + ex.Message);
            }
        }

        private void TemayiUygula()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            foreach (DataGridView dgv in new[] { dgvKitaplar, dgvOduncAlinanlar })
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;

                // Tam satır seçimi için ayarlar
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;

                // Açık Mavi Tema
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(176, 224, 230);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgv.EnableHeadersVisualStyles = false;
                dgv.RowTemplate.Height = 30;
            }

            btnOduncAl.BackColor = Color.FromArgb(100, 149, 237);
            btnOduncAl.ForeColor = Color.White;
            btnOduncAl.FlatStyle = FlatStyle.Flat;
            btnOduncAl.FlatAppearance.BorderSize = 0;
            btnOduncAl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void btnOduncAl_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.CurrentRow == null) return;

            DataRowView rowView = (DataRowView)dgvKitaplar.CurrentRow.DataBoundItem;
            int kitapID = Convert.ToInt32(rowView["KitapID"]);
            string kitapAdi = rowView["Ad"].ToString();
            int stok = Convert.ToInt32(rowView["Stok"]);

            // GÜNCELLEME: Sabit 1 yerine global sınıftan gerçek ID'yi alıyoruz
            int aktifKullaniciID = AktifKullanici.ID;

            if (stok <= 0)
            {
                MessageBox.Show("Bu kitap şu an stokta yok!");
                return;
            }

            try
            {
                using (var con = KutuphaneVeri.Baglan())
                {
                    con.Open();

                    // 1. KONTROL: Bu kitabı zaten ödünç almış ve iade etmemiş mi?
                    // "TeslimTarihi IS NULL" yerine "OnayDurumu < 2" kullanmak daha garantidir.
                    // (0: Onay Bekliyor, 1: Elinde, 2: Teslim Edildi)
                    string kontrolSorgusu = "SELECT COUNT(*) FROM OduncKitaplar WHERE KitapID = @id AND KullaniciID = @kid AND OnayDurumu < 2";

                    MySqlCommand cmdKontrol = new MySqlCommand(kontrolSorgusu, con);
                    cmdKontrol.Parameters.AddWithValue("@id", kitapID);
                    cmdKontrol.Parameters.AddWithValue("@kid", aktifKullaniciID);

                    if (Convert.ToInt32(cmdKontrol.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Bu kitap zaten üzerinizde kayıtlı veya onay bekliyor!");
                        return;
                    }

                    // 2. İSTEK GÖNDER
                    // OnayDurumu 0 olarak ekleniyor ki admin panelinde "Onay Bekleyenler" kısmına düşsün.
                    string sqlKayit = @"INSERT INTO OduncKitaplar (KullaniciID, KitapID, VerilisTarihi, OnayDurumu) 
                                VALUES (@kid, @kitapid, @alis, 0)";

                    MySqlCommand cmd2 = new MySqlCommand(sqlKayit, con);
                    cmd2.Parameters.AddWithValue("@kid", aktifKullaniciID);
                    cmd2.Parameters.AddWithValue("@kitapid", kitapID);
                    cmd2.Parameters.AddWithValue("@alis", DateTime.Now);

                    cmd2.ExecuteNonQuery();

                    MessageBox.Show($"{kitapAdi} için ödünç alma isteğiniz admin onayına gönderildi.");

                    // İsteğe bağlı: Tabloyu güncelleyerek stok bilgisini veya durumu tazeleyebilirsin
                    // KitaplariListele(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
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
                // Form1'in giriş ekranı olduğunu varsayıyorum
                girisPanel girisEkrani = new girisPanel();
                girisEkrani.Show();

                // Mevcut formu kapatıyoruz
                this.Close();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kitap giriniz...") // Burası artık tutarlı
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // 3. Leave Olayını Düzelt
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Kitap giriniz..."; // Burası artık tutarlı
                textBox1.ForeColor = Color.Gray;
            }
        }

        // 4. TextChanged Olayını Düzelt
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Arama kutusunun varsayılan metni ile aynı olup olmadığını kontrol et
            if (textBox1.Text == "Kitap giriniz..." || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (dgvKitaplar.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = "";
                }
                return;
            }

            if (dgvKitaplar.DataSource is DataTable dtFiltre)
            {
                string filtre = textBox1.Text.Replace("'", "''");
                dtFiltre.DefaultView.RowFilter = string.Format("Ad LIKE '%{0}%' OR Yazar LIKE '%{0}%'", filtre);
            }
        }
    }
}