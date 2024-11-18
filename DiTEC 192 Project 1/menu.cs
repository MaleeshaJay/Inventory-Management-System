using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiTEC_192_Project_1
{
    public partial class frmProducts : Form
    {
        
        public frmProducts()
        {
            InitializeComponent();
            
        }
        ConnectionDB conDB = new ConnectionDB();


      

        private void menu_Load(object sender, EventArgs e)
        {
            //Using Error Handling tool
            try
            {
                //Open the Connection
                conDB.conn();

                //Fill the table
                dgvProduct.DataSource = conDB.showRec("select * from Product");

            }
            catch(Exception ex)
            {
                //Catch the error
                MessageBox.Show("Error :" + ex.Message,"Stock Management System",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                //Close the Connection
                conDB.closeCon();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if Part No is null and Product Name is not null
            if (txtPNumber.Text == "" && txtPName.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();

                    dgvProduct.DataSource = conDB.showRec("select * from Product where PName = '" + txtPName.Text + "'");


                    //Display Message
                    MessageBox.Show("Products Found ! ", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display error Message
                    MessageBox.Show("Error : " + ex.Message, "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Close the Connection
                    conDB.closeCon();
                }
            }
            //Check if Part No is null and Make is not Null
            else if (txtPNumber.Text == "" && txtMake.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();

                    dgvProduct.DataSource = conDB.showRec("select * from" +
                        " Product where Make = '" + txtMake.Text + "'");


                    //Display Message
                    MessageBox.Show("Products Found ! ", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display error Message
                    MessageBox.Show("Error : " + ex.Message, "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Close the Connection
                    conDB.closeCon();
                }
            }
            else if (txtPNumber.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter the Part No ",
                    "Stock Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using error Handling tool
                try
                {
                    //Open the Connection
                    conDB.conn();

                    //Set the search record statement
                    System.Data.SqlClient.SqlDataReader sqldr = conDB.read("select" +
                        " * from Product where PNo = '" + txtPNumber.Text + "'");

                    //Read the Object
                    sqldr.Read();

                    //Assigning the Values
                    txtPName.Text = sqldr[1].ToString();
                    txtMake.Text = sqldr[2].ToString();
                    txtQty.Text = sqldr[3].ToString();
                    txtPrice.Text = sqldr[4].ToString();
                    dtpAddDate.Text = sqldr[5].ToString();

                    //Display Message
                    MessageBox.Show("Product Found ! ", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display error Message
                    MessageBox.Show("Error : " + ex.Message, "StockManagementSystem", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }
        //Create the Clear Method
        private void cle()
        {
            txtPNumber.Clear();
            txtPName.Clear();
            txtMake.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            dtpAddDate.ResetText();

            //Display Message
            MessageBox.Show("All Cleared !", "StockManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create the form object
            OrderList orderList = new OrderList();

            //Show the Form
            orderList.Show();

            //Unload Current Form
            this.Dispose(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Creating the Exit Confirmation form object
            frmExConf fEC = new frmExConf();

            //Show Exit Confirmation form
            fEC.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //Creating the Admin Login Form object
            frmAdminLogin fAL = new frmAdminLogin();

            //Show Admin Login Form
            fAL.Show();

            this.Dispose(false);

        }



        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            //Creating the Main Menu 2 form Object
            frmMainMenu2 fMM2 = new frmMainMenu2();

            //Show Main Menu 2
            fMM2.Show();

            //Unload current form
            this.Dispose(false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Create form Object
            frmCustList fCL = new frmCustList();
            //Show the Form
            fCL.Show();
            //Unload the Current form
            this.Dispose(false);
        }

       

        private void btnMainMenu_Click_1(object sender, EventArgs e)
        {
            //Creating thr Main Menu form Object
            frmMainMenu2 Mmenu = new frmMainMenu2();

            //Show the 
            Mmenu.Show();

            this.Dispose(false);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call the Clear Method
            cle();
            //Refresh the DataGridView
            dgvProduct.DataSource = conDB.showRec("select * from Product");
        }

        private void txtPNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
