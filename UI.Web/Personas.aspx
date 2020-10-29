<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="MateriasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <style type="text/css">
        #cardPersonas {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardPersonas" class="card">
                <div class="card-header">ABM Personas</div>
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
                                <asp:BoundField HeaderText="Usuario" DataField="Usuario.NombreUsuario" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
                                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                                <asp:BoundField HeaderText="Tipo de Persona" DataField="TipoPersona" />
                                <asp:BoundField HeaderText="Habilitado" DataField="Usuario.Habilitado" />
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


                    <asp:Panel ID="formPanel" Visible="false" runat="server" Height="473px" HorizontalAlign="Left" Width="1223px">

                       
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                        <br />

                        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="nombreTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Requirednombre" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="Campo Nombre es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="apellidoTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="Campo Apellido es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="emailTextBox" runat="server" CssClass="auto-style5" Width="171px" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Campo Email es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="direccionLabel" runat="server" Text="Dirección:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="direccionTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredDireccion" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="Campo Dirección es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="telefonoLabel" runat="server" Text="Teléfono:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="telefonoTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredTelefono" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="Campo Teléfono es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="fechaNacimientoTextBox" TextMode="DateTimeLocal" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFechaNacimiento" runat="server" ControlToValidate="fechaNacimientoTextBox" ErrorMessage="Campo Fecha de Nacimiento es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="legajoLabel" runat="server" Text="Legajo:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="legajoTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredLegajo" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="Campo Legajo es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlTipoPersonas" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredDdlTipoPersonas" runat="server" ControlToValidate="ddlTipoPersonas" ErrorMessage="Campo Tipo Persona es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="planLabel" runat="server" Text="Plan:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlPlanes" runat="server" CssClass="auto-style4" Height="20px" Width="167px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlPlanesRequired" runat="server" ControlToValidate="ddlPlanes" ErrorMessage="Campo Plan es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="usuarioLabel" runat="server" Text="Usuario:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="usuarioTextBox" runat="server" CssClass="auto-style5" Width="171px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredUsuario" runat="server" ControlToValidate="usuarioTextBox" ErrorMessage="Campo Usuario es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="claveTextBox" runat="server" CssClass="auto-style5" Width="171px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredClave" runat="server" ControlToValidate="claveTextBox" ErrorMessage="Campo Clave es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

                        <asp:Label ID="confirmarClaveLabel" runat="server" Text="Confirmar clave:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="confirmarClaveTextBox" runat="server" CssClass="auto-style5" Width="171px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredConfirmarClave" runat="server" ControlToValidate="confirmarClaveTextBox" ErrorMessage="Campo Confirmar Clave es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                        <br />

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
