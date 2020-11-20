using Database.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Database.Concrete.Sqlite
{
    public class DalKategori : IBaseDatabaseOperation<Kategori>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        int ReturnValue = 0;
        public DalKategori()
        {
            connection = Database.connection;
        }
        public int Add(Kategori Entity)
        {
            /*
             INSERT INTO [Kategoriler]
            ([Id]
            ,[KategoriAdi])
              VALUES
            (<Id, bigint,>
            ,<KategoriAdi, text,>);
              */

            string query = "insert into Kategoriler (KategoriAdi) values (@KategoriAdi)";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@KategoriAdi", Entity.KategoriAdi);

            command.Prepare();
            connection.Open();

            ReturnValue = command.ExecuteNonQuery();
            connection.Close();

            return ReturnValue;
        }

        public int Delete(Kategori Entity)
        {
            /*
             DELETE FROM [Kategoriler]
                WHERE <Search Conditions,,>;
             */
            string query = "DELETE FROM [Kategoriler] WHERE Id=@id ";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@id", Entity.Id);
            command.Prepare();
            connection.Open();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();
            return ReturnValue;
        }

        public List<Kategori> GetAll()
        {
            /*
             SELECT [Id]
               ,[KategoriAdi]
             FROM [Kategoriler];
             */

            List<Kategori> KategoriListe = new List<Kategori>();
            string query = "select * from [Kategoriler]";
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Kategori kategori = new Kategori();
                kategori.Id = reader.GetInt32(0);
                kategori.KategoriAdi = reader.GetString(1);


                KategoriListe.Add(kategori);
            }


            connection.Close();

            return KategoriListe;



        }

        public int Update(Kategori Entity)
        {
            /*
             UPDATE [Kategoriler] 
              SET [Id] = <Id, bigint,>
             ,[KategoriAdi] = <KategoriAdi, text,>
             WHERE <Search Conditions,,>;
             */

            string query = "update [Kategoriler] set [KategoriAdi] =@KategoriAdi where [Id] =@id";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@KategoriAdi", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@id", Entity.Id);
            connection.Open();
            command.Prepare();
            ReturnValue = command.ExecuteNonQuery();
            connection.Close();

            return ReturnValue;

        }
    }
}
