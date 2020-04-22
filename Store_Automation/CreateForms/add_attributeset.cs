using DataAccess;
using MetroFramework;
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
    public partial class add_attributeset : MetroForm
    {
        DataSet MyDs;
        DataSet MyDs1;
        bool update;
        public add_attributeset()
        {
            InitializeComponent();
        }
        public add_attributeset(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                string Id = id.Text;
                string Name = name.Text;
                string query = String.Format(Queries.insAttributeSet, Id, Name);
                DbCommand.insertIntoDb(query);

                for(int i=0; i< setAttributesGrid.Rows.Count; i++)
                {
                    string attId = setAttributesGrid.Rows[i].Cells[0].Value.ToString();
                    query = String.Format(Queries.insAttributeSetAttribute, Id, attId);
                    DbCommand.insertIntoDb(query);
                }
            }
            else
            {
                string query = String.Format(Queries.upAttributeset, name.Text,id.Text);
                DbCommand.insertIntoDb(query);
                string Id = id.Text;
                query = String.Format(Queries.delAttributeSetAttributes, Id);
                DbCommand.insertIntoDb(query);
                for (int i = 0; i < setAttributesGrid.Rows.Count; i++)
                {
                    string attId = setAttributesGrid.Rows[i].Cells[0].Value.ToString();
                    query = String.Format(Queries.insAttributeSetAttribute, Id, attId);
                    DbCommand.insertIntoDb(query);
                }
            }
            this.Close();
        }

        private void add_attributeset_Load(object sender, EventArgs e)
        {
            if (update)
            {
                id.Text = AttributeSetModel.id;
                id.Enabled = false;
                name.Text = AttributeSetModel.name;
                metroButton1.Text = "Update";

                string tableName = "Attributes";
                DataSet ds = DbCommand.getDataSet(Queries.attribute2, tableName);
                MyDs = ds;
                allAttributeGrid.DataSource = MyDs.Tables[tableName];

                string query = String.Format(Queries.attributeSetAttributesForUpdate,AttributeSetModel.id);
                ds = DbCommand.getDataSet(query, tableName);
                setAttributesGrid.Columns.Clear();
                MyDs1 = ds;
                setAttributesGrid.DataSource = MyDs1.Tables[tableName];
                allAttributeGrid.Columns[0].Width = 20;
                setAttributesGrid.Columns[0].Width = 20;

                for(int i=0; i< allAttributeGrid.Rows.Count;i++)
                {
                    for(int j = 0; j < setAttributesGrid.Rows.Count; j++)
                    {
                        if (allAttributeGrid.Rows[i].Cells[0].Value.ToString() == setAttributesGrid.Rows[j].Cells[0].Value.ToString())
                            allAttributeGrid.Rows.RemoveAt(i);
                    }
                }
            }
            else
            {
                string idName = "id";
                string idQuery = String.Format(Queries.newID, "attributeSet_ID", "attributeset");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);

                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(attributeSet_ID)"]) + 1).ToString();
                }
                catch (Exception )
                {
                    id.Text = "1";
                }

                

                string tableName ="Attributes";
                DataSet ds = DbCommand.getDataSet(Queries.attribute2, tableName);
                MyDs = ds;
                allAttributeGrid.DataSource = MyDs.Tables[tableName];
                allAttributeGrid.Columns[0].Width = 20;
                setAttributesGrid.Columns[0].Width = 20;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void allAttributeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void allAttributeGrid_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (allAttributeGrid.SelectedRows.Count != 0)
            {
                if (!update)
                {
                    int n = setAttributesGrid.Rows.Add();
                    setAttributesGrid.Rows[n].Cells[0].Value = allAttributeGrid.Rows[allAttributeGrid.SelectedRows[0].Index].Cells[0].Value;
                    setAttributesGrid.Rows[n].Cells[1].Value = allAttributeGrid.Rows[allAttributeGrid.SelectedRows[0].Index].Cells[1].Value;
                    allAttributeGrid.Rows.RemoveAt(allAttributeGrid.SelectedRows[0].Index);
                }
                else
                {
                    DataRow dr = MyDs1.Tables["Attributes"].NewRow();
                    dr["ID"] = allAttributeGrid.Rows[allAttributeGrid.SelectedRows[0].Index].Cells[0].Value;
                    dr["name"] = allAttributeGrid.Rows[allAttributeGrid.SelectedRows[0].Index].Cells[1].Value;
                    MyDs1.Tables["Attributes"].Rows.Add(dr);

                    allAttributeGrid.Rows.RemoveAt(allAttributeGrid.SelectedRows[0].Index);
                }
            }
            else MetroMessageBox.Show(this, "there is no item left in the list", "adding Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (setAttributesGrid.SelectedRows.Count != 0)
            {
                    DataRow dr = MyDs.Tables["Attributes"].NewRow();
                    dr["ID"] = setAttributesGrid.Rows[setAttributesGrid.SelectedRows[0].Index].Cells[0].Value;
                    dr["name"] = setAttributesGrid.Rows[setAttributesGrid.SelectedRows[0].Index].Cells[1].Value;
                    MyDs.Tables["Attributes"].Rows.Add(dr);
                    setAttributesGrid.Rows.RemoveAt(setAttributesGrid.SelectedRows[0].Index);
            }
            else MetroMessageBox.Show(this, "there is no item left in the list", "adding Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
