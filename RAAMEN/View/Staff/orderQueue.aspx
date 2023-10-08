<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/staffMaster.Master" AutoEventWireup="true" CodeBehind="orderQueue.aspx.cs" Inherits="RAAMEN.View.Staff.orderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is Order Queue</h1>

    <h1>Order List:</h1>

    <asp:GridView ID="gvOrders" runat="server"></asp:GridView>

    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Set Status for order Id: "></asp:Label>
    <asp:TextBox ID="idIn" runat="server"></asp:TextBox>
    <br />

    <asp:RadioButtonList ID="radioOrderStatus" runat="server">

        <asp:ListItem Text="Ongoing" Value="Ongoing"></asp:ListItem>
        <asp:ListItem Text="Done" Value="Done"></asp:ListItem>

    </asp:RadioButtonList>

    <br />
    <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"/>
    <br />

    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
