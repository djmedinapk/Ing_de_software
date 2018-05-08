<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/view/admin/idioma.aspx.cs" Inherits="view_admin_idioma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 13px;
        }
    </style>
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
                            <h2><asp:Label ID="L_agregar_idioma" runat="server" Text="Agregar Idioma"></asp:Label><small><asp:Label ID="Lheader2" runat="server" Text="..."></asp:Label></small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <form class="form-horizontal form-label-left input_mask">
                                
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    
                                    <asp:TextBox ID="Tnombre" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="idioma" Placeholder="idioma">
                                       
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tnombre" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="idioma"></asp:RequiredFieldValidator>
                                    
                                    <%--<input type="text" class="form-control has-feedback-left" id="inputSuccess2" placeholder="First Name">--%>
                                    <span class="fa fa-flag form-control-feedback left" aria-hidden="true"></span>
                                </div>
                                
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="Tcultura" runat="server" CssClass="form-control has-feedback-left" ValidationGroup="idioma" Placeholder="Terminacion"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcultura" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="idioma"></asp:RequiredFieldValidator>
                                    <%-- <input type="text" class="form-control" id="inputSuccess3" placeholder="Last Name">--%>
                                    <span class="fa fa-star form-control-feedback left" aria-hidden="true"></span>
                                </div>

                                <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                                    <div class="ln_solid"></div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                        <span class="right">
                                            <asp:Button ID="BTNagregarIdioma"  runat="server" CssClass="btn btn-success" Text="Guardar" ValidationGroup="idioma" OnClick="BTNagregarIdioma_Click"/>
                                        </span>
                                        
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                </div>

            </div>
            

        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" Visible="True">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-left panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <h2><asp:Label ID="L_cargar_idioma" runat="server" Text="Cargar idioma"></asp:Label><small><asp:Label ID="Label4" runat="server" Text="..."></asp:Label></small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <br />
                            <div class="col">
                            <asp:Label ID="L_lenguaje" Text="Lenguaje" runat="server" ></asp:Label>
                                <asp:DropDownList ID="DDL_lenguaje" runat="server" DataSourceID="ODS_idiomas" DataTextField="nombre" DataValueField="id" ValidationGroup="idioma" AutoPostBack="True">
                                </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ODS_idiomas" SelectMethod="cargar_idioma" TypeName="Logica.Lidioma"></asp:ObjectDataSource>
                             <asp:Label ID="L_lenguaje_pag" Text="Formulario" runat="server" ></asp:Label>
                                <asp:DropDownList ID="DDL_Leng_pag" runat="server" DataSourceID="ODS_forms" DataTextField="nombre" DataValueField="id" ValidationGroup="idioma" OnSelectedIndexChanged="DDL_Leng_pag_SelectedIndexChanged" AutoPostBack="True">
                             </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ODS_forms" SelectMethod="cargar_form" TypeName="Logica.Lidioma"></asp:ObjectDataSource>
                               
                                <br />
                                <br />
                                

                                <asp:GridView ID="Gridcontroles" runat="server" AutoGenerateColumns="false" DataKeyNames="control" DataSourceID="ODScontroles" OnRowUpdating="Controlupdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Control">
                                            <ItemTemplate>
                                                <asp:Label ID="control" runat="server" Text='<%# Bind("control") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Texto">
                                            <ItemTemplate>
                                                <asp:Label ID="ltexto" runat="server" Text='<%# Bind("texto") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Tbtexto" runat="server" Text='<%# Bind("texto") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_texto" runat="server" ControlToValidate="Tbtexto" ErrorMessage="*" Font-Names="Arial Black" Font-Size="Small" ForeColor="#CC0099" SetFocusOnError="True" ValidationGroup="controles"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:Button runat="server" Text="Actualizar" CommandName="update" CausesValidation="True" ID="Button1" OnCommand="Button1_Command" CommandArgument='<%# Bind("control") %>'></asp:Button>&nbsp;<asp:Button runat="server" Text="Cancelar" CommandName="Cancel" CausesValidation="False" ID="Button2"></asp:Button>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="Editar" CommandName="Edit" CausesValidation="False" ID="Button1"></asp:Button>
                                            </ItemTemplate>

                                            <ControlStyle BackColor="#66FF66" BorderStyle="Dashed" Font-Bold="True"></ControlStyle>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                                <asp:ObjectDataSource runat="server" ID="ODScontroles" SelectMethod="cargar_ctrl" TypeName="Logica.Lidioma" UpdateMethod="modificar_ODS_control">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDL_Leng_pag" PropertyName="SelectedValue" DefaultValue="1" Name="form" Type="Int32"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="DDL_lenguaje" PropertyName="SelectedValue" DefaultValue="1" Name="idioma" Type="Int32"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                                <br />
                               
                            </div>
                        </div>
                    </div>
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
                        <h2>
                            <asp:Label ID="L_idiomas" runat="server" Text="Idiomas"></asp:Label></h2>
                        <div class="clearfix"></div>
                    </div>

                    <div class="x_content">
                        <div class="table-responsive">
                            <table class="table table-striped jambo_table bulk_action">
                                <thead>
                                    <tr class="headings">
                                        <th class="column-title">
                                            <asp:Label ID="L_id" runat="server" Text="id"></asp:Label></th>
                                        <th class="column-title">
                                            <asp:Label ID="L_idioma" runat="server" Text="Idioma"></asp:Label></th>
                                        <th class="column-title">
                                            <asp:Label ID="L_cultura" runat="server" Text="Terminacion"></asp:Label></th>
                                        <th colspan="2" class="column-title no-link last"><span class="nobr"><asp:Label ID="L_action" runat="server" Text="Action"></asp:Label></span></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="ListView1" runat="server" DataSourceID="ODSusuario" DataKeyNames="id" >
                                        <ItemTemplate>
                                            <tr class="odd pointer">
                                                <td class=" ">
                                                    <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("id") %>'></asp:Label></td>
                                                <td class=" ">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label></td>
                                                <td class="">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("terminacion") %>'></asp:Label></td>
                                                <%--<td class="">
                                                <asp:Button ID="Bver" class="" Text="Ver" runat="server" CommandName="ver" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />
                                            </td>--%>
                                            <td class="">
                                                <asp:Button ID="Beliminar" class="" Text="Eliminar" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />

                                            </td>
                                            </tr>

                                        </ItemTemplate>
                                    </asp:ListView>
                                    <asp:ObjectDataSource runat="server" ID="ODSusuario" SelectMethod="cargar_idioma" TypeName="Logica.Lidioma"></asp:ObjectDataSource>
                                    
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

