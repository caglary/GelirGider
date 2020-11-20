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
    public partial class Giderler : Form
    {
        Business.GiderService _giderService;
        Business.HesapKartService _hesapKartService;
        Business.KategoriService _kategoriService;
        Gider _gider;

        public Giderler()
        {
            InitializeComponent();
            _giderService = new Business.GiderService();
            _hesapKartService = new Business.HesapKartService();
            _kategoriService = new Business.KategoriService();
        }

        private void Giderler_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = _giderService.GetAll().OrderByDescending(I => I.Tarih).ToList();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Helper.Hata(() =>
            {
                Gider gider = CreateGiderFromForm();
                _giderService.Add(gider);
                Listele();
            });

        }
        Gider CreateGiderFromForm()
        {
            Gider __gider = new Gider();
            __gider.GiderAdi = textBoxGiderAdi.Text;
            __gider.Hesap_Kart_Id = ((Hesap_Kart)comboBoxHesap.SelectedItem).Id;
            try
            {
                __gider.Miktar = Convert.ToDecimal(textBoxMiktar.Text);
            }
            catch (Exception)
            {

                throw new Exception("Tutar kısmını kontrol ediniz.");
            }
            
            __gider.Tarih = monthCalendar.SelectionStart;
            __gider.KategoriId = ((Kategori)comboBoxKategori.SelectedItem).Id;

            return __gider;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            var _item = _giderService.GetAll().Where(I => I.Id == id).SingleOrDefault();
            _gider = _item;
            textBoxGiderAdi.Text = _item.GiderAdi;
            textBoxMiktar.Text = _item.Miktar.ToString();
            monthCalendar.SetDate(_item.Tarih);
            var hesap = _hesapKartService.GetAll().Where(I => I.Id == _gider.Hesap_Kart_Id).SingleOrDefault();
            if (hesap != null)
                comboBoxHesap.Text = hesap.Kart_Hesap_Adi;
            var kategoriItem = _kategoriService.GetAll().Where(I => I.Id == _gider.KategoriId).SingleOrDefault();
            if (kategoriItem != null)
            {
                comboBoxKategori.Text = kategoriItem.KategoriAdi;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_gider != null)
            {
                var createdGider = CreateGiderFromForm();
                createdGider.Id = _gider.Id;
                _giderService.Update(createdGider);


                Listele();
            }
            else
            {

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _giderService.Delete(_gider);
            Listele();
        }
    }
}
