<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/adminMaster.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="RAAMEN.View.Admin.report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>This is report</h1>

    <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" />

</asp:Content>
