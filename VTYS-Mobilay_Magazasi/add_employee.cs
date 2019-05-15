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
                ID.Text = ((int)(ds.Tables[tableName].Rows[0]["max(employee_ID)"]) + 1).ToString();
            }
            else
            {
                metroButton1.Text = "Update";
                ID.Text = employee.id;
                name.Text = employee.name;
                lastName.Text = employee.lastName;
                telephone.Text = employee.tel;
                TC.Text = employee.tc;
                adress.Text = employee.adress;
                salary.Text = employee.salary;

                string tableName = "Department";
                DataSet ds;

                ds = DbCommand.getDataSet(Queries.department, tableName);


                if (ds != null)
                {
                    departmentList.DisplayMember = "Name";
                    departmentList.ValueMember = "ID";
                    departmentList.DataSource = ds.Tables[tableName];
                    for (int u = 0; u < departmentList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["Name"].ToString() == employee.department)
                            departmentList.SelectedIndex = u;

                    provinceList.PromptText = employee.department;
                    
                }
                tableName = "Province";
                ds = DbCommand.getDataSet(Queries.province2, tableName);
                if (ds != null)
                {
                    provinceList.DisplayMember = "prov_name";
                    provinceList.ValueMember = "province_ID";
                    provinceList.DataSource = ds.Tables[tableName];


                    for (int u = 0; u < provinceList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["prov_name"].ToString() == employee.provice)
                            provinceList.SelectedIndex = u;

                    provinceList.PromptText = employee.provice;
                }
                tableName = "District";
                string query = String.Format(Queries.districtProvince, provinceList.SelectedValue.ToString());
                
                ds = DbCommand.getDataSet(query, tableName);
                if (ds != null)
                {
                    districtList.DisplayMember = "dis_ID";
                    districtList.ValueMember = "district_ID";
                    districtList.DataSource = ds.Tables[tableName];

                    for (int u = 0; u < districtList.Items.Count; u++)
                        if (ds.Tables[tableName].Rows[u]["dis_ID"].ToString() == employee.district)
                            districtList.SelectedIndex = u;

                    districtList.PromptText = employee.district;


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
                    districtList.DisplayMember = "dis_ID";
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
                employee.id = ID.Text;
                employee.name = name.Text;
                employee.lastName = lastName.Text;
                employee.tc = TC.Text;
                employee.tel = telephone.Text;
                employee.adress = adress.Text;
                employee.district = districtList.SelectedValue.ToString();
                employee.provice = provinceList.SelectedValue.ToString();
                employee.department = departmentList.SelectedValue.ToString();
                employee.salary = salary.Text;

                string query = String.Format(Queries.insEmployee, employee.id, employee.name, employee.lastName, employee.tc, employee.tel, employee.adress, employee.district, employee.provice, employee.department, employee.salary);
                DbCommand.insertIntoDb(query);

            }
            else
            {
                employee.id = ID.Text;
                employee.name = name.Text;
                employee.lastName = lastName.Text;
                employee.tc = TC.Text;
                employee.tel = telephone.Text;
                employee.adress = adress.Text;
                employee.district = districtList.SelectedValue.ToString();
                employee.provice = provinceList.SelectedValue.ToString();
                employee.department = departmentList.SelectedValue.ToString();
                employee.salary = salary.Text;

                string query = String.Format(Queries.upEmployee, employee.name, employee.lastName, employee.tc, employee.tel, employee.adress, employee.district, employee.provice, employee.department, employee.salary, employee.id);
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
