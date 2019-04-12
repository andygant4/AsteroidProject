<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TestJSON_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" Runat="Server">
    <h4>Answer the question by matching your answer with the question!</h4>
    <asp:Image ID="Image1" runat="server" style="align-content:center" />
    <br/>
    <br/>
    <asp:Label ID="lblAnswer" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="ddAnswers" runat="server" style="border-style:Solid;z-index: 1; position: relative; width: 17%; margin-left: 30%; top: 0px; left: -15px;">
    </asp:DropDownList>
    <br/>
    <br/>

    <asp:Button ID="btnNext" runat="server" Text="Button" style="align-content:center" OnClick="Button1_Click" />
    <%--  <a href="javascript:void(0)" onclick="addQuestion()">test this shit</a>

    <script>
        function addQuestion() {
            var r = document.createElement('Div');
            r.style.height = "200px";
            r.style.width = "25px";
            r.style.position = "fixed";
            r.style.backgroundColor = "red";
            
        }
    </script>--%>
</asp:Content>

