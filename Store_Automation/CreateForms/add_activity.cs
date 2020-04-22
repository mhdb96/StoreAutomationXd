using DataAccess;
using MetroFramework.Forms;
using Models;
using System;
using System.Data;

namespace StoreAutomationUI
{
    public partial class add_activity : MetroForm
    {
        bool update;

        public add_activity()
        {
            InitializeComponent();
        }
        public add_activity(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void add_activity_Load(object sender, EventArgs e)
        {
            string tableName = "attribute";

            DataSet ds = DbCommand.getDataSet(Queries.activityType, tableName);

            if (ds != null)
            {
                activityValueList.DisplayMember = "Name";
                activityValueList.ValueMember = "ID";
                activityValueList.DataSource = ds.Tables[tableName];
                activityValueList.SelectedItem = null;
                activityValueList.PromptText = "Choose from the list";
            }
            if (!update)
            {
                string idName = "id";

                string idQuery = string.Format(Queries.newID, "activity_ID", "activity");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);

                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(activity_ID)"]) + 1).ToString();
                }
                catch (Exception)
                {
                    id.Text = "1";
                }
            }
            else
            {
                id.Text = activity.id;
                id.Enabled = false;
                name.Text = activity.name;
                activityValueList.Text = activity.activityType;
                metroButton1.Text = "Update";
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string Id = id.Text;
            string Name = name.Text;
            string activityId = activityValueList.SelectedValue.ToString();
            if (!update)
            {
                string query = string.Format(Queries.insActivityType, Id, Name, activityId);
                DbCommand.insertIntoDb(query);
            }
            else
            {

                string query = string.Format(Queries.upActivityType, Name, activityId, Id);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
