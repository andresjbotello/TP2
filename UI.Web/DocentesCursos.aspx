<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="DocentesCursosContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <style type="text/css">
        #cardDocentesCursos {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardDocentesCursos" class="card">
                <div class="card-header">ABM Docentes y Cursos</div>
                <div class="card-body">
                    <asp:Panel ID="gridPanel" runat="server" ScrollBars="Vertical">
                        <asp:Panel ID="gridActionPanel" runat="server">
                        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
                    </asp:Panel>
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                            SelectRowStyle-BackColor="Black"
                            SelectRowStyle-Forecolor="White"
                            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 0px" Width="995px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" />
                                <asp:BoundField HeaderText="ID Docente" DataField="IDDocente" />
                                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
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
                        <hr class="auto-style2" />
                    </asp:Panel>
    
                    <asp:Panel ID="formPanel" Visible="false" runat="server" Height="293px" HorizontalAlign="Left" Width="1223px">

                        <!-- Sección de docente -->
                        <asp:Label ID="docenteLabel" runat="server" Text="Docente:"></asp:Label>
                        <asp:DropDownList ID="ddlDocentes" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlDocentesRequired" runat="server" ControlToValidate="ddlDocentes" ErrorMessage="Campo Docente es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                         <!-- Sección de curso -->
                        <asp:Label ID="cursoLabel" runat="server" Text="Curso:"></asp:Label>
                        <asp:DropDownList ID="ddlCursos" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlCursosRequired" runat="server" ControlToValidate="ddlCursos" ErrorMessage="Campo Curso es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                         <!-- Sección de cargo -->
                        <asp:Label ID="cargoLabel" runat="server" Text="Cargo:"></asp:Label>
                        <asp:DropDownList ID="ddlCargos" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlCargosRequired" runat="server" ControlToValidate="ddlCargos" ErrorMessage="Campo Cargo es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />
                       
                        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
                            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Confirmar" BackColor="lightblue" ForeColor="black" Width="126px"/>
                            <br />
                            <hr class="auto-style2" />
                            <asp:ValidationSummary ID="ValidationSummaryDocentesCursos" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript=True />
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>