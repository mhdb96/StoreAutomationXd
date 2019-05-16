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
    public partial class loginForm : MetroForm
    {
        string pass;
        public loginForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            pass = metroTextBox1.Text;
            if(pass=="123")
            {
                data_entry data_Entry = new data_entry();
                data_Entry.Show();
                this.Hide();
            }
            else if(pass == "321")
            {
                admin Admin = new admin();
                Admin.Show();
                this.Hide();
            }
            else
            {
                MetroMessageBox.Show(loginForm.ActiveForm, "Password Incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
