using Business.Abstract;
using Database.Concrete.Sqlite;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class HesapKartService : IBaseServiceOperation<Hesap_Kart>
    {
        DalHesapKart _dalHesapKart;
        DalGelir _dalGelir;
        DalGider _dalGider;
        public HesapKartService()
        {
            _dalHesapKart = new DalHesapKart();
            _dalGelir = new  DalGelir();
            _dalGider = new  DalGider();
           
        }
        public int Add(Hesap_Kart Entity)
        {
            return _dalHesapKart.Add(Entity);
        }

        public int Delete(Hesap_Kart Entity)
        {
            var gelirler=_dalGelir.GetAll().Where(I => I.Hesap_Kart_Id == Entity.Id).ToList();
            var giderler=_dalGider.GetAll().Where(I => I.Hesap_Kart_Id == Entity.Id).ToList();

            if (gelirler.Count == 0 && giderler.Count==0)
            {
                return _dalHesapKart.Delete(Entity);

            }
            else throw new System.Exception($"{Entity.Kart_Hesap_Adi} adlı hesaba bağlı kayıtlar olduğundan bu hesabı silemezsiniz.");
        }

        public List<Hesap_Kart> GetAll()
        {
            return _dalHesapKart.GetAll();
        }

        public int Update(Hesap_Kart Entity)
        {
            return _dalHesapKart.Update(Entity);
        }
       
    }
}
