using MetroFramework.Forms;
using MySql.Data.MySqlClient;
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
    public partial class data_entry : MetroForm

    {
        public data_entry()
        {
            InitializeComponent();
        }
        

        
        private void data_entry_Load(object sender, EventArgs e)
        {
            
        }
        
        private void metroTile2_Click(object sender, EventArgs e)
        {
            panelControl(0);
        }

        //=============================================================
        //======================= Products ============================
        //=============================================================

        private void metroTile1_Click(object sender, EventArgs e)
        {
            string tableName = "products";
            panelControl(1);
            metroGrid2.DataSource= null;
            DataSet ds = Products.getDataSet(Queries.products, tableName);
            if(ds!=null)
                productsGrid.DataSource = ds.Tables[tableName];
        }

        private void metroGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            string tableName = "attributes";
            MessageBox.Show("");
            string pro_ID = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            string query = String.Format(Queries.productsAttributes, pro_ID);
            DataSet ds = Products.getDataSet(query, tableName);
            if (ds != null)
                metroGrid2.DataSource = ds.Tables[tableName];
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            add_product add = new add_product();
            add.ShowDialog();
        }

        //=============================================================
        //=======================          ============================
        //=============================================================
        private void metroTile9_Click(object sender, EventArgs e)
        {
            panelControl(2);
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            panelControl(4);
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            panelControl(5);
        }


        void panelControl (int p)
        {
            bool [] panels = new bool[6];
            for(int i=0;  i<6; i++)
                if (i == p)
                    panels[i] = true;
                else panels[i] = false;

            overviewPanel.Visible = panels[0];
            productsPanel.Visible = panels[1];
            ordersPanel.Visible = panels[2];
            costumersPanel.Visible = panels[3];
            suppliersPanel.Visible = panels[4];
            accountingPanel.Visible = panels[5];
        }

        
    }
}
