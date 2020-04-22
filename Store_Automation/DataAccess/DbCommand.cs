using System;
using Mycon = MySql.Data.MySqlClient.MySqlConnection;
using Myad = MySql.Data.MySqlClient.MySqlDataAdapter;
using Mycom = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;
using MetroFramework;
using System.Windows.Forms;
using StoreAutomationUI;

namespace DataAccess
{
    class DbCommand
    {
        //Verileri SQL komutuyla çekmek için kullanılan fonksiyon
        static public DataSet getDataSet(string query, string tableName)
        {
            try
            {
                //DataSet sınıfından ds isminde nesne oluşturdu
                //Veritabanı bağlantısı oluşturdu
                //DataAdapter oluşturdu
                DataSet ds = new DataSet();
                Mycon mycnct = DatabaseInfo.getConnection();
                Myad myadapter = new Myad();
                //
                //Gönderilen SQL komutunu DataAdapter yardımıyla çekti
                //Veritabanı bağlantısını açtı
                //Çekilen verileri DataSet'in içerisine doldurdu
                //Veritabanı bağlantısını kapattı
                //DataSet'i geri döndürdü
                myadapter.SelectCommand = new Mycom(query, mycnct);
                mycnct.Open();
                myadapter.Fill(ds, tableName);
                mycnct.Close();
                return ds;
                //
            }
            catch (Exception ex)
            {
                //Eğer try kısmında hata alırsak çalışması gereken kod
                MetroMessageBox.Show(data_entry.ActiveForm, ex.Message,"Database Error!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return null;
                //
            }
        }

        static public bool insertIntoDb(string query)
        {
            try
            {
                Mycon mycnct = DatabaseInfo.getConnection();
                Myad myadapter = new Myad();          
                myadapter.SelectCommand = new Mycom(query, mycnct);
                mycnct.Open();
                myadapter.SelectCommand.ExecuteNonQuery();
                mycnct.Close();
                return true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(data_entry.ActiveForm, ex.Message, "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        static public bool tryConncetion()
        {
            try
            {
                Mycon mycnct = DatabaseInfo.getConnection();
                mycnct.Open();
                mycnct.Close();
                return true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(data_entry.ActiveForm, ex.Message, "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

    }
}
