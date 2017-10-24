<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/CrearPublicacion.aspx.cs" Inherits="view_CrearPublicacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../App_Themes/assets/ckeditor/ckeditor.js"></script>

    <style >
      .jumbotron{
        padding-top: 0px;
        background-color: #FFFFFF;
      }
      .contenedor-cuerpo{
        padding-top: 10px;
      }
      .editor1{
        padding-top: 20px;
        
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <div class="row ">
      <div class="col-md-9 ">
          <div class="p-3 mb-2 bg-success text-white">Crear Nueva Publicacion</div>
          <div class="container-fluid" style="height: 3px; background-color: #f4e542"></div>
         <div class="jumbotron">
            <div class="container contenedor-cuerpo">
              <label for="Nombre-post">Nombre Post</label>
              <div class="input-group">                
                <input type="text" class="form-control" id="Nombre-post" name="a">
               </div>
               <label for="Descripcion-post">Descripcion</label>
              <div class="input-group">
                <input type="text" class="form-control" id="Descripcion-post" >
               </div>
              <div class="input-group editor1">
                  
                 <textarea name="editor1" id="editor1" style="width: 100%" >                   
                  </textarea>
               </div>
                
            </div>
          </div>
          <div class="d-flex flex-row-reverse" style="padding-bottom:55px;">
              <div class="p-2"><asp:Button ID="BcrearpostTerminar" runat="server" Text="Terminar" class="btn btn-warning" Width="300px"/></div>              
            </div>

          
        </div>
      <div class="col-md-3">
          <label for="Nombre-post">Miniatura</label>
              <div class="input-group" style="padding-bottom:15px;">                
                  <asp:FileUpload ID="FUminiatura" runat="server" class="form-control" />
              </div>
          <label for="Nombre-post">Etiquetas</label>
              <div class="input-group">                
                  <textarea id="TAcrearpostEtiquetas" cols="20" rows="4" class="form-control"></textarea>
              </div>

          
       </div>  

    
     </div>
    
     <script>
                // Replace the <textarea id="editor1"> with a CKEditor
                // instance, using default configuration.
                CKEDITOR.replace( 'editor1' );
     </script>
</asp:Content>

