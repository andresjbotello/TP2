<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<style type="text/css">
        #cardInscripciones {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardInscripciones" class="card">
                <div class="card-header">ABM Inscripciones</div>
                <div class="card-body">
    <asp:LinkButton ID="lbEditar" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="lbEliminar" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="lbNuevo" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    <asp:Panel ID="Panel1" runat="server" BackColor="#6699FF" ScrollBars="Vertical">
        <asp:GridView ID="gvInscripciones" runat="server" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" GridLines="None" Width="376px" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Inscripcion" />
                <asp:BoundField DataField="IDAlumno" HeaderText="ID Alumno" />
                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                <asp:BoundField DataField="CondicionActual" HeaderText="Condición" />
                <asp:BoundField DataField="nota" HeaderText="Nota" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelABM" runat="server" BackColor="#336699" Direction="LeftToRight" Height="227px" style="margin-left: 0px">
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label3" runat="server" Text="ID del Alumno"></asp:Label>
        <asp:DropDownList ID="ddlAlumno" runat="server" Height="21px" Width="128px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label5" runat="server" Text="ID del Curso"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="ddlCurso" runat="server" Height="18px" Width="127px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Condicion"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCondicion" runat="server" Height="16px" Width="126px" AutoPostBack="True" OnSelectedIndexChanged="ddlCondicion_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNota" ErrorMessage="Debe colocar una  nota entre 0 y 10" ValidationGroup="vgIns">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Nota"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbNota" runat="server" Min="1" Max="10" MaxLength="2" TextMode="Number" ></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbNota" Display="None" ErrorMessage="La nota debe ser entre 0 y 10" ForeColor="Red" MaximumValue="10" MinimumValue="0" SetFocusOnError="True" Type="Integer" ValidationGroup="vgIns">*</asp:RangeValidator>
        <br />
        <br />
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click" ValidationGroup="vgIns" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vgIns" />
    </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>