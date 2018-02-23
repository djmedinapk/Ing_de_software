<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Perfil.aspx.cs" Inherits="view_Perfil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .Beliminar{
            border:0px;
            background-color:#fff;
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

                    <h5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Lusername" runat="server" Text="" style="font-weight: 700; font-size: large"></asp:Label> <br>
                    </h5>
                    <h6 class="text-muted">
                        <ul>
                            <li>estado: <span style="color: #02FF32">online</span></li>
                            <li>total Post: <asp:Label ID="LtotalPublic" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </h6>
                    <div style="height: 100px"></div>
                    <div class="btn-group-vertical">
                        <button type="button" class="btn btn-outline-success  btn-block active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home">Publicaciones</button>
                        <%--<button type="button" class="btn btn-outline-success  btn-block" OnClick="BperfilMod_Click" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">perfil</button>--%>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">Perfil</button>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-ajustes-tab" data-toggle="pill" href="#v-pills-ajustes" role="tab" aria-controls="v-pills-ajustes" aria-expanded="false">Ajustes</button>
                        <asp:Button ID="Bmoderador" runat="server" Text="Moderador" class="btn btn-outline-warning  btn-block" role="tab" OnClick="Bmoderador_Click" />
                        <asp:Button ID="Badmin" runat="server" Text="Admin" class="btn btn-outline-dark  btn-block" role="tab" OnClick="Badmin_Click" />
                        <%--<asp:Button ID="BperfilMod" runat="server" Text="Perfil"   class="btn btn-outline-success  btn-block"  href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false" />--%>
                        <asp:Button ID="Blogout" runat="server" Text="Cerrar Sesion" class="btn btn-outline-danger  btn-block" role="tab" aria-controls="v-pills-profile" aria-expanded="false" OnClick="Blogout_Click"/>
                    </div>
                </div>
            </div>
            <div class="col-9 panel-derecho">
                <div class="tab-content" id="v-pills-tabContent">
                    <div class="tab-pane fade active show" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab" aria-expanded="true">
                        <h3>Foro Publico</h3><hr />
                        <div class="d-flex flex-row-reverse">
                            <asp:hyperlink id="HLperfilCrear" runat="server" Font-Size="34pt" NavigateUrl="~/view/post/CrearPublicacion.aspx" ><i class="fa fa-pencil-square-o text-success" aria-hidden="true" class="btn btn-warning"></i></asp:hyperlink>
                            <%--<asp:Button ID="BperfilCrearpost" runat="server" Text="Crear Publicacion" class="btn btn-warning"/>--%>
                        </div>
                        <div class="list-group" style="padding-bottom:60px;">
                            <asp:datalist runat="server" repeatlayout="Flow" DataSourceID="ODSpostPerfil" DataKeyField="id" OnItemCommand="Unnamed1_ItemCommand" >
                                <ItemTemplate>
                                   <div class="d-flex w-10 justify-content-end" style="margin-bottom:-15px;" >
                                       <div class="p-2 align-content-end">
                                           <asp:Button ID="Beliminar" class="close Beliminar" Text="x" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' />
                                           <%-- <button type="button" class="close">
                                       <span>x</span>
                                      </button >--%>
                                           <asp:HyperLink ID="HLmodificarPost" runat="server" class="close" NavigateUrl='<%# Bind("editar_post") %>'><span ><i class="fa fa-pencil-square-o"></i></span></asp:HyperLink>
                                        </div>
                                   
                                <asp:HyperLink id="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>' style="margin-top:10px;">
                                    <div class="p-10 align-self-end">
                                        <div class="d-flex w-10 justify-content-between" >
								      <h6 class="mb-1"><span style="max-width:300px;"><asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>' ></asp:Label></span></h6>
								      <small><asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></small>
								    </div>
								    <p class="mb-0"><asp:Label ID="Label1" runat="server" Text='<%# Bind("estado") %>'></asp:Label></p>	
                                    </div>
                                </asp:HyperLink>
                                       </div>
                                </ItemTemplate>
                            </asp:datalist>
                            <asp:ObjectDataSource ID="ODSpostPerfil" runat="server" SelectMethod="listar_post" TypeName="DAOperfil">
                                <SelectParameters>
                                    <asp:SessionParameter Name="user_id" SessionField="user_id" Type="Int32" />
                                    <asp:Parameter DefaultValue="123" Name="Sesion" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <asp:Panel ID="Pprivados" runat="server" >
                            <h3>Foro Privado</h3><hr />
                            <div class="list-group" style="padding-bottom:60px;">
                            <asp:datalist runat="server" repeatlayout="Flow" DataSourceID="ODSpostperfilPrivado" DataKeyField="id" OnItemCommand="Unnamed1_ItemCommand" >
                                <ItemTemplate>
                                   <div class="d-flex w-10 justify-content-end" style="margin-bottom:-15px;">
                                       <div class="p-2 align-content-end">
                                           <asp:Button ID="Beliminar" class="close Beliminar" Text="x" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' />
                                           <%-- <button type="button" class="close">
                                       <span>x</span>
                                      </button >--%>
                                           <asp:HyperLink ID="HLmodificarPost" runat="server" class="close" NavigateUrl='<%# Bind("editar_post") %>'><span ><i class="fa fa-pencil-square-o"></i></span></asp:HyperLink>
                                        </div>
                                   
                                <asp:HyperLink id="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>' style="margin-top:10px;">
                                    <div class="p-10 align-self-end" >
                                        <div class="d-flex w-100 justify-content-between" >
								      <h6 class="mb-1"><asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h6>
								      <small><asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></small>
								    </div>
								    <p class="mb-0"><asp:Label ID="Label1" runat="server" Text='<%# Bind("estado") %>'></asp:Label></p>	
                                    </div>
                                </asp:HyperLink>
                                       </div>
                                </ItemTemplate>
                            </asp:datalist>
                            <asp:ObjectDataSource ID="ODSpostperfilPrivado" runat="server" SelectMethod="listar_post_private" TypeName="DAOperfil">
                                <SelectParameters>
                                    <asp:SessionParameter Name="user_id" SessionField="user_id" Type="Int32" />
                                    <asp:Parameter DefaultValue="123" Name="Sesion" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        </asp:Panel>
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
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilNombre" placeholder="Nombre" ValidationGroup="perfil" ></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilNombre" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="perfil"></asp:RequiredFieldValidator>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="ñ " TargetControlID="TperfilNombre" />
                               
                                     <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="No se Admiten Caracteres Especiales" ControlToValidate="TperfilNombre" ValidationExpression="[^a-zA-Z \-]|( )|(\-\-)|(^\s*$)"></asp:RegularExpressionValidator>--%>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Apellido</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilApellido" placeholder="Apellido" ValidationGroup="perfil"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilApellido" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="perfil"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="ñ " TargetControlID="TperfilApellido" />
                                <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Edad</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilEdad" placeholder="Edad" textmode="number" MaxLength="2" ValidationGroup="perfil"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilEdad" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="perfil"></asp:RequiredFieldValidator>
                                <asp:RangeValidator id="rango1" runat="server" ControlToValidate="TperfilEdad" MinimumValue="1" MaximumValue="99" Type="Integer" Text="Edad No Valida" ForeColor="#CC3300" />
                               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"  TargetControlID="TperfilEdad" />
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Edad">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Sexo</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:RadioButtonList ID="RB1" runat="server" ValidationGroup="perfil">
                                    <asp:ListItem Selected="True">Masculino</asp:ListItem>
                                    <asp:ListItem>Femenino</asp:ListItem>
                                    <asp:ListItem>Otro</asp:ListItem>
                                </asp:RadioButtonList>
                            </dd>

                            
                        </dl>
                        <div class="row" style="padding-bottom:20px;">
                            <asp:Button ID="BperfilGuardar" runat="server" Text="Guardar Cambios" class="btn btn-secondary btn-lg btn-block" OnClick="BperfilGuardar_Click" ValidationGroup="perfil"/>
                        </div>
                        
                    </div>

                    <div class="tab-pane fade" id="v-pills-ajustes" role="tabpanel" aria-labelledby="v-pills-profile-tab" aria-expanded="false">
                        <dl class="row">
                            <dt class="col-sm-3 mt-5 text-right">Usuario</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesUsername" placeholder="Usuario"  ValidationGroup="ajustes"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilAjustesUsername" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="ajustes"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TperfilAjustesUsername" />
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">correo</dt>
                            <dd class="col-sm-9 mt-5">
                                        <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesCorreo"  placeholder="Correo"  TextMode="Email"  ValidationGroup="ajustes"></asp:textbox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TperfilAjustesCorreo" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="ajustes"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-ñ.@" TargetControlID="TperfilAjustesCorreo" />
                                        <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
                            </dd>
                            <dt class="col-sm-3 mt-5 text-right">correo Institucional</dt>
                            <dd class="col-sm-9 mt-5">
                                        <asp:Button ID="Bcorreoins" runat="server" Text="Registrar Correo"  CssClass="btn btn-success" OnClick="Bcorreoins_Click"/>
                                        
                                <asp:textbox runat="server" class="form-control input-lg" id="Tcorreoins" type="text" placeholder="Correo" textmode="Email" ReadOnly="True"></asp:textbox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-ñ.@" TargetControlID="TperfilAjustesCorreo" />
                                        <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Contraseña</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesContrasena" placeholder="Contraseña" TextMode="Password"></asp:textbox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TperfilAjustesContrasena" />
                           
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right"></dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilAjustesContrasena2" placeholder="Repetir Contraseña" TextMode="Password"></asp:textbox>

                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="TperfilAjustesContrasena" ControlToValidate="TperfilAjustesContrasena2" 
                                 ErrorMessage="No coinciden las contraseñas" ForeColor="Red"></asp:CompareValidator>
                                <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">--%>
                            </dd>
                        </dl>
                        <div class="row" style="padding-bottom:20px;">
                            <asp:Button ID="BajustesGuardar" runat="server" Text="Guardar Cambios" class="btn btn-secondary btn-lg btn-block" OnClick="BajustesGuardar_Click"  ValidationGroup="ajustes" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


