using DataAccess;
using MetroFramework.Forms;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAutomationUI
{
    public partial class add_employee : MetroForm
    {
        bool update;
        int controlP = 0;
        public add_employee()
        {
            InitializeComponent();
        }
        public add_employee(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void add_employee_Load(object sender, EventArgs e)
        {
            ID.Enabled = false;



            if (!update)
            {
                string tableName = "employee";
                DataSet ds;
                districtList.Enabled = false;
                
                ds = DbCommand.getDataSet(Queries.province2, tableName);
                

                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];
                    provinceList.SelectedItem = null;
                    provinceList.PromptText = "Choose from the list";
                }
                ds = DbCommand.getDataSet(Queries.department, tableName);

                if (ds != null)
                {
                    departmentList.DisplayMember = "Name";
                    departmentList.ValueMember = "ID";
                    departmentList.DataSource = ds.Tables[tableName];
                    departmentList.SelectedItem = null;
                    departmentList.PromptText = "Choose from the list";
                }

                string query = String.Format(Queries.newID, "employee_ID", "employee");
                ds = DbCommand.getDataSet(query, tableName);

                try
                {
                    ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(employee_ID)"]) + 1).ToString();
                }
                catch (Exception )
                {
                    ID.Text = "1";
                }

                
            }
            else
            {
                metroButton1.Text = "Update";
                ID.Text = EmployeeModel.id;
                name.Text = EmployeeModel.name;
                lastName.Text = EmployeeModel.lastName;
                telephone.Text = EmployeeModel.tel;
                TC.Text = EmployeeModel.tc;
                adress.Text = EmployeeModel.adress;
                salary.Text = EmployeeModel.salary;

                string tableName = "Department";
                DataSet ds;

                ds = DbCommand.getDataSet(Queries.department, tableName);


                if (ds != null)
                {
                    departmentList.DisplayMember = "Name";
                    departmentList.ValueMember = "ID";
                    departmentList.DataSource = ds.Tables[tableName];
                    for (int u = 0; u < departmentList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["Name"].ToString() == EmployeeModel.department)
                            departmentList.SelectedIndex = u;

                    provinceList.PromptText = EmployeeModel.department;
                    
                }
                tableName = "Province";
                ds = DbCommand.getDataSet(Queries.province2, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];


                    for (int u = 0; u < provinceList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["prov_name"].ToString() == EmployeeModel.provice)
                            provinceList.SelectedIndex = u;

                    provinceList.PromptText = EmployeeModel.provice;
                }
                tableName = "District";
                string query = String.Format(Queries.districtProvince, provinceList.SelectedValue.ToString());
                
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    districtList.DisplayMember = "dis_name";
                    districtList.ValueMember = "district_ID";
                    districtList.DataSource = ds.Tables[tableName];

                    for (int u = 0; u < districtList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["dis_name"].ToString() == EmployeeModel.district)
                            districtList.SelectedIndex = u;

                    districtList.PromptText = EmployeeModel.district;


                }



            }
        }

        private void provinceList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (provinceList.SelectedItem != null && controlP >= 2 || update==true)
            {
                string tableName = "District";
                string query = String.Format(Queries.districtProvince, provinceList.SelectedValue.ToString());
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                EmployeeModel.id = ID.Text;
                EmployeeModel.name = name.Text;
                EmployeeModel.lastName = lastName.Text;
                EmployeeModel.tc = TC.Text;
                EmployeeModel.tel = telephone.Text;
                EmployeeModel.adress = adress.Text;
                EmployeeModel.district = districtList.SelectedValue.ToString();
                EmployeeModel.provice = provinceList.SelectedValue.ToString();
                EmployeeModel.department = departmentList.SelectedValue.ToString();
                EmployeeModel.salary = salary.Text;

                string query = String.Format(Queries.insEmployee, EmployeeModel.id, EmployeeModel.name, EmployeeModel.lastName, EmployeeModel.tc, EmployeeModel.tel, EmployeeModel.adress, EmployeeModel.district, EmployeeModel.provice, EmployeeModel.department, EmployeeModel.salary);
                DbCommand.insertIntoDb(query);

            }
            else
            {
                EmployeeModel.id = ID.Text;
                EmployeeModel.name = name.Text;
                EmployeeModel.lastName = lastName.Text;
                EmployeeModel.tc = TC.Text;
                EmployeeModel.tel = telephone.Text;
                EmployeeModel.adress = adress.Text;
                EmployeeModel.district = districtList.SelectedValue.ToString();
                EmployeeModel.provice = provinceList.SelectedValue.ToString();
                EmployeeModel.department = departmentList.SelectedValue.ToString();
                EmployeeModel.salary = salary.Text;

                string query = String.Format(Queries.upEmployee, EmployeeModel.name, EmployeeModel.lastName, EmployeeModel.tc, EmployeeModel.tel, EmployeeModel.adress, EmployeeModel.district, EmployeeModel.provice, EmployeeModel.department, EmployeeModel.salary, EmployeeModel.id);
                DbCommand.insertIntoDb(query);

            }
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
