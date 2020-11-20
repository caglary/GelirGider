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
    public partial class Gelirler : Form
    {
        Business.GelirService _gelirService;
        Business.HesapKartService _hesapKartService;
        Business.KategoriService _kategoriService;
        Gelir _gelir;
        public Gelirler()
        {
            InitializeComponent();
            _gelirService = new Business.GelirService();
            _hesapKartService = new Business.HesapKartService();
            _kategoriService = new Business.KategoriService();
        }

        private void Gelirler_Load(object sender, EventArgs e)
        {

            Listele();

            comboBoxHesap.DataSource = _hesapKartService.GetAll();
            comboBoxHesap.DisplayMember = "Kart_Hesap_Adi";

            comboBoxKategori.DataSource = _kategoriService.GetAll();
            comboBoxKategori.DisplayMember = "KategoriAdi";

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Hesap_Kart_Id"].Visible = false;
            dataGridView1.Columns["KategoriId"].Visible = false;

        }

        private void Listele()
        {
            dataGridView1.DataSource = _gelirService.GetAll().OrderByDescending(I => I.Tarih).ToList();


        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_gelir != null)
            {
                var createdGelir = CreateGelirFromForm();
                createdGelir.Id = _gelir.Id;
                _gelirService.Update(createdGelir);


                Listele();
            }
            else
            {

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Helper.Hata(() =>
            {

                Gelir _gelir = CreateGelirFromForm();
                Helper.GelirControl(_gelir);
                _gelirService.Add(_gelir);
                Listele();

            });

        }

        private Gelir CreateGelirFromForm()
        {
            Gelir _gelir = new Gelir();
            _gelir.GelirAdi = textBoxGelirAdi.Text;
            Hesap_Kart _hesapKart = (Hesap_Kart)comboBoxHesap.SelectedItem;
            _gelir.Hesap_Kart_Id = _hesapKart.Id;
            try
            {
                _gelir.Miktar = Convert.ToDecimal(textBoxMiktar.Text);
            }
            catch (Exception)
            {
                throw new Exception("Tutar kısmını kontrol ediniz.");
            }

            _gelir.Tarih = monthCalendar.SelectionStart;
            _gelir.KategoriId = ((Kategori)comboBoxKategori.SelectedItem).Id;
            return _gelir;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            var _item = _gelirService.GetAll().Where(I => I.Id == id).SingleOrDefault();
            _gelir = _item;
            textBoxGelirAdi.Text = _item.GelirAdi;
            textBoxMiktar.Text = _item.Miktar.ToString();
            monthCalendar.SetDate(_item.Tarih);
            var hesap = _hesapKartService.GetAll().Where(I => I.Id == _gelir.Hesap_Kart_Id).SingleOrDefault();
            if (hesap != null)
                comboBoxHesap.Text = hesap.Kart_Hesap_Adi;
            var kategoriItem = _kategoriService.GetAll().Where(I => I.Id == _gelir.KategoriId).SingleOrDefault();
            if (kategoriItem != null)
            {
                comboBoxKategori.Text = kategoriItem.KategoriAdi;
            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Helper.Hata(() =>
            {

                _gelirService.Delete(_gelir);
                Listele();
            });

        }
    }
}
