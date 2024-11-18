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
    public partial class frmMainMenu2 : Form
    {
        public frmMainMenu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating the Products form object
            frmProducts fp = new frmProducts();

            //Show the Products form
            fp.Show();

            //Unload the current form
            this.Dispose(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Creating the Exit Confermation form object
            frmExConf exConf = new frmExConf();

            //Show the Exit Confirmation form
            exConf.Show();




        }

        private void frmMainMenu2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create customer form object
            frmCustList Cust = new frmCustList();

            //Show the customer form
            Cust.Show();

            this.Dispose(false);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            //Create Exit Confirmation Form Object
            frmExConf frmExConf = new frmExConf();

            //Show Exit Confirmation form object
            frmExConf.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creating the Order List form object
            OrderList order = new OrderList();

            //Show the Order form
            order.Show();

            //Unload Current form
            this.Dispose(false);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm fal = new LoginForm();

            fal.Show();

            this.Dispose(false);
        }
    }
}
