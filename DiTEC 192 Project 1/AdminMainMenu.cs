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
    public partial class frmAdminMainMenu : Form
    {
        public frmAdminMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating Admin Product Form Object
            frmAdminProducts fAdminPro = new frmAdminProducts();

            //Show the Product Form
            fAdminPro.Show();

            //Unload Current Form
            this.Dispose(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Create the admin login form object
            frmAdminLogin frmLog = new frmAdminLogin();
            //Show the form
            frmLog.Show();
            //Unload current form
            this.Dispose(false);

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Create Exit Confirmation Form Object
            frmExConf exConf = new frmExConf();
            //Show Exit Confirmation form object
            exConf.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creating the form object
            AdminCustomerList fAdminCust = new AdminCustomerList();
            //show the form
            fAdminCust.Show();
            //Unload current form
            this.Dispose(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           //Creating the form object
            frmAdminOrderList FaOL = new frmAdminOrderList();

           //show the form
           FaOL.Show();

           //Unload the Current Form
           this.Dispose(false);
        }
    }
}
