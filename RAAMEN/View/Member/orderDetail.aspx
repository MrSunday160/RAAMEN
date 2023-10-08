<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/memberMaster.Master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="RAAMEN.View.Member.orderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is Order Detail</h1>

    <h1>Order Detail:</h1>
    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" >

        <Columns>

            <asp:BoundField DataField="headerID" HeaderText="Header ID" />
            <asp:BoundField DataField="customerID" HeaderText="Customer ID" />
            <asp:BoundField DataField="staffID" HeaderText="Staff ID" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="ramenID" HeaderText="Ramen ID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="orderStatus" HeaderText="Order Status" />

        </Columns>

    </asp:GridView>

</asp:Content>
