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
    public partial class add_attributeset : MetroForm
    {
        public add_attributeset()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string Id = id.Text;
            string Name = name.Text;

            string query = String.Format(Queries.insAttributeSet,Id,Name);
            DbCommand.insertIntoDb(query);

            this.Close();
        }

        private void add_attributeset_Load(object sender, EventArgs e)
        {
            string idName = "id";

            string idQuery = String.Format(Queries.newID, "attributeSet_ID", "attributeset");
            DataSet idDs = DbCommand.getDataSet(idQuery, idName);
            id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(attributeSet_ID)"]) + 1).ToString();
        }
    }
}
