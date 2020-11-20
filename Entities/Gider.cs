using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gider
    {
        public int Id { get; set; }
        public string GiderAdi { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; }
        public int Hesap_Kart_Id { get; set; }
        public int KategoriId { get; set; }


    }
}
