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
    public partial class AdminCustomerList : Form
    {
        public AdminCustomerList()
        {
            InitializeComponent();
        }
        

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginForm frmLog = new LoginForm();

            frmLog.Show();

            this.Dispose(false);
        }
        ConnectionDB conDB = new ConnectionDB();
        private void AdminCustomerList_Load(object sender, EventArgs e)
        {
            //Using Error Handling tool
            try
            {
                //Open the Connection
                conDB.conn();

                //Fill the table
                dgvAdminCust.DataSource = conDB.showRec("select * from Customer");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmExConf exConf = new frmExConf();

            exConf.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmAdminMainMenu frmAdminMain = new frmAdminMainMenu();

            frmAdminMain.Show();

            this.Dispose(false);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //Calling the Clear Method
            cle();

       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if Customer ID is null and Customer Name is not null
            if (txtCID.Text == "" && txtCName.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();

                    //Set the search record statement
                    System.Data.SqlClient.SqlDataReader sqldr = conDB.read("select *" +
                        " from Customer where CustomerName = '" + txtCName.Text + "'");

                    //Read the Object
                    sqldr.Read();

                    //Assigning the Values
                    txtCID.Text = sqldr[0].ToString();
                    txtCAddress.Text = sqldr[2].ToString();
                    txtCTel.Text = sqldr[3].ToString();
                    txtCEmail.Text = sqldr[4].ToString();

                    //Display Message
                    MessageBox.Show("Customer Found ! ", "StockManagementSystem", 
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
            //Check if Customer ID is null
            else if (txtCID.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter Customer ID or Name!", "Stock Management System",
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
                        " Customer where CustomerID = '" + txtCID.Text + "'");

                    //Read the Object
                    sqldr.Read();

                    //Assigning the Values
                    txtCName.Text = sqldr[1].ToString();
                    txtCAddress.Text = sqldr[2].ToString();
                    txtCTel.Text = sqldr[3].ToString();
                    txtCEmail.Text = sqldr[4].ToString();

                    //Display Message
                    MessageBox.Show("Customer Found ! ", "StockManagementSystem",
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
        } //Create the Clear Method
        private void cle()
        {
            txtCID.Clear();
            txtCName.Clear();
            txtCAddress.Clear();
            txtCTel.Clear();
            txtCEmail.Clear();


            //Display Message
            MessageBox.Show("All Cleared !", "StockManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Check if all the infromation entered
            if (txtCID.Text == " " || txtCName.Text == "" || txtCAddress.Text == "" 
                || txtCTel.Text == "" || txtCEmail.Text == "")
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
                    conDB.recOpr("insert into Customer values('" + txtCID.Text + "','" 
                        + txtCName.Text + "' , '" + txtCAddress.Text + "' , '"
                        + txtCTel.Text + "' , '" + txtCEmail.Text + "')");

                    //Display Message
                    MessageBox.Show("New Customer Added Successfully !", "StockManagementSystem",
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
                    dgvAdminCust.DataSource = conDB.showRec("select * from Customer");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtCID.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter the Customer ID!", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtCName.Text == "" && txtCAddress.Text == "" && 
                txtCTel.Text == "" && txtCEmail.Text == "")
            {
                //Display Message
                MessageBox.Show("Missing Data", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using error Handling tool
                try
                {
                    //Open the Connection
                    conDB.conn();

                    //Update Record Statement
                    conDB.recOpr("update Customer set CustomerName='" + txtCName.Text +
                        "',CustomerAddress='" + txtCAddress.Text + "',TelNo='" + txtCTel.Text +
                        "',CustomerEmail='" + txtCEmail.Text + "' where CustomerID='" + txtCID.Text + "'");

                    //Display Message
                    MessageBox.Show("Customer Info Updated Successfully !", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display error Message
                    MessageBox.Show("Error :" + ex.Message, "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Fill the Table
                    dgvAdminCust.DataSource = conDB.showRec("select * from Customer");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtCID.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter the Customer ID", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Using Error Handling Tool
                try
                {
                    //Open the Connection
                    conDB.conn();

                    //Delete Record Statement
                    conDB.recOpr("delete from Customer where CustomerID='" + txtCID.Text + "'");

                    //Display Message
                    MessageBox.Show("Customer Deleted Successfully !", "Stock Management System",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display Error Message
                    MessageBox.Show("Error : " + ex.Message, "Stock Management System",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Fill the Table
                    dgvAdminCust.DataSource = conDB.showRec("select * from Customer");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }
    }
}


