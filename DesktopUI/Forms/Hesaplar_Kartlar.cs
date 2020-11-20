using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI.Forms
{
    public partial class Hesaplar_Kartlar : Form
    {
        Business.HesapKartService _hesapKartService;

        Hesap_Kart _hesapKart;

        public Hesaplar_Kartlar()
        {
            InitializeComponent();
            _hesapKartService = new Business.HesapKartService();
        }

        private void Hesaplar_Kartlar_Load(object sender, EventArgs e)
        {
            Listele();
            listBoxHesapListe.DisplayMember = "Kart_Hesap_Adi";
        }

        private void Listele()
        {
            listBoxHesapListe.DataSource = _hesapKartService.GetAll();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Hesap_Kart hesap = CreateHesapKartFromForm();
            _hesapKartService.Add(hesap);
            Listele();
        }

        private Hesap_Kart CreateHesapKartFromForm()
        {
            Hesap_Kart hesap = new Hesap_Kart();
            hesap.Kart_Hesap_Adi = textBoxHesapAdi.Text;
            hesap.Bakiye = Convert.ToDecimal(textBoxBakiye.Text);
            hesap.BaslangıcMiktarı = Convert.ToDecimal(textBoxBaslangicBakiye.Text);
            hesap.Hesap_Turu = textBoxHesapTuru.Text;
            return hesap;

        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_hesapKart != null)
            {
                var item = CreateHesapKartFromForm();
                item.Id = _hesapKart.Id;
                _hesapKartService.Update(item);
                Listele();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_hesapKart != null)
            {
                Helper.Hata(() =>
                {
                    _hesapKartService.Delete(_hesapKart);
                    Listele();
                });

            }
        }

        private void listBoxHesapListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Entities.Hesap_Kart)listBoxHesapListe.SelectedItem;
            if (item != null)
            {
                textBoxHesapAdi.Text = item.Kart_Hesap_Adi;
                textBoxBakiye.Text = item.Bakiye.ToString();
                textBoxBaslangicBakiye.Text = item.BaslangıcMiktarı.ToString();
                textBoxHesapTuru.Text = item.Hesap_Turu;
                _hesapKart = item;
            }
            else if (item == null)
            {
                _hesapKart = null;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            HesapOzet formHesapOzet = new HesapOzet(_hesapKart);
            formHesapOzet.ShowDialog();
            Listele();
        }
    }
}
