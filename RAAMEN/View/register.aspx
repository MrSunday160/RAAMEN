<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/RAAMEN.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="RAAMEN.View.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="userIn" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="emailIn" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
    <asp:RadioButtonList ID="radioGender" runat="server">

        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>

    </asp:RadioButtonList>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passIn" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
    <asp:TextBox ID="passInConfirm" runat="server"></asp:TextBox>
    <br />

    <br />
    <asp:Label ID="Label6" runat="server" Text="Role:"></asp:Label>
    <br />

    <asp:RadioButtonList ID="radioRole" runat="server">

        <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
        <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>

    </asp:RadioButtonList>

    <asp:Button ID="regisBtn" runat="server" Text="Register" OnClick="regisBtn_Click" />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
