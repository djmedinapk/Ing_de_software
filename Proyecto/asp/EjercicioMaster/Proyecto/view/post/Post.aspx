<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Post.aspx.cs" Inherits="view_post_Post" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
      .card-body{
        background-color: #FFFFFF;
        border-color: #808080;
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
                    <div class="d-flex justify-content-between" >
                        <div class="p-8">
                            <h2><asp:Label ID="LpostTitulo" runat="server" Text=""></asp:Label></h2>
                        </div>
                        <div class="p-2">
                            <div class="dropdown">
                              <button class="btn btn-outline-dark dropdown" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fa fa-ellipsis-v" aria-hidden="true"></i>
                              </button>
                              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item" data-toggle="modal" onclick="denunciapost()">Reportar</a>
                              </div>
                            </div>
                        </div>
                    </div>
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
          
          <asp:hyperlink id="HLavatarImagen" runat="server">

          <asp:Image ID="IpostAvatar" runat="server" class="img-thumbnail" width="200px" />

          <%--<img src="../perfil/img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">--%>
             </asp:hyperlink> <h5>
                  <asp:Label ID="LpostUsername" runat="server" Text=""></asp:Label>
                  <br>
            <small class="text-muted">Never use to be</small>
          </h5>
          <p class="text-muted" >
            <ul>
              <li>estado: <asp:Label ID="Label1" runat="server" Text="<span style='color: #02FF32'>online</span>"></asp:Label></li>
                <li>total Post:<asp:Label ID="LtotalPublic" runat="server" Text=""></asp:Label> </li>    
              
               </ul>
          </p>
       </div>  

    
     </div>
    <div class="row">
      <div class="col-md-9">
        <div class="d-flex justify-content-center  mb-3">
            <div class="p-2 align-self-center">
                <span><h4><asp:Label runat="server" Text="Puntúa Este Post: " ID="Lpuntuacionn"></asp:Label></h4></span>
            </div>
          <div class="p-4">
             <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
              <div class="btn-group mr-2 btn-group-lg text-center" role="group" aria-label="First group" style="width: 60%;">
                  <asp:button runat="server" text="1" id="Bpunt1" class="btn btn-success" OnClick="Bpunt1_Click"/>
                  <asp:button runat="server" text="2" id="Bpunt2" class="btn btn-success" OnClick="Bpunt2_Click"/>
                  <asp:button runat="server" text="3" id="Bpunt3" class="btn btn-success" OnClick="Bpunt3_Click"/>
                  <asp:button runat="server" text="4" id="Bpunt4" class="btn btn-success" OnClick="Bpunt4_Click"/>
                  <asp:button runat="server" text="5" id="Bpunt5" class="btn btn-success" OnClick="Bpunt5_Click"/>
              </div>
            </div>
          </div>
        </div>
        </div>
      </div>
    
    <div class="row">
     <div class="col-12">
         <asp:Panel ID="panel_comentario" runat="server">

         <a name="comentario1" id="comentario1"></a>
            <asp:TextBox ID="Tidcomentario" runat="server" type="hidden" Text="0"></asp:TextBox>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="Tidcomentario" />
              <div class="col-12">
                  <div class="form-group">
                        <label for="exampleFormControlTextarea1">Agregar Comentario</label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <textarea class="form-control" id="TAcomentario" rows="2" runat="server"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TAcomentario" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="comentario"></asp:RequiredFieldValidator>
                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="TAcomentario" />
                    </div>
              </div>
             <div class="d-flex justify-content-end ">
                 <div class="p-2"><asp:Button ID="BagregarComentario" runat="server" Text="Comentar" class="form-group btn-primary" OnClick="Button2_Click" ValidationGroup="comentario"/></div>
             </div>
          
         <asp:HyperLink ID="HLcomentarios" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#3366FF" >
                    <asp:Label runat="server" ID="LcargarComentarios" Text=""></asp:Label>
                </asp:HyperLink>
    </asp:Panel>
        <asp:DataList runat="server" DataSourceID="ODScargarComentarios" style="width:100%;">
            <ItemTemplate>
                <!----------------------------------inicio comentario------------------------>
                <div class="card col-12" style="width:100%;">
                  <div class="d-flex justify-content-between" >
                                <div class="p-2">
                                    <asp:Label id="LidPost" runat="server" Text='<%# Bind("id") %>' Visible="false" ></asp:Label>
                                  <span><h5><asp:Label id="Ltitulo" runat="server" Text='<%# Bind("username") %>'></asp:Label></h5></span> 
                                </div>
                                <div class="p-2">
                                 <asp:Label id="Label7" runat="server" Text='<%# Bind("denuncia") %>'></asp:Label>
                                    <small>Reportar</small>
                                  </a>
                                </div>
                         
                                </div>
                     <div class="card-body">
                          <p>
                              <asp:Label id="Label2" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                          </p>
                         
                       
                                    
                                              <div id="accordion" role="tablist">
                                                    <a data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                                      <asp:Label id="Label3" runat="server" Text='<%# Bind("respuestas") %>'></asp:Label> Respuestas
                                                    </a>
                                                  <asp:Label id="Label8" runat="server" Text='<%# Bind("comentaridpost") %>'></asp:Label>
                                                   <small>responder</small>
                                  </a>
                                                    <div id="collapseOne" class="collapse " role="tabpanel" aria-labelledby="headingOne" data-parent="#accordion">
                                                      
                                                        <asp:DataList ID="DLComentarios" runat="server" DataSourceID="ODScargarRespuestas" style="width:100%;" >
                                                            <ItemTemplate>
                                                                <!----------------------------------inicio comentario------------------------>
                                                                <div class="card" style="width: 100%;">
                                                                    <div class="d-flex justify-content-between">
                                                                                <div class="p-2">
                                                                                    <span><h5><asp:Label id="Label4" runat="server" Text='<%# Bind("username") %>'></asp:Label></h5></span> 
                                                                                </div>
                                                                                <div class="p-2">
                                                                                    <asp:Label id="Label6" runat="server" Text='<%# Bind("denuncia") %>'></asp:Label>
                                                                                    <small>Reportar</small>
                                                                                    </a>
                                                                                </div>
                         
                                                                                </div>
                                                                        <div class="card-body">
                                                                            <p>
                                                                                <asp:Label id="Label5" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                                                                            </p>
                                                                </div><div>
                                                            </ItemTemplate>
                                                            </asp:DataList>

                                                            <asp:ObjectDataSource ID="ODScargarRespuestas" runat="server" SelectMethod="ver_comentarios" TypeName="DAOpost">
                                                                <SelectParameters>
                                                                    <asp:QueryStringParameter Name="post_id" QueryStringField="id" Type="Int32" />
                                                                    <asp:ControlParameter ControlID="LidPost" DefaultValue='0' Name="comentario" PropertyName="Text" Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                    
                                                    
                                                    
                                                    </div>
                                              </div>
                  

                <!----------------------------------fin comentario------------------------>
                </div><div>
            </ItemTemplate>
         </asp:DataList>

         <asp:ObjectDataSource ID="ODScargarComentarios" runat="server" SelectMethod="ver_comentarios" TypeName="DAOpost">
             <SelectParameters>
                 <asp:QueryStringParameter Name="post_id" QueryStringField="id" Type="Int32" />
                 <asp:Parameter DefaultValue="0" Name="comentario" Type="Int32" />
             </SelectParameters>
         </asp:ObjectDataSource>

     </div>
     </div>   
     <div  id="modalDenuncia" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Denunciar Comentario</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                  <div class="form-group row">
                 <%-- <label for="staticEmail" class="col-sm-2 col-form-label" >Id</label>--%>
                  <div class="col-sm-10">
                      <asp:TextBox ID="TdenunciaComentarioID" runat="server"  class="form-control-plaintext" type="hidden" ValidationGroup="denunciacomentario"></asp:TextBox>
                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="TdenunciaComentarioID" />
                    <%--<input type="text" readonly class="form-control-plaintext" id="TdenunciaId">--%>
                  </div>
                </div>
                <div class="form-group">
                  <label for="exampleFormControlTextarea1">Razon De La Denúncia</label>
                  <textarea class="form-control" id="TdenunciaComentarioText" rows="3" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TdenunciaComentarioText" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="denunciacomentario"></asp:RequiredFieldValidator>
                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="TdenunciaComentarioText" />
                </div>
            </div>
            <div class="modal-footer">
                <asp:button runat="server" text="Enviar Denuncia" class="btn btn-primary" id="BenviarDenuncia" OnClick="Unnamed2_Click" ValidationGroup="denunciacomentario"/>
              <%--<button type="button" class="btn btn-primary">Enviar Denuncia</button>--%>
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
          </div>
        </div>
      </div>
    <div  id="modalDenuncia2" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Denunciar Publicacion</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                  <div class="form-group row">
                 <%-- <label for="staticEmail" class="col-sm-2 col-form-label" >Id</label>--%>
                  <div class="col-sm-10">
                      <label for="DDLopcion">Razón de la denuncia</label>
                      <asp:DropDownList ID="DDLopcion" runat="server" class="form-control">
                            <asp:ListItem Value="1" Text="Viola derechos de autor"></asp:ListItem> 
                            <asp:ListItem Value="2" Text="Contenido Inapropiado"></asp:ListItem> 
                            <asp:ListItem Value="3" Text="Otro"></asp:ListItem> 
                      </asp:DropDownList>
                    <%--<input type="text" readonly class="form-control-plaintext" id="TdenunciaId">--%>
                  </div>
                </div>
                <div class="form-group">
                  <label for="exampleFormControlTextarea1">Descripcion</label>
                  <textarea class="form-control" id="TdenunciaPostText" rows="3" runat="server"></textarea>
                </div>
            </div>
            <div class="modal-footer">
                <asp:button runat="server" text="Enviar Denuncia" class="btn btn-primary" id="BdenunciaPost" OnClick="BdenunciaPost_Click" />
              <%--<button type="button" class="btn btn-primary">Enviar Denuncia</button>--%>
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
          </div>
        </div>
      </div>

     <script type="text/javascript">
       function denunciar(id){
           $('#modalDenuncia').modal('toggle');
           $('#ContentPlaceHolder1_TdenunciaComentarioID').val(id);
         

       }
     </script>
    <script type="text/javascript">
        function comentaridpost(id) {
            
            $('#ContentPlaceHolder1_Tidcomentario').val(id);
            $('#ContentPlaceHolder1_TAcomentario').focus();
        }
     </script>
    <script type="text/javascript">
        function denunciapost() {
            $('#modalDenuncia2').modal('toggle');
        }
     </script>
    <asp:Label id="Lpopup" runat="server" Text=""></asp:Label>
</asp:Content>

