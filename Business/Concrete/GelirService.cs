using Business.Abstract;
using Database.Concrete.Sqlite;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business
{

    public class GelirService : IBaseServiceOperation<Gelir>
    {
        Database.Concrete.Sqlite.DalGelir _dalGelir;
        public GelirService()
        {

            _dalGelir = new DalGelir();
        }
        public int Add(Gelir Entity)
        {

            return _dalGelir.Add(Entity);
        }

        public int Delete(Gelir Entity)
        {
            int result = _dalGelir.Delete(Entity); //silindi. 
                                                   //silinen miktarı silinen hesaptan çıkarmak lazım.
            if (result == 1)
            {
                HesapKartService hesapKartService = new HesapKartService();
                var hesap = hesapKartService.GetAll().Where(I => I.Id == Entity.Hesap_Kart_Id).SingleOrDefault();
                hesap.Bakiye -= Entity.Miktar;
                result =hesapKartService.Update(hesap);
            }

            return result;
        }

        public List<Gelir> GetAll()
        {
            return _dalGelir.GetAll();
        }

        public int Update(Gelir Entity)
        {
            return _dalGelir.Update(Entity);
        }
    }
}
