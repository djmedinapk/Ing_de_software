<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Perfil.aspx.cs" Inherits="view_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" type="text/css" href="../App_Themes/css/modificar_perfil.css">
    <style>
        .flex-column {
            border-right: 1px solid;
            border-right-color: #fff;
        }

        .panel-izquierda {
            padding-left: 30px;
            padding-top: 20px;
        }

        .panel-derecho {
            padding-right: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Lpopup" runat="server" Text=""></asp:Label> 
    <div class="tabs">
        <div class="row">
            <div class="col-3 panel-izquierda">
                <div class="nav flex-column nav-pills " id="v-pills-tab" role="tablist">
                    <div style="width: 200px; min-height: 200px;">
                        <asp:image id="Iperfil" runat="server"  class="img-thumbnail" width="200px"></asp:image>
                        <%--<img src="../../img/123.jpg" alt="..." class="img-thumbnail" width="200px">--%>
                    </div>

                    <h5><asp:Label ID="Lusername" runat="server" Text=""></asp:Label> <br>
                        <small class="text-muted">Never use to be</small>
                    </h5>
                    <h6 class="text-muted">
                        <ul>
                            <li>estado: <span style="color: #02FF32">online</span></li>
                            <li>total mensajes: 12</li>
                            <li>total Post: 12</li>
                        </ul>
                    </h6>
                    <div style="height: 100px"></div>
                    <div class="btn-group-vertical">
                        <button type="button" class="btn btn-outline-success  btn-block active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home">Publicaciones</button>
                        <%--<button type="button" class="btn btn-outline-success  btn-block" OnClick="BperfilMod_Click" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">perfil</button>--%>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">Perfil</button>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-ajustes-tab" data-toggle="pill" href="#v-pills-ajustes" role="tab" aria-controls="v-pills-ajustes" aria-expanded="false">Ajustes</button>
                        <%--<asp:Button ID="BperfilMod" runat="server" Text="Perfil"   class="btn btn-outline-success  btn-block"  href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false" />--%>
                        <asp:Button ID="Blogout" runat="server" Text="Cerrar Sesion" class="btn btn-outline-danger  btn-block" role="tab" aria-controls="v-pills-profile" aria-expanded="false" OnClick="Blogout_Click"/>
                    </div>
                </div>
            </div>
            <div class="col-9 panel-derecho">
                <div class="tab-content" id="v-pills-tabContent">
                    <div class="tab-pane fade active show" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab" aria-expanded="true">
                        <div class="d-flex flex-row-reverse">
                            <asp:hyperlink id="HLperfilCrear" runat="server" Font-Size="34pt" NavigateUrl="~/view/post/CrearPublicacion.aspx" ><i class="fa fa-pencil-square-o text-success" aria-hidden="true" class="btn btn-warning"></i></asp:hyperlink>
                            <%--<asp:Button ID="BperfilCrearpost" runat="server" Text="Crear Publicacion" class="btn btn-warning"/>--%>
                        </div>
                        <div class="list-group">
                            <asp:datalist runat="server" repeatlayout="Flow" DataSourceID="ODSpostPerfil">
                                <ItemTemplate>
                                <asp:HyperLink id="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>'>
                                    <div class="d-flex w-100 justify-content-between">
								      <h6 class="mb-1"><asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h6>
								      <small><asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></small>
								    </div>
								    <p class="mb-0"><asp:Label ID="Label1" runat="server" Text='<%# Bind("estado") %>'></asp:Label></p>	
                                </asp:HyperLink>
                                </ItemTemplate>
                            </asp:datalist>
                            <asp:ObjectDataSource ID="ODSpostPerfil" runat="server" SelectMethod="listar_post" TypeName="DAOperfil">
                                <SelectParameters>
                                    <asp:SessionParameter Name="user_id" SessionField="user_id" Type="Int32" />
                                    <asp:Parameter DefaultValue="123" Name="Sesion" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab" aria-expanded="false">
                        <dl class="row">

                            <dt class="col-sm-3 text-right">Imagen de Perfil</dt>
                            <dd class="col-sm-9">
                                <dl class="row">
                                    <dt class="col-sm-4">
                                        <asp:image id="IperfilImage" runat="server" ImageUrl="" class="img-thumbnail" width="200px"></asp:image>
                                        <%--<img src="../../img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">--%>
                                    </dt>
                                    <dd class="col-sm-8">
                                        <asp:fileupload id="FUperfilImagen" runat="server" class="form-control input-lg"></asp:fileupload>
                                        <%--<input class="form-control input-lg" id="inputlg" type="file" >--%>
                                        <span class="badge badge-secondary">tamaño maximo 4MB</span>
                                    </dd>
                                </dl>
                            </dd>
                            <dt class="col-sm-3 mt-5 text-right">Nombre</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilNombre" placeholder="Nombre"></asp:textbox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="TperfilNombre" ValidationExpression="\w+" ForeColor="Red"></asp:RegularExpressionValidator>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilNombre" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Apellido</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilApellido" placeholder="Apellido"></asp:textbox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="TperfilApellido" ValidationExpression="\w+" ForeColor="Red"></asp:RegularExpressionValidator>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilApellido" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Edad</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilEdad" placeholder="Edad" textmode="Number"></asp:textbox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Tipo de entrada incorrecta" ControlToValidate="TperfilEdad" ValidationExpression=".{0,3}" ForeColor="Red"></asp:RegularExpressionValidator>
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilEdad" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Edad">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Sexo</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:RadioButtonList ID="RB1" runat="server">
                                    <asp:ListItem Selected="True">Masculino</asp:ListItem>
                                    <asp:ListItem>Femenino</asp:ListItem>
                                    <asp:ListItem>Otro</asp:ListItem>
                                </asp:RadioButtonList>
                            </dd>

                            
                        </dl>
                        <div class="row" style="padding-bottom:20px;">
                            <asp:Button ID="BperfilGuardar" runat="server" Text="Guardar Cambios" class="btn btn-secondary btn-lg btn-block" ValidationGroup="1" OnClick="BperfilGuardar_Click" />
                        </div>
                        
                    </div>

                    <div class="tab-pane fade" id="v-pills-ajustes" role="tabpanel" aria-labelledby="v-pills-profile-tab" aria-expanded="false">
                        <dl class="row">
                            <dt class="col-sm-3 mt-5 text-right">Usuario</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesUsername" placeholder="Usuario"></asp:textbox>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">correo</dt>
                            <dd class="col-sm-9 mt-5">
                                        <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesCorreo" type="text" placeholder="Correo" textmode="Email"></asp:textbox>
                                        <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Contraseña</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesContrasena" placeholder="Contraseña"></asp:textbox>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right"></dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesContrasena2" placeholder="Repetir Contraseña"></asp:textbox>
                                <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">--%>
                            </dd>
                        </dl>
                        <div class="row" style="padding-bottom:20px;">
                            <asp:Button ID="BajustesGuardar" runat="server" Text="Guardar Cambios" class="btn btn-secondary btn-lg btn-block" OnClick="BajustesGuardar_Click" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

