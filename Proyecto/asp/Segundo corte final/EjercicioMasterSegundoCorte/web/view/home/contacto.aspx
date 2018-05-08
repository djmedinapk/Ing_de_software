<%@ Page Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/contacto.aspx.cs" Inherits="view_home_contacto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
       
    <div class="row">
        <div class="col-md-12">
            <div class="well well-sm">
                <form class="form-horizontal" method="post">
                    <fieldset>
                        <legend class="text-center header"><asp:Label ID="L_contactenos" runat="server" Text="Contactenos"></asp:Label></legend>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_nombre" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Nombre"  ></asp:TextBox>
                               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_nombre" ForeColor="Red" ValidationExpression="[a-zA-Z ]*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_nombre" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="ñ " TargetControlID="Tcontacto_nombre" />
                            </div>
                        </div>
                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_apellido" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Apellido"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_apellido" ForeColor="Red" ValidationExpression="[a-zA-Z ]*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_apellido" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="ñ " TargetControlID="Tcontacto_apellido" />
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-envelope-o bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_correo" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Correo electrónico"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_correo" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_correo" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="@_-ñ." TargetControlID="Tcontacto_correo" />
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-phone-square bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_telefono" runat="server" class="form-control input-lg" MaxLength=20 placeholder="Teléfono" TextMode="Number"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_telefono" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_telefono" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers, Custom" ValidChars="" TargetControlID="Tcontacto_telefono" />
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-pencil-square-o bigicon"></i></span>
                            <div class="col-md-8">
                                <asp:TextBox ID="Tcontacto_contenido" runat="server" class="form-control input-lg" MaxLength=2000 placeholder="Escriba aquí su solicitud (2000 caracteres máximo)" TextMode="MultiLine" Rows="7"  ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_contenido" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="@/-_´´{}()*-+|#" TargetControlID="Tcontacto_contenido" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-8 text-center">
                                <asp:Button ID="B_contacto" runat="server" Text="Enviar" class="btn btn-block" OnClick="B_contacto_Click" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>


		 



    


    <!-- Optional JavaScript -->
            
</asp:Content>
