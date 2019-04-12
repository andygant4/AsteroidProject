<%@ Page Title="" Language="C#" MasterPageFile="~/Prog3/Prog3MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Prog3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" Runat="Server">
    <asp:GridView ID="ProductGrid" runat="server" AutoGenerateColumns="False" 
     style="z-index: 1; position: relative; width: 50%; margin-left:25%; 
     align-items: center; height: 176px" >

   <Columns>
      <asp:BoundField DataField="ProductID" HeaderText="Product ID" >
        <ItemStyle HorizontalAlign="Center"  Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" 
        DataFormatString="{0:c}" HtmlEncode="False" >
        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="Description" HeaderText="Description">
        <ItemStyle HorizontalAlign="right" Width="10%"></ItemStyle></asp:BoundField>
   </Columns>

</asp:GridView>

</asp:Content>

