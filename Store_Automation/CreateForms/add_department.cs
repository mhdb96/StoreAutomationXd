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

namespace StoreAutomationUI
{
    public partial class add_department : MetroForm
    {
        bool update;

        public add_department()
        {
            InitializeComponent();
        }
        public add_department(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string Id = id.Text;
            string Name = name.Text;
            if (!update)
            {
                string query = String.Format(Queries.insDepartment, Id, Name);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                string query = String.Format(Queries.upDepartment, Name, Id);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void add_department_Load(object sender, EventArgs e)
        {

            if (update)
            {
                id.Text = DepartmentModel.id;
                id.Enabled = false;
                name.Text = DepartmentModel.name;
                metroButton1.Text = "Update";

            }
            else
            {
                string idName = "id";

                string idQuery = String.Format(Queries.newID, "department_ID", "department");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);

                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(department_ID)"]) + 1).ToString();
                }
                catch (Exception )
                {
                    id.Text = "1";
                }

                

            }
        }
    }
}
