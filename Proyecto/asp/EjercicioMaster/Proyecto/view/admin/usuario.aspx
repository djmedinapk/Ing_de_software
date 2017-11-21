<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/view/admin/usuario.aspx.cs" Inherits="view_admin_usuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right_col" role="main">
        <!-----------DatosUser----------------->
        <asp:Label ID="Lalert" runat="server" Text=""></asp:Label>
        <asp:Panel ID="PanelUser" runat="server" Visible="True">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-left panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <h2>Datos de Sesion:  <small><asp:Label ID="Lheader" runat="server" Text="Label"></asp:Label></small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tid" runat="server" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="Tusername" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="sesion"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tusername" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="Tusername" />
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess2" placeholder="First Name">--%>
                                    <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tmail" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="sesion"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tmail" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-ñ.@" TargetControlID="Tmail" />
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess4" placeholder="Email">--%>
                                    <span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tpass" runat="server" CssClass="form-control has-feedback-left"  ValidationGroup="sesion" MaxLength="25" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tpass" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-$ñ" TargetControlID="Tpass" />
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess4" placeholder="Email">--%>
                                    <span class="fa fa-key form-control-feedback left" aria-hidden="true"></span>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:CheckBox ID="RBadmin" runat="server" Class="js-switch" data-switchery="true"/>asdasd
                                    
                                    <input type="checkbox" class="js-switch" ID="admin"  /> Admin
                                    <div class="ln_solid"></div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <span class="right">
                                            <asp:Button ID="BTNactualizarsesion" OnClick="BTNactualizarsesion_Click" runat="server" ValidationGroup="sesion"  CssClass="btn btn-success" Text="Guardar" />
                                        </span>
                                    </div>
                                </div>
                            
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-left panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <h2>Datos Perfil <small><asp:Label ID="Lheader2" runat="server" Text="Label"></asp:Label></small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <form class="form-horizontal form-label-left input_mask">

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tnombre" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="perfil"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tnombre" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess2" placeholder="First Name">--%>
                                    <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tapellido" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="perfil"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tapellido" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    <%-- <input type="text" class="form-control" id="inputSuccess3" placeholder="Last Name">--%>
                                    <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tedad" runat="server" MaxLength="3" CssClass="form-control has-feedback-left" TextMode="Number" ValidationGroup="perfil" type="number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tedad" ForeColor="Red" Font-Size="XX-Small"></asp:RequiredFieldValidator>
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess4" placeholder="Email">--%>
                                    <span class="fa fa-calendar form-control-feedback left" aria-hidden="true"></span>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <label>Genero:</label>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-md-3 col-sm-1 col-xs-4">
                                            
                                            <asp:RadioButton ID="RM" runat="server"  GroupName="sexo" CssClass="flat" required="required" Text="Masculino" />
                                        </div>
                                        <div class="col-md-3 col-sm-1 col-xs-4">
                                            
                                            <asp:RadioButton ID="RF" runat="server" GroupName="sexo" Text="Femenino" CssClass="flat" />
                                        </div>
                                        <div class="col-md-3 col-sm-1 col-xs-4">
                                            
                                            <asp:RadioButton ID="RO" runat="server" GroupName="sexo" Text="Otro" CssClass="flat" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <div class="ln_solid"></div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <span class="right">
                                            <asp:Button ID="BTNactualizarPerfil"  runat="server" CssClass="btn btn-success" OnClick="BTNactualizarPerfil_Click" Text="Guardar" ValidationGroup="perfil" />
                                        </span>
                                        
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                    <div class="ln_solid"></div>
                    <span class="left">
                        <asp:Button ID="Bvolver" runat="server" CssClass="btn btn-success" Text="Volver" OnClick="Bvolver_Click" />
                    </span>
                </div>
            </div>

        </asp:Panel>
        <!-----------/DatosUser----------------->
        <!-----------top publicaciones mas puntuadas----------------->
        <asp:Panel ID="Paneldatos" runat="server" Visible="True">
            <div class="clearfix"></div>

        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <ul class="nav navbar-left panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <h2>Usuarios</h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <div class="table-responsive">
                        <table class="table table-striped jambo_table bulk_action">
                            <thead>
                                <tr class="headings">
                                    <th class="column-title">id </th>
                                    <th class="column-title">username</th>
                                    <th class="column-title">correo </th>
                                    <th class="column-title">estado</th>
                                    <th class="column-title">Permisos </th>
                                    <th colspan="2" class="column-title no-link last"><span class="nobr">Action</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="ListView1" runat="server" DataSourceID="ODSusuario" DataKeyNames="id">
                                    <ItemTemplate>
                                        <tr class="odd pointer">
                                            <td class=" ">
                                                <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("id") %>'></asp:Label></td>
                                            <td class=" ">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("username") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("correo") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("estado") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("permisos") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Button ID="Bver" class="" Text="Ver" runat="server" CommandName="ver" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />
                                            </td>
                                            <td class="">
                                                <asp:Button ID="Beliminar" class="" Text="Suspender" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />

                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ObjectDataSource runat="server" ID="ODSusuario" SelectMethod="cargar_usuarios" TypeName="DAOadmin">
                                    
                                </asp:ObjectDataSource>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>
        <!-----------/top publicaciones mas puntuadas----------------->
    </div>
    
</asp:Content>

