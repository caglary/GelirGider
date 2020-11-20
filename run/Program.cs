using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace run
{
    class Program
    {
        static void Main(string[] args)
        {
            //FakeData();

            int arabaSayisi = 5;
            Increase(ref arabaSayisi);
            Console.WriteLine(arabaSayisi);
            Console.ReadLine();

        }

        private static void Increase(ref int arabaSayisi)
        {
            arabaSayisi += 1;
        }

        private static void FakeData()
        {
            do
            {
                Console.Clear();
                Gelir g = new Gelir();
                g.GelirAdi = global::FakeData.TextData.GetSentence();
                g.Hesap_Kart_Id = global::FakeData.NumberData.GetNumber(1, 100);
                g.Miktar = global::FakeData.NumberData.GetNumber(10, 2000);
                Database.Concrete.Sqlite.DalGelir dal = new Database.Concrete.Sqlite.DalGelir();
                //dal.Add(g);
                var liste = dal.GetAll();
                foreach (var item in liste)
                {
                    Console.WriteLine(item.Id + "--->" + item.GelirAdi + " " + item.Miktar + " " + item.Tarih.ToString().Substring(0, 10));
                }
                Console.WriteLine("Silmek istediğiniz Id giriniz.");
                int updatedId = Convert.ToInt32(Console.ReadLine());
                dal.Update(new Gelir
                {
                    Id = updatedId,
                    GelirAdi = "Maaş",
                    Hesap_Kart_Id = 2,
                    Miktar = 2500,
                    Tarih = Convert.ToDateTime(" 10.10.2020")
                });

            } while (Console.ReadLine() != "q");



            Console.ReadLine();
        }
    }
}
