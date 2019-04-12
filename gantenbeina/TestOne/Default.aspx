<%@ Page Title="" Language="C#" MasterPageFile="~/TestOne/TestOneMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TestOne_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" Runat="Server">
    <asp:GridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="False" 
     style="z-index: 1; position: relative; width: 60%; margin-left:25%; 
     align-items: center; height: 170px">
    <Columns>
      <asp:BoundField DataField="EmpID" HeaderText="Employee ID" >
        <ItemStyle HorizontalAlign="Center"  Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="FirstName" HeaderText="First Name" >
        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="LastName" HeaderText="Last Name" >
        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="HireDate" HeaderText="Hire Date"
           DataFormatString="{0:D}" HtmlEncode="False" >
        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle></asp:BoundField>

      <asp:BoundField DataField="Position" HeaderText="Position">
        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle></asp:BoundField>
   </Columns>
   </asp:GridView>
</asp:Content>

