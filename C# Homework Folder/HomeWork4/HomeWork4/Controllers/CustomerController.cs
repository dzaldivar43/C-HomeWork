using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using HomeWork4.Models;


namespace HomeWork4.Controllers
{
    public class CustomerController : Controller
    {
        public string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\dzaldivar43\C-HomeWork\C# Homework Folder\HomeWork4\HomeWork4\App_Data\ProductMaster.mdf;Integrated Security=True";
        //
        // GET: /Customer/
        [HttpGet]
        public ActionResult Index()
        {
            List<Customer> obj12 = selectdata();
            return View(obj12);
        }

        private List<Customer> selectdata()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("select * from CustomerDetail", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 0;  
            var modellist = new List<Customer>();

            while (i <= ds.Tables[0].Rows.Count - 1)
            {
                var obj = new Customer();
                obj.customerid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                obj.fname = ds.Tables[0].Rows[i][1].ToString();
                obj.lname = ds.Tables[0].Rows[i][2].ToString();
                obj.country = ds.Tables[0].Rows[i][3].ToString();
                obj.state = ds.Tables[0].Rows[i][4].ToString();
                obj.Contact =decimal.Parse(ds.Tables[0].Rows[i][5].ToString());
                obj.member_since = int.Parse(ds.Tables[0].Rows[i][6].ToString());

                modellist.Add(obj);
                i++;
            }
            return modellist;
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("select * from CustomerDetail where CustomerID=" + id, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            Customer obj = new Customer();
            obj.customerid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
            obj.fname = ds.Tables[0].Rows[i][1].ToString();
            obj.lname = ds.Tables[0].Rows[i][2].ToString();
            obj.country = ds.Tables[0].Rows[i][3].ToString();
            obj.state = ds.Tables[0].Rows[i][4].ToString();
            obj.Contact = decimal.Parse(ds.Tables[0].Rows[i][5].ToString());
            obj.member_since = int.Parse(ds.Tables[0].Rows[i][6].ToString());
            return View(obj);

        }

    }
}
