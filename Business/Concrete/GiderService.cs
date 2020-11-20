using Business.Abstract;
using Database.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class GiderService : IBaseServiceOperation<Gider>
    {
        Database.Concrete.Sqlite.DalGider _dalGider;
        public GiderService()
        {
            _dalGider = new Database.Concrete.Sqlite.DalGider();
        }
        public int Add(Gider Entity)
        {
            //gider yapılan hesabın bakiyesini sorgulanacak ve 0 tl nin altında ise gider eklenemeyecek.
            HesapKartService hesapKartService = new HesapKartService();
            var hesap=hesapKartService.GetAll().Where(I => I.Id == Entity.Hesap_Kart_Id).SingleOrDefault();
            if (hesap!=null)
            {
                if ((hesap.Bakiye-Entity.Miktar) >= 0) return _dalGider.Add(Entity);
                else throw new System.Exception("Bakiye yetersiz!");
            }
            else throw new System.Exception("Hesap/Kart Bilgisine ulaşılamadı.");



        }

        public int Delete(Gider Entity)
        {
            
            int result = _dalGider.Delete(Entity);  //silindi. 
                                                   //silinen miktarı silinen hesaptan çıkarmak lazım.
            if (result == 1)
            {
                HesapKartService hesapKartService = new HesapKartService();
                var hesap = hesapKartService.GetAll().Where(I => I.Id == Entity.Hesap_Kart_Id).SingleOrDefault();
                hesap.Bakiye += Entity.Miktar;
                result = hesapKartService.Update(hesap);
            }

            return result;

        }

        public List<Gider> GetAll()
        {
            return _dalGider.GetAll();

        }

        public int Update(Gider Entity)
        {
            return _dalGider.Update(Entity);

        }
    }
}
