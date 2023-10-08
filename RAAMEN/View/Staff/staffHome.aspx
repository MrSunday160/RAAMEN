<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/staffMaster.Master" AutoEventWireup="true" CodeBehind="staffHome.aspx.cs" Inherits="RAAMEN.View.Staff.staffHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is staff home</h1>

    <asp:Label ID="Label1" runat="server" Text="Customer Data"></asp:Label>
    <br />
    <asp:GridView ID="gvMember" runat="server"></asp:GridView>

</asp:Content>
