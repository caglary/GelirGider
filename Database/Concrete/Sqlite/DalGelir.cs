using Database.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Database.Concrete.Sqlite
{
    public class DalGelir : IBaseDatabaseOperation<Gelir>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        int ReturnValue = 0;
        DalHesapKart _dalHesapKart;

        public DalGelir()
        {

            connection = Database.connection;
            _dalHesapKart = new DalHesapKart();

        }
        public int Add(Gelir Entity)
        {
            /*
             INSERT INTO [Gelirler]
           ([Id]
           ,[GelirAdi]
           ,[Miktar]
           ,[Tarih]
           ,[HesapId])
           ,[KategoriId]
              VALUES
           (<Id, bigint,>
           ,<GelirAdi, text,>
           ,<Miktar, real,>
           ,<Tarih, text,>
           ,<HesapId, bigint,>)
           ,KategoriId;
             
             
             */
            string query = "insert into Gelirler (GelirAdi,Miktar,Tarih,HesapId,KategoriId) values (@geliradi,@miktar,@tarih,@hasapid,@KategoriId)";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@geliradi", Entity.GelirAdi);
            command.Parameters.AddWithValue("@miktar", Entity.Miktar);
            command.Parameters.AddWithValue("@hasapid", Entity.Hesap_Kart_Id);
            command.Parameters.AddWithValue("@tarih", Entity.Tarih);
            command.Parameters.AddWithValue("@KategoriId", Entity.KategoriId);

            command.Prepare();
            connection.Open();

            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            if (ReturnValue == 1)
            {
                DalHesapKart dalHesapKart = new DalHesapKart();
                dalHesapKart.BakiyeAdd(Entity.Miktar, Entity.Hesap_Kart_Id);
            }
            return ReturnValue;
        }

        public int Delete(Gelir Entity)
        {
            /*
            DELETE FROM [Gelirler]
            WHERE <Search Conditions,,>;
             */
            string query = "DELETE FROM [Gelirler] WHERE Id=@id ";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@id", Entity.Id);
            command.Prepare();
            connection.Open();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            return ReturnValue;
        }

        public List<Gelir> GetAll()
        {
            // SELECT[Id]
            //,[GelirAdi]
            //,[Miktar]
            //,[Tarih]
            //,[HesapId]
            //,[KategoriId]
            //  FROM[Gelirler];
            List<Gelir> GelirListe = new List<Gelir>();
            string query = "select * from [Gelirler]";
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Gelir gelir = new Gelir();
                gelir.Id = reader.GetInt32(0);
                gelir.GelirAdi = reader.GetString(1);
                gelir.Miktar = reader.GetDecimal(2);
                gelir.Tarih = reader.GetDateTime(3);
                gelir.Hesap_Kart_Id = reader.GetInt32(4);
                gelir.KategoriId = reader.GetInt32(5);

                GelirListe.Add(gelir);
            }


            connection.Close();

            return GelirListe;
        }

        public int Update(Gelir Entity)
        {
            //           UPDATE[Gelirler]
            //  SET[Id] = < Id, bigint,>
            //     ,[GelirAdi] = <GelirAdi, text,>
            //     ,[Miktar] = <Miktar, real,>
            //     ,[Tarih] = <Tarih, text,>
            //     ,[HesapId] = <HesapId, bigint,>
            //WHERE<Search Conditions,,>;
            string query = "update [Gelirler] set [GelirAdi] =@geliradi,[Miktar] =@miktar,[Tarih] =@tarih,[HesapId] =@hesapId [KategoriId]=@KategoriId where [Id] =@id";
            
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@geliradi", Entity.GelirAdi);
            command.Parameters.AddWithValue("@miktar", Entity.Miktar);
            command.Parameters.AddWithValue("@tarih", Entity.Tarih);
            command.Parameters.AddWithValue("@hesapId", Entity.Hesap_Kart_Id);
            command.Parameters.AddWithValue("@id", Entity.Id);
            command.Parameters.AddWithValue("@KategoriId", Entity.KategoriId);
            connection.Open();
            command.Prepare();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();



            return ReturnValue;
        }
    }
}
