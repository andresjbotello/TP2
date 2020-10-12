<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
 
</asp:Content>
<asp:Content ID="MateriasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <style type="text/css">
        #cardMaterias {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardMaterias" class="card">
                <div class="card-header">ABM Comisiones</div>
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
                                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                <asp:BoundField HeaderText="Hs Semanales" DataField="hsSemanales" />
                                <asp:BoundField HeaderText="Hs Totales" DataField="hsTotales" />
                                <asp:BoundField HeaderText="Plan" DataField="IdPlan" />
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
                        <asp:Label ID="planLabel" runat="server" Text="Plan:"></asp:Label>
                        <asp:DropDownList ID="ddlPlanes" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlPlanesRequired" runat="server" ControlToValidate="ddlPlanes" ErrorMessage="Campo Planes es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="descripcionTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Requireddescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Campo Descripcion es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="HsSemanalesLabel" runat="server" Text="Hs Semanales:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="HsSemanalesTextBox" runat="server" CssClass="auto-style7" Width="90px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredHsSemanalesValidator" runat="server" ControlToValidate="HsSemanalesTextBox" ErrorMessage="Campo HS semanales es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="HsTotalesLabel" runat="server" Text="Hs Totales:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="HsTotalesTextBox" runat="server" CssClass="auto-style7" Width="91px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="HsTotalesTextBox" ErrorMessage="Campo HS Totales es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
                            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Confirmar" BackColor="lightblue" ForeColor="black" Width="126px"/>
                            <br />
                            <hr class="auto-style2" />
                            <asp:ValidationSummary ID="ValidationSummaryUsuarios" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript=True />
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
