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
    public partial class frmAdminLogoutConf : Form
    {
        public frmAdminLogoutConf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create Login form Object
            LoginForm frmLog = new LoginForm();

            //Show the Form
            frmLog.Show();

            //Unload Current Form
            this.Dispose(false);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Unload this form
            this.Dispose(false );
        }
    }
}
