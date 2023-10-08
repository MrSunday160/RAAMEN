<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="manageRamen.aspx.cs" Inherits="RAAMEN.View.Admin.manageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is manage Ramen</h1>

    <asp:Label ID="Label1" runat="server" Text="Ramen Data"></asp:Label>
    <br />
    <asp:GridView ID="gvAllRamen" runat="server"></asp:GridView>
    <br />
    <br />

    <asp:Label ID="Label3" runat="server" Text="Update Ramen ID: "></asp:Label>
    <asp:TextBox ID="updateIn" runat="server"></asp:TextBox>
    <asp:Button ID="updateBtn" runat="server" Text="Update Ramen" OnClick="updateBtn_Click"/>
    <br />

    <asp:Button ID="insertBtn" runat="server" Text="Insert Ramen" OnClick="insertBtn_Click"/>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Delete Ramen ID: "></asp:Label>
    <asp:TextBox ID="deleteIn" runat="server"></asp:TextBox>
    &nbsp
    <asp:Button ID="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click"/>
    <br />

    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
