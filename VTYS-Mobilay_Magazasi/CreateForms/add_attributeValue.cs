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
    public partial class add_attributeValue : MetroForm
    {
        bool update;

        public add_attributeValue()
        {
            InitializeComponent();
        }
        public add_attributeValue(bool u)
        {
            InitializeComponent();
            update = u;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void add_attributeValue_Load(object sender, EventArgs e)
        {
            string tableName = "attribute";

            DataSet ds = DbCommand.getDataSet(Queries.attribute, tableName);

            if (ds != null)
            {
                attributeValueList.DisplayMember = "att_name";
                attributeValueList.ValueMember = "attribute_ID";
                attributeValueList.DataSource = ds.Tables[tableName];
                attributeValueList.SelectedItem = null;
                attributeValueList.PromptText = "Choose from the list";
            }
            if (!update)
            { 
                string idName = "id";

                string idQuery = String.Format(Queries.newID, "attributeValue_ID", "attributevalue");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);

                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(attributeValue_ID)"]) + 1).ToString();
                }
                catch (Exception ex)
                {
                    id.Text = "1";
                }

                

                
            }
            else
            {
                id.Text = attributeValue.id;
                id.Enabled = false;
                name.Text = attributeValue.name;
                attributeValueList.Text = attributeValue.attribute;

                metroButton1.Text = "Update";
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            string Id = id.Text;
            string Name = name.Text;
            string AttributeId = attributeValueList.SelectedValue.ToString();
            if (!update)
            {
                string query = String.Format(Queries.insAttributeValue, Id, Name, AttributeId);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                
                string query = String.Format(Queries.upAttributeValue, Name, AttributeId, Id);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
