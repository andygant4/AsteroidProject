<%@ Page Title="" Language="C#" MasterPageFile="~/Prog5/Prog5MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Prog5_Checkout" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Prog5Body" Runat="Server">

        <asp:GridView ID="GridView1" style="width: 60%; margin-left:20%; border-style: solid; border-right-color: black; border-bottom-color:black; border-left-color:black; border-top-color:black" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Product ID" HeaderText="Product ID" >
            <ControlStyle BorderStyle="Solid" />
            <FooterStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="Product Name" HeaderText="Product Name" >
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" >
            <ControlStyle BorderStyle="Solid" />
            <FooterStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="Unit Price" DataFormatString="{0:c}" HeaderText="Unit Price">
            <ItemStyle HorizontalAlign="Right" BorderStyle="Solid" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="Cost" DataFormatString="{0:c}" HeaderText="Cost" >
            <ControlStyle BorderStyle="Solid" />
            <FooterStyle BorderStyle="Solid" />
            <ItemStyle BorderStyle="Solid" HorizontalAlign="Right" Width="10%" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <br />
    <br />
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" style="position: relative; width:20%; margin-left: 40%" OnClick="btnCheckout_Click" />
</asp:Content>