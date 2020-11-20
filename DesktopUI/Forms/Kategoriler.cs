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
    public partial class Kategoriler : Form
    {
        Business.KategoriService _kategoriService;
        public Kategoriler()
        {
            InitializeComponent();
            _kategoriService = new Business.KategoriService();
        }

        private void Kategoriler_Load(object sender, EventArgs e)
        {
            Listele();
            listBoxKategoriListe.DisplayMember = "KategoriAdi";
        }

        private void Listele()
        {
            listBoxKategoriListe.DataSource = _kategoriService.GetAll();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _kategoriService.Add(new Kategori { KategoriAdi = textBoxKategoriAdi.Text });
            Listele();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Kategori _kategori = (Kategori)listBoxKategoriListe.SelectedItem;
            _kategoriService.Delete(_kategori);
            Listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori _kategori = (Kategori)listBoxKategoriListe.SelectedItem;
            _kategoriService.Update(new Kategori { KategoriAdi = textBoxKategoriAdi.Text, Id = _kategori.Id });
            Listele();

        }

        private void listBoxKategoriListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _kategori = (Kategori)listBoxKategoriListe.SelectedItem;
           textBoxKategoriAdi.Text=  _kategori.KategoriAdi;
        }
    }
}
