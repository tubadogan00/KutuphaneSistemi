namespace kütüphaneSistemi
{
    partial class adminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            button1 = new Button();
            panel1 = new Panel();
            btnKitapEkle = new Button();
            btnKitapGuncelle = new Button();
            btnKaydet = new Button();
            btnKitapSil = new Button();
            lblStok = new Label();
            lblTur = new Label();
            lblSayfa = new Label();
            lblYayinYili = new Label();
            lblISBN = new Label();
            lblYazar = new Label();
            lblKitapAdi = new Label();
            txtISBN = new TextBox();
            txtKitapAdi = new TextBox();
            txtYazar = new TextBox();
            txtSayfa = new TextBox();
            txtTur = new TextBox();
            txtStok = new TextBox();
            txtYil = new TextBox();
            dgvAdminKitaplar = new DataGridView();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            lblkullaniciAra = new Label();
            txtArama = new TextBox();
            panel2 = new Panel();
            btnKaydett = new Button();
            btnKullaniciGuncelle = new Button();
            btnKullaniciSil = new Button();
            btnKullaniciEkle = new Button();
            lblEmail = new Label();
            lblAdSoyad = new Label();
            txtEmail = new TextBox();
            txtKullaniciAdi = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvKullanicilar = new DataGridView();
            tabPage3 = new TabPage();
            dgvOnayBekleyenler = new DataGridView();
            btnTeslimAl = new Button();
            label1 = new Label();
            btnOnayla = new Button();
            txtOduncArama = new TextBox();
            btnReddet = new Button();
            dgvOduncTakip = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdminKitaplar).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOnayBekleyenler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOduncTakip).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1400, 800);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1392, 767);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📚 Kitap Yönetimi";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvAdminKitaplar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1386, 761);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(lblStok);
            groupBox1.Controls.Add(lblTur);
            groupBox1.Controls.Add(lblSayfa);
            groupBox1.Controls.Add(lblYayinYili);
            groupBox1.Controls.Add(lblISBN);
            groupBox1.Controls.Add(lblYazar);
            groupBox1.Controls.Add(lblKitapAdi);
            groupBox1.Controls.Add(txtISBN);
            groupBox1.Controls.Add(txtKitapAdi);
            groupBox1.Controls.Add(txtYazar);
            groupBox1.Controls.Add(txtSayfa);
            groupBox1.Controls.Add(txtTur);
            groupBox1.Controls.Add(txtStok);
            groupBox1.Controls.Add(txtYil);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.Location = new Point(903, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(15);
            groupBox1.Size = new Size(480, 755);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kitap Bilgileri";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.CornflowerBlue;
            button1.ForeColor = Color.White;
            button1.Location = new Point(313, 692);
            button1.Name = "button1";
            button1.Size = new Size(150, 45);
            button1.TabIndex = 14;
            button1.Text = "Çıkış Yap";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(btnKitapEkle);
            panel1.Controls.Add(btnKitapGuncelle);
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(btnKitapSil);
            panel1.Location = new Point(310, 479);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 220);
            panel1.TabIndex = 6;
            // 
            // btnKitapEkle
            // 
            btnKitapEkle.BackColor = Color.CornflowerBlue;
            btnKitapEkle.FlatStyle = FlatStyle.Flat;
            btnKitapEkle.ForeColor = Color.White;
            btnKitapEkle.Location = new Point(3, 23);
            btnKitapEkle.Name = "btnKitapEkle";
            btnKitapEkle.Size = new Size(150, 40);
            btnKitapEkle.TabIndex = 2;
            btnKitapEkle.Text = "Kitap Ekle";
            btnKitapEkle.UseVisualStyleBackColor = false;
            btnKitapEkle.Click += btnKitapEkle_Click;
            // 
            // btnKitapGuncelle
            // 
            btnKitapGuncelle.BackColor = Color.CornflowerBlue;
            btnKitapGuncelle.FlatStyle = FlatStyle.Flat;
            btnKitapGuncelle.ForeColor = Color.White;
            btnKitapGuncelle.Location = new Point(3, 93);
            btnKitapGuncelle.Name = "btnKitapGuncelle";
            btnKitapGuncelle.Size = new Size(150, 40);
            btnKitapGuncelle.TabIndex = 4;
            btnKitapGuncelle.Text = "Kitap Güncelle";
            btnKitapGuncelle.UseVisualStyleBackColor = false;
            btnKitapGuncelle.Click += btnKitapGuncelle_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.CornflowerBlue;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.ForeColor = Color.White;
            btnKaydet.Location = new Point(3, 128);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 40);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnKitapSil
            // 
            btnKitapSil.BackColor = Color.CornflowerBlue;
            btnKitapSil.FlatStyle = FlatStyle.Flat;
            btnKitapSil.ForeColor = Color.White;
            btnKitapSil.Location = new Point(3, 58);
            btnKitapSil.Name = "btnKitapSil";
            btnKitapSil.Size = new Size(150, 40);
            btnKitapSil.TabIndex = 3;
            btnKitapSil.Text = "Kitap Sil";
            btnKitapSil.UseVisualStyleBackColor = false;
            btnKitapSil.Click += btnKitapSil_Click;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStok.Location = new Point(37, 254);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(105, 23);
            lblStok.TabIndex = 13;
            lblStok.Text = "Stok Adedi:";
            // 
            // lblTur
            // 
            lblTur.AutoSize = true;
            lblTur.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTur.Location = new Point(37, 221);
            lblTur.Name = "lblTur";
            lblTur.Size = new Size(42, 23);
            lblTur.TabIndex = 12;
            lblTur.Text = "Tür:";
            // 
            // lblSayfa
            // 
            lblSayfa.AutoSize = true;
            lblSayfa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSayfa.Location = new Point(37, 188);
            lblSayfa.Name = "lblSayfa";
            lblSayfa.Size = new Size(109, 23);
            lblSayfa.TabIndex = 11;
            lblSayfa.Text = "Sayfa Sayısı:";
            // 
            // lblYayinYili
            // 
            lblYayinYili.AutoSize = true;
            lblYayinYili.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYayinYili.Location = new Point(37, 155);
            lblYayinYili.Name = "lblYayinYili";
            lblYayinYili.Size = new Size(86, 23);
            lblYayinYili.TabIndex = 10;
            lblYayinYili.Text = "Yayın Yılı:";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblISBN.Location = new Point(37, 122);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(54, 23);
            lblISBN.TabIndex = 9;
            lblISBN.Text = "ISBN:";
            // 
            // lblYazar
            // 
            lblYazar.AutoSize = true;
            lblYazar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYazar.Location = new Point(37, 85);
            lblYazar.Name = "lblYazar";
            lblYazar.Size = new Size(57, 23);
            lblYazar.TabIndex = 8;
            lblYazar.Text = "Yazar:";
            // 
            // lblKitapAdi
            // 
            lblKitapAdi.AutoSize = true;
            lblKitapAdi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKitapAdi.Location = new Point(37, 52);
            lblKitapAdi.Name = "lblKitapAdi";
            lblKitapAdi.Size = new Size(91, 23);
            lblKitapAdi.TabIndex = 7;
            lblKitapAdi.Text = "Kitap Adı:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(176, 119);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(180, 32);
            txtISBN.TabIndex = 6;
            // 
            // txtKitapAdi
            // 
            txtKitapAdi.Location = new Point(176, 49);
            txtKitapAdi.Name = "txtKitapAdi";
            txtKitapAdi.Size = new Size(180, 32);
            txtKitapAdi.TabIndex = 5;
            // 
            // txtYazar
            // 
            txtYazar.Location = new Point(176, 82);
            txtYazar.Name = "txtYazar";
            txtYazar.Size = new Size(180, 32);
            txtYazar.TabIndex = 4;
            // 
            // txtSayfa
            // 
            txtSayfa.Location = new Point(176, 185);
            txtSayfa.Name = "txtSayfa";
            txtSayfa.Size = new Size(180, 32);
            txtSayfa.TabIndex = 3;
            // 
            // txtTur
            // 
            txtTur.Location = new Point(176, 218);
            txtTur.Name = "txtTur";
            txtTur.Size = new Size(180, 32);
            txtTur.TabIndex = 2;
            // 
            // txtStok
            // 
            txtStok.Location = new Point(176, 251);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(180, 32);
            txtStok.TabIndex = 1;
            // 
            // txtYil
            // 
            txtYil.Location = new Point(176, 152);
            txtYil.Name = "txtYil";
            txtYil.Size = new Size(180, 32);
            txtYil.TabIndex = 0;
            // 
            // dgvAdminKitaplar
            // 
            dgvAdminKitaplar.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvAdminKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminKitaplar.Dock = DockStyle.Fill;
            dgvAdminKitaplar.Location = new Point(3, 3);
            dgvAdminKitaplar.Name = "dgvAdminKitaplar";
            dgvAdminKitaplar.RowHeadersWidth = 51;
            dgvAdminKitaplar.Size = new Size(894, 755);
            dgvAdminKitaplar.TabIndex = 0;
            dgvAdminKitaplar.SelectionChanged += dgvAdminKitaplar_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1392, 767);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "👤 Kullanıcı Yönetimi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(lblkullaniciAra);
            groupBox2.Controls.Add(txtArama);
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(lblEmail);
            groupBox2.Controls.Add(lblAdSoyad);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtKullaniciAdi);
            groupBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox2.Location = new Point(906, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(15);
            groupBox2.Size = new Size(483, 758);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kullanıcı Bilgileri";
            // 
            // lblkullaniciAra
            // 
            lblkullaniciAra.AutoSize = true;
            lblkullaniciAra.Location = new Point(13, 259);
            lblkullaniciAra.Name = "lblkullaniciAra";
            lblkullaniciAra.Size = new Size(150, 25);
            lblkullaniciAra.TabIndex = 6;
            lblkullaniciAra.Text = "🔍Kullanıcı Ara:";
            // 
            // txtArama
            // 
            txtArama.Location = new Point(193, 252);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(180, 32);
            txtArama.TabIndex = 5;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.Controls.Add(btnKaydett);
            panel2.Controls.Add(btnKullaniciGuncelle);
            panel2.Controls.Add(btnKullaniciSil);
            panel2.Controls.Add(btnKullaniciEkle);
            panel2.Location = new Point(285, 520);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 220);
            panel2.TabIndex = 4;
            // 
            // btnKaydett
            // 
            btnKaydett.BackColor = Color.CornflowerBlue;
            btnKaydett.ForeColor = Color.White;
            btnKaydett.Location = new Point(3, 139);
            btnKaydett.Name = "btnKaydett";
            btnKaydett.Size = new Size(174, 40);
            btnKaydett.TabIndex = 5;
            btnKaydett.Text = "Kaydet";
            btnKaydett.UseVisualStyleBackColor = false;
            btnKaydett.Click += btnKaydett_Click;
            // 
            // btnKullaniciGuncelle
            // 
            btnKullaniciGuncelle.BackColor = Color.CornflowerBlue;
            btnKullaniciGuncelle.ForeColor = Color.White;
            btnKullaniciGuncelle.Location = new Point(3, 93);
            btnKullaniciGuncelle.Name = "btnKullaniciGuncelle";
            btnKullaniciGuncelle.Size = new Size(177, 40);
            btnKullaniciGuncelle.TabIndex = 4;
            btnKullaniciGuncelle.Text = "Kullanıcı Güncelle";
            btnKullaniciGuncelle.UseVisualStyleBackColor = false;
            btnKullaniciGuncelle.Click += btnKullaniciGuncelle_Click;
            // 
            // btnKullaniciSil
            // 
            btnKullaniciSil.BackColor = Color.CornflowerBlue;
            btnKullaniciSil.ForeColor = Color.White;
            btnKullaniciSil.Location = new Point(3, 47);
            btnKullaniciSil.Name = "btnKullaniciSil";
            btnKullaniciSil.Size = new Size(174, 40);
            btnKullaniciSil.TabIndex = 3;
            btnKullaniciSil.Text = "Kullanıcı Sil";
            btnKullaniciSil.UseVisualStyleBackColor = false;
            btnKullaniciSil.Click += btnKullaniciSil_Click;
            // 
            // btnKullaniciEkle
            // 
            btnKullaniciEkle.BackColor = Color.CornflowerBlue;
            btnKullaniciEkle.ForeColor = Color.White;
            btnKullaniciEkle.Location = new Point(3, 3);
            btnKullaniciEkle.Name = "btnKullaniciEkle";
            btnKullaniciEkle.Size = new Size(174, 40);
            btnKullaniciEkle.TabIndex = 2;
            btnKullaniciEkle.Text = "Kullanıcı Ekle";
            btnKullaniciEkle.UseVisualStyleBackColor = false;
            btnKullaniciEkle.Click += btnKullaniciEkle_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(76, 92);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 23);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblAdSoyad
            // 
            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdSoyad.Location = new Point(49, 44);
            lblAdSoyad.Name = "lblAdSoyad";
            lblAdSoyad.Size = new Size(92, 23);
            lblAdSoyad.TabIndex = 2;
            lblAdSoyad.Text = "Ad Soyad:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(193, 89);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 32);
            txtEmail.TabIndex = 1;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(193, 41);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(180, 32);
            txtKullaniciAdi.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.Controls.Add(dgvKullanicilar, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1386, 761);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // dgvKullanicilar
            // 
            dgvKullanicilar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvKullanicilar.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKullanicilar.Location = new Point(3, 3);
            dgvKullanicilar.Name = "dgvKullanicilar";
            dgvKullanicilar.RowHeadersWidth = 51;
            dgvKullanicilar.Size = new Size(894, 755);
            dgvKullanicilar.TabIndex = 0;
            dgvKullanicilar.SelectionChanged += dgvKullanicilar_SelectionChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvOnayBekleyenler);
            tabPage3.Controls.Add(btnTeslimAl);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(btnOnayla);
            tabPage3.Controls.Add(txtOduncArama);
            tabPage3.Controls.Add(btnReddet);
            tabPage3.Controls.Add(dgvOduncTakip);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1392, 767);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ödünç İşlemleri";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvOnayBekleyenler
            // 
            dgvOnayBekleyenler.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvOnayBekleyenler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOnayBekleyenler.Location = new Point(717, 54);
            dgvOnayBekleyenler.Name = "dgvOnayBekleyenler";
            dgvOnayBekleyenler.RowHeadersWidth = 51;
            dgvOnayBekleyenler.Size = new Size(686, 442);
            dgvOnayBekleyenler.TabIndex = 5;
            // 
            // btnTeslimAl
            // 
            btnTeslimAl.BackColor = Color.CornflowerBlue;
            btnTeslimAl.FlatStyle = FlatStyle.Flat;
            btnTeslimAl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTeslimAl.ForeColor = Color.White;
            btnTeslimAl.Location = new Point(6, 502);
            btnTeslimAl.Name = "btnTeslimAl";
            btnTeslimAl.Size = new Size(171, 29);
            btnTeslimAl.TabIndex = 4;
            btnTeslimAl.Text = "Seçili Kitabı Teslim Al";
            btnTeslimAl.UseVisualStyleBackColor = false;
            btnTeslimAl.Click += btnTeslimAl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 21);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Üye Adı:";
            label1.Click += label1_Click;
            // 
            // btnOnayla
            // 
            btnOnayla.BackColor = Color.CornflowerBlue;
            btnOnayla.FlatStyle = FlatStyle.Flat;
            btnOnayla.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOnayla.ForeColor = Color.White;
            btnOnayla.Location = new Point(717, 502);
            btnOnayla.Name = "btnOnayla";
            btnOnayla.Size = new Size(94, 29);
            btnOnayla.TabIndex = 3;
            btnOnayla.Text = "Onayla";
            btnOnayla.UseVisualStyleBackColor = false;
            btnOnayla.Click += btnOnayla_Click;
            // 
            // txtOduncArama
            // 
            txtOduncArama.Location = new Point(88, 18);
            txtOduncArama.Name = "txtOduncArama";
            txtOduncArama.Size = new Size(125, 27);
            txtOduncArama.TabIndex = 1;
            txtOduncArama.TextChanged += txtOduncArama_TextChanged;
            // 
            // btnReddet
            // 
            btnReddet.BackColor = Color.CornflowerBlue;
            btnReddet.FlatStyle = FlatStyle.Flat;
            btnReddet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReddet.ForeColor = Color.White;
            btnReddet.Location = new Point(833, 502);
            btnReddet.Name = "btnReddet";
            btnReddet.Size = new Size(94, 29);
            btnReddet.TabIndex = 6;
            btnReddet.Text = "Reddet";
            btnReddet.UseVisualStyleBackColor = false;
            btnReddet.Click += btnReddet_Click;
            // 
            // dgvOduncTakip
            // 
            dgvOduncTakip.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvOduncTakip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOduncTakip.Location = new Point(6, 54);
            dgvOduncTakip.Name = "dgvOduncTakip";
            dgvOduncTakip.RowHeadersWidth = 51;
            dgvOduncTakip.Size = new Size(687, 442);
            dgvOduncTakip.TabIndex = 2;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 800);
            Controls.Add(tabControl1);
            MinimumSize = new Size(1200, 700);
            Name = "adminPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kütüphane Yönetim Paneli";
            WindowState = FormWindowState.Maximized;
            Activated += adminPanel_Activated;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdminKitaplar).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOnayBekleyenler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOduncTakip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvAdminKitaplar;
        private Button btnKaydet;
        private Button btnKitapGuncelle;
        private Button btnKitapSil;
        private Button btnKitapEkle;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label lblStok;
        private Label lblTur;
        private Label lblSayfa;
        private Label lblYayinYili;
        private Label lblISBN;
        private Label lblYazar;
        private Label lblKitapAdi;
        private TextBox txtISBN;
        private TextBox txtKitapAdi;
        private TextBox txtYazar;
        private TextBox txtSayfa;
        private TextBox txtTur;
        private TextBox txtStok;
        private TextBox txtYil;
        private DataGridView dgvKullanicilar;
        private GroupBox groupBox2;
        private TextBox txtEmail;
        private TextBox txtKullaniciAdi;
        private Label lblEmail;
        private Label lblAdSoyad;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Button btnKaydett;
        private Button btnKullaniciGuncelle;
        private Button btnKullaniciSil;
        private Button btnKullaniciEkle;
        private TextBox txtArama;
        private Label lblkullaniciAra;
        private Button button1;
        private TabPage tabPage3;
        private TextBox txtOduncArama;
        private Label label1;
        private Button btnTeslimAl;
        private Button btnOnayla;
        private DataGridView dgvOduncTakip;
        private Button btnReddet;
        private DataGridView dgvOnayBekleyenler;
    }
}