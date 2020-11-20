namespace DesktopUI
{
    partial class Form1
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
            this.btnKategoriler = new System.Windows.Forms.Button();
            this.btnHesaplar = new System.Windows.Forms.Button();
            this.btnGelirler = new System.Windows.Forms.Button();
            this.btnGiderler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKategoriler
            // 
            this.btnKategoriler.Location = new System.Drawing.Point(252, 251);
            this.btnKategoriler.Name = "btnKategoriler";
            this.btnKategoriler.Size = new System.Drawing.Size(139, 138);
            this.btnKategoriler.TabIndex = 0;
            this.btnKategoriler.Text = "Kategoriler";
            this.btnKategoriler.UseVisualStyleBackColor = true;
            this.btnKategoriler.Click += new System.EventHandler(this.btnKategoriler_Click);
            // 
            // btnHesaplar
            // 
            this.btnHesaplar.Location = new System.Drawing.Point(47, 251);
            this.btnHesaplar.Name = "btnHesaplar";
            this.btnHesaplar.Size = new System.Drawing.Size(139, 138);
            this.btnHesaplar.TabIndex = 0;
            this.btnHesaplar.Text = "Hesaplar/Kartlar";
            this.btnHesaplar.UseVisualStyleBackColor = true;
            this.btnHesaplar.Click += new System.EventHandler(this.btnHesaplar_Click);
            // 
            // btnGelirler
            // 
            this.btnGelirler.Location = new System.Drawing.Point(252, 58);
            this.btnGelirler.Name = "btnGelirler";
            this.btnGelirler.Size = new System.Drawing.Size(139, 138);
            this.btnGelirler.TabIndex = 0;
            this.btnGelirler.Text = "Gelirler";
            this.btnGelirler.UseVisualStyleBackColor = true;
            this.btnGelirler.Click += new System.EventHandler(this.btnGelirler_Click);
            // 
            // btnGiderler
            // 
            this.btnGiderler.Location = new System.Drawing.Point(47, 58);
            this.btnGiderler.Name = "btnGiderler";
            this.btnGiderler.Size = new System.Drawing.Size(139, 138);
            this.btnGiderler.TabIndex = 0;
            this.btnGiderler.Text = "Giderler";
            this.btnGiderler.UseVisualStyleBackColor = true;
            this.btnGiderler.Click += new System.EventHandler(this.btnGiderler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 484);
            this.Controls.Add(this.btnKategoriler);
            this.Controls.Add(this.btnHesaplar);
            this.Controls.Add(this.btnGiderler);
            this.Controls.Add(this.btnGelirler);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnKategoriler;
        private System.Windows.Forms.Button btnHesaplar;
        private System.Windows.Forms.Button btnGelirler;
        private System.Windows.Forms.Button btnGiderler;
    }
}

