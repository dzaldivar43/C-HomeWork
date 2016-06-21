<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSharp.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IDEA CENTER MANAGEMENT APP</title>
    <link href="CSS/CSS.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <style type="text/css">
        .mydatagrid {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #646464;
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
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
             '<img src="images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=pnlAddEdit.ClientID %>");
            $.blockUI.defaults.css = {};
        });
            function Hidepopup() {
                $find("popup").hide();
                return false;
            }
    </script>
</head>
<body style="margin: 0; padding: 0">
    <form id="form1" runat="server">
        <div id="header">
            <div class="shell">
                <div id="head">
                    <h1><a href="#">Idea Center Inventory Management Application</a></h1>
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
                        <li><a href="CSharp.aspx" class="active"><span>Product Management</span></a></li>
                        <li><a href="Search.aspx"><span>Search Control</span></a></li>
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

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Width="550px"
                        AutoGenerateColumns="false" AlternatingRowStyle-BackColor="Blue"
                        HeaderStyle-BackColor="green" AllowPaging="true"
                        OnPageIndexChanging="OnPaging"
                        PageSize="10" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" HtmlEncode="true" />
                            <asp:BoundField DataField="proName" HeaderText="Product Name" HtmlEncode="true" />
                            <asp:BoundField DataField="proCategory" HeaderText="Product Category" HtmlEncode="true" />
                            <asp:BoundField DataField="price" HeaderText="Value" HtmlEncode="true" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" HtmlEncode="true" />
                            <asp:TemplateField ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="#C2D69B" />
                    </asp:GridView>
                    <br />  
                    <asp:Button ID="btnAdd" runat="server" Text="Add New Product" OnClick="Add" BackColor="Green" ForeColor="White" BorderColor="Wheat" Height="40px" Width="190px" Font-Size="Medium"/>

                    <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: none">
                        <asp:Label Font-Bold="true" ID="Label4" runat="server" Text="Product Details"></asp:Label>
                        <br />
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="ProductId" required="required"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustomerID" Width="40px" MaxLength="5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Save" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                    <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
                        PopupControlID="pnlAddEdit" TargetControlID="lnkFake"
                        BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    <asp:AsyncPostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- End Help Navigation -->

            <%--	<div class="message thank-message">
			<p><strong>Congratulations your information has been submited!</strong></p>
		</div>
		
		<div class="message error-message">
			<p><strong>Error! The following fields were not entred correctly...</strong></p>
		</div>


		<h6 class="red">Header styles</h6>		
		<h1>Header h1</h1>
		<h2>Header h2</h2>
		<h3>Header h3</h3>
		<h4>Header h4</h4>
		<h5>Header h5</h5>
		<h6>Header h6</h6>
		<br />
		<h6 class="red">Paragraph styles</h6>
		<p>Lorem ipsum dolor sit amet, <a href="#">consectetur adipiscing elit</a>. Aenean non aliquam felis. Sed justo justo, hendrerit vel fermentum nec, pellentesque non ligula. Nulla sodales dictum diam, vel tincidunt lorem commodo non. Vivamus ullamcorper tellus sit amet urna placerat ut egestas ante auctor. Sed arcu justo, iaculis eget pellentesque sit amet, viverra ut mauris. Aliquam erat volutpat. Nulla eget auctor turpis. Ut mi arcu, laoreet ac pretium vel, placerat non velit. Etiam rhoncus dui metus. Quisque ut dictum ante. Morbi pretium nibh sit amet dolor elementum vitae vehicula lacus dignissim.Curabitur non quam et eros lacinia euismod id a felis. </p>
				
		<p>Nam vestibulum ligula et enim dapibus vitae gravida diam molestie. In mauris ipsum, hendrerit vitae mattis et, aliquet at sem. Aliquam erat volutpat. Nullam suscipit ullamcorper est at placerat. In neque mi, eleifend ac sagittis eu, condimentum in tellus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean aliquam, diam id sagittis dictum, justo est volutpat ligula, sed posuere justo libero ac nisl. Phasellus sed varius arcu. Sed bibendum ante eget ligula euismod sed tempus enim ornare. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam erat volutpat. </p>
		
		<br />
		<h6 class="red">Unordered List style</h6>
		<ul>
			<li>Sum dolor sit amet</li>
			<li>Consectetur adipiscing elit</li>
			<li>Aenean aliquam, diam id sagittisDictum</li>
			<li>Justo est Sed posuere justo libero</li>
			<li>Phasellus sed varius arcu</li>
		</ul>
		
		<br />
		<h6 class="red">Ordered List style</h6>
		<ol>
			<li>Sum dolor sit amet</li>
			<li>Consectetur adipiscing elit</li>
			<li>Aenean aliquam, diam id sagittisDictum</li>
			<li>Justo est Sed posuere justo libero</li>
			<li>Phasellus sed varius arcu</li>
		</ol>--%>
        </div>

        <!-- End Content -->
        </div>

        <!-- Footer -->
        <div id="footer">
            <p>&copy; Sitename.com. Design by <a href="http://chocotemplates.com">ChocoTemplates.com</a></p>
        </div>

    </form>
</body>
</html>
