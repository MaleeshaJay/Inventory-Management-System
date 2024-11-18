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
    public partial class frmAdminProducts : Form
    {
        public frmAdminProducts()
        {
            InitializeComponent();
        }
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //Checking if Part No is null and Product Name is not null
            if(txtPNumber.Text == "" && txtPName.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();
                    
                    dgvAdminProducts.DataSource = conDB.showRec("select * from" +
                        " Product where PName = '" + txtPName.Text + "'");


                    //Display Message
                    MessageBox.Show("Products Found ! ", "StockManagementSystem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Display error Message
                    MessageBox.Show("Error : " + ex.Message, "StockManagementSystem"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Close the Connection
                    conDB.closeCon();
                }
            }
            //Check if Part No is null and Make is not Null
            else if(txtPNumber.Text == "" && txtMake.Text != "")
            {
                try
                {
                    //Open the Connection
                    conDB.conn();

                    dgvAdminProducts.DataSource = conDB.showRec("select * from" +
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
                MessageBox.Show("Please Enter the Part No ", "Stock Management System",
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
                    System.Data.SqlClient.SqlDataReader sqldr = conDB.read("select * from " +
                        "Product where PNo = '" + txtPNumber.Text + "'");

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

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Call the Clear Method
            cle();

            //Refresh the Data Grid view
            dgvAdminProducts.DataSource = conDB.showRec("select * from Product");
        }
        ConnectionDB conDB = new ConnectionDB();
        private void frmAdminProducts_Load(object sender, EventArgs e)
        {
            //Using Error Handling tool
            try
            {
                //Open the Connection
                conDB.conn();

                //Fill the table
                dgvAdminProducts.DataSource = conDB.showRec("select * from Product");

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Create Exit confirmation form object
            frmExConf exConf = new frmExConf();

            //Show the form
            exConf.Show();

            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            //Create the form object
            frmAdminMainMenu AdminMenu = new frmAdminMainMenu();
            
            //Show the form
            AdminMenu.Show();
            
            //Unload Current Form
            this.Dispose(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm frmLog = new LoginForm();

            frmLog.Show();

            this.Dispose(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Check if all the infromation entered
            if (txtPNumber.Text == "" || txtPName.Text == "" || txtMake.Text == "" 
                || txtQty.Text == "" || txtPrice.Text == "")
            {
                //Display Message
                MessageBox.Show("Missing Data", "Stock Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    conDB.recOpr("insert into Product values('" + txtPNumber.Text + "','" + txtPName.Text +
                        "' , '" + txtMake.Text + "' , '" + txtQty.Text + "' , '" + txtPrice.Text + "', '" 
                        + dtpAddDate.Text + "')");

                    //Display Message
                    MessageBox.Show("New Product Added Successfully !", "StockManagementSystem",
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
                    dgvAdminProducts.DataSource = conDB.showRec("select * from Product");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPNumber.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter the Part No!", "Stock Management System",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPName.Text == "" && txtMake.Text == "" && txtQty.Text == ""
                && txtPrice.Text == "")
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
                    conDB.recOpr("update Product set PName='" + txtPName.Text + "',Make='"
                        + txtMake.Text + "',Qty='" + txtQty.Text + "',Price='" + txtPrice.Text
                        + "',PDate='" + dtpAddDate.Text + "' where PNo='" + txtPNumber.Text + "'");

                    //Display Message
                    MessageBox.Show("Product Update Successfully !", "StockManagementSystem", 
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
                    dgvAdminProducts.DataSource = conDB.showRec("select * from Product");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtPNumber.Text == "")
            {
                //Display Message
                MessageBox.Show("Please Enter the Part No", "Stock Management System",
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
                    conDB.recOpr("delete from Product where PNo='" + txtPNumber.Text + "'");

                    //Display Message
                    MessageBox.Show("Product Deleted Successfully !", "Stock Management System",
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
                    dgvAdminProducts.DataSource = conDB.showRec("select * from Product");

                    //Call the Clear Method
                    cle();

                    //Close the Connection
                    conDB.closeCon();
                }
            }
        }

        private void txtPNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvAdminProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
