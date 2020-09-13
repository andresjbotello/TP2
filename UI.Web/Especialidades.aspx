<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="EspecialidadesContent" ContentPlaceHolderID="bodyContenPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectRowStyle-BackColor="Black"
            SelectRowStyle-Forecolor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <hr />
    </asp:Panel>
    
    <asp:Panel ID="formPanel" Visible="false" runat="server" Height="293px" HorizontalAlign="Left" Width="1223px">
        <br />
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Requireddescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Campo Descripcion es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        
     
        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Confirmar" BackColor="lightblue" ForeColor="black" Width="110px"/>
            <asp:ValidationSummary ID="ValidationSummaryUsuarios" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript=True />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
