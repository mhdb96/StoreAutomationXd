using MetroFramework;
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
    public partial class db_settings : MetroForm
    {
        public db_settings()
        {
            InitializeComponent();
        }

        private void db_settings_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = DatabaseInfo.server;
            metroTextBox2.Text = DatabaseInfo.port.ToString();
            metroTextBox3.Text = DatabaseInfo.database;
            metroTextBox4.Text = DatabaseInfo.user;
            metroTextBox5.Text = DatabaseInfo.pass;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DatabaseInfo.server = metroTextBox1.Text;
            DatabaseInfo.port = Convert.ToUInt32(metroTextBox2.Text);
            DatabaseInfo.database = metroTextBox3.Text;
            DatabaseInfo.user = metroTextBox4.Text;
            DatabaseInfo.pass = metroTextBox5.Text;
            if (DbCommand.tryConncetion())
                MetroMessageBox.Show(this, "Conneted Successfully" , "Database Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
