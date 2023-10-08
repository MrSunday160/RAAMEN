<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/memberMaster.Master" AutoEventWireup="true" CodeBehind="orderRamen.aspx.cs" Inherits="RAAMEN.View.Member.orderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is Order Ramen</h1>

    <h1>Ramen Details:</h1>

    <asp:GridView id="gvRamenData" runat="server" AutoGenerateColumns="false">

        <Columns>

            <asp:BoundField DataField="ID" HeaderText="Ramen ID" />
            <asp:BoundField DataField="meatID" HeaderText="meatID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Broth" HeaderText="Broth" />
            <asp:BoundField DataField="Price" HeaderText="Price" />

            <asp:TemplateField>

                <ItemTemplate>

                    <asp:TextBox ID="qtyIn" runat="server" placeholder="Quantity"></asp:TextBox>

                    <asp:Button id="addToCartBtn" runat="server" Text="Add To Cart" OnClick="addToCartBtn_Click" CommandArgument='<%# Eval("ID") %>' />

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <h1>Your cart:</h1>

    <asp:GridView ID="gvCart" runat="server"></asp:GridView>

    <br />
    <asp:Button ID="clearBtn" runat="server" Text="Clear Cart" OnClick="clearBtn_Click" />
    <asp:Button ID="orderBtn" runat="server" Text="Order" OnClick="orderBtn_Click" />
    &nbsp
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</asp:Content>
