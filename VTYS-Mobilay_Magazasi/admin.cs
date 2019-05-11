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
        public admin(bool u)
        {
            InitializeComponent();
            update = u;
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
        }
        //=============================================================
        //======================= PROVINCE ============================
        //=============================================================
        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);
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
            add_attributeset update = new add_attributeset();
            update.ShowDialog();
        }
    }
}
