<%@ Page Title="" Language="C#" MasterPageFile="~/Prog3/Prog3MasterPage.master" AutoEventWireup="true" CodeFile="Updating.aspx.cs" Inherits="Prog3_Updating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" Runat="Server">
    <asp:Button ID="btnFirst" runat="server" Text="First" OnClick="btnFirst_Click" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 22.5%; z-index: 1;" />
    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click1" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 5%; z-index: 1;"/>
    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click1" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 5%; z-index: 1;"/>
    <asp:Button ID="btnLast" runat="server" Text="Last" OnClick="btnLast_Click" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 5%; z-index: 1;"/>
    <br />
    <br />

    <asp:Label ID="LabelID" runat="server" Text="Product ID" style="display: inline-block; width: 15%; z-index: 1; 
                position: relative; width: 15%; margin-left:12.5%; text-align: center"></asp:Label>
    <asp:Label ID="LabelName" runat="server" Text="Product Name" style="display: inline-block; width: 15%; z-index: 1; 
                position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>
    <asp:Label ID="LabelPrice" runat="server" Text="Unit Price" style="display: inline-block; width: 15%; z-index: 1; 
                position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>
    <asp:Label ID="LabelDescripton" runat="server" Text="Description" style="display: inline-block; width: 15%; z-index: 1; 
                position: relative; width: 15%; margin-left:5%; text-align: center"></asp:Label>

    <br />
    <asp:TextBox ID="txtID" runat="server" style="display: inline-block; position: relative; width: 15%; 
                text-align: left; margin-left: 12.5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server" style="display: inline-block; position: relative; width: 15%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" style="display: inline-block; position: relative; width: 15%; 
                text-align: right; margin-left: 5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtDescription" runat="server" style="display: inline-block; position: relative; width: 15%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>

    <br />
    <br />

    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 25%; z-index: auto;"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 10%; z-index: auto;"/>
    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" style="display: inline-block; position: relative; width: 10%; 
                text-align: center; margin-left: 10%; z-index: auto;"/>

    <br />
    <br />

    <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
</asp:Content>

