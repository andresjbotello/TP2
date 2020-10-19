<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <style type="text/css">
        #cardCursos {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardCursos" class="card">
                <div class="card-header">ABM Cursos</div>
                <div class="card-body">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            &nbsp;&nbsp;
            </asp:Panel>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectRowStyle-BackColor="Black"
            SelectRowStyle-Forecolor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <columns>
                <asp:BoundField HeaderText="Nro Curso" DataField="id" />
                <asp:BoundField HeaderText="Materia" DataField="IdMateria" />
                <asp:BoundField HeaderText="Comision" DataField="IdComision" />
                <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                <asp:BoundField DataField="cupo" HeaderText="Cupo" />
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
        <asp:Label ID="nroCursoLabel" runat="server" Text="Nro Curso:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="nroCursoTextBox" runat="server" CssClass="auto-style5" ReadOnly="true" Width="39px"></asp:TextBox>
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="EspecialidadesLabel" runat="server" Text="Especialidades:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="auto-style3" Width="178px" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Campo Especialidades es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PlanesLabel" runat="server" Text="Planes:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlPlanes" runat="server" CssClass="auto-style6" Width="175px" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlPlanes" ErrorMessage="Campo Planes es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="materiaLabel" runat="server" Text="Materia:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlMaterias" runat="server" CssClass="auto-style7" Width="170px" AutoPostBack="True"></asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMaterias" ErrorMessage="Campo Materia es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="ComisionLabel" runat="server" Text="Comision:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlComisiones" runat="server" CssClass="auto-style4" Width="170px" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlComisiones" ErrorMessage="Campo Comision es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="AnoLabel" runat="server" Text="Año:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="AnoTextBox" runat="server" CssClass="auto-style2" Width="78px"></asp:TextBox>
        <br />
        <asp:Label ID="CupoLabel" runat="server" Text="Cupo:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="CupoTextBox" runat="server" Width="94px" CssClass="auto-style6"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CupoTextBox" ErrorMessage="Campo Cupo es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
     
        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Confirmar" BackColor="lightblue" ForeColor="black" Width="106px"/>
            <div><asp:Label ID="Info" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label></div>
            <asp:ValidationSummary ID="ValidationSummaryUsuarios" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript="true" />
        </asp:Panel>
    </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>