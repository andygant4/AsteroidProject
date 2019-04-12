<%@ Page Title="" Language="C#" MasterPageFile="~/TestOne/TestOneMasterPage.master" AutoEventWireup="true" CodeFile="Individual.aspx.cs" Inherits="TestOne_Individual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" Runat="Server">

    <br />
    <br />

    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" style="display: inline-block; position: relative; width: 15%; 
                text-align: center; margin-left: 30%; z-index: 1;"/>
    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" style="display: inline-block; position: relative; width: 15%; 
                text-align: center; margin-left: 10%; z-index: 1;"/>

    <br />
    <br />
    <br />
    <br />

    <asp:TextBox ID="txtID" runat="server" style="display: inline-block; position: relative; width: 10%; 
                text-align: left; margin-left: 15%; z-index: auto;" ReadOnly="True"></asp:TextBox>
    <asp:TextBox ID="txtFirst" runat="server" style="display: inline-block; position: relative; width: 10%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtLast" runat="server" style="display: inline-block; position: relative; width: 10%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtHireDate" runat="server" style="display: inline-block; position: relative; width: 10%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>
    <asp:TextBox ID="txtPosition" runat="server" style="display: inline-block; position: relative; width: 10%; 
                text-align: left; margin-left: 5%; z-index: auto;"></asp:TextBox>

    <br />
    <br />
    <br />
    <br />
    
    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" style="display: inline-block; position: relative; width: 15%; 
                text-align: center; margin-left: 17.5%; z-index: auto;"/>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" style="display: inline-block; position: relative; width: 15%; 
                text-align: center; margin-left: 10%; z-index: auto;"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="display: inline-block; position: relative; width: 15%; 
                text-align: center; margin-left: 10%; z-index: auto;"/>

    <br />
    <br />
    <br />

    <textarea id="txtMessage" runat="server" cols="20" rows="2" ReadOnly ="true" style="height:200px;z-index: 1; position: relative; width: 50%; margin-left:25%"></textarea>
</asp:Content>

