using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_Mobilay_Magazasi
{
    class DatabaseInfo
    {
        //Veritabanının bilgilerini string değişkenlere attı
        public static string server = "localhost";
        public static string user = "root";
        public static string pass = "alpha86";
        public static string database = "pro";
        public static uint port = 3306;
        //
        static public MySqlConnection getConnection()
        {
            //MySqlConnectionStringBuilder sınıfından builder nesnesi yaratıp bilgileri içine attı
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pass,
                Database = database,
                Port = port
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
