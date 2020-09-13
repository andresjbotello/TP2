<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css" style="background-color: transparent; background-image: url(Resources/UTN.png);">
        .auto-style1 {
            width: 1274px;
        }
        .auto-style2 {
            height: 29px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
            width: 1209px;
        }
        .auto-style5 {
            width: 1209px;
        }
        .auto-style6 {
            height: 29px;
            width: 1274px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2" align="center" colspan="4">
                    <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenidos!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" align="right">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td class="auto-style4">
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1" align="right">
            <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                </td>
                <td class="auto-style5">
            <asp:TextBox ID="txtClave" runat="server" textmode="password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" align="right">
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
                <td class="auto-style5" align="left">
            <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click"/>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
        <p>
        
    <asp:Label ID="estadolbl" runat="server" Text="" align="right" ForeColor="#FF3300"></asp:Label>
        </p>
    </form>
</body>
</html>