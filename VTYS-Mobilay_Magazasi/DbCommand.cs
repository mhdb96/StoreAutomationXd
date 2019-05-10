﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mycon = MySql.Data.MySqlClient.MySqlConnection;
using Myad = MySql.Data.MySqlClient.MySqlDataAdapter;
using Mycom = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;
using MetroFramework;
using System.Windows.Forms;

namespace VTYS_Mobilay_Magazasi
{
    class DbCommand
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
                MessageBox.Show("");
                return null;
            }
        }

        /*static public DataTable getDataTable(string query, string tableName)
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
        }*/

        static public bool insertIntoDb(string query)
        {
            try
            {
                DataTable dt = new DataTable();
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
                MessageBox.Show("");
                return false;
            }
        }

    }
}
