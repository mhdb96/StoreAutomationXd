using MetroFramework.Controls;
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
    public partial class add_product : MetroForm
    {
        public add_product()
        {
            InitializeComponent();
        }

        private void add_product_Load(object sender, EventArgs e)
        {
            string tableName = "attributeSet";
            DataSet ds = Products.getDataSet(Queries.attributeSet, tableName);
            if (ds != null)
            {
                attributeSetList.DisplayMember = "set_name";
                attributeSetList.ValueMember = "attributeSet_ID";
                attributeSetList.DataSource = ds.Tables[tableName];   
                attributeSetList.SelectedItem = null;
                attributeSetList.PromptText = "Choose from the list";
            }
        }
           

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

     

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string tableName = "setAttributes";
            string setID = attributeSetList.SelectedValue.ToString();
            string query = String.Format(Queries.setAttributes, setID);
            DataSet ds= Products.getDataSet(query, tableName);
            if (ds == null)
                MessageBox.Show("");
                panel1.Visible = true;
            metroButton4.Enabled = false;

            int[] attributeID = new int [ds.Tables[tableName].Rows.Count];
            for(int u=0; u< attributeID.Length; u++)
            {
                attributeID[u] = (int) ds.Tables[tableName].Rows[u]["attribute_attribute_ID"];
            }


            string atttableName = "AttributeNames";
            DataSet attDs = Products.getDataSet(Queries.attribute, atttableName);
            if (attDs == null)
                MessageBox.Show("");

            MetroLabel[] lblTeamNames = new MetroLabel[ds.Tables[tableName].Rows.Count];
            for (int u = 0; u < lblTeamNames.Count(); u++)
            {
                lblTeamNames[u] = new MetroLabel();
            }
            int i = 0;
            foreach (MetroLabel lbl in lblTeamNames)
            {
                string name =(string) attDs.Tables[atttableName].Rows[attributeID[i]-1]["att_name"];
                lbl.Name = name;
                lbl.Text = name;
                lbl.Location = new Point(471, 209 + (i * 40));
                lbl.Visible = true;
                this.Controls.Add(lbl);
                i++;
            }

            MetroComboBox[] listTeamNames = new MetroComboBox[ds.Tables[tableName].Rows.Count];

            for (int u = 0; u < listTeamNames.Count(); u++)
            {
                listTeamNames[u] = new MetroComboBox();
            }
            i = 0;
            foreach (MetroComboBox list in listTeamNames)
            {
                string valuetableName = "AttributeValues";
                string valueQuery = String.Format(Queries.attributeValues, attributeID[i].ToString());
                DataSet attValDs = Products.getDataSet(valueQuery, valuetableName);
                if (attValDs == null)
                    MessageBox.Show("");


                string name = "TeamNumber" + i.ToString();

                list.Name = name;
                list.Text = name;
                list.Location = new Point(603, 199 + (i * 40));
                list.Visible = true;
                list.DisplayMember = "val_value";
                list.ValueMember = "attributeValue_ID";
                list.DataSource = attValDs.Tables[valuetableName];
                list.SelectedItem = null;
                list.PromptText = "Choose from the list";

                this.Controls.Add(list);
                i++;
            }
        }
    }
}
