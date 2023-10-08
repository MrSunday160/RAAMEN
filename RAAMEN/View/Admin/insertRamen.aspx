<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="insertRamen.aspx.cs" Inherits="RAAMEN.View.Admin.insertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is Insert Ramen Page</h1>
    <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click"/>
    <br />
    <br />

    <h1>Insert ramen data:</h1>
    <br />

    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="nameIn" runat="server"></asp:TextBox>
    <br />

    <asp:RadioButtonList ID="radioMeat" runat="server">
        <asp:ListItem Text="Pork" Value="Pork"></asp:ListItem>
        <asp:ListItem Text="Beef" Value="Beef"></asp:ListItem>
        <asp:ListItem Text="Chicken" Value="Chicken"></asp:ListItem>

    </asp:RadioButtonList>

    <asp:Label ID="Label3" runat="server" Text="Broth"></asp:Label>
    <asp:TextBox ID="brothIn" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="priceIn" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click"/>
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
