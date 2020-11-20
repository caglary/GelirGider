using System.Data.SQLite;
using System.IO;

namespace Database.Concrete.Sqlite
{
    public static class Database
    {
        static string ConnectionString = @"Data Source=MyDatabase.sqlite;Version=3;";
        public static SQLiteConnection connection = new SQLiteConnection(ConnectionString);
        public static void DatabaseExist()
        {
            if (!File.Exists("MyDatabase.sqlite"))
                DatabaseCreate();
        }

        private static void DatabaseCreate()
        {
            //will code!!!
        }
    }

    

}
