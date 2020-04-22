using DataAccess;
using MetroFramework.Forms;
using Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace StoreAutomationUI
{
    public partial class add_supplier : MetroForm
    {
        SupplierModel mySup = new SupplierModel();
        int controlP = 0;
        bool update = false;

        public add_supplier()
        {
            InitializeComponent();
        }

        public add_supplier(SupplierModel sup)
        {
            InitializeComponent();
            update = true;
            mySup = sup;
        }

        private void add_supplier_Load(object sender, EventArgs e)
        {
            ID.Enabled = false;
            if (!update)
            {
                string tableName = "Customers";
                DataSet ds;
                districtList.Enabled = false;

                ds = DbCommand.getDataSet(Queries.suppliersProvince, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];
                    provinceList.SelectedItem = null;
                    provinceList.PromptText = "Choose from the list";
                }


                string query = string.Format(Queries.newID, "supplier_ID", "supplier");
                ds = DbCommand.getDataSet(query, tableName);

                try
                {
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(supplier_ID)"]) + 1).ToString();
                }
                catch (Exception)
                {
                    ID.Text = "1";
                }


            }
            else
            {
                addSupplierBtn.Text = "Update";
                ID.Text = mySup.id;
                name.Text = mySup.name;
                telephone.Text = mySup.telephone;
                adress.Text = mySup.adress;
                string tableName = "Province";
                DataSet ds;

                ds = DbCommand.getDataSet(Queries.suppliersProvince, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];


                    for (int u = 0; u < provinceList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["province_ID"].ToString() == mySup.provinceID)
                            provinceList.SelectedIndex = u;

                    provinceList.PromptText = mySup.provinceName;
                }
                tableName = "District";
                string query = string.Format(Queries.suppliersDistrict, mySup.provinceID);
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    districtList.DisplayMember = "dis_name";
                    districtList.ValueMember = "district_ID";
                    districtList.DataSource = ds.Tables[tableName];

                    for (int u = 0; u < districtList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["district_ID"].ToString() == mySup.districtID)
                            districtList.SelectedIndex = u;

                    districtList.PromptText = mySup.districtName;
                }
            }



        }

        private void telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                mySup.id = ID.Text;
                mySup.name = name.Text;
                mySup.telephone = telephone.Text;
                mySup.adress = adress.Text;
                mySup.provinceID = provinceList.SelectedValue.ToString();
                mySup.districtID = districtList.SelectedValue.ToString();
                string query = string.Format(Queries.insSupplier, mySup.id, mySup.name, mySup.telephone, mySup.adress, mySup.provinceID, mySup.districtID);
                DbCommand.insertIntoDb(query);
            }
            else
            {
                mySup.name = name.Text;
                mySup.telephone = telephone.Text;
                mySup.adress = adress.Text;
                mySup.provinceID = provinceList.SelectedValue.ToString();
                mySup.districtID = districtList.SelectedValue.ToString();
                string query = string.Format(Queries.upSupplier, mySup.name, mySup.telephone, mySup.adress, mySup.provinceID, mySup.districtID, mySup.id);
                DbCommand.insertIntoDb(query);
            }


            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void provinceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provinceList.SelectedItem != null && controlP >= 2)
            {
                string tableName = "District";
                string query = string.Format(Queries.customersDistrict, provinceList.SelectedValue.ToString());
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
    }
}
