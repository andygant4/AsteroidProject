﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Prog5/Prog5MasterPage.master" AutoEventWireup="true" CodeFile="Updating.aspx.cs" Inherits="Prog5_Updating" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Prog5Body" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" style="border-style: solid; border-right-color: black; border-bottom-color:black; border-left-color:black;height:50px;width:125px;position: relative; width: 50%; margin-left: 25%" datakeynames="ProductID"  
        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" 
        AutoGenerateRows="False" CellPadding="4" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None" OnItemInserted="DetailsView1_ItemInserted" 
        OnPageIndexChanged="DetailsView1_PageIndexChanged" AllowPaging="True" OnItemDeleted="DetailsView1_ItemDeleted" OnItemUpdated="DetailsView1_ItemUpdated">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" >
            <HeaderStyle BorderStyle="Solid" />
            <ItemStyle BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
            <HeaderStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Unit Price" >
            <HeaderStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description" >
            <HeaderStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
            </asp:BoundField>
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>

    <br />
    <br />
    <br />

    <textarea id="txtMessage" runat="server" cols="20" rows="2" style="height:200px;z-index: 1; position: relative; width: 40%; margin-left:30%"></textarea>
</asp:Content>
