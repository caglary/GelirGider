using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gelir
    {
        public int Id { get; set; }
        public string GelirAdi { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; }
        public int Hesap_Kart_Id { get; set; }
        public int KategoriId { get; set; }

    }
}
