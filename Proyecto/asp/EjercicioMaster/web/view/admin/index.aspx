<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/view/admin/index.aspx.cs" Inherits="view_admin_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right_col" role="main">
        <!-- top tiles -->
        <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count"></div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-user"></i>Total usuarios</span>
                <div class="count green">
                    <asp:HyperLink ID="HLtotalUser" runat="server" data-container="body" data-toggle="popover" data-trigger="hover" data-placement="bottom">
                        <asp:Label ID="LtotalUsers" runat="server" Text="" class="count green"></asp:Label></asp:HyperLink>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-file-text" aria-hidden="true"></i>Total Publicaciones</span>
                <div class="count green">
                    <asp:HyperLink ID="HLtotalPost" runat="server" data-container="body" data-toggle="popover" data-trigger="hover" data-placement="bottom">
                        <asp:Label ID="LtotalPost" runat="server" Text="" class="count green"></asp:Label></asp:HyperLink>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-comments" aria-hidden="true"></i>Total Comentarios</span>
                <div class="count green">
                    <asp:Label ID="LtotalComentarios" runat="server" Text="" class="count"></asp:Label>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-thumbs-up" aria-hidden="true"></i>Total puntos</span>
                <div class="count green">
                    <asp:Label ID="LtotalPuntos" runat="server" Text="" class="count"></asp:Label>
                </div>
            </div>
        </div>
        <!-- /top tiles -->
        <!--- top perfiles de usuario-->
        <div class="row">
            <div class="col-md-4">
                <div class="x_panel">
                    <div class="x_title">
                        <ul class="nav navbar-left panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <h2>Top Perfiles Publicaciones</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="ODStoppub">
                            <ItemTemplate>
                                <article class="media event" style="padding-top: 10px;">
                                    <a class="pull-left date">
                                        <p class="month">publicaciones</p>
                                        <p class="day">
                                            <asp:Label ID="Lpubs" runat="server" Text='<%# Bind("publicaciones") %>'></asp:Label>
                                        </p>
                                    </a>
                                    <div class="media-body">
                                        <a class="title" href="#">
                                            <asp:Label ID="Lusername" runat="server" Text='<%# Bind("username") %>'></asp:Label></a>
                                        <p>
                                            <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("correo") %>'></asp:Label></p>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource runat="server" ID="ODStoppub" SelectMethod="cargar_top_user_post" TypeName="Logica.Ladmin_main"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="x_panel">
                    <div class="x_title">
                        <ul class="nav navbar-left panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <h2>Top Perfiles Puntos</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="ODStoppoint">
                            <ItemTemplate>
                                <article class="media event" style="padding-top: 10px;">
                                    <a class="pull-left date">
                                        <p class="month">puntos</p>
                                        <p class="day">
                                            <asp:Label ID="Lpubs" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </p>
                                    </a>
                                    <div class="media-body">
                                        <a class="title" href="#">
                                            <asp:Label ID="Lusername" runat="server" Text='<%# Bind("username") %>'></asp:Label></a>
                                        <p>
                                            <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("correo") %>'></asp:Label></p>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource runat="server" ID="ODStoppoint" SelectMethod="cargar_top_user_puntos" TypeName="Logica.Ladmin_main"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Top Profiles <small>Sessions</small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Settings 1</a>
                                    </li>
                                    <li><a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <article class="media event">
                            <a class="pull-left date">
                                <p class="month">April</p>
                                <p class="day">23</p>
                            </a>
                            <div class="media-body">
                                <a class="title" href="#">Item One Title</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </article>
                        <article class="media event">
                            <a class="pull-left date">
                                <p class="month">April</p>
                                <p class="day">23</p>
                            </a>
                            <div class="media-body">
                                <a class="title" href="#">Item Two Title</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </article>
                        <article class="media event">
                            <a class="pull-left date">
                                <p class="month">April</p>
                                <p class="day">23</p>
                            </a>
                            <div class="media-body">
                                <a class="title" href="#">Item Two Title</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </article>
                        <article class="media event">
                            <a class="pull-left date">
                                <p class="month">April</p>
                                <p class="day">23</p>
                            </a>
                            <div class="media-body">
                                <a class="title" href="#">Item Two Title</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </article>
                        <article class="media event">
                            <a class="pull-left date">
                                <p class="month">April</p>
                                <p class="day">23</p>
                            </a>
                            <div class="media-body">
                                <a class="title" href="#">Item Three Title</a>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </article>
                    </div>
                </div>
            </div>
        </div>
        <!--.------ /top perfiles de usuario-->
        <!-----------top publicaciones mas puntuadas----------------->
        <div class="clearfix"></div>

        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <ul class="nav navbar-left panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <h2>Publicaciones Mas Populares<small>visitas</small></h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <div class="table-responsive">
                        <table class="table table-striped jambo_table bulk_action">
                            <thead>
                                <tr class="headings">
                                    <th class="column-title">Titulo </th>
                                    <th class="column-title">Fecha</th>
                                    <th class="column-title">Visitas </th>
                                    <th class="column-title no-link last"><span class="nobr">Action</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="ListView1" runat="server" DataSourceID="ODSposts">
                                    <ItemTemplate>
                                        <tr class="odd pointer">
                                            <td class=" ">
                                                <asp:Label ID="Lcorreo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></td>
                                            <td class=" ">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("visitas") %>'></asp:Label></td>
                                            <td class="">
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("id_post") %>'>Ver</asp:HyperLink></td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ObjectDataSource runat="server" ID="ODSposts" SelectMethod="listar_ver_post_home" TypeName="Logica.Lpost">
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
        <!-----------/top publicaciones mas puntuadas----------------->
    </div>


</asp:Content>

