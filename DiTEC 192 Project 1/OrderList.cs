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
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }
        ConnectionDB conDB = new ConnectionDB();

        private void OrderList_Load(object sender, EventArgs e)
        {
            //Using Error Handling tool
            try
            {
                //Open the Connection
                conDB.conn();

                //Fill the table
                dgvOrders.DataSource = conDB.showRec("select * from POrder");

            }
            catch (Exception ex)
            {
                //Catch the error
                MessageBox.Show("Error :" + ex.Message, "Stock Management System", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Close the Connection
                conDB.closeCon();
            }
        }
        //Creating the clear method
        private void cle()
        {
            txtOID.Clear();
            txtPNo.Clear();
            txtCName.Clear();
            txtQty.Clear();
            txtTotPrice.Clear();


            //Display Message
            MessageBox.Show("All Cleared !", "StockManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if Order No is null and Customer Name is not null
            if (txtOID.Text == "" && txtCName.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();


                    //Show results in DataGridView
                    dgvOrders.DataSource = conDB.showRec("select * from POrder " +
                        "where CustName = '" + txtCName.Text + "'");



                    //Display Message
                    MessageBox.Show("Order Found ! ", "StockManagementSystem", 
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
            //Check if Order No is null
            else if (txtOID.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter Order No or Customer Name! ", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using error Handling tool
                try
                {
                    //Open the Connection
                    conDB.conn();

                    //Set the search record statement
                    System.Data.SqlClient.SqlDataReader sqldr = conDB.read("select * from" +
                        " POrder where OrderNo = '" + txtOID.Text + "'");

                    //Read the Object
                    sqldr.Read();

                    //Assigning the Values
                    txtPNo.Text = sqldr[1].ToString();
                    txtCName.Text = sqldr[2].ToString();
                    txtQty.Text = sqldr[3].ToString();
                    txtTotPrice.Text = sqldr[4].ToString();



                    //Display Message
                    MessageBox.Show("Order Found ! ", "StockManagementSystem", 
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //Calling the Clear Method
            cle();

            //Refresh the table
            dgvOrders.DataSource = conDB.showRec("select * from POrder");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check if all the infromation entered
            if (txtOID.Text == "" || txtPNo.Text == "" || txtCName.Text == "" 
                || txtQty.Text == "" || txtTotPrice.Text == "")
            {
                //Display Message
                MessageBox.Show("Missing Data", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Calling the Clear Method
                cle();
            }
            else
            {
                //Using error Handling tool
                try
                {
                    //Open the Connection
                    conDB.conn();
                 
                    //Add new Record Statement
                    conDB.recOpr("insert into POrder values('" + txtOID.Text + "'" +
                        ",'" + txtPNo.Text + "' , '" + txtCName.Text + "' , '" 
                        + txtQty.Text + "' , '" + txtTotPrice.Text + "')");

                    //Display Message
                    MessageBox.Show("New Order Added Successfully !", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    //Display Error Message
                    MessageBox.Show("Error : " + ex.Message, "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    //Fill the Table
                    dgvOrders.DataSource = conDB.showRec("select * from POrder");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //Create admin login form Object
            frmAdminLogin frmAdmin = new frmAdminLogin();

            //Show the form
            frmAdmin.Show();

            //Unload Current Form
            this.Dispose(false);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {

            frmMainMenu2 mainMenu2 = new frmMainMenu2();

            mainMenu2.Show();

            this.Dispose(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmExConf frmExConf = new frmExConf();

            frmExConf.Show();

          
        }

        private void txtTotPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
