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
            MetroLabel[] txtTeamNames = new MetroLabel[ds.Tables[tableName].Rows.Count];

            for (int u = 0; u < txtTeamNames.Count(); u++)
            {
                txtTeamNames[u] = new MetroLabel();
            }
            int i = 0;
            foreach (MetroLabel txt in txtTeamNames)
            {
                string name = "TeamNumber" + i.ToString();

                txt.Name = name;
                txt.Text = name;
                txt.Location = new Point(471, 209 + (i * 40));
                txt.Visible = true;
                this.Controls.Add(txt);
                i++;
            }

            MetroComboBox[] listTeamNames = new MetroComboBox[ds.Tables[tableName].Rows.Count];

            for (int u = 0; u < txtTeamNames.Count(); u++)
            {
                listTeamNames[u] = new MetroComboBox();
            }
            i = 0;
            foreach (MetroComboBox list in listTeamNames)
            {
                string name = "TeamNumber" + i.ToString();

                list.Name = name;
                list.Text = name;
                list.Location = new Point(603, 199 + (i * 40));
                list.Visible = true;
                this.Controls.Add(list);
                i++;
            }
        }
    }
}
