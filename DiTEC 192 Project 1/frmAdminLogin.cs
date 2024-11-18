using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiTEC_192_Project_1
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear the text boxes
            txtUName.Clear();
            txtPwd.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Checking Textboxes empty or not
            if (txtUName.Text == "" && txtPwd.Text == "")
            {
                //Display error Message
                MessageBox.Show("Please Enter Username & Password !! ", " Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Verify the Username and Password
            else if (txtUName.Text == "admin" && txtPwd.Text == "123")
            {
                //Display Welcome Message
                MessageBox.Show("Welcome Admin !!", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Create the Admin Menu Form Object
                frmAdminMainMenu fAdminMenu = new frmAdminMainMenu();

                //Show the Form
                fAdminMenu.Show();

                //Unload current form
                this.Dispose(false);
            }
            else
            {
                //Display Message
                MessageBox.Show("Invalid UserName or Password !!", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Set the focus UID TextBox
                txtUName.Focus();

                //Select UID TextBox
                txtUName.SelectAll();

                //Clear the Password
                txtPwd.Clear();
            }


        }

        private void frmAdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Dispose(false);
        }
    }
}
