namespace kütüphaneSistemi
{
    partial class girisPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            btnGiris = new Button();
            label1 = new Label();
            label2 = new Label();
            btnUyeOl = new Button();
            SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Anchor = AnchorStyles.None;
            txtKullaniciAdi.Location = new Point(406, 93);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(125, 27);
            txtKullaniciAdi.TabIndex = 0;
            // 
            // txtSifre
            // 
            txtSifre.Anchor = AnchorStyles.None;
            txtSifre.Location = new Point(406, 186);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(125, 27);
            txtSifre.TabIndex = 1;
            // 
            // btnGiris
            // 
            btnGiris.Anchor = AnchorStyles.None;
            btnGiris.BackColor = Color.CornflowerBlue;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGiris.ForeColor = Color.White;
            btnGiris.Location = new Point(361, 273);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(94, 29);
            btnGiris.TabIndex = 2;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(307, 96);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(314, 189);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 4;
            label2.Text = "Şifre:";
            // 
            // btnUyeOl
            // 
            btnUyeOl.Anchor = AnchorStyles.None;
            btnUyeOl.BackColor = Color.CornflowerBlue;
            btnUyeOl.FlatStyle = FlatStyle.Flat;
            btnUyeOl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUyeOl.ForeColor = Color.White;
            btnUyeOl.Location = new Point(361, 321);
            btnUyeOl.Name = "btnUyeOl";
            btnUyeOl.Size = new Size(94, 29);
            btnUyeOl.TabIndex = 5;
            btnUyeOl.Text = "Üye Ol";
            btnUyeOl.UseVisualStyleBackColor = false;
            btnUyeOl.Click += btnUyeOl_Click;
            // 
            // girisPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUyeOl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGiris);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Name = "girisPanel";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKullaniciAdi;
        private TextBox txtSifre;
        private Button btnGiris;
        private Label label1;
        private Label label2;
        private Button btnUyeOl;
    }
}
