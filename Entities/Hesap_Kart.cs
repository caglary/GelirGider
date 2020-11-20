using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hesap_Kart
    {
        public int Id { get; set; }
        public string Kart_Hesap_Adi { get; set; }
        public string Hesap_Turu { get; set; }
        public decimal Bakiye { get; set; }
        public decimal BaslangıcMiktarı { get; set; }

    }
}
