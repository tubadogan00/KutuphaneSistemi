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
            KitaplariGetirVeGoster(); // Verileri veritabanından çek

            // Ödünç alınanlar tablosunun sütunlarını burada manuel tanımlayalım
            dgvOduncAlinanlar.Columns.Clear(); // Önce temizle
            dgvOduncAlinanlar.Columns.Add("KitapAdi", "Kitap Adı");
            dgvOduncAlinanlar.Columns.Add("ISBN", "ISBN");
            dgvOduncAlinanlar.Columns.Add("AlisTarihi", "Alınma Tarihi");
            dgvOduncAlinanlar.Columns.Add("TeslimTarihi", "Teslim Tarihi");

            // Tasarım ayarları
            dgvOduncAlinanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            if (dgvKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen ödünç almak için bir kitap seçin.");
                return;
            }

            // 1. Seçili satırdaki verileri al
            DataRowView rowView = (DataRowView)dgvKitaplar.CurrentRow.DataBoundItem;
            int kitapID = Convert.ToInt32(rowView["KitapID"]); // Veritabanındaki ID
            string kitapAdi = rowView["Ad"].ToString();
            string isbn = rowView["ISBN"].ToString();
            int stok = Convert.ToInt32(rowView["Stok"]);

            // 2. KONTROL: Daha önce alınmış mı? (ISBN üzerinden)
            foreach (DataGridViewRow row in dgvOduncAlinanlar.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == isbn)
                {
                    MessageBox.Show("Bu kitap zaten sizde mevcut!", "Kısıtlama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 3. KONTROL: Stok durumu
            if (stok > 1)
            {
                try
                {
                    using (var con = KutuphaneVeri.Baglan())
                    {
                        con.Open();
                        // Veritabanında stoğu güncelle
                        string sorgu = "UPDATE Kitaplar SET Stok = Stok - 1 WHERE KitapID = @id";
                        MySqlCommand cmd = new MySqlCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@id", kitapID);
                        cmd.ExecuteNonQuery();
                    }

                    // Arayüzü güncelle
                    DateTime alis = DateTime.Now;
                    DateTime teslim = alis.AddDays(30);
                    dgvOduncAlinanlar.Rows.Add(kitapAdi, isbn, alis.ToString("dd.MM.yyyy"), teslim.ToString("dd.MM.yyyy"));

                    // Tabloyu yeniden yükle ki stok azalmış haliyle görünsün
                    KitaplariGetirVeGoster();

                    MessageBox.Show($"{kitapAdi} başarıyla ödünç alındı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ödünç alma sırasında hata oluştu: " + ex.Message);
                }
            }
            else if (stok == 1)
            {
                MessageBox.Show("Bu kitap son kopyadır, ödünç verilemez!", "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Bu kitap stokta yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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