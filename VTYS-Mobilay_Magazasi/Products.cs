using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mycon = MySql.Data.MySqlClient.MySqlConnection;
using Myad = MySql.Data.MySqlClient.MySqlDataAdapter;
using Mycom = MySql.Data.MySqlClient.MySqlCommand;


namespace VTYS_Mobilay_Magazasi
{
    class Products
    {
        static public DataSet getDataSet(string query, string tableName)
        {
                try
                {
                    DataSet ds = new DataSet();
                    Mycon mycnct = DatabaseInfo.getConnection();
                    Myad myadapter = new Myad();
                    myadapter.SelectCommand = new Mycom(query, mycnct);
                    mycnct.Open();
                    myadapter.Fill(ds, tableName);
                    mycnct.Close();
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }       
        }

        static public DataTable getDataTable(string query, string tableName)
        {
            try
            {
                DataTable dt = new DataTable();
                Mycon mycnct = DatabaseInfo.getConnection();
                Myad myadapter = new Myad();
                myadapter.SelectCommand = new Mycom(query, mycnct);
                mycnct.Open();
                myadapter.Fill(dt);
                mycnct.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
