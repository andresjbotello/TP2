<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <div class="d-flex justify-content-center">
		<div class="d-flex flex-column">
            <div class="card" style="margin-top: 20px;">
                <div class="card-header">Sistema Académico</div>
                <div class="card-body">
                    <div id="menu">
			            <ul>
                            <li runat="server" id="liPersonas"><a href="Personas.aspx">Personas</a></li>
                            <li runat="server" id="liEspecialidades"><a href="Especialidades.aspx">Especialidades</a></li>
                            <li runat="server" id="liPlanes"><a href="Planes.aspx">Planes</a></li>
                            <li runat="server" id="liMaterias"><a href="Materias.aspx">Materias</a></li>
                            <li runat="server" id="liCursos"><a href="Cursos.aspx">Cursos</a></li>
                            <li runat="server" id="liComisiones"><a href="Comisiones.aspx">Comisiones</a></li>
                            <li runat="server" id="liInscripciones"><a href="Inscripciones.aspx">Inscripciones</a></li>
                            <li runat="server" id="liInscripcionesDC"><a href="DocentesCursos.aspx">Inscripciones Docentes a Cursos</a></li>
			            </ul>
		            </div>
                </div>
            </div>
		    
		</div>
	</div>
    
</asp:Content>


