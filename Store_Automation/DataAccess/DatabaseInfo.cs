using MySql.Data.MySqlClient;

namespace DataAccess
{
    class DatabaseInfo
    {
        //Veritabanının bilgilerini string değişkenlere attı

        // db4free.net
        public static string server = "db4free.net";
        public static string user = "db_tester";
        public static string pass = "fortesting";
        public static string database = "store_auto_db";
        public static uint port = 3306;

        //// Local
        //public static string server = "localhost";
        //public static string user = "root";        
        //public static string pass = "alpha86";        
        //public static string database = "pro";        
        //public static uint port = 3307;

        static public MySqlConnection getConnection()
        {
            //MySqlConnectionStringBuilder sınıfından builder nesnesi yaratıp bilgileri içine attı
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Port = port,
                Database = database,
                UserID = user,
                Password = pass,
                OldGuids = true
            };
            //
            //build nesnesi yardımıyla MySqlConnection sınıfından myConnection nesnesi oluşturdu
            //ve geri döndürdü
            MySqlConnection myConnection = new MySqlConnection(builder.ToString());
            return myConnection;
            //
        }
    }
}
