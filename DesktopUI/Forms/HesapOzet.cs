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
    public partial class HesapOzet : Form
    {
        Business.GelirService _gelirService;
        Business.GiderService _giderService;
        Business.HesapKartService _hesapKartService;
        Business.KategoriService _kategoriService;
        Entities.Hesap_Kart _hesapKart;
        decimal bakiye, toplamGelir, toplamGider;

        public HesapOzet(Entities.Hesap_Kart hesapKart)
        {
            InitializeComponent();
            _gelirService = new Business.GelirService();
            _giderService = new Business.GiderService();
            _hesapKartService = new Business.HesapKartService();
            _kategoriService = new Business.KategoriService();
            _hesapKart = hesapKart;
        }

        private void HesapOzet_Load(object sender, EventArgs e)
        {
            labelHesapKartAdi.Text = _hesapKart.Kart_Hesap_Adi;
            var hesaplar = _hesapKartService.GetAll();
            int index = hesaplar.FindIndex(I => I.Id == _hesapKart.Id);
            hesaplar.RemoveAt(index);
            comboBoxHesaplar.DataSource = hesaplar;
            comboBoxHesaplar.DisplayMember = "Kart_Hesap_Adi";
            GelirGiderYazdir();
        }

        private void GelirGiderYazdir()
        {
            #region Gelir Gider yazdır --> Datagridview
            var gelir = _gelirService.GetAll().Where(I => I.Hesap_Kart_Id == _hesapKart.Id).ToList();
            var gider = _giderService.GetAll().Where(I => I.Hesap_Kart_Id == _hesapKart.Id).ToList();
            List<HesapOzetItem> liste = new List<HesapOzetItem>();
            foreach (var item in gelir)
            {
                HesapOzetItem hesapOzetItem = new HesapOzetItem();
                hesapOzetItem.Kategori = (_kategoriService.GetAll().Where(I => I.Id == item.KategoriId).SingleOrDefault().KategoriAdi);
                hesapOzetItem.Isim = item.GelirAdi;
                hesapOzetItem.Tutar = item.Miktar;
                hesapOzetItem.Tarih = item.Tarih;
                liste.Add(hesapOzetItem);
            }
            foreach (var item in gider)
            {
                HesapOzetItem hesapOzetItem = new HesapOzetItem();
                hesapOzetItem.Kategori = (_kategoriService.GetAll().Where(I => I.Id == item.KategoriId).SingleOrDefault().KategoriAdi);
                hesapOzetItem.Isim = item.GiderAdi;
                hesapOzetItem.Tutar = -(item.Miktar);
                hesapOzetItem.Tarih = item.Tarih;
                liste.Add(hesapOzetItem);
            }
            dataGridView1.DataSource = liste.OrderByDescending(I => I.Tarih).ToList();

            bakiye = _hesapKartService.GetAll().Where(I => I.Id == _hesapKart.Id).SingleOrDefault().Bakiye;
            labelBakiye.Text = "Bakiye : " + bakiye.ToString();

            toplamGelir = _gelirService.GetAll().Where(I => I.Hesap_Kart_Id == _hesapKart.Id).Sum(I => I.Miktar);
            labelToplamGelir.Text = "Toplam Gelir : " + toplamGelir.ToString();

            toplamGider = _giderService.GetAll().Where(I => I.Hesap_Kart_Id == _hesapKart.Id).Sum(I => I.Miktar);
            labelToplamGider.Text = "Toplam Gider : " + toplamGider.ToString();
            #endregion
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {


                //Bakiye kontrolu yapılıyor.
                var tutartextbox = Convert.ToDecimal(this.textBoxTutar.Text);
                
                if (bakiye - tutartextbox < 0)
                    throw new Exception("Bakiye yetersiz.");

                Entities.Kategori kategori = new Entities.Kategori();
                kategori = _kategoriService.GetAll().Where(I => I.KategoriAdi == "Para Transferi").SingleOrDefault();

                while (kategori == null)
                {
                    //kategori oluşturulması gerekiyor.
                    Entities.Kategori __kategori = new Entities.Kategori();
                    __kategori.KategoriAdi = "Para Transferi";
                    _kategoriService.Add(__kategori);
                    kategori = _kategoriService.GetAll().Where(I => I.KategoriAdi == "Para Transferi").SingleOrDefault();
                }

                int kimeId = ((Entities.Hesap_Kart)comboBoxHesaplar.SelectedItem).Id;
                int kimdenId = _hesapKart.Id;
                decimal tutar = Convert.ToDecimal(textBoxTutar.Text);

                Entities.Gider __gider = new Entities.Gider();
                __gider.GiderAdi = ((Entities.Hesap_Kart)comboBoxHesaplar.SelectedItem).Kart_Hesap_Adi;
                __gider.Hesap_Kart_Id = kimdenId;
                __gider.KategoriId = kategori.Id;
                __gider.Miktar = tutar;
                __gider.Tarih = DateTime.Now;
                _giderService.Add(__gider);

                Entities.Gelir __gelir = new Entities.Gelir();
                __gelir.GelirAdi = _hesapKart.Kart_Hesap_Adi;
                __gelir.Hesap_Kart_Id = kimeId;
                __gelir.KategoriId = kategori.Id;
                __gelir.Miktar = tutar;
                __gelir.Tarih = DateTime.Now;
                _gelirService.Add(__gelir);

                GelirGiderYazdir();
            }
            catch (Exception exception)
            {

                Helper.MesajError(exception.Message);
            }
        }
    }
    class HesapOzetItem
    {
        public string Kategori { get; set; }
        public string Isim { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Tarih { get; set; }
    }
}
