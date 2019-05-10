using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework;
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
        Products myPro = new Products();
        public add_product()
        {
            InitializeComponent();
        }

        private void add_product_Load(object sender, EventArgs e)
        {
            string tableName = "attributeSet";
            DataSet ds = DbCommand.getDataSet(Queries.attributeSet, tableName);
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
            string id = "id";
            string idQuery = String.Format(Queries.newID, "product_ID", "product");
            DataSet idDs = DbCommand.getDataSet(idQuery, id);
            if (idDs == null)
                MessageBox.Show("");
            ID.Text =((int) (idDs.Tables[id].Rows[0]["max(product_ID)"])+1).ToString();
            myPro.id = ID.Text;

            string tableName = "setAttributes";
            string setID = attributeSetList.SelectedValue.ToString();
            string query = String.Format(Queries.setAttributes, setID);
            DataSet ds= DbCommand.getDataSet(query, tableName);
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
            DataSet attDs = DbCommand.getDataSet(Queries.attribute, atttableName);
            if (attDs == null)
                MessageBox.Show("DataSet is empty!");

            MetroLabel[] lblTeamNames = new MetroLabel[ds.Tables[tableName].Rows.Count];
            for (int u = 0; u < lblTeamNames.Count(); u++)
            {
                lblTeamNames[u] = new MetroLabel();
            }
            myPro.count = ds.Tables[tableName].Rows.Count;
            myPro.setArrayslength();
            int i = 0;
            foreach (MetroLabel lbl in lblTeamNames)
            {
                myPro.attribute_id[i]= attDs.Tables[atttableName].Rows[attributeID[i] - 1]["attribute_ID"].ToString();
                myPro.attribute_name[i] = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                string name ="lbl"+(string) attDs.Tables[atttableName].Rows[attributeID[i]-1]["att_name"];
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
                DataSet attValDs = DbCommand.getDataSet(valueQuery, valuetableName);
                if (attValDs == null)
                    MessageBox.Show("DataSet is empty!");
                string name = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                list.Name = name;
                list.Text = name;
                list.Location = new Point(603, 199 + (i * 40));
                list.Visible = true;
                list.DisplayMember = "val_value";
                list.ValueMember = "attributeValue_ID";
                list.DataSource = attValDs.Tables[valuetableName];
                list.SelectedItem = null;
                list.PromptText = "Choose from the list";
                list.Style = MetroFramework.MetroColorStyle.Green;

                this.Controls.Add(list);
                i++;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            myPro.name = name.Text;
            myPro.desc = description.Text;
            myPro.price = price.Text;
            myPro.stock = stock.Text;
            myPro.set_id = attributeSetList.SelectedValue.ToString();
            string query = String.Format(Queries.insProduct,myPro.id, myPro.name,myPro.desc,myPro.price,myPro.stock,myPro.set_id);
            if (!DbCommand.insertIntoDb(query))
                MessageBox.Show("");

            for(int i=0; i<myPro.count; i++)
            {
                MetroComboBox list = (MetroComboBox)Controls[myPro.attribute_name[i]];
                myPro.att_val_id[i] = list.SelectedValue.ToString();
                query = String.Format(Queries.insProductAttribute, myPro.id, myPro.att_val_id[i] , myPro.set_id, myPro.attribute_id[i]);
                
                DbCommand.insertIntoDb(query);
               
            }
            

            this.Close();

        }

        private void add_product_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
