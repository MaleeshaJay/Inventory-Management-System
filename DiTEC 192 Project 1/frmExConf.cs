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
    public partial class frmExConf : Form
    {
        public frmExConf()
        {
            InitializeComponent();
        }
        //Yes Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Exit From the Application
            Application.Exit();
        }
        //No Button
        private void button2_Click(object sender, EventArgs e)
        {
            //Unload Exit Confirmation form
            this.Dispose(false);
        }
    }
}
