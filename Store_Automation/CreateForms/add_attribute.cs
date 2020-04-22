using DataAccess;
using MetroFramework.Forms;
using System;
using System.Data;

namespace StoreAutomationUI
{
    public partial class add_attribute : MetroForm
    {
        bool update;

        public add_attribute()
        {
            InitializeComponent();
        }
        public add_attribute(bool u)
        {
            InitializeComponent();
            update = u;
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                string Id = id.Text;
                string Name = name.Text;

                string query = string.Format(Queries.insAttribute, Id, Name);
                DbCommand.insertIntoDb(query);
            }
            else
            {

                string query = string.Format(Queries.upAttribute, name.Text, id.Text);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void add_attribute_Load(object sender, EventArgs e)
        {
            if (update)
            {
                id.Text = Models.AttributeModel.id;
                id.Enabled = false;
                name.Text = Models.AttributeModel.name;
                metroButton1.Text = "Update";
            }
            else
            {
                string idName = "id";

                string idQuery = string.Format(Queries.newID, "attribute_ID", "attribute");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);
                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(attribute_ID)"]) + 1).ToString();
                }
                catch (Exception)
                {
                    id.Text = "1";
                }


            }
        }
    }
}
