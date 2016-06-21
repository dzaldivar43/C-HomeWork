<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Idea Center Inventory Management App</title>
    <link href="CSS/CSS.css" rel="styleshneet" type="text/css" />
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <style type="text/css">
        input[type=text], input[type=password], select {
            width: 200px;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .mydatagrid {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #646464s ;
            font-family: Arial;
            color: White;
            border: none 0px transparent;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            border: none 0px transparent;
        }

            .rows:hover {
                background-color: #ff8000;
                font-family: Arial;
                color: #fff;
                text-align: left;
            }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: black;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }
    </style>
</head>
<body style="margin: 0; padding: 0">
    <form id="form2" runat="server">
        <div id="header">
            <div class="shell">
                <div id="head">
                    <h1><a href="#">Welcome to the Idea Center Invetory Management App</a></h1>
                    <div class="right">
                        <p>
                            <a href="#"><strong>
                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></strong></a> | 
						<a href="session.aspx">Logout</a>
                        </p>
                    </div>
                </div>
                <!-- Navigation -->
                <div id="navigation">
                    <ul>
                        <li><a href="CSharp.aspx"><span>Product Management</span></a></li>
                        <li><a href="Search.aspx" class="active"><span>Search Control</span></a></li>
                    </ul>
                </div>
                <!-- End Navigation -->

            </div>
        </div>
        <!-- End Header -->
        <!-- Content -->
        <div id="content" class="shell">
            <!-- Help Navigation -->
            <div id="help-nav">
                <a href="#">Dashboard</a> &gt; 
            </div>
            <center>
                <table border="1" cellspacing="5px" cellpadding="10px">
                    <tr>
                        <th>Enter Product Name </th>
                        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search" BackColor="Green" ForeColor="White" BorderColor="Wheat" Height="40px" Width="190px" Font-Size="Medium" OnClick="Button1_Click"></asp:Button>
                        </td>
                    </tr>
              
                    </table>
                <table>          
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" HtmlEncode="true" />
                            <asp:BoundField DataField="proName" HeaderText="Product Name" HtmlEncode="true" />
                            <asp:BoundField DataField="proCategory" HeaderText="Category" HtmlEncode="true" />
                            <asp:BoundField DataField="price" HeaderText="Value" HtmlEncode="true" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" HtmlEncode="true" />
                           
                        </Columns>

                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </center>

        </div>

        <!-- End Content -->
        </div>

        <!-- Footer -->
        <div id="footer">           
                <p>&copy; Design by <a href="#">Damien Zaldivar</a></p>
        </div>

    </form>
</body>
</html>
