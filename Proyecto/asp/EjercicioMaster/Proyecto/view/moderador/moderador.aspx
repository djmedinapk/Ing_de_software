﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/moderador.aspx.cs" Inherits="view_moderador_moderador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <script src="https://s.codepen.io/assets/libs/modernizr.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
    <link rel="stylesheet" type="text/css" href="../App_Themes/css/modificar_perfil.css">
    <link rel="stylesheet" type="text/css" href="../../App_Themes/css/moderador.css">
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
            min-height:600px;
        }
        #ContentPlaceHolder1_DLlistarPosts{
            width:100%;
        }
        .Beliminar{
            border:0px;
            background-color:#fff;
        }
        .peras{
            text-align:center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Lpopup" runat="server" Text=""></asp:Label> 
    <div class="tabs">
        <div class="row panel-derecho">
            <%--<div class="col-sm-3 panel-izquierda">
                <div class="nav flex-column nav-pills " id="v-pills-tab" role="tablist">
                    <div style="width: 200px; min-height: 200px;">
                        <asp:image id="Iperfil" runat="server"  class="img-thumbnail" width="200px"></asp:image>
                        <%--<img src="../../img/123.jpg" alt="..." class="img-thumbnail" width="200px">
                    </div>

                    <h5><asp:Label ID="Lusername" runat="server" Text=""></asp:Label> <br>
                        <small class="text-muted">%%TRAngo%%</small>
                    </h5>
                    <h6 class="text-muted">
                        <ul>
                            <li>estado: <span style="color: #02FF32">online</span></li>
                            <li>total Post: <asp:Label ID="LtotalPublic" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </h6>
                    <div style="height: 100px"></div>
                   
                </div>
            </div>--%>
            <div class="col-sm-12 panel-derecho">
                <div class="col">
                  <ul class="nav nav-tabs justify-content-center" id="myTab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link btn-outline-success active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="false">Publicaciones</a>
                    </li>
                      <li class="nav-item dropdown">
                        <a class="nav-link btn-outline-success dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="true">Denuncias</a>
                        <div class="dropdown-menu">
                          <a class="dropdown-item" id="denunciaComentario-tab" data-toggle="tab" href="#denunciaComentario" role="tab" aria-controls="denunciaComentario" aria-selected="false">Comentarios</a>
                            
                          <a class="dropdown-item" id="denunciaComentario-tab" data-toggle="tab" href="#denunciaComentario" role="tab" aria-controls="denunciaComentario" aria-selected="false">Comentarios</a>
                         <div class="dropdown-divider"></div>
                        </div>
                      </li>
                  </ul>
                </div>
                  <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active show" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="list-group">
                        <asp:DataList ID="DLlistarPosts" runat="server" DataSourceID="ODSlistarPosts">
                            <ItemTemplate>
                                 <div class="d-flex w-10 justify-content-end" style="margin-bottom:0px;">
                                       <div class="p-2 align-content-end">
                                           <asp:Button ID="Beliminar" class="close Beliminar" Text="x" runat="server" CommandName="eliminar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />
                                           <%-- <button type="button" class="close">
                                       <span>x</span>
                                      </button >--%>
                                           <asp:Button ID="Bvalidar" class="close Beliminar" Text="✓" runat="server" CommandName="validar" CommandArgument='<%#  Bind("id") %>' OnCommand="Beliminar_Command" />
                                        </div>
                                   
                                <asp:HyperLink id="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>'>
                                     <div class="p-10 align-self-end" >
                                    <div class="d-flex justify-content-between" >
								      <h6 class="mb-1"><asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h6>
								      <small><asp:Label ID="Label2" runat="server" Text='<%# Bind("miniatura") %>'></asp:Label></small>
								    </div>
								    <p class="mb-0"><asp:Label ID="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                                         </div>
                                </asp:HyperLink>
                                     </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="ODSlistarPosts" runat="server" SelectMethod="listar_post_moderador" TypeName="DAOpost">
                        </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="denunciaComentario" role="tabpanel" aria-labelledby="denunciaComentario-tab">
                        <asp:GridView ID="GridView1" runat="server" DataSourceID="ODSlistarComentarios" AutoGenerateColumns="False" CssClass="rwd-table" AllowPaging="True" AllowSorting="True" DataKeyNames="id_denuncia">
                            <Columns>
                                <asp:BoundField DataField="id_denuncia" AccessibleHeaderText="Id" HeaderText="Id">
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" AccessibleHeaderText="Contenido Denuncia" HeaderText="Contenido Denuncia">
                                    <HeaderStyle Width="30%" CssClass="peras"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="contenido_comentario" AccessibleHeaderText="Comentario" HeaderText="Comentario">
                                    <HeaderStyle CssClass="peras"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False" SortExpression="id_denuncia">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="" CommandName="Delete" CausesValidation="False" ID="LinkButton1"><i class="fa fa-times" aria-hidden="true" style="font-size:16px; color:white;"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ODSlistarComentarios" SelectMethod="mostar_denuncia_comentario" TypeName="DAOdenuncia" DeleteMethod="eliminar_denuncia_comentario">
                            <DeleteParameters>
                                <asp:Parameter Name="id_denuncia" Type="Int32"  ></asp:Parameter>
                            </DeleteParameters>
                        </asp:ObjectDataSource>
                    </div>
                  </div>
                </div>
            </div>
    </div>
</asp:Content>



