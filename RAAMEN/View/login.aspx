<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/RAAMEN.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RAAMEN.View.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="userIn" runat="server"></asp:TextBox>

    <br />

    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passIn" runat="server" TextMode="Password"></asp:TextBox>

    <br />

    <asp:RadioButton ID="rememberRadio" runat="server" Text="Remember Me"/>
    <br />

    <asp:Button ID="loginBtn" runat="server" Text="Log In" OnClick="loginBtn_Click" />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
