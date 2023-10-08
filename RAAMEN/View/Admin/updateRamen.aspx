<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="updateRamen.aspx.cs" Inherits="RAAMEN.View.Admin.updateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is Update Ramen Page</h1>

    <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click"/>
    <br />
    <br />

    <h1>Update ramen data:</h1>
    <br />

    <asp:GridView ID="gvDataById" runat="server"></asp:GridView>
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

    <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
