using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("======================= Welcome to Mega Mart ======================");
            Console.WriteLine("XXXXXXXXXXXXXXXX-----------------@@XXX@@----------------XXXXXXXXXXXXXXX");
        Options:
            Console.WriteLine("Which action do you want to perform?");
            Console.WriteLine();
            //text based menu
            Console.WriteLine("1.Add Products ");
            Console.WriteLine("2.Search Product ");
            Console.WriteLine("3.Remove Products ");
            Console.WriteLine("4.Update Quantity ");
            Console.WriteLine("5.Print Product List ");   
            Console.WriteLine("6.View total Amount Sold ");
            Console.WriteLine("7.Exit ");
            Console.WriteLine();
            Console.WriteLine();
            //choose option to perform action
            Console.Write("Choose option:");
            string strOpt = Console.ReadLine();

            product objPro = new product();
            DBOperation objDB = new DBOperation();

            //based on the option below case executed
            if (strOpt == "1")
            {
            AddProduct:
                Console.WriteLine("Please Enter Product Details :");
                Console.WriteLine();
                Console.Write("Producer Name :");
                objPro.ProName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Product Category :");
                objPro.ProCategory = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Product Price :");
                objPro.Price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Product Quantity :");
                objPro.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (objDB.AddProducts(objPro) > 0)
                 {
                      Console.WriteLine("Product Data has been inserted successfully!");
                    Console.WriteLine();
                    Console.Write("Do you want to insert more Product Data? (Y/N):");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        goto AddProduct;
                    }
                    else
                    {
                        goto Options;
                    }
                }
                else
                    Console.Write("Product Data Insert failed...!");
        
            }
            else if (strOpt == "2")
            {
            ViewPro:
                Console.WriteLine("Please provide the Product Name :");
                Console.WriteLine();
                Console.Write("Product Name :");

                //whatever name provide it will fetch form sql
                objPro = objDB.SearchProduct(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Product Name :" + objPro.ProName);
                Console.WriteLine();
                Console.WriteLine("Product Category " + objPro.ProCategory);
                Console.WriteLine();
                Console.WriteLine("Product Price : 2" + objPro.Price);
                Console.WriteLine();
                Console.WriteLine("Product Quantity :  " + objPro.Quantity);
                Console.WriteLine();
                Console.Write("Do you want to view more Product Data? (Y/N):");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    Console.WriteLine();
                    goto ViewPro;
                }
                else
                {
                    goto Options;
                }
           
            }
            else if (strOpt == "3")
            {
            DeleteProduct:
                Console.WriteLine("Please Enter Product Details:");
                Console.WriteLine();
                Console.Write("Product ID:");
                if (objDB.DeleteProduct(Convert.ToInt32(Console.ReadLine())) > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product Data has been deleted successfully!!!");
                    Console.WriteLine();
                    Console.Write("Do you want to delete another Product Data (Y/N):");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        goto DeleteProduct;
                    }
                    else
                    {
                        goto Options;
                    }
                }
                else
                {
                    Console.WriteLine("Prodduct Data deletion failed!!!");
                }
            }
            else if (strOpt == "4")
            {
            UpdateProduct:
                Console.WriteLine("Please Enter Product Details: ");
                Console.WriteLine();
                Console.Write("Product ID: ");
                Int32 PID = Convert.ToInt32(Console.ReadLine());
                if (objDB.CheckProductId(PID))
                {
                    objPro.ProductID = PID;
                    Console.WriteLine();
                    Console.Write("Product Name:");
                    objPro.ProName = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Product Category:");
                    objPro.ProCategory = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Product Price:");
                    objPro.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Quantity:");
                    objPro.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    

                    Console.Write("Do you Really want to update the Product Data? (Y/N):");

                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        if (objDB.UpdateQuantity(objPro) > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Product Data Updated Successfully!!!");
                            Console.WriteLine();
                            Console.Write("Do you want to Update another Product data? (Y/N) :");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                Console.WriteLine();
                                goto UpdateProduct;
                            }
                            else
                            {
                                Console.WriteLine();
                                goto Options;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Product data updation failed.Server Is too busy to respond");
                            Console.Write("Do you want to Update another Product data? (Y/N) :");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                Console.WriteLine();
                                goto UpdateProduct;
                            }
                            else
                            {
                                Console.WriteLine();
                                goto Options;
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Entered Product-Id doesn't exists.");
                    Console.WriteLine();
                    Console.Write("Do you want to Update another Product data? (Y/N) :");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        goto UpdateProduct;
                    }
                    else
                    {
                        Console.WriteLine();
                        goto Options;
                    }
                }
            }
            else if (strOpt == "5")
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = objDB.DisplayAllProduct();
                if (dt.Rows.Count > 0)
                {
                    Console.Write("{0}{1}{2}{3}{4}", "ID".PadRight(15), "ProductName".PadRight(15), "Category".PadRight(15), "Price".PadRight(15), "Quantity".PadRight(15));
                    Console.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        string ID = row["ProductId"].ToString();
                        string Name = row["proName"].ToString();
                        string Category = row["proCategory"].ToString();
                        string Price = row["price"].ToString();
                        string Quantity = row["Quantity"].ToString();
                        Console.Write("{0}\t{1}\t{2}\t{3}\t{4}", ID.PadRight(15), Name.PadRight(15), Category.PadRight(15), Price.PadRight(15), Quantity.PadRight(15));
                        Console.WriteLine();
                    }
                    Console.Write("Do you want to Perform another Operation (Y/N):");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        goto Options;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Prodduct Data Display failed!!!");
                }
             
            }
            else if (strOpt == "7")
            {
                Environment.Exit(0);
            }
        }
    }
}
#region Classes For IMS
class product
{
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

#endregion
