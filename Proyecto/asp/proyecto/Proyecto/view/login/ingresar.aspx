﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/ingresar.aspx.cs" Inherits="view_login_ingresar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../App_Themes/css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
  			<div class="col text-right">
  				<label class="mr-5 mt-5 "><h2>Iniciar Sesion</h2></label>
  			</div>
  			<div class="col">
  				<label class="ml-3 mt-5 "><h2>Registrarse</h2></label>
  			</div>
  		</div>	
		 <div class="row align-items-center ">
             <form id="form2" >
		    <div class="col login_div ">		    
		     		<dl class="row ">
					  <dt class="col-sm-3"></dt>
					  <dd class="col-sm-8">
					  	<div class="form-group">
						    <label for="inputlg"></label>
                              <asp:TextBox ID="TloginUser" runat="server" class="form-control input-lg" MaxLength=50 placeholder="Usuario o Correo"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TloginUser" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="h"></asp:RequiredFieldValidator>
						   <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario ò Correo">--%>
						  </div>

					   </dd>

					  <dt class="col-sm-3"></dt>
					  <dd class="col-sm-8">
					    <div class="form-group">
						    <label for="inputlg"></label>
                            <asp:TextBox ID="TloginPassword" runat="server" class="form-control input-lg" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TloginPassword" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="h"></asp:RequiredFieldValidator>
                            <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-3"></dt>
					  <dd class="col-sm-8">
					    <div class="form-group">
						    <label for="inputlg"></label>
                            <asp:Button ID="Blogin" runat="server" Text="Ingresar" class="btn btn-block" ValidationGroup="h" />
						    <%--<button type="button" class="btn btn-block">Ingresar</button>--%>
						  </div>
					  </dd>			  
					</dl>
		    </div>
             </form>
		    <div class="col">		    
		     		<dl class="row ">
					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					  	<div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                              <asp:TextBox ID="TregistroCorreo" runat="server" class="form-control input-lg" placeholder="Correo" TextMode="Email"></asp:TextBox>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroCorreo" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                              <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
						  </div>

					   </dd>
					   <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					  	<div class="form-group">
						    <%--<label for="inputlg"></label>--%>
                              <asp:TextBox ID="TregistroUser" runat="server" class="form-control input-lg" placeholder="Usuario"></asp:TextBox>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroUser" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                              <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">--%>
						  </div>

					   </dd>

					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:TextBox ID="TregistroPassword" runat="server" class="form-control input-lg" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
						   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroPassword" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:TextBox ID="TregistroPassword2" runat="server" class="form-control input-lg" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroPassword2" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
						    <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Confirmar Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:Button ID="Bregistro" runat="server" Text="Crear Cuenta" class="btn btn-warning btn-block"/>
						    <%--<button type="button" class="btn btn-warning btn-block">Crear Cuenta</button>--%>
						  </div>
					  </dd>			  
					</dl>
		    </div>    
		  </div>


</asp:Content>
