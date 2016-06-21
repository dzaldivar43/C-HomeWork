<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        input[type=text],  input[type=password],select {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        input[type=submit] {
            width: 100%;
            background-color: #4CAF50;
            color: white;   
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            input[type=submit]:hover {
                background-color: #45a049;
            }

        div {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           
   <div aria-autocomplete="inline">
       <Center><h3>Welcome to the Idea Center Inventory Management App</h3></Center>
    <label for="fname">UserName</label>
      <asp:TextBox ID="TextBox1" runat="server" required="required"></asp:TextBox>

    <label for="lname">Password</label>
      <asp:TextBox ID="TextBox2" runat="server" required="required" TextMode="Password"></asp:TextBox>
  
      <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
       <asp:Label ID="Label1" runat="server" Text="" Visible="false" BorderStyle="Double" Font-Bold="true"></asp:Label>
</div>
    </form>
</body>
</html>
