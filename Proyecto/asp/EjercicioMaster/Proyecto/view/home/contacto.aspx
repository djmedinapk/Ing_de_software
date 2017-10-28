<%@ Page Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/contacto.aspx.cs" Inherits="view_home_contacto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
        <div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="well well-sm">
                <form class="form-horizontal" method="post">
                    <fieldset>
                        <legend class="text-center header">Contactenos</legend>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_nombre" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Nombre"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_nombre" ForeColor="Red" ValidationExpression="[a-zA-Z ]*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_nombre" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_apellido" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Apellido"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_apellido" ForeColor="Red" ValidationExpression="[a-zA-Z ]*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_apellido" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-envelope-o bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_correo" runat="server" class="form-control input-lg" MaxLength=80 placeholder="Correo electrónico"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_correo" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_correo" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-phone-square bigicon"></i></span>
                            <div class="col-md-8">
                              <asp:TextBox ID="Tcontacto_telefono" runat="server" class="form-control input-lg" MaxLength=20 placeholder="Teléfono" TextMode="Number"  ></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="Tcontacto_telefono" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_telefono" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-pencil-square-o bigicon"></i></span>
                            <div class="col-md-8">
                                <asp:TextBox ID="Tcontacto_contenido" runat="server" class="form-control input-lg" MaxLength=2000 placeholder="Escriba aquí su solicitud (2000 caracteres máximo)" TextMode="MultiLine" Rows="7"  ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcontacto_contenido" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
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
</div>

		 






    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
            
</asp:Content>
