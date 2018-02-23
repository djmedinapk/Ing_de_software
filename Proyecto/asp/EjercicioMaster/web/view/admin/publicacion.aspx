<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="publicacion.aspx.cs" Inherits="view_admin_publicacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="right_col" role="main">
          <div class="clearfix"></div>

        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <ul class="nav navbar-left panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <h2>Publicas</h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <div class="table-responsive">
                        <table class="table table-striped jambo_table bulk_action">
                            <thead>
                                <tr class="headings">
                                    <th class="column-title">id </th>
                                    <th class="column-title">Titulo</th>
                                    <th class="column-title">Descripcion </th>
                                    <th class="column-title">estado</th>
                                    <th class="column-title">Fecha </th>
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
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("miniatura") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("fecha") %>'></asp:Label></td>
                                            <td class="">
                                             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("id_post") %>'>Ver</asp:HyperLink></td>
                                            </td>
                                            <td class="">
                                                 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Bind("id_post2") %>'>Modificar</asp:HyperLink></td>
                                                <%--<asp:Button ID="Beliminar" class="" Text="Suspender" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />--%>

                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ObjectDataSource runat="server" ID="ODSusuario" SelectMethod="crud_post" TypeName="DAOadmin">
                                     <SelectParameters>
                                        <asp:Parameter DefaultValue="2" Name="orden" Type="String"></asp:Parameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>

        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <ul class="nav navbar-left panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <h2>Privadas</h2>
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
                                <asp:ListView ID="ListView2" runat="server" DataSourceID="ODSpost2">
                                    <ItemTemplate>
                                        <tr class="odd pointer">
                                            <td class=" ">
                                                <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("id_post") %>'></asp:Label></td>
                                            <td class=" ">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("miniatura") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("fecha") %>'></asp:Label></td>
                                            <td class="">
                                             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("id_post") %>'>Ver</asp:HyperLink></td>
                                            </td>
                                            <td class="">
                                                <%--<asp:Button ID="Beliminar" class="" Text="Suspender" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />--%>

                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ObjectDataSource runat="server" ID="ODSpost2" SelectMethod="crud_post" TypeName="DAOadmin">
                                     <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="orden" Type="String"></asp:Parameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
          </div>
</asp:Content>

