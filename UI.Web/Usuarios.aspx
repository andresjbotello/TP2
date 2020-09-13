<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" BackColor="Black" DataKeyNames="ID" ForeColor="White">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" SortExpression="NombreUsuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" SortExpression="Habilitado" />
                <asp:CommandField HeaderText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
