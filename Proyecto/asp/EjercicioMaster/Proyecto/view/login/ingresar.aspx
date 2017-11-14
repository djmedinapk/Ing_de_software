<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/ingresar.aspx.cs" Inherits="view_login_ingresar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../App_Themes/css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row" style="height:50px;"><center>
                         <asp:Label ID="LMensaje" runat="server" ForeColor="#99FF33" Text=""></asp:Label>
                     </center>
       
    </div>
    <div class="row">
  			<div class="col text-right">
  				<label class="mr-5 mt-3 "><h2>Iniciar Sesion</h2></label>
  			</div>
  			<div class="col">
  				<label class="ml-3 mt-3 "><h2>Registrarse</h2></label>
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
                              <asp:TextBox ID="TloginUser" runat="server" class="form-control input-lg text-lowercase" MaxLength=50 placeholder="Usuario o Correo"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TloginUser" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="h"></asp:RequiredFieldValidator>
						      <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TloginUser" />
                              <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario ò Correo">--%>
						    
						  </div>

					   </dd>

					  <dt class="col-sm-3"></dt>
					  <dd class="col-sm-8">
					    <div class="form-group">
						    <label for="inputlg"></label>
                            <asp:TextBox ID="TloginPassword" runat="server" class="form-control input-lg" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TloginPassword" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="h"></asp:RequiredFieldValidator>
                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TloginPassword" />
                            <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-3"></dt>
					  <dd class="col-sm-8">
					    <div class="form-group">
						    <label for="inputlg"></label>
                            <asp:Button ID="Blogin" runat="server" Text="Ingresar" class="btn btn-block" ValidationGroup="h" OnClick="Blogin_Click" />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/view/login/restaurar_contraseña.aspx">Recuperar Contraseña</asp:HyperLink>
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
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-ñ.@" TargetControlID="TregistroCorreo" />
                              <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
						  </div>

					   </dd>
					   <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					  	<div class="form-group">
						    <%--<label for="inputlg"></label>--%>
                              <asp:TextBox ID="TregistroUser" runat="server" class="form-control input-lg text-lowercase" placeholder="Usuario"></asp:TextBox>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroUser" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TregistroUser" />
                              <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">--%>
						  </div>

					   </dd>

					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:TextBox ID="TregistroPassword" runat="server" class="form-control input-lg" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
						   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroPassword" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                           <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Debe contener numeros y letras" ControlToValidate="TregistroPassword" ForeColor="Red" ValidationExpression="[a-zA-Z]+\w*\d+\w*"></asp:RegularExpressionValidator>--%>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-$ñ" TargetControlID="TregistroPassword" />
                            <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:TextBox ID="TregistroPassword2" runat="server" class="form-control input-lg" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TregistroPassword2" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="TregistroPassword" ControlToValidate="TregistroPassword2" ForeColor="Red"></asp:CompareValidator>
						    <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Confirmar Contraseña">--%>
						  </div>
					  </dd>	
					  <dt class="col-sm-0"></dt>
					  <dd class="col-sm-9">
					    <div class="form-group">
						   <%-- <label for="inputlg"></label>--%>
                            <asp:Button ID="Bregistro" runat="server" Text="Crear Cuenta" class="btn btn-warning btn-block" OnClick="Bregistro_Click"/>
						    <%--<button type="button" class="btn btn-warning btn-block">Crear Cuenta</button>--%>
						  </div>
					  </dd>			  
					</dl>
		    </div>    
		  </div>


</asp:Content>

