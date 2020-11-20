namespace DesktopUI.Forms
{
    partial class Hesaplar_Kartlar
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxBaslangicBakiye = new System.Windows.Forms.TextBox();
            this.textBoxBakiye = new System.Windows.Forms.TextBox();
            this.textBoxHesapTuru = new System.Windows.Forms.TextBox();
            this.textBoxHesapAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBoxHesapListe = new System.Windows.Forms.ListBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(289, 188);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(97, 35);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Ekle";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxBaslangicBakiye
            // 
            this.textBoxBaslangicBakiye.Location = new System.Drawing.Point(428, 123);
            this.textBoxBaslangicBakiye.Name = "textBoxBaslangicBakiye";
            this.textBoxBaslangicBakiye.Size = new System.Drawing.Size(167, 22);
            this.textBoxBaslangicBakiye.TabIndex = 7;
            // 
            // textBoxBakiye
            // 
            this.textBoxBakiye.Location = new System.Drawing.Point(428, 94);
            this.textBoxBakiye.Name = "textBoxBakiye";
            this.textBoxBakiye.Size = new System.Drawing.Size(167, 22);
            this.textBoxBakiye.TabIndex = 8;
            // 
            // textBoxHesapTuru
            // 
            this.textBoxHesapTuru.Location = new System.Drawing.Point(428, 65);
            this.textBoxHesapTuru.Name = "textBoxHesapTuru";
            this.textBoxHesapTuru.Size = new System.Drawing.Size(167, 22);
            this.textBoxHesapTuru.TabIndex = 9;
            // 
            // textBoxHesapAdi
            // 
            this.textBoxHesapAdi.Location = new System.Drawing.Point(428, 36);
            this.textBoxHesapAdi.Name = "textBoxHesapAdi";
            this.textBoxHesapAdi.Size = new System.Drawing.Size(167, 22);
            this.textBoxHesapAdi.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bakiye :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Başlangıç Bakiye :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hesap Türü :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hesap/Kart Adı: ";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(392, 188);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(129, 35);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Güncelle";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(527, 188);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(74, 35);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Sil";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxHesapListe
            // 
            this.listBoxHesapListe.FormattingEnabled = true;
            this.listBoxHesapListe.ItemHeight = 16;
            this.listBoxHesapListe.Location = new System.Drawing.Point(12, 25);
            this.listBoxHesapListe.Name = "listBoxHesapListe";
            this.listBoxHesapListe.Size = new System.Drawing.Size(271, 292);
            this.listBoxHesapListe.TabIndex = 12;
            this.listBoxHesapListe.SelectedIndexChanged += new System.EventHandler(this.listBoxHesapListe_SelectedIndexChanged);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(289, 274);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(182, 43);
            this.buttonShow.TabIndex = 13;
            this.buttonShow.Text = "Hesap Görüntüle";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // Hesaplar_Kartlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 357);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.listBoxHesapListe);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxBaslangicBakiye);
            this.Controls.Add(this.textBoxBakiye);
            this.Controls.Add(this.textBoxHesapTuru);
            this.Controls.Add(this.textBoxHesapAdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Hesaplar_Kartlar";
            this.Text = "Hesaplar_Kartlar";
            this.Load += new System.EventHandler(this.Hesaplar_Kartlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxBaslangicBakiye;
        private System.Windows.Forms.TextBox textBoxBakiye;
        private System.Windows.Forms.TextBox textBoxHesapTuru;
        private System.Windows.Forms.TextBox textBoxHesapAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListBox listBoxHesapListe;
        private System.Windows.Forms.Button buttonShow;
    }
}