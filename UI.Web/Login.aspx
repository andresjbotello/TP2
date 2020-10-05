<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--esto es para Bootstrap-->
        <asp:ScriptManager ID="ScriptManager1" runat="server">  
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-3.5.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
        </Scripts>
        </asp:ScriptManager>
        <!---->

        <div class="d-flex justify-content-center">
            <div class="d-flex flex-column">
                <div class="display-4">¡Bienvenido!</div>
                <div class="form-group">
                    <asp:Label ID="lblUsuario" runat="server">Usuario: </asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblClave" runat="server">Clave: </asp:Label>
                    <asp:TextBox ID="txtClave" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click"/>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        
        <p>
        
    <asp:Label ID="estadolbl" runat="server" Text="" align="right" ForeColor="#FF3300"></asp:Label>
        </p>
    </form>
</body>
</html>