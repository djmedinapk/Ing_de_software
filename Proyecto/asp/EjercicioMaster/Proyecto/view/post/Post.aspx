<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Post.aspx.cs" Inherits="view_post_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style >
      .jumbotron{
        padding-top: 0px;
        padding-left: 0px;
        background-color: #FFFFFF;
        border-color: #000;
        border:1px solid;
        margin: 10px;
        -webkit-box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.29);
        -moz-box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.29);
        box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.29);
      }
      .contenedor-cuerpo{
        padding-top: 10px;
      }
      .editor1{
        padding-top: 20px;
        
      }
      .contenido {
        min-height: 600px;
      }
      .card-footer{
        background-color: #FFFFFF;
        border-color: #FFFFFF;
      }
      .card-header{
        background-color: #FFFFFF;
        border-color: #FFFFFF;
      }
      .card{
        background-color: #FFFFFF;
        border-color: #FFFFFF;
      }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row ">
      <div class="col-md-9  contenido">
        
           <div class="card ">
                <div class="card-header">
                    <asp:Label ID="LpostTitulo" runat="server" Text=""></asp:Label>
                </div>
                <div class="card-body contenido">
                  <asp:Label ID="LpostContenido" runat="server" Text=""></asp:Label>
                </div>
                <div class="card-footer text-muted">
                 <asp:Label ID="LpostFuentes" runat="server" Text=""></asp:Label><br>
                 <asp:Label ID="LpostEtiquetas" runat="server" Text=""></asp:Label>
                 <asp:Label ID="LpostCategoria" runat="server" Text=""></asp:Label>
                </div>
              </div>
          

          
        </div>
      <div class="col-md-3 ">
          <asp:Image ID="IpostAvatar" runat="server" class="img-thumbnail" width="200px" />
          <%--<img src="../perfil/img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">--%>
              <h5>
                  <asp:Label ID="LpostUsername" runat="server" Text=""></asp:Label>
                  <br>
            <small class="text-muted">Never use to be</small>
          </h5>
          <p class="text-muted" >
            <ul>
              <li>estado: <span style="color: #02FF32">online</span></li>
                <li>total mensajes: 12</li>
                <li>total Post: 12</li>    
              
               </ul>
          </p>
       </div>  

    
     </div>
    <div class="row">
      <div class="col-md-9">
        <div class="d-flex justify-content-center  mb-3">
          <div class="p-4">
             <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
              <div class="btn-group mr-2 btn-group-lg text-center" role="group" aria-label="First group" style="width: 60%;">
                <button type="button" class="btn btn-success">1</button>
                <button type="button" class="btn btn-success">2</button>
                <button type="button" class="btn btn-success">3</button>
                <button type="button" class="btn btn-success">4</button>
                <button type="button" class="btn btn-success">5</button>
              </div>
            </div>
          </div>
        </div>
        </div>
      </div>
   <diiv class="row">
     <div class="col-12" style="background-color:darkgray;">
                <asp:HyperLink ID="HLcomentarios" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#3366FF">
                    <asp:Label runat="server" ID="LcargarComentarios" Text=""></asp:Label>
                </asp:HyperLink>
     </div>
     </diiv>  
</asp:Content>

