<%@ Page Title="" Language="C#" MasterPageFile="~/Prog5/Prog5MasterPage.master" AutoEventWireup="true" CodeFile="Shopping.aspx.cs" Inherits="Prog5_Shopping" %>
<%@ MasterType VirtualPath="~/Prog5/Prog5MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Prog5Body" Runat="Server">
    <br />  <br /> 

    <asp:Label ID="lblID" runat="server" Text="Product ID" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center"></asp:Label>
    <asp:Label ID="lblName" runat="server" Text="Product Name" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>
    <asp:Label ID="lblPrice" runat="server" Text="Price" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center"></asp:Label>

    <br /> 

    <asp:TextBox ID="txtID" runat="server" style="border-style:Solid;display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: left" OnTextChanged="txtID_TextChanged" AutoPostBack="True"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server" style="border-style:Solid;display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right" ReadOnly ="true"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" style="border-style:Solid;display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: right" ReadOnly ="true"></asp:TextBox>

    <br />  <br /> <br />  <br /> <br />

    <asp:Label ID="lblQuantity" runat="server" Text="Quantity" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center"></asp:Label>

    <br /> 

    <asp:TextBox ID="txtQuantity" runat="server" style="border-style:Solid;display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: left"></asp:TextBox>

    <br />

    <asp:CompareValidator ID="CompareValidatorQuan" ControlToValidate="txtQuantity" runat="server" style="z-index:auto;position:relative;width:20%;margin-left:17.5%;" ErrorMessage="Quanity must be a non-negative integer!" Operator="GreaterThan" Type="Integer" ValueToCompare="-1"></asp:CompareValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuan" ControlToValidate="txtQuantity" style="z-index:auto;position:relative;width:25%;margin-left:17.5%;display:inline-block" runat="server" ErrorMessage="Enter a Quantity please!"></asp:RequiredFieldValidator>

    <br />  <br /> <br />  <br /> 

    <asp:Label ID="lblSub" runat="server" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align: center" Text="Sub Total"></asp:Label>
    <asp:Label ID="lblTax" runat="server" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center" Text="Tax"></asp:Label>
    <asp:Label ID="lblTotal" runat="server" style="display:inline-block;width:15%;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align: center" Text="Grand Total"></asp:Label>

    <br />

    <asp:TextBox ID="txtSub" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:17.5%; text-align:right" runat="server" ReadOnly="true"></asp:TextBox>
    <asp:TextBox ID="txtTax" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align:right" runat="server" ReadOnly="true"></asp:TextBox>
    <asp:TextBox ID="txtTotal" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left:10%; text-align:right" runat="server" ReadOnly="true"></asp:TextBox>

    <br />  <br /> <br />  <br /> <br />

    <asp:Button ID="btnCalculate" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left: 30%" Text="Calculate" OnClick="btnCalculate_Click" />
    <asp:Button ID="btnAddToBag" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 15%; margin-left: 10%" Text="Add to Shopping Bag" OnClick="btnAddToBag_Click" Enabled="False" />
</asp:Content>
