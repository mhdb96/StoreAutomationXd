using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
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
        int controlAc = 0;

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
            string tableName = "Customers";


            //SQL kodunu Queries sınıfından çekip string değişkene attı
            //Ardından string değişkenindeki kodu kullanılarak DbCommand sınıfından
            //verileri alıp DataSet değişkenine attı

            DataSet ds = DbCommand.getDataSet(Queries.customers, tableName);
            //
            //Gelen veriler productsGrid'e aktardı
            if (ds != null)
                customersGrid.DataSource = ds.Tables[tableName];

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

        private void activityTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlAc = 0;
            activityList.Visible = true;
            accountingGrid.Enabled = true;
            string tableName = "Accounting";
            if (activityTypeList.SelectedIndex == 0)//income
            {
                DataSet ds = DbCommand.getDataSet(Queries.incomes, tableName);

                if (ds != null)
                    accountingGrid.DataSource = ds.Tables[tableName];
                string query = String.Format(Queries.activity, "1");
                ds = DbCommand.getDataSet(query, tableName);

                if (ds != null)
                {
                    activityList.DisplayMember = "act_name";
                    activityList.ValueMember = "activity_ID";
                    activityList.DataSource = ds.Tables[tableName];
                    activityList.SelectedItem = null;
                    activityList.PromptText = "Choose from the list";
                }

            }
            else if (activityTypeList.SelectedIndex == 1) //expense
            {
                DataSet ds = DbCommand.getDataSet(Queries.expenses, tableName);
                if (ds != null)
                    accountingGrid.DataSource = ds.Tables[tableName];

                string query = String.Format(Queries.activity, "2");
                ds = DbCommand.getDataSet(query, tableName);

                if (ds != null)
                {
                    activityList.DisplayMember = "act_name";
                    activityList.ValueMember = "activity_ID";
                    activityList.DataSource = ds.Tables[tableName];
                    activityList.SelectedItem = null;
                    activityList.PromptText = "Choose from the list";
                }
            }
        }

        private void activityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = "type";
            string query;
            DataSet ds;
            if (activityList.SelectedItem != null && controlAc >= 2)
            {
                if (activityTypeList.SelectedIndex == 0)//income
                {

                    query = String.Format(Queries.incomesType, activityList.SelectedValue.ToString());
                    ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                        accountingGrid.DataSource = ds.Tables[tableName];

                }
                else if (activityTypeList.SelectedIndex == 1) //expense
                {
                    query = String.Format(Queries.expensesType, activityList.SelectedValue.ToString());
                    ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                        accountingGrid.DataSource = ds.Tables[tableName];
                }
            }
            controlAc++;
        }

        private void addAccountingBtn_Click(object sender, EventArgs e)
        {
            Activity myAct = new Activity();
            if (activityTypeList.SelectedIndex == 0)//income
            {
                add_activity add = new add_activity(Activity.type[0]);
                add.ShowDialog();

            }
            else if (activityTypeList.SelectedIndex == 1) //expense
            {
                add_activity add = new add_activity(Activity.type[1]);
                add.ShowDialog();
            }
        }

        private void updateAccountingBtn_Click(object sender, EventArgs e)
        {
            if (accountingGrid.SelectedRows.Count != 0)
            {
                string type;
                Activity myAct = new Activity();

                myAct.ID = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                myAct.desc = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
                myAct.ammount = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
                myAct.activityName = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
                
                if (activityTypeList.SelectedIndex == 0)
                {
                    type = Activity.type[0]; //income 
                    string tableName = "IncomeData";
                    string query = String.Format(Queries.incomesData, myAct.ID);
                    DataSet ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        
                        myAct.activityID = ds.Tables[tableName].Rows[0]["activity_ID"].ToString();
                    }
                }
                else
                {
                    type = Activity.type[1]; //expense
                    string tableName = "SellData";
                    string query = String.Format(Queries.expensesData, myAct.ID);
                    DataSet ds = DbCommand.getDataSet(query, tableName);
                    if (ds != null)
                    {
                        myAct.activityID = ds.Tables[tableName].Rows[0]["activity_ID"].ToString();
                    }
                }
                add_activity update = new add_activity(type,myAct);
                update.ShowDialog();
            }
            else
                MetroMessageBox.Show(this, "You must choose an order before trying to update it", "Update Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void deleteAccountingBtn_Click(object sender, EventArgs e)
        {
            if (accountingGrid.SelectedRows.Count != 0)
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    Activity myAct = new Activity();
                    string type;
                    if (activityTypeList.SelectedIndex == 0)
                    {
                        type = Activity.type[0]; //income
                        myAct.ID = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                        string query = String.Format(Queries.delIncome, myAct.ID);
                        DbCommand.insertIntoDb(query);
                        //metroTile1_Click(sender, e);
                    }
                    else
                    {
                        type = Activity.type[1]; //expense
                        myAct.ID = accountingGrid.Rows[accountingGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                        string query = String.Format(Queries.delExpense, myAct.ID);
                        DbCommand.insertIntoDb(query);
                        //metroTile1_Click(sender, e);
                    }
                }
            }
            else
                MetroMessageBox.Show(this, "You must choose a product before trying to delete it", "Deletion Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

            MetroPanel[] pa = new MetroPanel[6];
            pa[0] = overviewPanel;
            pa[1] = productsPanel;
            pa[2] = ordersPanel;
            pa[3] = costumersPanel;
            pa[4] = suppliersPanel;
            pa[5] = accountingPanel;

            foreach(MetroPanel myp in pa)
            {
                myp.Size = new Size(900, 550);
                myp.Location = new Point(150, 20);
                myp.BackColor = Color.White;

            }
        }

        private void productsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            



        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productsOverviewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productsTile_Click(object sender, EventArgs e)
        {
            suppliersTable.Visible = false;
            productsOverviewPanel.Visible = true;
            tableLayoutPanel4.Visible = true;
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            customersTable.Visible = false;

            string tableName = "products";
            string query;

            DataSet ds = DbCommand.getDataSet(Queries.productsCount, tableName);

            int productsCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.attributeSetsCount, tableName);
            int attributeSetsCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.attributeSets, tableName);

            int[,] count_ID = new int[attributeSetsCount, 2];
            int[,] count_ID2 = new int[4, 2];
            for (int i = 0; i < attributeSetsCount; i++)
            {
                string attributeSetID = ds.Tables[tableName].Rows[i]["attributeSet_ID"].ToString();
                count_ID[i, 1] = (int)ds.Tables[tableName].Rows[i]["attributeSet_ID"];
                query = String.Format(Queries.pro_setCount, attributeSetID);
                DataSet pro_setCountDs = DbCommand.getDataSet(query, tableName);
                count_ID[i, 0] = Int32.Parse(pro_setCountDs.Tables[tableName].Rows[0]["count(*)"].ToString());
            }
            int r = 0;
            for (int i = 0; i < 4; i++)
            {
                int max = -1;
                int id = -1;
                for (int j = 0; j < attributeSetsCount; j++)
                {

                    if (count_ID[j, 0] > max)
                    {
                        max = count_ID[j, 0];
                        id = count_ID[j, 1];
                        r = j;

                    }

                }
                count_ID2[i, 0] = max;
                count_ID2[i, 1] = id;
                count_ID[r, 0] = -2;

            }
            query = String.Format(Queries.attributeSetName, count_ID2[0, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel6.Text = ds.Tables[tableName].Rows[0]["set_name"].ToString();
            metroProgressBar1.Value = (100 * count_ID2[0, 0]) / productsCount;

            query = String.Format(Queries.attributeSetName, count_ID2[1, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel7.Text = ds.Tables[tableName].Rows[0]["set_name"].ToString();
            metroProgressBar2.Value = (100 * count_ID2[1, 0]) / productsCount;

            query = String.Format(Queries.attributeSetName, count_ID2[2, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel8.Text = ds.Tables[tableName].Rows[0]["set_name"].ToString();
            metroProgressBar3.Value = (100 * count_ID2[2, 0]) / productsCount;

            int t = count_ID2[3, 1];
            query = String.Format(Queries.attributeSetName, count_ID2[3, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel9.Text = ds.Tables[tableName].Rows[0]["set_name"].ToString();
            metroProgressBar4.Value = (100 * count_ID2[3, 0]) / productsCount;


            ds = DbCommand.getDataSet(Queries.last5Pro, tableName);
            productsOverviewGrid.DataSource = ds.Tables[tableName];

            ds = DbCommand.getDataSet(Queries.reStockPro, tableName);
            reStockProGrid.DataSource = ds.Tables[tableName];


        }

        private void customersTile_Click(object sender, EventArgs e)
        {
            suppliersTable.Visible = false;
            tableLayoutPanel4.Visible = false;
            customersTable.Visible = true;
            customersTable.Dock = DockStyle.Fill;
            string tableName = "products";
            string query;
            DataSet ds;
        
            ds = DbCommand.getDataSet(Queries.last5Sell, tableName);
            sellOverviewGrid.DataSource = ds.Tables[tableName];



            ds = DbCommand.getDataSet(Queries.sellCount, tableName);

            int sellCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.customersCount, tableName);
            int customersCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.customersData, tableName);

            int[,] count_ID = new int[customersCount, 2];
            int[,] count_ID2 = new int[4, 2];
            for (int i = 0; i < customersCount; i++)
            {
                string customerID = ds.Tables[tableName].Rows[i]["customer_ID"].ToString();
                count_ID[i, 1] = (int)ds.Tables[tableName].Rows[i]["customer_ID"];
                query = String.Format(Queries.sell_cusCount, customerID);
                DataSet sell_cusCountDs = DbCommand.getDataSet(query, tableName);
                count_ID[i, 0] = Int32.Parse(sell_cusCountDs.Tables[tableName].Rows[0]["count(*)"].ToString());
            }
            int r = 0;
            for (int i = 0; i < 4; i++)
            {
                int max = -1;
                int id = -1;
                for (int j = 0; j < customersCount; j++)
                {

                    if (count_ID[j, 0] > max)
                    {
                        max = count_ID[j, 0];
                        id = count_ID[j, 1];
                        r = j;

                    }

                }
                count_ID2[i, 0] = max;
                count_ID2[i, 1] = id;
                count_ID[r, 0] = -2;

            }
            query = String.Format(Queries.customersName, count_ID2[0, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel10.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar5.Value = (100 * count_ID2[0, 0]) / sellCount;

            query = String.Format(Queries.customersName, count_ID2[1, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel11.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar6.Value = (100 * count_ID2[1, 0]) / sellCount;

            query = String.Format(Queries.customersName, count_ID2[2, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel12.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar7.Value = (100 * count_ID2[2, 0]) / sellCount;

            int t = count_ID2[3, 1];
            query = String.Format(Queries.customersName, count_ID2[3, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel13.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar8.Value = (100 * count_ID2[3, 0]) / sellCount;


            ds = DbCommand.getDataSet(Queries.districtsCount, tableName);

            int districtCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.customersCount, tableName);
            customersCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.districtData, tableName);

            count_ID = new int[districtCount, 2];
            count_ID2 = new int[3, 2];
            for (int i = 0; i < districtCount; i++)
            {
                string districtID = ds.Tables[tableName].Rows[i]["district_ID"].ToString();
                count_ID[i, 1] = (int)ds.Tables[tableName].Rows[i]["district_ID"];
                query = String.Format(Queries.sell_cusCount, districtID);
                DataSet dis_cusCountDs = DbCommand.getDataSet(query, tableName);
                count_ID[i, 0] = Int32.Parse(dis_cusCountDs.Tables[tableName].Rows[0]["count(*)"].ToString());
            }
            r = 0;
            for (int i = 0; i < 3; i++)
            {
                int max = -1;
                int id = -1;
                for (int j = 0; j < districtCount; j++)
                {

                    if (count_ID[j, 0] > max)
                    {
                        max = count_ID[j, 0];
                        id = count_ID[j, 1];
                        r = j;

                    }

                }
                count_ID2[i, 0] = max;
                count_ID2[i, 1] = id;
                count_ID[r, 0] = -2;

            }
            query = String.Format(Queries.districName, count_ID2[0, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel14.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar9.Value = (100 * count_ID2[0, 0]) / customersCount;

            query = String.Format(Queries.districName, count_ID2[1, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel15.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar10.Value = (100 * count_ID2[1, 0]) / customersCount;

            query = String.Format(Queries.districName, count_ID2[2, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel16.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar11.Value = (100 * count_ID2[2, 0]) / customersCount;     





        }

        private void suppliersTile_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Visible = false;
            customersTable.Visible = false;
            suppliersTable.Visible = true;
            suppliersTable.Dock = DockStyle.Fill;
            string tableName = "Buy";
            string query;
            DataSet ds;

            ds = DbCommand.getDataSet(Queries.last5Buy, tableName);
            suppliersOverviewGrid.DataSource = ds.Tables[tableName];



            ds = DbCommand.getDataSet(Queries.buyCount, tableName);

            int buyCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.suppliersCount, tableName);
            int suppliersCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.suppliersData, tableName);

            int[,] count_ID = new int[suppliersCount, 2];
            int[,] count_ID2 = new int[4, 2];
            for (int i = 0; i < suppliersCount; i++)
            {
                string supplierID = ds.Tables[tableName].Rows[i]["supplier_ID"].ToString();
                count_ID[i, 1] = (int)ds.Tables[tableName].Rows[i]["supplier_ID"];
                query = String.Format(Queries.buy_supCount, supplierID);
                DataSet buy_supCountDs = DbCommand.getDataSet(query, tableName);
                count_ID[i, 0] = Int32.Parse(buy_supCountDs.Tables[tableName].Rows[0]["count(*)"].ToString());
            }
            int r = 0;
            for (int i = 0; i < 4; i++)
            {
                int max = -1;
                int id = -1;
                for (int j = 0; j < suppliersCount; j++)
                {

                    if (count_ID[j, 0] > max)
                    {
                        max = count_ID[j, 0];
                        id = count_ID[j, 1];
                        r = j;

                    }

                }
                count_ID2[i, 0] = max;
                count_ID2[i, 1] = id;
                count_ID[r, 0] = -2;

            }
            query = String.Format(Queries.suppliersName, count_ID2[0, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel17.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar12.Value = (100 * count_ID2[0, 0]) / buyCount;

            query = String.Format(Queries.suppliersName, count_ID2[1, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel18.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar13.Value = (100 * count_ID2[1, 0]) / buyCount;

            query = String.Format(Queries.suppliersName, count_ID2[2, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel19.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar14.Value = (100 * count_ID2[2, 0]) / buyCount;

            int t = count_ID2[3, 1];
            query = String.Format(Queries.suppliersName, count_ID2[3, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel20.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar15.Value = (100 * count_ID2[3, 0]) / buyCount;


            ds = DbCommand.getDataSet(Queries.districtsCount, tableName);

            int districtCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.suppliersCount, tableName);
            suppliersCount = Int32.Parse(ds.Tables[tableName].Rows[0]["count(*)"].ToString());
            ds = DbCommand.getDataSet(Queries.districtData, tableName);

            count_ID = new int[districtCount, 2];
            count_ID2 = new int[3, 2];
            for (int i = 0; i < districtCount; i++)
            {
                string districtID = ds.Tables[tableName].Rows[i]["district_ID"].ToString();
                count_ID[i, 1] = (int)ds.Tables[tableName].Rows[i]["district_ID"];
                query = String.Format(Queries.buy_supCount, districtID);
                DataSet dis_cusCountDs = DbCommand.getDataSet(query, tableName);
                count_ID[i, 0] = Int32.Parse(dis_cusCountDs.Tables[tableName].Rows[0]["count(*)"].ToString());
            }
            r = 0;
            for (int i = 0; i < 3; i++)
            {
                int max = -1;
                int id = -1;
                for (int j = 0; j < districtCount; j++)
                {

                    if (count_ID[j, 0] > max)
                    {
                        max = count_ID[j, 0];
                        id = count_ID[j, 1];
                        r = j;

                    }

                }
                count_ID2[i, 0] = max;
                count_ID2[i, 1] = id;
                count_ID[r, 0] = -2;

            }
            query = String.Format(Queries.districName, count_ID2[0, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel21.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar16.Value = (100 * count_ID2[0, 0]) / suppliersCount;

            query = String.Format(Queries.districName, count_ID2[1, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel22.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar17.Value = (100 * count_ID2[1, 0]) / suppliersCount;

            query = String.Format(Queries.districName, count_ID2[2, 1].ToString());
            ds = DbCommand.getDataSet(query, tableName);
            metroLabel23.Text = ds.Tables[tableName].Rows[0]["name"].ToString();
            metroProgressBar18.Value = (100 * count_ID2[2, 0]) / suppliersCount;
        }

        private void accountingTile_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Visible = false;
            customersTable.Visible = false;
            suppliersTable.Visible = false;
            accountingTable.Visible = true;
            accountingTable.Dock = DockStyle.Fill;

            string tableName = "Buy";
            string query;
            DataSet ds;

            ds = DbCommand.getDataSet(Queries.last5Incomes, tableName);
            incomesOverviewGrid.DataSource = ds.Tables[tableName];

            ds = DbCommand.getDataSet(Queries.last5Expenses, tableName);
            expensesOverviewGrid.DataSource = ds.Tables[tableName];




        }
    }
}
