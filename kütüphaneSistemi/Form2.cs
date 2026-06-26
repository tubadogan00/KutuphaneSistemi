using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace kütüphaneSistemi
{
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public int YayinYili { get; set; }
        public int Sayfa { get; set; }
        public string Tur { get; set; }
        public int Stok { get; set; }
    }
    public partial class Form2 : Form
    {
        

        List<Kitap> kitaplar = new List<Kitap>
        {
            new Kitap { Ad = "Suç ve Ceza", Yazar = "Dostoyevski", ISBN = "978-975", YayinYili = 1866, Sayfa = 687, Tur = "Roman", Stok = 6 },
            new Kitap { Ad = "Sefiller", Yazar = "Victor Hugo", ISBN = "978-976", YayinYili = 1862, Sayfa = 1462, Tur = "Klasik", Stok = 0 },
            new Kitap { Ad = "Nutuk", Yazar = "M. Kemal Atatürk", ISBN = "978-977", YayinYili = 1927, Sayfa = 500, Tur = "Tarih", Stok = 1 },
            new Kitap { Ad = "1984", Yazar = "George Orwell", ISBN = "978-004", YayinYili = 1949, Sayfa = 328, Tur = "Bilim Kurgu", Stok = 5 },
            new Kitap { Ad = "Beyaz Geceler", Yazar = "Dostoyevski", ISBN = "978-005", YayinYili = 1848, Sayfa = 112, Tur = "Roman", Stok = 3 },
            new Kitap { Ad = "Simyacı", Yazar = "Paulo Coelho", ISBN = "978-006", YayinYili = 1988, Sayfa = 184, Tur = "Macera", Stok = 8 },
            new Kitap { Ad = "Kürk Mantolu Madonna", Yazar = "Sabahattin Ali", ISBN = "978-007", YayinYili = 1943, Sayfa = 177, Tur = "Roman", Stok = 4 },
            new Kitap { Ad = "Hayvan Çiftliği", Yazar = "George Orwell", ISBN = "978-008", YayinYili = 1945, Sayfa = 152, Tur = "Distopya", Stok = 7 },
            new Kitap { Ad = "Küçük Prens", Yazar = "Antoine de Saint-Exupéry", ISBN = "978-009", YayinYili = 1943, Sayfa = 96, Tur = "Çocuk", Stok = 10 },
            new Kitap { Ad = "Satranç", Yazar = "Stefan Zweig", ISBN = "978-010", YayinYili = 1942, Sayfa = 94, Tur = "Roman", Stok = 2 },
            new Kitap { Ad = "Şeker Portakalı", Yazar = "José Mauro de Vasconcelos", ISBN = "978-011", YayinYili = 1968, Sayfa = 200, Tur = "Roman", Stok = 5 },
            new Kitap { Ad = "Dönüşüm", Yazar = "Franz Kafka", ISBN = "978-012", YayinYili = 1915, Sayfa = 104, Tur = "Klasik", Stok = 3 },
            new Kitap { Ad = "Uçurtma Avcısı", Yazar = "Khaled Hosseini", ISBN = "978-013", YayinYili = 2003, Sayfa = 375, Tur = "Roman", Stok = 6 }
        };

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TemayiUygula();

            // 1. KİTAPLAR TABI İÇİN AYARLAR
            dgvKitaplar.DataSource = kitaplar;

            dgvKitaplar.Columns["Ad"].HeaderText = "Kitap Adı";
            dgvKitaplar.Columns["Yazar"].HeaderText = "Yazar";
            dgvKitaplar.Columns["ISBN"].HeaderText = "ISBN";
            dgvKitaplar.Columns["YayinYili"].HeaderText = "Yayın Yılı";
            dgvKitaplar.Columns["Sayfa"].HeaderText = "Sayfa";
            dgvKitaplar.Columns["Tur"].HeaderText = "Tür";
            dgvKitaplar.Columns["Stok"].HeaderText = "Stok";

            dgvKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvKitaplar.Size = new Size(820, 500);

            int x1 = (tabPage1.ClientSize.Width - dgvKitaplar.Width) / 2;
            int y1 = (tabPage1.ClientSize.Height - dgvKitaplar.Height - 50) / 2;
            dgvKitaplar.Location = new Point(x1, y1);
            btnOduncAl.Location = new Point(x1, dgvKitaplar.Bottom + 10);

            // 2. ÖDÜNÇ ALINANLAR TABI İÇİN AYARLAR
            dgvOduncAlinanlar.ColumnCount = 4;
            dgvOduncAlinanlar.Columns[0].Name = "Kitap Adı";
            dgvOduncAlinanlar.Columns[1].Name = "ISBN";
            dgvOduncAlinanlar.Columns[2].Name = "Alınma Tarihi";
            dgvOduncAlinanlar.Columns[3].Name = "Teslim Tarihi";
            dgvOduncAlinanlar.Size = new Size(770, 300);
            dgvOduncAlinanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            int x2 = (tabPage2.ClientSize.Width - dgvOduncAlinanlar.Width) / 2;
            int y2 = (tabPage2.ClientSize.Height - dgvOduncAlinanlar.Height) / 2;
            dgvOduncAlinanlar.Location = new Point(x2, y2);
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
            if (dgvKitaplar.CurrentRow != null)
            {
                Kitap seciliKitap = (Kitap)dgvKitaplar.CurrentRow.DataBoundItem;

                // 1. KONTROL: Daha önce alınmış mı? (ISBN üzerinden kontrol)
                foreach (DataGridViewRow row in dgvOduncAlinanlar.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == seciliKitap.ISBN)
                    {
                        MessageBox.Show("Bu kitap zaten sizde mevcut, tekrar alamazsınız!", "Kısıtlama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // İşlemi durdur
                    }
                }

                // 2. KONTROL: Stok kısıtlaması (Daha önce yazdığımız kod)
                if (seciliKitap.Stok > 1)
                {
                    seciliKitap.Stok--;
                    dgvKitaplar.Refresh();

                    DateTime alis = DateTime.Now;
                    DateTime teslim = alis.AddDays(30);

                    dgvOduncAlinanlar.Rows.Add(seciliKitap.Ad, seciliKitap.ISBN, alis.ToString("dd.MM.yyyy"), teslim.ToString("dd.MM.yyyy"));
                    MessageBox.Show($"{seciliKitap.Ad} başarıyla ödünç alındı.");
                }
                else if (seciliKitap.Stok == 1)
                {
                    MessageBox.Show("Bu kitap son kopyadır, ödünç verilemez!", "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Bu kitap stokta yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}