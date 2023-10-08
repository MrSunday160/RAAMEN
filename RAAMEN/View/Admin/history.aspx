<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="history.aspx.cs" Inherits="RAAMEN.View.Admin.history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is History</h1>

    <h1>All data:</h1>

    <asp:GridView ID="gvHeader" runat="server" AutoGenerateColumns="false">

        <Columns>

            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="customerID" HeaderText="Customer ID" />
            <asp:BoundField DataField="staffID" HeaderText="Staff ID" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="orderStatus" HeaderText="Order Status" />

            <asp:TemplateField HeaderText="Actions">

                <ItemTemplate>
                    <asp:Button id="viewDetailBtn" runat="server" Text="View Detail" OnClick="viewDetailBtn_Click" CommandArgument='<%# Eval("ID") %>' />
                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>
