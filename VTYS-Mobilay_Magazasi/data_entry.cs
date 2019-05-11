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
        int controlS = 0;
        int controlA = 0;
        int controlV = 0;
        public data_entry()
        {
            InitializeComponent();
        }
        

        //Form Yüklendiğinde Gerçekleşecek Olaylar
        private void data_entry_Load(object sender, EventArgs e)
        {
            
        }

        //=============================================================
        //======================= OVERVIEW ============================
        //=============================================================
        private void metroTile2_Click(object sender, EventArgs e)
        {
            panelControl(0);
        }

        //=============================================================
        //======================= PRODUCTS ============================
        //=============================================================

        //PRODUCTS'a tıklandığında tüm ürünleri gösteren fonksiyon
        private void metroTile1_Click(object sender, EventArgs e)
        {
            string tableName = "products";
            panelControl(1);
            metroGrid2.DataSource= null;

            //SQL kodunu Queries sınıfından çekip string değişkene attı
            //Ardından string değişkenindeki kodu kullanılarak DbCommand sınıfından
            //verileri alıp DataSet değişkenine attı
            string query = String.Format(Queries.products, "product_ID");
            DataSet ds = DbCommand.getDataSet(query, tableName);
            //
            //Gelen veriler productsGrid'e aktardı
            if (ds!=null)
                productsGrid.DataSource = ds.Tables[tableName];
            //
            //productsGrid'n sütün genişlikleri manuel olarak ayarladı
            productsGrid.Columns[0].Width = 30;
            productsGrid.Columns[3].Width = 50;
            productsGrid.Columns[4].Width = 50;
            //
        }

        //Seçilen ürünün özelliklerini farklı bir tabloya aktaran fonksiyon
        private void metroGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            string tableName = "attributes";

            //productsGrid'de tıklanan satırın id'sini alıp string bir değişkene attı
            //Ardından bu id'yi kullanılarak Queries sınıfından SQL kodunu çekip string bir değişkene attı
            //Daha Sonra string değişkenindeki SQL kodu kullanılarak DbCommand sınıfından
            //verileri alıp DataSet değişkenine attı
            string pro_ID = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            string query = String.Format(Queries.productsAttributes, pro_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);
            //
            //Gelen veriler metroGrid2'ye aktardı
            if (ds != null)
                metroGrid2.DataSource = ds.Tables[tableName];
            //
        }

        //add butonuna tıklandığında çalışacak fonksiyon
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //add_product'sınıfından yeni bir nesne tanımlandı ve yeni bir pencerede açıldı
            add_product add = new add_product();
            add.ShowDialog();
            //
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            Products myPro = new Products();
            myPro.name = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
            myPro.desc = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
            myPro.price = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
            myPro.stock = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[4].Value.ToString();
            myPro.set_name = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[5].Value.ToString();
            myPro.id = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

            string tableName = "attributes";
            string name = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[5].Value.ToString();
            string query = String.Format(Queries.set_ID, name);
            DataSet ds = DbCommand.getDataSet(query, tableName);
            if (ds != null)
                myPro.set_id = ds.Tables[tableName].Rows[0]["attributeset_ID"].ToString();

            myPro.count = metroGrid2.Rows.Count;
            myPro.setArrayslength();
            for(int i=0; i<myPro.count; i++)
            {
                name = metroGrid2.Rows[i].Cells[0].Value.ToString();
                query = String.Format(Queries.att_ID, name);
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                    myPro.attribute_id[i] = ds.Tables[tableName].Rows[0]["attribute_ID"].ToString();

                name = metroGrid2.Rows[i].Cells[1].Value.ToString();
                query = String.Format(Queries.attVal_ID, name);
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                    myPro.att_val_id[i] = ds.Tables[tableName].Rows[0]["attributeValue_ID"].ToString();

                myPro.attribute_name[i] = metroGrid2.Rows[i].Cells[0].Value.ToString();
            }
            add_product update = new add_product(myPro,true);
            update.ShowDialog();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (productsGrid.SelectedRows.Count != 0)
            {
                Products myPro = new Products();
                myPro.id = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

                string query = String.Format(Queries.delProductAtt, myPro.id);
                DbCommand.insertIntoDb(query);
                query = String.Format(Queries.delProduct, myPro.id);
                DbCommand.insertIntoDb(query);
                metroTile1_Click(sender, e);
            }
            else MessageBox.Show("sec");
            

        }
        private void filterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterList.SelectedIndex == 0) //Category
            {
                controlS = 0;
                controlA = 0;
                controlV = 0;
                metroButton2.Visible = false;
                logicFilter.Visible = false;
                metroTextBox2.Visible = false;
                metroTextBox3.Visible = false;
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
                attributeSetList.Visible = true;
                attributeList.Visible = false;
                attributeValuesList.Visible = false;
            }
            else if (filterList.SelectedIndex == 1) //Stock
            {
                metroTextBox2.Text = "";
                metroTextBox3.Text = "";
                metroButton2.Visible = true;
                logicFilter.Visible = true;
                logicFilter.SelectedItem = null;
                logicFilter.PromptText = "Choose a filter";
                metroTextBox2.Visible = false;
                metroTextBox3.Visible = false;
                attributeValuesList.Visible = false;
                attributeSetList.Visible = false;
                attributeList.Visible = false;
            }
            else //Price
            {
                metroTextBox2.Text = "";
                metroTextBox3.Text = "";
                metroButton2.Visible = true;
                logicFilter.Visible = true;
                logicFilter.SelectedItem = null;
                logicFilter.PromptText = "Choose a filter";
                metroTextBox2.Visible = false;
                metroTextBox3.Visible = false;
                attributeValuesList.Visible = false;
                attributeSetList.Visible = false;
                attributeList.Visible = false;
            }
        }

        private void logicFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (logicFilter.SelectedIndex == 3)
            {
                metroTextBox2.Visible = true;
                metroTextBox3.Visible = true;
            }
            else
            {
                metroTextBox3.Visible = false;
                metroTextBox2.Visible = true;
            }
        }

        private void attributeSetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlA = 0;
            controlV = 0;
            if (attributeSetList.SelectedItem != null && controlS >= 2)
            {
                string tableName = "attribute";
                string query = String.Format(Queries.setAttributedata, attributeSetList.SelectedValue.ToString());
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    attributeList.DisplayMember = "att_name";
                    attributeList.ValueMember = "attribute_ID";
                    attributeList.DataSource = ds.Tables[tableName];
                    attributeList.SelectedItem = null;
                    attributeList.PromptText = "Choose from the list";
                }
                attributeList.Visible = true;
                attributeValuesList.Visible = false;

                query = String.Format(Queries.productsFiltering, attributeSetList.SelectedValue.ToString());
                ds = DbCommand.getDataSet(query, tableName);
                productsGrid.DataSource = ds.Tables[tableName]; ;
            }
            controlS++;
        }

        private void attributeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlV = 0;
            if (attributeList.SelectedItem != null && controlA >= 2)
            {
                string tableName = "attribute";
                string query = String.Format(Queries.attributeValues, attributeList.SelectedValue.ToString());
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    attributeValuesList.DisplayMember = "val_value";
                    attributeValuesList.ValueMember = "attributeValue_ID";
                    attributeValuesList.DataSource = ds.Tables[tableName];
                    attributeValuesList.SelectedItem = null;
                    attributeValuesList.PromptText = "Choose from the list";
                }
                attributeValuesList.Visible = true;
            }
            controlA++;
        }

        private void attributeValuesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (attributeList.SelectedItem != null && controlV >= 2)
            {
                string tableName = "Products";
                string query = String.Format(Queries.attributeValues, attributeList.SelectedValue.ToString());
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    query = String.Format(Queries.productsFiltering, attributeSetList.SelectedValue.ToString() + " and pa.attributeValue_attributeValue_ID = " + attributeValuesList.SelectedValue.ToString());
                    ds = DbCommand.getDataSet(query, tableName);
                    productsGrid.DataSource = ds.Tables[tableName]; ;
                }
            }
            controlV++;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string filter="";

            if (filterList.SelectedIndex == 1)
                filter = "pro_stock";
            else if (filterList.SelectedIndex == 2)
                filter = "pro_price";
            
            string tableName = "Products";
            string query = "";
            if (logicFilter.SelectedIndex == 3)
                query = String.Format(Queries.productsBetweenFilter, filter, metroTextBox2.Text, metroTextBox3.Text);
            else
                query = String.Format(Queries.productsBasicFilter, filter,logicFilter.SelectedItem.ToString(),metroTextBox2.Text);
            DataSet ds = DbCommand.getDataSet(query, tableName);
            if (ds != null)
            {
                productsGrid.DataSource = ds.Tables[tableName]; ;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string tableName = "Products";
            string query = String.Format(Queries.productsSearch,metroTextBox1.Text);
            DataSet ds = DbCommand.getDataSet(query, tableName);
            if (ds != null)
            {
                productsGrid.DataSource = ds.Tables[tableName]; ;
            }
        }

        //=============================================================
        //======================= ORDERS ==============================
        //=============================================================
        private void metroTile9_Click(object sender, EventArgs e)
        {
            panelControl(2);
        }

        //=============================================================
        //======================= COSTUMERS ===========================
        //=============================================================
        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);
        }

        //=============================================================
        //======================= SUPPLIERS ===========================
        //=============================================================
        private void metroTile11_Click(object sender, EventArgs e)
        {
            panelControl(4);
        }

        //=============================================================
        //======================= ACCOUNTING ==========================
        //=============================================================
        private void metroTile12_Click(object sender, EventArgs e)
        {
            panelControl(5);
        }

        //Tıklanan panelin açılıp diğer panellerin kapanmasını gerçekleştiren kod
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

        private void productsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
