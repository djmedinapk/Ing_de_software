<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/verPerfil.aspx.cs" Inherits="view_perfil_verPerfil" %>

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
        #ContentPlaceHolder1_DLlistarPosts{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Lpopup" runat="server" Text=""></asp:Label> 
    <div class="tabs">
        <div class="row">
            <div class="col-sm-3 panel-izquierda">
                <div class="nav flex-column nav-pills " id="v-pills-tab" role="tablist">
                    <div style="width: 200px; min-height: 200px;">
                        <asp:image id="Iperfil" runat="server"  class="img-thumbnail" width="200px"></asp:image>
                        <%--<img src="../../img/123.jpg" alt="..." class="img-thumbnail" width="200px">--%>
                    </div>

                    <h5><asp:Label ID="Lusername" runat="server" Text=""></asp:Label> <br>
                        <%--<small class="text-muted">%%TRAngo%%</small>--%>
                    </h5>
                    <h6 class="text-muted">
                        <ul>
                            <li>estado: <span style="color: #02FF32"><asp:Label ID="Lestado" runat="server" Text=""></asp:Label></span></li>
                            <li>total Post: <asp:Label ID="LtotalPublic" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </h6>
                    <div style="height: 100px"></div>
                   
                </div>
            </div>
            <div class="col-sm-9 panel-derecho">
                <div class="col">
                  <ul class="nav nav-tabs justify-content-end" id="myTab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link btn-outline-success active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="false"><asp:Label ID="L_publicaciones" runat="server" Text="Publicacion"></asp:Label></a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link btn-outline-success" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false"><asp:Label ID="L_informacion" runat="server" Text="Informacion"></asp:Label></a>
                    </li>
                  </ul>
                </div>
                  <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active show" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="list-group">
                        <asp:DataList ID="DLlistarPosts" runat="server" DataSourceID="ODSlistarPosts">
                            <ItemTemplate>
                                <asp:HyperLink id="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>'>
                                    <div class="d-flex justify-content-between" >
								      <h6 class="mb-1"><asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h6>
								      <small><asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></small>
								    </div>
								    <p class="mb-0"><asp:Label ID="Label1" runat="server" Text='<%# Bind("estado") %>'></asp:Label></p>	
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:DataList>
                            <asp:ObjectDataSource ID="ODSlistarPosts" runat="server" SelectMethod="Llistar_post_perfil_public" TypeName="Logica.LPerfil">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="" Name="user_id" QueryStringField="id" Type="Int32" />
                                <asp:Parameter DefaultValue="123" Name="Sesion" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                      <p>
                          <strong><asp:Label ID="L_nombre" runat="server" Text="Nombre"></asp:Label></strong><asp:Label ID="Lnombre" runat="server" Text=""></asp:Label>
                      </p>
                        <p>
                          <strong><asp:Label ID="L_edad" runat="server" Text="Edad"></asp:Label></strong><asp:Label ID="Ledad" runat="server" Text=""></asp:Label>
                      </p>
                        <p>
                          <strong><asp:Label ID="L_genero" runat="server" Text="Genero"></asp:Label></strong><asp:Label ID="Lgenero" runat="server" Text=""></asp:Label>
                      </p>
                    </div>
                  </div>
                </div>
            </div>
    </div>
</asp:Content>



