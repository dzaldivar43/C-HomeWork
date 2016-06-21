using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Business_Logic_Layer
/// </summary>
public class Business_Logic_Layer
{
	public Business_Logic_Layer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int productID;
    private string proName = string.Empty;
    private string proCategory = string.Empty;
    private decimal price;
    private int quantity;

    #region ::public properties ::

    public int ProductID
    {
        get { return this.productID; }
        set { this.productID = value; }
    }

    public string ProName
    {
        get { return this.proName; }
        set { this.proName = value; }
    }

    public string ProCategory
    {
        get { return this.proCategory; }
        set { this.proCategory = value; }
    }

    public decimal Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public int Quantity
    {
        get { return this.quantity; }
        set { this.quantity = value; }
    }

    #endregion

}