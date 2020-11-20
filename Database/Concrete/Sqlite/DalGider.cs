using Database.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Database.Concrete.Sqlite
{
    public class DalGider : IBaseDatabaseOperation<Gider>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        int ReturnValue = 0;

        public DalGider()
        {

            connection = Database.connection;

        }
        public int Add(Gider Entity)
        {
            /*
           INSERT INTO [Giderler]
           ([Id]
           ,[GiderAdi]
           ,[Miktar]
           ,[Tarih]
           ,[HesapId])
           ,[KategoriId]
     VALUES
           (<Id, bigint,>
           ,<GiderAdi, text,>
           ,<Miktar, real,>
           ,<Tarih, text,>
           ,<HesapId, bigint,>
           ,KategoriId);
             */
            string query = "insert into Giderler (GiderAdi,Miktar,Tarih,HesapId,KategoriId) values (@gideradi,@miktar,@tarih,@hasapid,@KategoriId)";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@gideradi", Entity.GiderAdi);
            command.Parameters.AddWithValue("@miktar", Entity.Miktar);
            command.Parameters.AddWithValue("@hasapid", Entity.Hesap_Kart_Id);
            command.Parameters.AddWithValue("@KategoriId", Entity.KategoriId);
            command.Parameters.AddWithValue("@tarih", Entity.Tarih);

            command.Prepare();
            connection.Open();

            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            if (ReturnValue == 1)
            {
                DalHesapKart dalHesapKart = new DalHesapKart();
                dalHesapKart.BakiyeSubtraction(Entity.Miktar, Entity.Hesap_Kart_Id);
            }
            return ReturnValue;
        }

        public int Delete(Gider Entity)
        {
            /*
           DELETE FROM [Giderler]
           WHERE <Search Conditions,,>;
             */
            string query = "DELETE FROM [Giderler] WHERE Id=@id ";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@id", Entity.Id);
            command.Prepare();
            connection.Open();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            return ReturnValue;
        }

        public List<Gider> GetAll()
        {
            /*
             SELECT [Id]
          ,[GiderAdi]
          ,[Miktar]
          ,[Tarih]
          ,[HesapId]
           FROM [Giderler];

             */
            List<Gider> GiderListe = new List<Gider>();
            string query = "select * from [Giderler]";
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Gider gider = new Gider();
                gider.Id = reader.GetInt32(0);
                gider.GiderAdi = reader.GetString(1);
                gider.Miktar = reader.GetDecimal(2);
                gider.Tarih = reader.GetDateTime(3);
                gider.Hesap_Kart_Id = reader.GetInt32(4);
                gider.KategoriId = reader.GetInt32(5);


                GiderListe.Add(gider);
            }


            connection.Close();

            return GiderListe;
        }

        public int Update(Gider Entity)
        {
            /*
             UPDATE [Giderler] 
             SET [Id] = <Id, bigint,>
             ,[GiderAdi] = <GiderAdi, text,>
             ,[Miktar] = <Miktar, real,>
             ,[Tarih] = <Tarih, text,>
             ,[HesapId] = <HesapId, bigint,>
             ,[KategoriId]=@KategoriId
             WHERE <Search Conditions,,>;
             
             */
            string query = "update [Giderler] set [GiderAdi] =@GiderAdi,[Miktar] =@miktar,[Tarih] =@tarih,[HesapId] =@hesapId KategoriId=@KategoriId where [Id] =@id";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@GiderAdi", Entity.GiderAdi);
            command.Parameters.AddWithValue("@miktar", Entity.Miktar);
            command.Parameters.AddWithValue("@tarih", Entity.Tarih);
            command.Parameters.AddWithValue("@hesapId", Entity.Hesap_Kart_Id);
            command.Parameters.AddWithValue("@KategoriId", Entity.KategoriId);
            command.Parameters.AddWithValue("@id", Entity.Id);
            connection.Open();
            command.Prepare();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();



            return ReturnValue;
        }
    }
}
