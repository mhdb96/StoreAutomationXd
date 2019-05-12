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
    public partial class add_orders : MetroForm
    {
        bool update = false;
        Order myOrdr = new Order();
        string type; 
        public add_orders(string t)
        {
            InitializeComponent();
            type = t;

        }

        public add_orders(string t,Order order)
        {
            InitializeComponent();
            type = t;
            myOrdr = order;
            update = true;

        }

        private void add_orders_Load(object sender, EventArgs e)
        {
            if (!update)
            {
                string tableName;
                DataSet ds;
                if (type == "buy")
                {
                    metroLabel2.Text = "choose a supplier";
                    tableName = "Suppliers";
                    ds = DbCommand.getDataSet(Queries.ordersSuppliers, tableName);
                    if (ds != null)
                    {
                        cusList.DisplayMember = "sup_name";
                        cusList.ValueMember = "supplier_ID";
                        cusList.DataSource = ds.Tables[tableName];
                        cusList.SelectedItem = null;
                        cusList.PromptText = "Choose from the list";
                    }
                    string query = String.Format(Queries.newID, "Buy_ID", "buy");
                    ds = DbCommand.getDataSet(query, tableName);
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(Buy_ID)"]) + 1).ToString();
                }
                else
                {
                    tableName = "Cutomers";
                    ds = DbCommand.getDataSet(Queries.ordersCustomers, tableName);
                    if (ds != null)
                    {
                        cusList.DisplayMember = "name";
                        cusList.ValueMember = "customer_ID";
                        cusList.DataSource = ds.Tables[tableName];
                        cusList.SelectedItem = null;
                        cusList.PromptText = "Choose from the list";

                    }
                    string query = String.Format(Queries.newID, "sell_ID", "sell");
                    ds = DbCommand.getDataSet(query, tableName);
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(sell_ID)"]) + 1).ToString();
                }

                tableName = "Products";
                ds = DbCommand.getDataSet(Queries.ordersProducts, tableName);
                if (ds != null)
                {
                    proList.DisplayMember = "pro_name";
                    proList.ValueMember = "product_ID";
                    proList.DataSource = ds.Tables[tableName];
                    proList.SelectedItem = null;
                    proList.PromptText = "Choose from the list";
                }
                
                
            }
            else
            {
                addOrderBtn.Text = "Update";
                metroButton1.Visible = false;
                metroLabel1.Text = "product";
                cusList.Enabled = false;
                cusList.PromptText = myOrdr.cusName;
                proList.Enabled = false;
                proList.PromptText = myOrdr.proName;
                ID.Text = myOrdr.id;
                Price.Text = myOrdr.price;
                metroDateTime1.Text = myOrdr.date;
                Qty.Text = myOrdr.qty;

                if (type == "buy")
                {
                    metroLabel2.Text = "supplier:";
                    
                }
                else
                {
                    metroLabel2.Text = "customer:";
                }
            }
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }



        private void cusList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                myOrdr.type = type;
                myOrdr.id = ID.Text;
                myOrdr.cusID = cusList.SelectedValue.ToString();
                myOrdr.proID = proList.SelectedValue.ToString();
                myOrdr.price = Price.Text;
                myOrdr.qty = Qty.Text;
                myOrdr.date = metroDateTime1.Value.ToString("yyyy-MM-dd  HH:mm:ss");
                string tableName = type;
                string query = "";
                if (type == "buy")
                    query = String.Format(Queries.insBuy, myOrdr.id, myOrdr.proID, myOrdr.cusID, myOrdr.price, myOrdr.date, myOrdr.qty);
                else
                    query = String.Format(Queries.insSell, myOrdr.id, myOrdr.cusID, myOrdr.proID, myOrdr.price, myOrdr.date, myOrdr.qty);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                myOrdr.type = type;
                myOrdr.price = Price.Text;
                myOrdr.qty = Qty.Text;
                myOrdr.date = metroDateTime1.Value.ToString("yyyy-MM-dd  HH:mm:ss");

                string tableName = type;
                string query = "";
                if (type == "buy")
                    query = String.Format(Queries.upBuy, myOrdr.price, myOrdr.date, myOrdr.qty,myOrdr.id);
                else
                    query = String.Format(Queries.upSell,myOrdr.price, myOrdr.date, myOrdr.qty, myOrdr.id);
                DbCommand.insertIntoDb(query);
            }

            
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
