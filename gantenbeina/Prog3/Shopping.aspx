<%@ Page Title="" Language="C#" MasterPageFile="~/Prog3/Prog3MasterPage.master" AutoEventWireup="true" CodeFile="Shopping.aspx.cs" Inherits="Prog3_Shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" Runat="Server">
    <br />
    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br />
    <br />

    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    <br />
    <br />

    <asp:TextBox ID="txtSubTotal" runat="server" ReadOnly ="true"></asp:TextBox>
    <asp:TextBox ID="txtTax" runat="server" ReadOnly ="true"></asp:TextBox>
    <asp:TextBox ID="txtGrandTotal" runat="server" ReadOnly ="true"></asp:TextBox>
</asp:Content>

