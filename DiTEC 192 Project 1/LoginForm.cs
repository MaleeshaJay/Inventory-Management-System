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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Checking Textboxes empty or not
            if(txtUName.Text == "" && txtPwd.Text == "")
            {
                //Display error Message
                MessageBox.Show("Please Enter Username & Password !! ", " User Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Verify the Username and Password
            else if(txtUName.Text == "user" && txtPwd.Text == "123")
            {
                //Display Welcome Message
                MessageBox.Show("Welcome User !!" ,"User Login", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frmMainMenu2 frmMM = new frmMainMenu2();
                
                //Loading the Main Menu
                frmMM.Show();
                //Unload Current Form
                this.Dispose(false);
            }
            else
            {
                //Display Message
                MessageBox.Show("Invalid UserName or Password !!", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Set the focus UID TextBox
                txtUName.Focus();

                //Select UID TextBox
                txtUName.SelectAll();

                //Clear the Password
                txtPwd.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUName.Clear();
            txtPwd.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAdminLogin frmAdminLogin = new frmAdminLogin();
            frmAdminLogin.Show();
            this.Dispose(false);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
