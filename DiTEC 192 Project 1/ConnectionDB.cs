using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DiTEC_192_Project_1
{
    internal class ConnectionDB
    {
        //Create the instant variable
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adapt;
        DataSet DataSet;

        //Create the memory variable
        String sql;

        //Create the Connection Method
        public SqlConnection conn()
        {
            //Set the Connection String
            sql = @"Data Source = DESKTOP-MPFTOTL; Initial Catalog = StockManagementSystem;
                    Integrated Security = True ";

            //Set the Connection 
            con = new SqlConnection(sql);

            //Open the Connection
            con.Open();

            //Pass the Connection
            return con;
        }

        //Create the close Connection method
        
        public void closeCon()
        {
            //Close the Connection
            con.Close();
        }

        //Create the Record Operation Method
        public void recOpr(String qry)
        {
            //Set the SQL Statement in Command Control
            cmd = new SqlCommand(qry,con);

            //Update Database
            cmd.ExecuteNonQuery();
        }
        //Create the Search Record Method
        public SqlDataReader read(String qry)
        {
            //Assigning the SQL Statement
            cmd = new SqlCommand(qry,con);

            //Read the Reader object
            
            dr = cmd.ExecuteReader();

            //Pass the Value
            return dr;
        }
        //Create the show table Method
        public object showRec(string qry)
        {
            //Assigning the Value SQL Statement
            adapt = new SqlDataAdapter(qry, con);
            //Fill the DataTable
            adapt.Fill(DataSet = new DataSet());
            //Show the Table
            object dv = DataSet.Tables[0];
            //Pass the Form
            return dv;

        }
       
    }
}
