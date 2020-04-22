using MetroFramework.Controls;
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
    public partial class add_product : MetroForm
    {
        ProductModel myPro = new ProductModel();
        bool update;
        public add_product()
        {
            InitializeComponent();
        }

        public add_product(ProductModel upPro, bool u)
        {
            InitializeComponent();
            myPro = upPro;
            update = u;
        }
        //Form açıldığında gerçekleşecek olaylar
        private void add_product_Load(object sender, EventArgs e)
        {
            if (!update)
            {

                string tableName = "attributeSet";
                //DataSet sınıfından ds isminde nesne oluşturup 
                //DbCommand sınıfı yardımıyla Queries'den SQL komutunu alıp ds içerisine attı
                DataSet ds = DbCommand.getDataSet(Queries.attributeSet, tableName);
                //
                if (ds != null)
                {
                    attributeSetList.DisplayMember = "set_name";//Görünecek olan hücreler belirler
                    attributeSetList.ValueMember = "attributeSet_ID";//Arka planda tutulacak hücre id'lerini belirler
                    attributeSetList.DataSource = ds.Tables[tableName];//SQL komutuyla DataSet'e çektiğimiz bilgileri attributeSetList'e atar
                    attributeSetList.SelectedItem = null;//Seçili olan değeri boş yapar
                    attributeSetList.PromptText = "Choose from the list";//Açıklama metni
                }
            }
            else
            {
                attributeSetList.SelectedItem = null;
                attributeSetList.PromptText = myPro.set_name;
                attributeSetList.Enabled = false;
                metroButton4.Visible = false;
                metroButton2.Text = "Update";
                panel1.Visible = true;
                ID.Enabled = false;
                ID.Text = myPro.id;
                name.Text = myPro.name;
                description.Text = myPro.desc;
                price.Text = myPro.price;
                stock.Text = myPro.stock;
                string tableName = "setAttributes";
                string setID = myPro.set_id;
                string query = String.Format(Queries.setAttributes, setID);
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds == null)
                    MessageBox.Show("");
                int[] attributeID = new int[ds.Tables[tableName].Rows.Count];
                for (int u = 0; u < attributeID.Length; u++)
                {
                    attributeID[u] = (int)ds.Tables[tableName].Rows[u]["attribute_attribute_ID"];
                }

                string atttableName = "AttributeNames";
                DataSet attDs = DbCommand.getDataSet(Queries.attribute, atttableName);
                if (attDs == null)
                    MessageBox.Show("DataSet is empty!");

                MetroLabel[] lblNames = new MetroLabel[ds.Tables[tableName].Rows.Count];
                for (int u = 0; u < lblNames.Count(); u++)
                {
                    lblNames[u] = new MetroLabel();
                }
                myPro.count = ds.Tables[tableName].Rows.Count;
                int i = 0;
                foreach (MetroLabel lbl in lblNames)
                {

                    lbl.Name = "lbl" + (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    lbl.Text = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    lbl.Location = new Point(471, 100 + (i * 40));
                    lbl.Visible = true;
                    this.Controls.Add(lbl);
                    i++;
                }

                MetroComboBox[] listNames = new MetroComboBox[ds.Tables[tableName].Rows.Count];
                for (int u = 0; u < listNames.Count(); u++)
                {
                    listNames[u] = new MetroComboBox();
                }
                i = 0;
                foreach (MetroComboBox list in listNames)
                {
                    string valuetableName = "AttributeValues";
                    string valueQuery = String.Format(Queries.attributeValues, attributeID[i].ToString());
                    DataSet attValDs = DbCommand.getDataSet(valueQuery, valuetableName);
                    if (attValDs == null)
                        MessageBox.Show("DataSet is empty!");
                    string name = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    list.Name = name;
                    //list.Text = name;
                    list.Location = new Point(603, 90 + (i * 40));
                    list.Visible = true;
                    list.DisplayMember = "val_value";
                    list.ValueMember = "attributeValue_ID";
                    list.DataSource = attValDs.Tables[valuetableName];
                    //list.PromptText = "Choose from the list";
                    list.Style = MetroFramework.MetroColorStyle.Green;
                    this.Controls.Add(list);

                    string valIndextableName = "AttributeValues";
                    string valIndexQuery = String.Format(Queries.attributeValues, attributeID[i].ToString());
                    DataSet valIndexDs = DbCommand.getDataSet(valIndexQuery, valIndextableName);
                    if (attValDs == null)
                        MessageBox.Show("DataSet is empty!");

                    for (int u = 0; u < list.Items.Count; u++)
                    {
                        if (valIndexDs.Tables[valIndextableName].Rows[u]["attributeValue_ID"].ToString() == myPro.att_val_id[i])
                        {
                            list.SelectedIndex = u;
                            list.PromptText = valIndexDs.Tables[valIndextableName].Rows[u]["val_value"].ToString();
                        }
                    }
                    i++;
                }
            }

        }

        //Cancel butonunun gerçekleştirdiği olayın fonksiyonu
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                panel1.Visible = true;
                metroButton4.Enabled = false;
                attributeSetList.Enabled = false;

                string id = "id";
                //Queries sınıfından SQL komutları string bir değişkene attı
                //Ardından DbCommand'i kullanarak verileri çekip DataSet'e attı
                //Toplam ürün sayısını elde etti
                string idQuery = String.Format(Queries.newID, "product_ID", "product");
                DataSet idDs = DbCommand.getDataSet(idQuery, id);
                //
                if (idDs == null)
                    MessageBox.Show("");

                try
                {
                    ID.Text = ((int)(idDs.Tables[id].Rows[0]["max(product_ID)"]) + 1).ToString();
                }
                catch (Exception ex)
                {
                    ID.Text = "1";
                }

                
                myPro.id = ID.Text;

                string tableName = "setAttributes";
                string setID = attributeSetList.SelectedValue.ToString();
                string query = String.Format(Queries.setAttributes, setID);
                DataSet ds = DbCommand.getDataSet(query, tableName);
                if (ds == null)
                    MessageBox.Show("");


                int[] attributeID = new int[ds.Tables[tableName].Rows.Count];
                for (int u = 0; u < attributeID.Length; u++)
                {
                    attributeID[u] = (int)ds.Tables[tableName].Rows[u]["attribute_attribute_ID"];
                }

                string atttableName = "AttributeNames";
                DataSet attDs = DbCommand.getDataSet(Queries.attribute, atttableName);
                if (attDs == null)
                    MessageBox.Show("DataSet is empty!");

                MetroLabel[] lblTeamNames = new MetroLabel[ds.Tables[tableName].Rows.Count];
                for (int u = 0; u < lblTeamNames.Count(); u++)
                {
                    lblTeamNames[u] = new MetroLabel();
                }
                myPro.count = ds.Tables[tableName].Rows.Count;
                myPro.setArrayslength();
                int i = 0;
                foreach (MetroLabel lbl in lblTeamNames)
                {
                    myPro.attribute_id[i] = attDs.Tables[atttableName].Rows[attributeID[i] - 1]["attribute_ID"].ToString();
                    myPro.attribute_name[i] = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    string name = "lbl" + (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    lbl.Name = name;
                    lbl.Text = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    lbl.Location = new Point(471, 100 + (i * 40));
                    lbl.Visible = true;
                    this.Controls.Add(lbl);
                    i++;
                }

                MetroComboBox[] listTeamNames = new MetroComboBox[ds.Tables[tableName].Rows.Count];

                for (int u = 0; u < listTeamNames.Count(); u++)
                {
                    listTeamNames[u] = new MetroComboBox();
                }
                i = 0;
                foreach (MetroComboBox list in listTeamNames)
                {
                    string valuetableName = "AttributeValues";
                    string valueQuery = String.Format(Queries.attributeValues, attributeID[i].ToString());
                    DataSet attValDs = DbCommand.getDataSet(valueQuery, valuetableName);
                    if (attValDs == null)
                        MessageBox.Show("DataSet is empty!");
                    string name = (string)attDs.Tables[atttableName].Rows[attributeID[i] - 1]["att_name"];
                    list.Name = name;
                    list.Text = name;
                    list.Location = new Point(603, 90 + (i * 40));
                    list.Visible = true;
                    list.DisplayMember = "val_value";
                    list.ValueMember = "attributeValue_ID";
                    list.DataSource = attValDs.Tables[valuetableName];
                    list.SelectedItem = null;
                    list.PromptText = "Choose from the list";
                    list.Style = MetroFramework.MetroColorStyle.Green;
                    this.Controls.Add(list);
                    i++;
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
                myPro.name = name.Text;
                myPro.desc = description.Text;
                myPro.price = price.Text;
                myPro.stock = stock.Text;
            if (!update)
            {
                myPro.set_id = attributeSetList.SelectedValue.ToString();
                string query = String.Format(Queries.insProduct, myPro.id, myPro.name, myPro.desc, myPro.price, myPro.stock, myPro.set_id);
                DbCommand.insertIntoDb(query);
                for (int i = 0; i < myPro.count; i++)
                {
                    MetroComboBox list = (MetroComboBox)Controls[myPro.attribute_name[i]];
                    myPro.att_val_id[i] = list.SelectedValue.ToString();
                    query = String.Format(Queries.insProductAttribute, myPro.id, myPro.att_val_id[i], myPro.set_id, myPro.attribute_id[i]);

                    DbCommand.insertIntoDb(query);

                }
                this.Close();
            }
            else
            {
                DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string query = String.Format(Queries.upProduct, myPro.name, myPro.desc, myPro.price, myPro.stock, myPro.id);
                    DbCommand.insertIntoDb(query);
                    for (int i = 0; i < myPro.count; i++)
                    {
                        MetroComboBox list = (MetroComboBox)Controls[myPro.attribute_name[i]];
                        myPro.att_val_id[i] = list.SelectedValue.ToString();
                        query = String.Format(Queries.upProductAtt, myPro.att_val_id[i], myPro.id, myPro.attribute_id[i]);
                        DbCommand.insertIntoDb(query);

                    }
                    this.Close();
                }
            }
            
        }

        private void add_product_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
