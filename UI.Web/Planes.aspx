<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>


<asp:Content ID="PlanesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

     <style type="text/css">
        #cardPlanes {
            margin-top: 20px;
        }
    </style>
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column">
            <div id="cardPlanes" class="card">
                <div class="card-header">ABM Planes</div>
                <div class="card-body">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
&nbsp;
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            &nbsp;
            </asp:Panel>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectRowStyle-BackColor="Black"
            SelectRowStyle-Forecolor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <columns>
                <asp:BoundField DataField="IdEspecialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:CommandField ShowSelectButton="True" />
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
        <br />
        <hr />
    </asp:Panel>
    
    <asp:Panel ID="formPanel" Visible="false" runat="server" Height="293px" HorizontalAlign="Left" Width="1223px">
        <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEspecialidades" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="ddlEspecialidadesRequiered" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Campo Especialidad es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Requireddescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Campo Descripcion es requerido" ForeColor="#FF3300" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        
     
        <br />
        
     
        <asp:Panel ID="formActionPanel" runat="server" Height="27px" Width="1221px">
            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" Text="Confirmar" BackColor="lightblue" ForeColor="black" Width="114px"/>
            <asp:ValidationSummary ID="ValidationSummaryUsuarios" runat="server" BackColor="White" ForeColor="#FF3300" ValidationGroup="vg" EnableClientScript=True Height="63px" Width="1461px" />
        </asp:Panel>
    </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
