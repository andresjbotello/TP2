<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContenPlaceHolder" runat="server">
    
    <div id="header-wrapper">
		<div id="header">
			<div id="logo" style="align-content:center">
				<h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sistema Academico</h1>
			</div>
			<div id="menu" class="auto-style2">
				<ul>
			        <li runat="server" id="liUsuarios"><a href="Usuarios.aspx">Usuarios</a></li>
                    <li runat="server" id="liPersonas"><a href="Personas.aspx">Personas</a></li>
                    <li runat="server" id="liEspecialidades"><a href="Especialidades.aspx">Especialidades</a></li>
                    <li runat="server" id="liPlanes"><a href="Planes.aspx">Planes</a></li>
                    <li runat="server" id="liMaterias"><a href="Materias.aspx">Materias</a></li>
                    <li runat="server" id="liCursos"><a href="Cursos.aspx">Cursos</a></li>
                    <li runat="server" id="liComisiones"><a href="Comisiones.aspx">Comisiones</a></li>
                    <li runat="server" id="liInscripciones"><a href="Inscripciones.aspx">Incripciones</a></li>
                    <li runat="server" id="liInscripcionesDC"><a href="InscripcionesDC.aspx">Incripciones Docentes a Cursos</a></li>

				</ul>
			</div>
		</div>
	</div>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolderHead">
    <style type="text/css">
        .auto-style2 {
            width: 222px;
        height: 193px;
    }
    </style>
</asp:Content>

