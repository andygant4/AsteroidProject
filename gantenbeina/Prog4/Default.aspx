<%@ Page Title="" Language="C#" MasterPageFile="~/Prog4/Prog4MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Prog4_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Prog4Body" Runat="Server">

    <asp:GridView ID="GridView1" style="width: 60%; margin-left:20%; align-items: center; height: 176px; border-style: solid; border-right-color: black; border-bottom-color:black; border-left-color:black; border-top-color:black" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnPageIndexChanged="GridView1_PageIndexChanged" PageSize="5">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" >
        <ControlStyle BorderStyle="Solid" />
        <FooterStyle BorderStyle="Solid" />
        <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
        <ItemStyle BorderStyle="Solid" HorizontalAlign="Left" Width="20%" />
        </asp:BoundField>
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Unit Price">
        <ItemStyle HorizontalAlign="Right" BorderStyle="Solid" Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="Description" HeaderText="Description" >
        <ItemStyle BorderStyle="Solid" HorizontalAlign="Right" Width="10%" />
        </asp:BoundField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
</asp:Content>