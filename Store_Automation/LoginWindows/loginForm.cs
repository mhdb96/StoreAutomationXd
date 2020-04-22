using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace StoreAutomationUI
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
            if (pass == "123")
            {
                data_entry data_Entry = new data_entry();
                data_Entry.Show();
                this.Hide();
            }
            else if (pass == "321")
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            db_settings db = new db_settings();
            db.ShowDialog();
        }
    }
}
