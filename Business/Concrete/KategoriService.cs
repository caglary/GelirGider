using Business.Abstract;
using Database.Concrete.Sqlite;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class KategoriService : IBaseServiceOperation<Kategori>
    {
        DalKategori _dalKategori;
        public KategoriService()
        {
            _dalKategori = new DalKategori();
        }
        public int Add(Kategori Entity)
        {
            var result = GetAll().Where(I => I.KategoriAdi == Entity.KategoriAdi);
            if (result == null)
                return _dalKategori.Add(Entity);
            else
                return -99;
        }

        public int Delete(Kategori Entity)
        {
            return _dalKategori.Delete(Entity);
        }

        public List<Kategori> GetAll()
        {
            return _dalKategori.GetAll();
        }

        public int Update(Kategori Entity)
        {
            return _dalKategori.Update(Entity);
        }
    }
}
