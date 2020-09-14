<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContenPlaceHolder" runat="server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 3px;
        }
        .auto-style5 {
            margin-left: 70px;
        }
        .auto-style6 {
            margin-left: 91px;
        }
        .auto-style8 {
            margin-left: 57px;
        }
    </style>

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
                <asp:BoundField HeaderText="ID" DataField="id" />
                <asp:BoundField HeaderText="Comision" DataField="Descripcion" />
                <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="IDPlan" />
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
        <div style="align-content:center">
        &nbsp;
        <br />
        <asp:Label ID="DescComLabel" runat="server" Text="Descripcion:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="DescComTextBox" runat="server" CssClass="auto-style5" Width="97px"></asp:TextBox>
        &nbsp;
            <asp:RequiredFieldValidator ID="DescComRequiredFieldVal" runat="server" ControlToValidate="DescComTextBox" ErrorMessage="Campo Descripcion es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="EspecialidadLabel" runat="server" Text="Especialidad:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="auto-style8" Width="165px" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Campo Especialidad es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="AnoEspecialidadLabel" runat="server" Text="Año Especialidad:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="anoEspecialidadTextBox" runat="server" CssClass="auto-style3" Width="155px" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="anoEspecialidadTextBox" ErrorMessage="Campo Año Especialidades es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PlanesLabel" runat="server" Text="Planes:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlPlanes" runat="server" CssClass="auto-style6" Width="175px" AutoPostBack="True"></asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlPlanes" ErrorMessage="Campo Planes es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        </div>
        
          
        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Aceptar" BackColor="lightblue" ForeColor="black" Width="93px"/>
            <asp:Button ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" Text="Cancelar" BackColor="lightblue" ForeColor="black" />
            <asp:ValidationSummary ID="ValidationSummaryUsuarios" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript=True />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
