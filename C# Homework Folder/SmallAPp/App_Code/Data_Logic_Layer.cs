using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for Data_Logic_Layer
/// </summary>
public class Data_Logic_Layer
{
    public Data_Logic_Layer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region ::Class Fields::
    //provide conncetivity database
    SqlConnection con = null;
    //fire query database
    SqlCommand cmd = null;

    //read information  
    SqlDataReader dr = null;

    string strSqlCmd = string.Empty;
    string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\dzaldivar43\C-HomeWork\C# Homework Folder\SmallAPp\App_Data\Product_Master.mdf;Integrated Security=True";

    #endregion

    #region ::Public Methods::

    public int AddProducts(Business_Logic_Layer objProduct)
    {
        try
        {
            con = new SqlConnection(conStr);
            if (con.State != ConnectionState.Open)
                con.Open();

            strSqlCmd = "SP_AddProduct";
            cmd = new SqlCommand(strSqlCmd, con);
            cmd.CommandType = CommandType.StoredProcedure;


            // Using SqlParameter Array Collection

            SqlParameter[] p = { 
                                   new SqlParameter("@name", objProduct.ProName),
                                   new SqlParameter("@category", objProduct.ProCategory),
                                   new SqlParameter("@price", objProduct.Price),
                                   new SqlParameter("@quantity", objProduct.Quantity)
                                   };
            cmd.Parameters.AddRange(p);

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

    public DataTable SearchProduct(string ProductName)
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

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            return new DataTable();
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

    public int UpdateQuantity(Business_Logic_Layer objPro)
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