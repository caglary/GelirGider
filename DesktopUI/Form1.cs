using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGelirler_Click(object sender, EventArgs e)
        {

            Form formGelirler = new Forms.Gelirler();

            formGelirler.ShowDialog();




        }

        private void btnHesaplar_Click(object sender, EventArgs e)
        {

            Form formHesaplar_Kartlar = new Forms.Hesaplar_Kartlar();

            formHesaplar_Kartlar.ShowDialog();


        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {

            Form formGiderler = new Forms.Giderler();

            formGiderler.ShowDialog();


        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {

            Form formKategoriler = new Forms.Kategoriler();

            formKategoriler.ShowDialog();

        }
    }
}
