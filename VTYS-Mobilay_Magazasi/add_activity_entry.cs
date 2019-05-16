using MetroFramework;
using MetroFramework.Forms;
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
    public partial class add_activity_entry : MetroForm
    {
        VTYS_Mobilay_Magazasi.Activity myAct = new Activity();
        string type;
        bool update = false;

        public add_activity_entry(string t)
        {
            InitializeComponent();
            type = t;
        }

        public add_activity_entry(string t, Activity ac)
        {
            InitializeComponent();
            type = t;
            myAct = ac;
            update = true;
        }

        private void add_activity_Load(object sender, EventArgs e)
        {
            if(!update)
            {
                if (type == Activity.type[0])
                {
                    string tableName = "Income";
                    string query = String.Format(Queries.activity, "1");
                    DataSet ds = DbCommand.getDataSet(query, tableName);

                    if (ds != null)
                    {
                        activityList.DisplayMember = "act_name";
                        activityList.ValueMember = "activity_ID";
                        activityList.DataSource = ds.Tables[tableName];
                        activityList.SelectedItem = null;
                        activityList.PromptText = "Choose from the list";
                    }
                    query = String.Format(Queries.newID, "incomes_ID", "incomes");
                    ds = DbCommand.getDataSet(query, tableName);
                    try
                    {
                        ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(incomes_ID)"]) + 1).ToString();
                    }
                    catch (Exception ex)
                    {
                        ID.Text = "1";
                    }
                    
                }
                else
                {
                    string tableName = "Expense";
                    string query = String.Format(Queries.activity, "2");
                    DataSet ds = DbCommand.getDataSet(query, tableName);

                    if (ds != null)
                    {
                        activityList.DisplayMember = "act_name";
                        activityList.ValueMember = "activity_ID";
                        activityList.DataSource = ds.Tables[tableName];
                        activityList.SelectedItem = null;
                        activityList.PromptText = "Choose from the list";
                    }
                    query = String.Format(Queries.newID, "expenses_ID", "expenses");
                    ds = DbCommand.getDataSet(query, tableName);
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(expenses_ID)"]) + 1).ToString();
                }
            }
            else
            {
                addActivityBtn.Text = "Update";
                
                ID.Text = myAct.ID;
                ammount.Text = myAct.ammount;
                desc.Text = myAct.desc;
                string tableName = "Activity";
                DataSet ds;

                if (type == Activity.type[0])
                {
                    

                    string query = String.Format(Queries.activity, "1");
                    ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        activityList.DisplayMember = "act_name";
                        activityList.ValueMember = "activity_ID";
                        activityList.DataSource = ds.Tables[tableName];


                        for (int u = 0; u < activityList.Items.Count; u++)
                            if (ds.Tables[tableName].Rows[u]["activity_ID"].ToString() == myAct.activityID)
                                activityList.SelectedIndex = u;

                        activityList.PromptText = myAct.activityName;
                    }
                }
                else
                {

                    string query = String.Format(Queries.activity, "2");
                    ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        activityList.DisplayMember = "act_name";
                        activityList.ValueMember = "activity_ID";
                        activityList.DataSource = ds.Tables[tableName];


                        for (int u = 0; u < activityList.Items.Count; u++)
                            if (ds.Tables[tableName].Rows[u]["activity_ID"].ToString() == myAct.activityID)
                                activityList.SelectedIndex = u;

                        activityList.PromptText = myAct.activityName;
                    }
                }

            }
            
            
        }

        private void addActivityBtn_Click(object sender, EventArgs e)
        {
            if(!update)
            {
                if(activityList.SelectedItem != null)
                {
                    string tableName = type;
                    string query = "";
                    myAct.ID = ID.Text;
                    myAct.desc = desc.Text;
                    myAct.ammount = ammount.Text;
                    myAct.activityID = activityList.SelectedValue.ToString();

                    if (type == Activity.type[0])
                    {
                        myAct.activityTypeID = "1";
                        query = String.Format(Queries.insIncome, myAct.ID, myAct.desc, myAct.ammount, myAct.activityID, myAct.activityTypeID);
                    }
                    else
                    {
                        myAct.activityTypeID = "2";
                        query = String.Format(Queries.insExpense, myAct.ID, myAct.desc, myAct.ammount, myAct.activityID, myAct.activityTypeID);
                    }
                    DbCommand.insertIntoDb(query);
                    this.Close();

                }
                else
                {
                    MetroMessageBox.Show(this, "You must choose an activity before trying to add it", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {

            }

            

            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ammount_Click(object sender, EventArgs e)
        {

        }

        private void ammount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
