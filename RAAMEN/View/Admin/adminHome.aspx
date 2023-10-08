<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="RAAMEN.View.Admin.adminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is admin home</h1>

    <h1>Staff data:</h1>

    <asp:GridView ID="gvStaffData" runat="server"></asp:GridView>

</asp:Content>
