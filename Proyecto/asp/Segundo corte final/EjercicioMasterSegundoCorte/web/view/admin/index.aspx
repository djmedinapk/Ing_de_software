<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/view/admin/index.aspx.cs" Inherits="view_admin_index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="right_col" role="main">
        <!-- top tiles -->
        <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count"></div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-user"></i>
                    <asp:Label ID="L_total_usuarios" runat="server" Text="Total usuarios"></asp:Label></span>
                <div class="count green">
                    <asp:HyperLink ID="HLtotalUser" runat="server" data-container="body" data-toggle="popover" data-trigger="hover" data-placement="bottom">
                        <asp:Label ID="LtotalUsers" runat="server" Text="" class="count green"></asp:Label></asp:HyperLink>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-file-text" aria-hidden="true"></i><asp:Label ID="L_total_publicaciones" runat="server" Text="Total Publicaciones"></asp:Label></span>
                <div class="count green">
                    <asp:HyperLink ID="HLtotalPost" runat="server" data-container="body" data-toggle="popover" data-trigger="hover" data-placement="bottom">
                        <asp:Label ID="LtotalPost" runat="server" Text="" class="count green"></asp:Label></asp:HyperLink>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-comments" aria-hidden="true"></i><asp:Label ID="L_total_comentarios" runat="server" Text="Total Comentarios"></asp:Label></span>
                <div class="count green">
                    <asp:Label ID="LtotalComentarios" runat="server" Text="" class="count"></asp:Label>
                </div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span class="count_top"><i class="fa fa-thumbs-up" aria-hidden="true"></i><asp:Label ID="L_total_puntos" runat="server" Text="Total puntos"></asp:Label></span>
                <div class="count green">
                    <asp:Label ID="LtotalPuntos" runat="server" Text="" class="count"></asp:Label>
                </div>
            </div>
        </div>
        <!-- /top tiles -->
        <!--- top perfiles de usuario-->
        
        <div class="row">
            <div class="col-md-3">
                <div class="x_panel">
                    <div class="x_title">
                        <ul class="nav navbar-left panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <h2>
                            <asp:Label ID="L_top_perfiles_publicaciones" runat="server" Text="Top Perfiles Publicaciones"></asp:Label></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="ODStoppub">
                            <ItemTemplate>
                                <article class="media event" style="padding-top: 10px;">
                                    <a class="pull-left date">
                                        <p class="month">
                                            <asp:Label ID="L_publicaciones" runat="server" Text="Publicaciones"></asp:Label></p>
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

            <div class="col-md-3">
                <div class="x_panel">
                    <div class="x_title">
                        <ul class="nav navbar-left panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <h2>
                            <asp:Label ID="L_top_perfiles_puntos" runat="server"  Text="Top Perfiles Puntos"></asp:Label></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="ODStoppoint">
                            <ItemTemplate>
                                <article class="media event" style="padding-top: 10px;">
                                    <a class="pull-left date">
                                        <p class="month">
                                            <asp:Label ID="L_puntos" runat="server" Text="puntos"></asp:Label></p>
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

            <div class="col-md-6">
                <div class="x_panel">
                    <div class="x_title">
                         <ul class="nav navbar-left panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <h2>
                            <asp:Label ID="L_top_perfiles" runat="server" Text="Chart "></asp:Label></h2>
                       
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                       <ajaxToolkit:BarChart ID="BarChart1" runat="server" 
                            ChartHeight="300" ChartWidth="450" ChartType="Column"
                            ChartTitle="Foro Publico versus Foro Privado" 
                            CategoriesAxis="Visitas"  
                            ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9" 
                            ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB" >
                            <Series>
                            </Series>
                            </ajaxToolkit:BarChart>
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
                    <h2>
                        <asp:Label ID="L_top_publicaciones_populares" runat="server" Text="Publicaciones Mas Populares"></asp:Label><small><asp:Label ID="L_visitas" runat="server" Text="visitas"></asp:Label></small></h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <div class="table-responsive">
                        <table class="table table-striped jambo_table bulk_action">
                            <thead>
                                <tr class="headings">
                                    <th class="column-title">
                                        <asp:Label ID="L_titulo" runat="server" Text="Titulo"></asp:Label> </th>
                                    <th class="column-title">
                                        <asp:Label ID="L_fecha" runat="server" Text="Fecha"></asp:Label></th>
                                    <th class="column-title">
                                        <asp:Label ID="L_visitas1" runat="server" Text="Visitas "></asp:Label></th>
                                    <th class="column-title no-link last"><span class="nobr">
                                        <asp:Label ID="L_action" runat="server" Text="Action"></asp:Label></span></th>
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

