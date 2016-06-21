using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {

            Label7.Text = "Welcome " + Session["username"].ToString();
            if (!IsPostBack)
            {
                this.BindData();
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void BindData()
    {
        Data_Logic_Layer d = new Data_Logic_Layer();
        if (TextBox1.Text != null)
        {
            GridView1.DataSource = d.SearchProduct(TextBox1.Text);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = d.SearchProduct("bis");
            GridView1.DataBind();
        }
  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindData();
    }
}