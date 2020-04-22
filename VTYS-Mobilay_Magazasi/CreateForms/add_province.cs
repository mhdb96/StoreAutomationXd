using DataAccess;
using MetroFramework.Forms;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYS_Mobilay_Magazasi
{

    public partial class add_province : MetroForm
    {
        bool update;

        public add_province()
        {
            InitializeComponent();
        }
        public add_province(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                string Id = id.Text;
                string Name = name.Text;

                string query = String.Format(Queries.insProvince, Id, Name);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                string query = String.Format(Queries.upProvince, name.Text, id.Text);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }

        private void add_province_Load(object sender, EventArgs e)
        {

            if (update)
            {
                id.Text = ProvinceModel.id;
                id.Enabled = false;
                name.Text = ProvinceModel.name;
                metroButton1.Text = "Update";
            }
            else
            {
                string idName = "id";

                string idQuery = String.Format(Queries.newID, "province_ID", "province");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);

                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(province_ID)"]) + 1).ToString();
                }
                catch (Exception )
                {
                    id.Text = "1";
                }

                

            }
        }
    }
}
