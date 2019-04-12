<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Prog2_Default" %>

<!DOCTYPE html>

<%--/*
//---------------------------------------------------------------------------------------------
// Class : CS 3870
//
// Name : Andrew Gantenbein
//
// UserName : gantenbeina
//
// Description: Page Default.aspx of Prog2
//
//-----------------------------------------------------------------------------------------------%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CS3870 - Program 2</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet.css" />
    <style type="text/css">
        .centerPage {
            margin: auto;
            width: 20%;
        }
        .CS3870Program {
            font-family: Terminal;
            color: #FF0000;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="CS3870Title">Web Protocols, Technologies and Applications</h1>
            <h2 class="CS3870Name">Andrew Gantenbein</h2>
             <ul class="navbar">
                <li><a href ="Default.aspx">Start Page</a></li>
                <li><a href ="OrderingProduct.aspx">Order Form</a></li>
            </ul>
            <h3 class="CS3870Program">CS 3870: Program 2</h3>
            <ul class="centerPage">
                <li> Dynamic Pages </li>
                <li> PostBack </li>
                <li> Event Procedures </li>
                <li> Validation </li>
                <li> Style and CSS Files </li>
            </ul>
        </div>
    </form>
</body>
</html>
