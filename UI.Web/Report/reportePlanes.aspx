<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportePlanes.aspx.cs" Inherits="UI.Web.Report.reportePlanes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="creportePlanes" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <rsweb:ReportViewer ID="RvPlanes" runat="server" Height="499px" Width="1462px" >

       <LocalReport ReportPath="Report/repPlanes.rdlc">
       </LocalReport>

</rsweb:ReportViewer>

</asp:Content>