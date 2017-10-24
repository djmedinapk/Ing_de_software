<%@ Page Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/restaurar_contraseña.aspx.cs" Inherits="view_restaurar_contraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
		    <div class="row " style="padding-bottom:200px;">		    
		     		<dl >
					  <dt class="col-sm-12">Por favor digite su nombre de usuario</dt>
					  <dd class="col-sm-10">
                          <div class="form-group">
                              <label for="inputlg"></label>
                              <asp:TextBox ID="TResetPassUser" runat="server" class="form-control input-lg" MaxLength=35 placeholder="Username" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TResetPassUser" ForeColor="Red" Font-Size="XX-Small" ></asp:RequiredFieldValidator>
						   <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario ò Correo">--%>
						  </div>
					   </dd>
					  
					  <dd class="col-sm-8">
					    <div class="form-group">
						    
                            <asp:Button ID="BResetPass" runat="server" Text="Recuperar" class="btn btn-block" OnClick="B_recuperar_Click" />
						    <%--<button type="button" class="btn btn-block">Ingresar</button>--%>
						</div>
                        <div>
                            <asp:Label ID="L_respuesta" runat="server"></asp:Label>
                        </div>
					  </dd>			  
					</dl>
		    </div>
            
</asp:Content>
