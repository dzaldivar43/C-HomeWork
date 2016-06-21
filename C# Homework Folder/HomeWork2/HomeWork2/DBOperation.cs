using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace HomeWork2
{
    class DBOperation
    {
        #region ::Class Fields::
        //provide conncetivity database
        SqlConnection con = null;
        

        //fire query database
        SqlCommand cmd = null;

        //read information
        SqlDataReader dr = null;

        string strSqlCmd = string.Empty;
        string conStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Bhavin\Documents\Visual Studio 2013\Projects\HomeWork2\HomeWork2\Database1.mdf;Integrated Security=True";

        #endregion

        #region ::Public Methods::

        public int AddProducts(product objProduct)
        {
            try
            {
                con = new SqlConnection(conStr);
                if (con.State != ConnectionState.Open)
                    con.Open();

                strSqlCmd = "insert into Product values(@name,@category,@price,@quantity)";
                cmd = new SqlCommand(strSqlCmd, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@name", objProduct.ProName);
                cmd.Parameters.AddWithValue("@category", objProduct.ProCategory);
                cmd.Parameters.AddWithValue("@price", objProduct.Price);
                cmd.Parameters.AddWithValue("@quantity", objProduct.Quantity);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception  ex)
            {
                throw ex;
                //return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public product SearchProduct(string ProductName)
        {
            try
            {
                strSqlCmd = "Select * from Product where proName LIKE '%' + @ProName + '%'"; 
               // strSqlCmd = "SP_GetEmployee";
                con = new SqlConnection(conStr);
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(strSqlCmd, con);
                cmd.Parameters.AddWithValue("@ProName", ProductName);
                cmd.CommandType = CommandType.Text;
           
                dr = cmd.ExecuteReader();
                product objPro = new product();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        objPro.ProName = dr["proName"].ToString();
                        objPro.ProCategory = dr["proCategory"].ToString();
                        objPro.Price = Convert.ToDecimal(dr["price"].ToString());
                        objPro.Quantity = int.Parse(dr["Quantity"].ToString());
                        objPro.ProductID = int.Parse(dr["ProductId"].ToString());
                    }
                }
                return objPro;

            }
            catch (Exception)
            {
                return new product();
            }
            finally
            {
                //dr.Close();
                con.Close();
            }
        }

        public int DeleteProduct(int proId)
        {
            try
            {
                strSqlCmd = "Delete from Product where ProductId=" + proId;
                con = new SqlConnection(conStr);

                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(strSqlCmd, con);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateQuantity(product objPro)
        {
            try
            {
                strSqlCmd = "Update Product set  Quantity=" + objPro.Quantity + " where ProductId=" + objPro.ProductID;

                con = new SqlConnection(conStr);
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand(strSqlCmd, con);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return 0;
            }
            finally
            {
                con.Close();
            }
        }
            
        public bool CheckProductId(Int32 Pid)
        {
            strSqlCmd = "Select * from Product where ProductId=" + Pid;
            con = new SqlConnection(conStr);
            bool flag;
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(strSqlCmd, con);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
                flag = true;
            else
                flag = false;

            return flag;
        }

        public DataTable DisplayAllProduct()
        {
            strSqlCmd = "Select * from Product ";
            con = new SqlConnection(conStr);

            if (con.State != ConnectionState.Open)
                con.Open();

            cmd = new SqlCommand(strSqlCmd, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            
        }

        #endregion

    }

}

