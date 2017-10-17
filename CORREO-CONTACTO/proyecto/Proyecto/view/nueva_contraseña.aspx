<%@ Page Language="C#" MasterPageFile="~/Master1.master" AutoEventWireup="true" CodeFile="~/Controller/view/nueva_contraseña.aspx.cs" Inherits="view_nueva_contraseña" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
            <div class="row " >		    
		     		<dl >
					  <dt class="col-sm-15">Escriba su nueva contraseña</dt>
					  <dd class="col-sm-10">
                          <div class="form-group">
                              <label for="inputlg"></label>
                              <asp:TextBox ID="TNewPassUser" runat="server" class="form-control input-lg" MaxLength=30 placeholder="Nueva contraseña" TextMode="Password"  ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TNewPassUser" ForeColor="Red" Font-Size="XX-Small" ></asp:RequiredFieldValidator>
						   <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario ò Correo">--%>
						  </div>
					   </dd>
                        <dd class="col-sm-10">
                          <div class="form-group">
                              <label for="inputlg"></label>
                              <asp:TextBox ID="TNewPassUser2" runat="server" class="form-control input-lg" MaxLength=30 placeholder="Repita la contraseña" TextMode="Password" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TNewPassUser2" ForeColor="Red" Font-Size="XX-Small" ></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Verifique la contraseña ingresada" ControlToCompare="TNewPassUser2" ControlToValidate="TNewPassUser" ForeColor="#FF3300"></asp:CompareValidator>
						   <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario ò Correo">--%>
						  </div>
					   </dd>
					  
					  <dd class="col-sm-8">
					    <div class="form-group">
						    
                            <asp:Button ID="BCambiarcontraseña" runat="server" Text="Cambiar contraseña" class="btn btn-block" OnClick="BCambiarcontraseña_Click" />
						    <%--<button type="button" class="btn btn-block">Ingresar</button>--%>
						</div>
                        <div>
                            <asp:Label ID="L_respuesta" runat="server"></asp:Label>
                        </div>
					  </dd>			  
					</dl>
		    </div>
            
</asp:Content>
