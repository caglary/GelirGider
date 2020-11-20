namespace DesktopUI.Forms
{
    partial class HesapOzet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelHesapKartAdi = new System.Windows.Forms.Label();
            this.comboBoxHesaplar = new System.Windows.Forms.ComboBox();
            this.textBoxTutar = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBakiye = new System.Windows.Forms.Label();
            this.labelToplamGider = new System.Windows.Forms.Label();
            this.labelToplamGelir = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(546, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelHesapKartAdi
            // 
            this.labelHesapKartAdi.AutoSize = true;
            this.labelHesapKartAdi.Location = new System.Drawing.Point(12, 9);
            this.labelHesapKartAdi.Name = "labelHesapKartAdi";
            this.labelHesapKartAdi.Size = new System.Drawing.Size(73, 17);
            this.labelHesapKartAdi.TabIndex = 1;
            this.labelHesapKartAdi.Text = "Hesap Adı";
            // 
            // comboBoxHesaplar
            // 
            this.comboBoxHesaplar.FormattingEnabled = true;
            this.comboBoxHesaplar.Location = new System.Drawing.Point(220, 67);
            this.comboBoxHesaplar.Name = "comboBoxHesaplar";
            this.comboBoxHesaplar.Size = new System.Drawing.Size(121, 24);
            this.comboBoxHesaplar.TabIndex = 2;
            // 
            // textBoxTutar
            // 
            this.textBoxTutar.Location = new System.Drawing.Point(347, 69);
            this.textBoxTutar.Name = "textBoxTutar";
            this.textBoxTutar.Size = new System.Drawing.Size(100, 22);
            this.textBoxTutar.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(454, 67);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Gönder";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Para Transfer İşlemi";
            // 
            // labelBakiye
            // 
            this.labelBakiye.AutoSize = true;
            this.labelBakiye.Location = new System.Drawing.Point(12, 47);
            this.labelBakiye.Name = "labelBakiye";
            this.labelBakiye.Size = new System.Drawing.Size(50, 17);
            this.labelBakiye.TabIndex = 1;
            this.labelBakiye.Text = "Bakiye";
            // 
            // labelToplamGider
            // 
            this.labelToplamGider.AutoSize = true;
            this.labelToplamGider.Location = new System.Drawing.Point(9, 64);
            this.labelToplamGider.Name = "labelToplamGider";
            this.labelToplamGider.Size = new System.Drawing.Size(94, 17);
            this.labelToplamGider.TabIndex = 1;
            this.labelToplamGider.Text = "Toplam Gider";
            // 
            // labelToplamGelir
            // 
            this.labelToplamGelir.AutoSize = true;
            this.labelToplamGelir.Location = new System.Drawing.Point(9, 81);
            this.labelToplamGelir.Name = "labelToplamGelir";
            this.labelToplamGelir.Size = new System.Drawing.Size(89, 17);
            this.labelToplamGelir.TabIndex = 1;
            this.labelToplamGelir.Text = "Toplam Gelir";
            // 
            // HesapOzet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 450);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxTutar);
            this.Controls.Add(this.comboBoxHesaplar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelToplamGelir);
            this.Controls.Add(this.labelToplamGider);
            this.Controls.Add(this.labelBakiye);
            this.Controls.Add(this.labelHesapKartAdi);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HesapOzet";
            this.Text = "HesapOzet";
            this.Load += new System.EventHandler(this.HesapOzet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelHesapKartAdi;
        private System.Windows.Forms.ComboBox comboBoxHesaplar;
        private System.Windows.Forms.TextBox textBoxTutar;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBakiye;
        private System.Windows.Forms.Label labelToplamGider;
        private System.Windows.Forms.Label labelToplamGelir;
    }
}