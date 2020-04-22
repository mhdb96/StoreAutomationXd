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
using DataAccess;
using Models;

namespace VTYS_Mobilay_Magazasi
{
    public partial class add_customers : MetroForm
    {
        Customer myCstr = new Customer();
        int controlP = 0;
        bool update = false;

        public add_customers()
        {
            InitializeComponent();
        }
        public add_customers(Customer cus)
        {
            InitializeComponent();
            update = true;
            myCstr = cus;
        }

        private void add_customers_Load(object sender, EventArgs e)
        {
            ID.Enabled = false;
            if (!update)
            {
                string tableName = "Customers";
                DataSet ds;
                districtList.Enabled = false;

                ds = DbCommand.getDataSet(Queries.customersProvince, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];
                    provinceList.SelectedItem = null;
                    provinceList.PromptText = "Choose from the list";
                }


                string query = String.Format(Queries.newID, "customer_ID", "customer");
                ds = DbCommand.getDataSet(query, tableName);

                try
                {
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(customer_ID)"]) + 1).ToString();
                }
                catch (Exception ex)
                {
                    ID.Text = "1";
                }

                
            }
            else
            {
                addCustomerBtn.Text = "Update";
                ID.Text = myCstr.id;
                name.Text = myCstr.name;
                lastName.Text= myCstr.lastName;
                telephone.Text = myCstr.telephone;
                TC.Text = myCstr.TC;
                adress.Text = myCstr.adress;

                string tableName = "Province";
                DataSet ds;

                ds = DbCommand.getDataSet(Queries.customersProvince, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];


                    for (int u = 0; u < provinceList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["province_ID"].ToString() == myCstr.provinceID)
                            provinceList.SelectedIndex = u;
                    
                    provinceList.PromptText = myCstr.provinceName;
                }
                tableName = "District";
                string query = String.Format(Queries.customersDistrict, myCstr.provinceID);
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    districtList.DisplayMember = "dis_name";
                    districtList.ValueMember = "district_ID";
                    districtList.DataSource = ds.Tables[tableName];

                    for (int u = 0; u < districtList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["district_ID"].ToString() == myCstr.districtID)
                            districtList.SelectedIndex = u;

                    districtList.PromptText = myCstr.districtName;


                }



            }
            

        }


        private void metroTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void provinceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provinceList.SelectedItem != null && controlP >= 2)
            {
                string tableName = "District";
                string query = String.Format(Queries.customersDistrict, provinceList.SelectedValue.ToString());
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    districtList.DisplayMember = "dis_name";
                    districtList.ValueMember = "district_ID";
                    districtList.DataSource = ds.Tables[tableName];
                    districtList.SelectedItem = null;
                    districtList.PromptText = "Choose from the list";
                }
                districtList.Enabled = true;
            }
            controlP++;
        }

        private void districtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            if(!update)
            {
                myCstr.id = ID.Text;
                myCstr.name = name.Text;
                myCstr.lastName = lastName.Text;
                myCstr.telephone = telephone.Text;
                myCstr.TC = TC.Text;
                myCstr.adress = adress.Text;
                myCstr.provinceID = provinceList.SelectedValue.ToString();
                myCstr.districtID = districtList.SelectedValue.ToString();
                string query = String.Format(Queries.insCustomer, myCstr.id, myCstr.name, myCstr.lastName, myCstr.telephone, myCstr.TC, myCstr.adress, myCstr.provinceID, myCstr.districtID);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                myCstr.name = name.Text;
                myCstr.lastName = lastName.Text;
                myCstr.telephone = telephone.Text;
                myCstr.TC = TC.Text;
                myCstr.adress = adress.Text;
                myCstr.provinceID = provinceList.SelectedValue.ToString();
                myCstr.districtID = districtList.SelectedValue.ToString();

                string query = String.Format(Queries.upCustomer,myCstr.name, myCstr.lastName, myCstr.telephone, myCstr.TC, myCstr.adress, myCstr.provinceID, myCstr.districtID, myCstr.id);
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
