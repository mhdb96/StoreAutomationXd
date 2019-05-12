using MetroFramework.Forms;
using MetroFramework;
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
            if (productsGrid.SelectedRows.Count != 0)
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
                for (int i = 0; i < myPro.count; i++)
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
                add_product update = new add_product(myPro, true);
                update.ShowDialog();
            }
            else
                MetroMessageBox.Show(this, "You must choose a product before trying to update it", "Update Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (productsGrid.SelectedRows.Count != 0)
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(dr == DialogResult.Yes)
                {
                    Products myPro = new Products();
                    myPro.id = productsGrid.Rows[productsGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                    string query = String.Format(Queries.delProductAtt, myPro.id);
                    DbCommand.insertIntoDb(query);
                    query = String.Format(Queries.delProduct, myPro.id);
                    DbCommand.insertIntoDb(query);
                    metroTile1_Click(sender, e);
                }
                
            }
            else MetroMessageBox.Show(this,"You must choose a product before trying to delete it","Deletion Erorr",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            

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
            ordersGrid.Enabled = false;

        }

        private void orderTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ordersGrid.Enabled = true;
            string tableName = "orders";
            if(orderTypelist.SelectedIndex == 0)//buy
            {
                DataSet ds = DbCommand.getDataSet(Queries.buy, tableName);

                if (ds != null)
                    ordersGrid.DataSource = ds.Tables[tableName];
            }
            else if (orderTypelist.SelectedIndex == 1) //sell
            {
                DataSet ds = DbCommand.getDataSet(Queries.sell, tableName);
                if (ds != null)
                    ordersGrid.DataSource = ds.Tables[tableName];
            }
            ordersGrid.Columns[0].Width = 80;
            ordersGrid.Columns[3].Width = 50;
            ordersGrid.Columns[4].Width = 150;
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            string type;
            if (orderTypelist.SelectedIndex == 0)
                type = "buy"; //buy
            else
                type = "sell"; //sell
            add_orders add = new add_orders(type);
            add.ShowDialog();
        }

        private void updateOrderBtn_Click(object sender, EventArgs e)
        {
            if (ordersGrid.SelectedRows.Count != 0)
            {
                string type;
                Order myOrdr = new Order();
                myOrdr.id = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                myOrdr.cusName = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
                myOrdr.proName = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
                myOrdr.price = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
                myOrdr.qty = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[5].Value.ToString();
                if (orderTypelist.SelectedIndex == 0)
                {
                    type = "buy"; //buy
                    myOrdr.type = type;
                    string tableName = "BuyData";
                    string query = String.Format(Queries.buyData, myOrdr.id);
                    DataSet ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        myOrdr.proID = ds.Tables[tableName].Rows[0]["product_ID"].ToString();
                        myOrdr.date = ds.Tables[tableName].Rows[0]["buy_date"].ToString();
                        myOrdr.cusID = ds.Tables[tableName].Rows[0]["supplier_ID"].ToString();
                    }
                } 
                else
                {
                    type = "sell"; //sell
                    myOrdr.type = type;
                    string tableName = "SellData";
                    string query = String.Format(Queries.sellData, myOrdr.id);
                    DataSet ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        myOrdr.proID = ds.Tables[tableName].Rows[0]["product_ID"].ToString();
                        myOrdr.date = ds.Tables[tableName].Rows[0]["sel_date"].ToString();
                        myOrdr.cusID = ds.Tables[tableName].Rows[0]["customer_ID"].ToString();
                    }
                }
                add_orders update = new add_orders(type, myOrdr);
                update.ShowDialog();
            }
            else
                MetroMessageBox.Show(this, "You must choose an order before trying to update it", "Update Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (ordersGrid.SelectedRows.Count != 0)
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    Order myOrdr = new Order();
                    string type;
                    if (orderTypelist.SelectedIndex == 0)
                    {
                        type = "buy"; //Buy
                        myOrdr.id = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                        string query = String.Format(Queries.delBuy, myOrdr.id);
                        DbCommand.insertIntoDb(query);
                        //metroTile1_Click(sender, e);
                    }
                    else
                    {
                        type = "sell"; //sell
                        myOrdr.id = ordersGrid.Rows[ordersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                        string query = String.Format(Queries.delSell, myOrdr.id);
                        DbCommand.insertIntoDb(query);
                        //metroTile1_Click(sender, e);
                    }
                }
            }
            else
                MetroMessageBox.Show(this, "You must choose a product before trying to delete it", "Deletion Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //=============================================================
        //======================= CUSTOMERS ===========================
        //=============================================================
        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);
            string tableName = "Customers";
            

            //SQL kodunu Queries sınıfından çekip string değişkene attı
            //Ardından string değişkenindeki kodu kullanılarak DbCommand sınıfından
            //verileri alıp DataSet değişkenine attı

            DataSet ds = DbCommand.getDataSet(Queries.customers, tableName);
            //
            //Gelen veriler productsGrid'e aktardı
            if (ds != null)
                customersGrid.DataSource = ds.Tables[tableName];
            //
            //productsGrid'n sütün genişlikleri manuel olarak ayarladı
            customersGrid.Columns[0].Width = 30;
            customersGrid.Columns[1].Width = 150;
            customersGrid.Columns[2].Width = 85;
            customersGrid.Columns[3].Width = 85;
            customersGrid.Columns[4].Width = 150;
            customersGrid.Columns[5].Width = 100;
            customersGrid.Columns[3].Width = 100;
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            add_customers add = new add_customers();
            add.ShowDialog();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customersGrid.SelectedRows.Count != 0)
            {
                Customer myCstr = new Customer();
                myCstr.id = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                myCstr.telephone = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
                myCstr.TC = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
                myCstr.adress = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[4].Value.ToString();
                myCstr.provinceName = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[5].Value.ToString();
                myCstr.districtName = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[6].Value.ToString();
                string tableName = "CustomerData";
                string query = String.Format(Queries.customerData, myCstr.id);
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    myCstr.provinceID = ds.Tables[tableName].Rows[0]["province_ID"].ToString();
                    myCstr.districtID = ds.Tables[tableName].Rows[0]["district_ID"].ToString();
                    myCstr.name = ds.Tables[tableName].Rows[0]["cus_name"].ToString();
                    myCstr.lastName = ds.Tables[tableName].Rows[0]["cus_lastName"].ToString();
                }
                add_customers update = new add_customers (myCstr);
                update.ShowDialog();
            }
            else
                MetroMessageBox.Show(this, "You must choose an order before trying to update it", "Update Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customersGrid.SelectedRows.Count != 0)
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    Customer myCstr = new Customer();
                    myCstr.id = customersGrid.Rows[customersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                    string query = String.Format(Queries.delCustomer, myCstr.id);
                    DbCommand.insertIntoDb(query);
                    metroTile10_Click(sender, e);
                }
            }
        }

        //=============================================================
        //======================= SUPPLIERS ===========================
        //=============================================================
        private void metroTile11_Click(object sender, EventArgs e)
        {
            panelControl(4);
            string tableName = "Suppliers";


            //SQL kodunu Queries sınıfından çekip string değişkene attı
            //Ardından string değişkenindeki kodu kullanılarak DbCommand sınıfından
            //verileri alıp DataSet değişkenine attı
            
            DataSet ds = DbCommand.getDataSet(Queries.suppliers, tableName);
            //
            //Gelen veriler productsGrid'e aktardı
            if (ds != null)
                suppliersGrid.DataSource = ds.Tables[tableName];
            //
            //productsGrid'n sütün genişlikleri manuel olarak ayarladı
            suppliersGrid.Columns[0].Width = 30;
            suppliersGrid.Columns[1].Width = 150;
            suppliersGrid.Columns[2].Width = 85;
            suppliersGrid.Columns[3].Width = 150;
            suppliersGrid.Columns[4].Width = 100;
            suppliersGrid.Columns[5].Width = 100;

        }

        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            add_supplier add = new add_supplier();
            add.ShowDialog();

        }

        private void updateSupplierBtn_Click(object sender, EventArgs e)
        {
            if (suppliersGrid.SelectedRows.Count != 0)
            {
                Supplier mySup = new Supplier();
                mySup.id = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                mySup.name = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
                mySup.telephone = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
                mySup.adress = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
                mySup.provinceName = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[4].Value.ToString();
                mySup.districtName = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[5].Value.ToString();

                string tableName = "SupplierData";
                string query = String.Format(Queries.supplierData, mySup.id);
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    mySup.provinceID = ds.Tables[tableName].Rows[0]["province_ID"].ToString();
                    mySup.districtID = ds.Tables[tableName].Rows[0]["district_ID"].ToString();
                }
                add_supplier update = new add_supplier(mySup);
                update.ShowDialog();
            }
            else
                MetroMessageBox.Show(this, "You must choose an order before trying to update it", "Update Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void deleteSupplierBtn_Click(object sender, EventArgs e)
        {
            if (suppliersGrid.SelectedRows.Count != 0)
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    Supplier mySup = new Supplier();
                    mySup.id = suppliersGrid.Rows[suppliersGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                    string query = String.Format(Queries.delSuplier, mySup.id);
                    DbCommand.insertIntoDb(query);
                    metroTile11_Click(sender, e);
                }
            }
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

            Panel[] pa = new Panel[6];
            pa[0] = overviewPanel;
            pa[1] = productsPanel;
            pa[2] = ordersPanel;
            pa[3] = costumersPanel;
            pa[4] = suppliersPanel;
            pa[5] = accountingPanel;

            foreach(Panel myp in pa)
            {
                myp.Size = new Size(900, 550);
                myp.Location = new Point(150, 20);
                myp.BackColor = Color.White;

            }
        }

        private void productsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
