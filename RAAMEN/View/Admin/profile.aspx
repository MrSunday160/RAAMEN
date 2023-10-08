<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="RAAMEN.View.Admin.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is profile</h1>

    <asp:Label ID="Label5" runat="server" Text="Your Profile:"></asp:Label>
    <asp:GridView ID="gvProfile" runat="server"></asp:GridView>

    <br />
    <br />

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
    <br />

    <asp:Label ID="Label4" runat="server" Text="Confirm Your Password"></asp:Label>
    <asp:TextBox ID="passConfIn" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
