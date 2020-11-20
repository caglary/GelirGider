using Database.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Database.Concrete.Sqlite
{
    public class DalHesapKart : IBaseDatabaseOperation<Hesap_Kart>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        int ReturnValue = 0;
        public DalHesapKart()
        {
            connection = Database.connection;
        }
        public int Add(Hesap_Kart Entity)
        {
            /*
             INSERT INTO [HesapKart]
           ([HesapId]
           ,[HesapKartAdi]
           ,[HesapTuru]
           ,[Bakiye]
           ,[BaslangicBakiye])
             VALUES
           (<HesapId, bigint,>
           ,<HesapKartAdi, text,>
           ,<HesapTuru, text,>
           ,<Bakiye, real,>
           ,<BaslangicBakiye, real,>);
             
             */
            string query = "insert into HesapKart (HesapKartAdi,HesapTuru,Bakiye,BaslangicBakiye) values (@HesapKartAdi,@HesapTuru,@Bakiye,@BaslangicBakiye)";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@HesapKartAdi", Entity.Kart_Hesap_Adi);
            command.Parameters.AddWithValue("@HesapTuru", Entity.Hesap_Turu);
            command.Parameters.AddWithValue("@Bakiye", (Entity.Bakiye + Entity.BaslangıcMiktarı));
            command.Parameters.AddWithValue("@BaslangicBakiye", Entity.BaslangıcMiktarı);

            command.Prepare();
            connection.Open();

            ReturnValue = command.ExecuteNonQuery();
            connection.Close();

            return ReturnValue;

        }
        public int Delete(Hesap_Kart Entity)
        {
            /*
             DELETE FROM [HesapKart]
             WHERE <Search Conditions,,>;
             
             */

            string query = "DELETE FROM [HesapKart] WHERE HesapId=@id ";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@id", Entity.Id);
            command.Prepare();
            connection.Open();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            return ReturnValue;


        }
        public List<Hesap_Kart> GetAll()
        {
            /*
             SELECT [HesapId]
            ,[HesapKartAdi]
            ,[HesapTuru]
            ,[Bakiye]
            ,[BaslangicBakiye]
              FROM [HesapKart];
             */


            List<Hesap_Kart> HesapListe = new List<Hesap_Kart>();
            string query = "select * from [HesapKart]";
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Hesap_Kart hesap = new Hesap_Kart();
                hesap.Id = reader.GetInt32(0);
                hesap.Kart_Hesap_Adi = reader.GetString(1);
                hesap.Hesap_Turu = reader.GetString(2);
                hesap.Bakiye = reader.GetDecimal(3);
                hesap.BaslangıcMiktarı = reader.GetDecimal(4);

                HesapListe.Add(hesap);
            }


            connection.Close();

            return HesapListe;
        }
        public int Update(Hesap_Kart Entity)
        {
            /*
             UPDATE [HesapKart] 
              SET [HesapId] = <HesapId, bigint,>
              ,[HesapKartAdi] = <HesapKartAdi, text,>
              ,[HesapTuru] = <HesapTuru, text,>
              ,[Bakiye] = <Bakiye, real,>
              ,[BaslangicBakiye] = <BaslangicBakiye, real,>
                 WHERE <Search Conditions,,>;
              */
            string query = "update [HesapKart] " +
                "set [HesapKartAdi] =@HesapKartAdi," +
                "[HesapTuru] =@HesapTuru,[Bakiye] =@Bakiye," +
                "[BaslangicBakiye] =@BaslangicBakiye " +
                "where [HesapId] =@HesapId";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@HesapKartAdi", Entity.Kart_Hesap_Adi);
            command.Parameters.AddWithValue("@HesapId", Entity.Id);
            command.Parameters.AddWithValue("@HesapTuru", Entity.Hesap_Turu);
            command.Parameters.AddWithValue("@Bakiye", Entity.Bakiye);
            command.Parameters.AddWithValue("@BaslangicBakiye", Entity.BaslangıcMiktarı);
            connection.Open();
            command.Prepare();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();



            return ReturnValue;

        }
        public void BakiyeAdd(decimal Tutar, int HesapKartId)
        {
            Entities.Hesap_Kart hesap = GetAll().Where(I => I.Id == HesapKartId).SingleOrDefault();
            decimal bakiye = hesap.Bakiye;
            decimal guncelBakiye = bakiye + Tutar;
            hesap.Bakiye = guncelBakiye;
            Update(hesap);
        }
        public void BakiyeSubtraction(decimal Tutar, int HesapKartId)
        {
            Entities.Hesap_Kart hesap = GetAll().Where(I => I.Id == HesapKartId).SingleOrDefault();
            decimal bakiye = hesap.Bakiye;
            decimal guncelBakiye = bakiye - Tutar;
            hesap.Bakiye = guncelBakiye;
            Update(hesap);
        }

    }
}
