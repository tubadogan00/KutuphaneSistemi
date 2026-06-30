namespace kütüphaneSistemi
{
    partial class uyeOlForm
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
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            btnUyeOl = new Button();
            btnGeri = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(250, 121);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 0;
            label1.Text = "Email Adresiniz:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(272, 195);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 1;
            label2.Text = "Yeni Şifreniz:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.Location = new Point(407, 118);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtSifre
            // 
            txtSifre.Anchor = AnchorStyles.None;
            txtSifre.Location = new Point(407, 188);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(125, 27);
            txtSifre.TabIndex = 3;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // btnUyeOl
            // 
            btnUyeOl.Anchor = AnchorStyles.None;
            btnUyeOl.BackColor = Color.CornflowerBlue;
            btnUyeOl.FlatStyle = FlatStyle.Flat;
            btnUyeOl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnUyeOl.ForeColor = Color.White;
            btnUyeOl.Location = new Point(336, 271);
            btnUyeOl.Name = "btnUyeOl";
            btnUyeOl.Size = new Size(94, 29);
            btnUyeOl.TabIndex = 4;
            btnUyeOl.Text = "Üye Ol";
            btnUyeOl.UseVisualStyleBackColor = false;
            btnUyeOl.Click += btnUyeOl_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGeri.BackColor = Color.CornflowerBlue;
            btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGeri.ForeColor = Color.White;
            btnGeri.Location = new Point(617, 21);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(160, 29);
            btnGeri.TabIndex = 5;
            btnGeri.Text = "Giriş Ekranına Dön";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // uyeOlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGeri);
            Controls.Add(label1);
            Controls.Add(txtSifre);
            Controls.Add(btnUyeOl);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Name = "uyeOlForm";
            Text = "Üyelik İşlemleri";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtSifre;
        private Button btnUyeOl;
        private Button btnGeri;
    }
}