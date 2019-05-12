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
    public partial class admin : MetroForm
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }
        //=============================================================
        //======================= ATTRİBUTE ===========================
        //=============================================================
        private void metroTile7_Click(object sender, EventArgs e)
        {
            panelControl(0);

            string tableName = "attribute";

            metroGrid1.DataSource = null;

            string query = Queries.attribute;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributeGrid.DataSource = ds.Tables[tableName];

            attributeGrid.Columns[0].Width = 30;

        }
        //=============================================================
        //======================= ATTRIBUTE SET =======================
        //=============================================================
        private void metroTile8_Click(object sender, EventArgs e)
        {
            panelControl(1);
            string tableName = "attributeSet";

            metroGrid2.DataSource = null;

            string query = Queries.attributeSet2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributesetGrid.DataSource = ds.Tables[tableName];

            attributesetGrid.Columns[0].Width = 30;
        }
        //=============================================================
        //======================= ATTRIBUTE VALUE =====================
        //=============================================================
        private void metroTile9_Click(object sender, EventArgs e)
        {
            panelControl(2);

            string tableName = "products";
            metroGrid4.DataSource = null;

            string query = Queries.attributeValues2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributeValueGrid.DataSource = ds.Tables[tableName];

            attributeValueGrid.Columns[0].Width = 30;
            attributeValueGrid.Columns[1].Width = 100;


        }
        //=============================================================
        //======================= PROVINCE ============================
        //=============================================================
        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);

            string tableName = "province";

            metroGrid3.DataSource = null;

            string query = Queries.province;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                provinceGrid.DataSource = ds.Tables[tableName];

            provinceGrid.Columns[0].Width = 30;
        }
        //=============================================================
        //======================= DISTRICT ============================
        //=============================================================
        private void metroTile11_Click(object sender, EventArgs e)
        {
            panelControl(4);
        }
        //=============================================================
        //======================= EMPLOYEE ============================
        //=============================================================
        private void metroTile12_Click(object sender, EventArgs e)
        {
            panelControl(5);
        }

        void panelControl(int p)
        {
            bool[] panels = new bool[6];
            for (int i = 0; i < 6; i++)
                if (i == p)
                    panels[i] = true;
                else panels[i] = false;

            attributePanel.Visible = panels[0];
            attributesetPanel.Visible = panels[1];
            attributevaluePanel.Visible = panels[2];
            provincePanel.Visible = panels[3];
            districtPanel.Visible = panels[4];
            employeePanel.Visible = panels[5];
        }

        private void btnAddAttributeset_Click(object sender, EventArgs e)
        {
            add_attributeset add = new add_attributeset();
            add.ShowDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            attributeSet.id = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            attributeSet.name = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
            
            add_attributeset update = new add_attributeset(true);
            update.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            add_attribute add = new add_attribute();
            add.ShowDialog();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            attribute.id = attributeGrid.Rows[attributeGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            attribute.name = attributeGrid.Rows[attributeGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_attribute update = new add_attribute(true);
            update.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            add_province add = new add_province();
            add.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            province.id = provinceGrid.Rows[provinceGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            province.name = provinceGrid.Rows[provinceGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_province update = new add_province(true);
            update.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            add_attributeValue add = new add_attributeValue();
            add.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            attributeValue.id = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            attributeValue.name = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
            attributeValue.attribute = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[2].Value.ToString();

            add_attributeValue update = new add_attributeValue(true);
            update.ShowDialog();
        }
    }
}
