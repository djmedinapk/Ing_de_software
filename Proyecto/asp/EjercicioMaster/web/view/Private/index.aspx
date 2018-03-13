<%@ Page Title="" Language="C#" MasterPageFile="~/Master1_1.master" AutoEventWireup="true" CodeFile="~/Controller/view/private/index.aspx.cs" Inherits="view_Private_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <div style="width:100%; height:500px;">
                    <center><img src="../../img/img-pruba.png" alt="..."></center>
                </div>
                <div class="carousel-caption d-none d-md-block" style="color: #000">
                    <h3>Foro Udec</h3>
                    <p>hey</p>
                </div>
            </div>
            <div class="carousel-item">
                <div style="width:100%; height:500px;">
                    <center><img src="../../img/img-pruba.png" alt="..."></center>
                </div>
                <div class="carousel-caption d-none d-md-block" style="color: #000">
                    <h3>Foro Udec da la Bienvenida</h3>
                    <p>hey</p>
                </div>
            </div>
            <div class="carousel-item">
                <div style="width:100%; height:500px;">
                    <center><img src="../../img/img-pruba.png" alt="..."></center>
                </div>
                <div class="carousel-caption d-none d-md-block" style="color: #000">
                    <h3>Foro Udec a Tu servicio</h3>
                    <p>hey</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="sr-only">Next</span>
        </a>
      </div>
      <div class="contenido">
        <ul class="nav nav-tabs justify-content-center" id="myTab" role="tablist">
          <li class="nav-item eleccion">
            <a class="nav-link active eleccion" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Mas Vistos</a>
          </li>
          <li class="nav-item eleccion">
            <a class="nav-link eleccion" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Mas Votados</a>
          </li>
          <li class="nav-item eleccion">
            <a class="nav-link eleccion" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Recientes</a>
          </li>
        </ul>
        <div class="tab-content" id="myTabContent">
          <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
              <asp:DataList ID="DataList1" runat="server" DataSourceID="ODSpostVisitas" RepeatColumns="3" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False">
                  <ItemTemplate>
                      <div class="p-2 cardss">
                         <%--<asp:image id="Iperfil" runat="server"  width="110px" height="60px" ImageUrl='<%# Bind("miniatura") %>' align="left"></asp:image>--%>
                        <h5><asp:Label ID="Ltitulo1" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h5>
                        <p class="card-text"><asp:Label id="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                          <hr />
                          <asp:HyperLink runat="server" id="HyperLink2" class="btn btn-outline-dark btn-sm" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                      </div>
                  </ItemTemplate>
              </asp:DataList>
              <asp:ObjectDataSource runat="server" ID="ODSpostVisitas" SelectMethod="ver_post_home_private" TypeName="Logica.Lpost">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="1" Name="orden" Type="String"></asp:Parameter>
                  </SelectParameters>
              </asp:ObjectDataSource>
              
            
          </div>
          <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
              <asp:DataList ID="DataList2" runat="server" DataSourceID="ODSpostpoints" RepeatColumns="3" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False">
                  <ItemTemplate>
                      <div class="p-2 cardss">
                        <h5><asp:Label ID="Ltitulo1" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h5>
                        <p class="card-text"><asp:Label id="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                          <hr />
                          <asp:HyperLink runat="server" id="HyperLink2" class="btn btn-outline-dark btn-sm" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                      </div>
                  </ItemTemplate>
              </asp:DataList>
              <asp:ObjectDataSource runat="server" ID="ODSpostpoints" SelectMethod="ver_post_home_private" TypeName="Logica.Lpost">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="2" Name="orden" Type="String"></asp:Parameter>
                  </SelectParameters>
              </asp:ObjectDataSource>
          </div>
          <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
              <asp:DataList ID="DataList3" runat="server" DataSourceID="ODSpostrecent" RepeatColumns="3" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False">
                  <ItemTemplate>
                      <div class="p-2 cardss">
                        <h5><asp:Label ID="Ltitulo1" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h5>
                        <p class="card-text"><asp:Label id="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                          <hr />
                          <asp:HyperLink runat="server" id="HyperLink2" class="btn btn-outline-dark btn-sm" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                      </div>
                  </ItemTemplate>
              </asp:DataList>
              <asp:ObjectDataSource runat="server" ID="ODSpostrecent" SelectMethod="ver_post_home_private" TypeName="Logica.Lpost">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="3" Name="orden" Type="String"></asp:Parameter>
                  </SelectParameters>
              </asp:ObjectDataSource>
          </div>
        </div>
      </div> 
</asp:Content>

