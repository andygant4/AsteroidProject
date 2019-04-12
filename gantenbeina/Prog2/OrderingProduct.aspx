<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderingProduct.aspx.cs" Inherits="Prog2_OrderingProduct" %>

<%--
//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Page OrderingProduct.aspx of Prog2
//
//-----------------------------------------------------------------------------------------------%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CS3870 - Program 2</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet.css" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="CS3870Title">Web Protocols, Technologies and Applications</h1>
        <h2 class="CS3870Name">Andrew Gantenbein</h2>
        <ul class="navbar">
            <li><a href ="Default.aspx">Start Page</a></li>
            <li><a href ="OrderingProduct.aspx">Order Form</a></li>
        </ul>
        <div>
            <asp:Label ID="lblID" runat="server" style="z-index: 1; position: relative; width: 15%; margin-left: 17.5%; display: inline-block; text-align: center" Text="Product ID"></asp:Label>
            <asp:Label ID="lblPrice" runat="server" style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center" Text="Price"></asp:Label>
            <asp:Label ID="lblQuan" runat="server" style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center" Text="Quantity"></asp:Label>
            <br />

            <asp:TextBox ID="txtID" runat="server" style="display: inline-block; position: relative; width: 15%; 
                text-align: left; margin-left: 17.5%; z-index: auto;"></asp:TextBox>
            <asp:TextBox ID="txtPrice" runat="server" style="margin-left: 10%; display: inline-block; position: relative; 
                z-index: auto; width: 15%; text-align: right"></asp:TextBox>
            <asp:TextBox ID="txtQuantity" runat="server" style="margin-left: 10%; display: inline-block; position: relative; 
                z-index: auto; width: 15%; left: 0px; text-align: right"></asp:TextBox>

            <br />

            <asp:RequiredFieldValidator ID="txtIDValidator" runat="server" ErrorMessage="ID cannot be empty!" ControlToValidate="txtID" style="z-index:auto; position:relative; margin-left:17.5%; width:15%; display:inline-block;"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="txtReqPriceValidator" runat="server" ErrorMessage="Price cannot be empty!" ControlToValidate="txtPrice"
                style="z-index:auto;position:relative;margin-left:10.5%;width:15%;display:inline-block;"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="txtReqQuanValidator" runat="server" ErrorMessage="Quantity cannot be empty!" ControlToValidate="txtQuantity" style="z-index:auto;position:relative;margin-left:10.5%;width:15%;display:inline-block;"></asp:RequiredFieldValidator>

            <asp:CompareValidator ID="txtPriceValidator" runat="server" ErrorMessage="Unit price must be a positive number!" ControlToValidate="txtPrice" Operator="GreaterThan" 
                Type="Currency" ValueToCompare="0"
                style="z-index:auto;position:relative;margin-left:-41%;width:20%;display:inline-block;"></asp:CompareValidator>
            <asp:CompareValidator ID="txtQuanValidator" runat="server" ErrorMessage="Quantity must be a non-negative integer!" ControlToValidate="txtQuantity" Operator="GreaterThan" ValueToCompare="0" style="z-index:auto;position:relative;margin-left:5%;width:25%;display:inline-block;visibility:hidden;"></asp:CompareValidator>

            <br />

            <asp:Label ID="lblSubTotal" runat="server" Text="Sub Total" style="z-index: auto; position: relative; width: 15%; margin-left: 17.5%; display: inline-block; text-align: center"></asp:Label>
            <asp:Label ID="lblTax" runat="server" Text="Tax" style="z-index: auto; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center"></asp:Label>
            <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" style="z-index: auto; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center"></asp:Label>
            
            <br />

            <asp:TextBox ID="txtSubTotal" runat="server" ReadOnly="True" style="display: inline-block; position: relative; width: 15%; 
                text-align: right; margin-left: 17.5%; z-index: auto;"></asp:TextBox>
            <asp:TextBox ID="txtTax" runat="server" ReadOnly="True" style="margin-left: 10%; display: inline-block; position: relative; 
                z-index: auto; text-align: right; width:15%" ></asp:TextBox>
            <asp:TextBox ID="txtGrandTotal" runat="server" ReadOnly="True" style="margin-left: 10%; display: inline-block; position: relative; 
                text-align: right; z-index: auto; width: 15%"></asp:TextBox>

            <br />
            <br />
            <br />

            <asp:Button ID="btnCompute" runat="server" Text="Compute" OnClick="btnCompute_Click" style="height: 26px; width: 80px; z-index: 1; position: relative; width: 10%; margin-left: 35%"/>
            <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="False" OnClick="btnReset_Click" style="height: 26px; width: 80px; z-index: 1; position: relative; width: 10%; margin-left: 10%" />
            
        </div>
        
    </form>
</body>
</html>
