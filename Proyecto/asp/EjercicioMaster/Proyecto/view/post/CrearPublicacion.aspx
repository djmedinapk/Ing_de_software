﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/CrearPublicacion.aspx.cs" Inherits="view_CrearPublicacion" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../App_Themes/assets/ckeditor/ckeditor.js"></script>
<%--    <script src="../../App_Themes/assets/bootstrap-tagsinput-master/src/bootstrap-tagsinput.js"></script>
    <link href="../../App_Themes/assets/bootstrap-tagsinput-master/src/bootstrap-tagsinput.css" rel="stylesheet" />--%>
<%--    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/css/bootstrap.min.css">--%>
    <link href="../../App_Themes/assets/bootstrap-tagsinput-master/dist/bootstrap-tagsinput.css" rel="stylesheet" />
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
      .label-info{
          background-color:#09ac43;
          border-radius:3px;
          padding: 3px;
          font-size: 11px;

      }
      .bootstrap-tagsinput{
          color:#000000;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
      <div class="col-12 m-2 bg-success text-white" style="padding: 10px;">Crear Nueva Publicacion</div>
    </div>
     <div class="row ">

      <div class="col-md-9 ">
          
          <div class="container-fluid" style="height: 3px; background-color: #f4e542"></div>
         <div class="jumbotron">
            <div class="container contenedor-cuerpo">
              <label for="Nombre-post">Nombre Post</label>
              <div class="input-group"> 
                  <asp:TextBox ID="TpostNombre" runat="server"  class="form-control" ValidationGroup="post"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TpostNombre" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="post"></asp:RequiredFieldValidator>
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="TpostNombre" />
                 
                  <%-- <input type="text" id="Nombre-post" name="a">--%>

               </div>
               <label for="Descripcion-post">Descripcion</label>
              <div class="input-group">
                  <asp:TextBox ID="Tpostdescripcion" runat="server"  class="form-control" ValidationGroup="post"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tpostdescripcion" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="post"></asp:RequiredFieldValidator>
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ " TargetControlID="Tpostdescripcion" />
                 

                <%--<input type="text" class="form-control" id="Descripcion-post" >--%>
               </div>
                <label for="DDLcategoria">Categoria</label>
            <div class="input-group">
                <asp:dropdownlist runat="server" id="DDLcategoria" class="form-control" DataSourceID="ODSlistarCategoria" DataTextField="nombre" DataValueField="id" ValidationGroup="post"></asp:dropdownlist>
                <asp:ObjectDataSource ID="ODSlistarCategoria" runat="server" SelectMethod="listar_categoria" TypeName="DAOpost"></asp:ObjectDataSource>
               </div>
              <div class="input-group editor1">
                 
                   <input type="text"  name='editor1' id='editor1' style='width: 100%' onkeyup="PassValue()"/>
                  
                  <%--<textarea  name='editor1' id='editor1' style='width: 100%' onkeyup="PassValue(this);"></textarea>--%>
                  <%--<asp:TextBox name='editor1' id='editor1' style='width: 100%' runat="server"></asp:TextBox>--%>
                 
                  <asp:Label ID="Label1" runat="server" Text="" Visible="False" ValidationGroup="post"></asp:Label>
                   

               </div>
                 <label for="Descripcion-post">Fuente(s)</label>
                 <div class="input-group editor1">
                   <asp:RadioButton ID="RBpostfuentes1" runat="server" Text="El contenido es de mi autoria y/o recopilacion de varias fuentes" GroupName="fuentes" OnCheckedChanged="RBpostfuentes2_CheckedChanged"  Checked="true" ValidationGroup="post"/>
                  </div>
                  <div class="input-group editor1">
                      <asp:RadioButton ID="RBpostfuentes2" runat="server" Text="Otras fuentes: " GroupName="fuentes" OnCheckedChanged="RBpostfuentes2_CheckedChanged" ValidationGroup="post" />
                      <asp:TextBox ID="TpostFuentes" runat="server" class="form-control"></asp:TextBox>  
                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ /:;." TargetControlID="TpostFuentes" />
                  </div>
                      
            </div>
          </div>
        </div>
      <div class="col-md-3">
          <label for="Nombre-post">Miniatura</label>
              <div class="input-group" style="padding-bottom:15px;">                
                  <asp:FileUpload ID="FUminiatura" runat="server" class="form-control" />
              </div>
          <label for="Nombre-post">Etiquetas</label>
              <div class="input-group">
                  <%--<input type="text" value="" data-role="tagsinput"  class="input-group"/>--%>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TpostEtiquetas" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="post"></asp:RequiredFieldValidator>
                  <asp:TextBox ID="TpostEtiquetas" runat="server" data-role="tagsinput" class="input-group"></asp:TextBox>
                  
              </div>
          <label for="Nombre-post"><sub>las etiquetas deben ir separadas por una coma</sub></label>

          
       </div>  

    
     </div>
    <asp:Label ID="Leditor" Text="" runat="server"></asp:Label>
    <div class="d-flex justify-content-center" style="padding-bottom:55px;">
              <div class="p-2"><asp:Button ID="BcrearpostTerminar" runat="server" Text="Terminar" class="btn btn-warning" Width="300px" OnClick="BcrearpostTerminar_Click" ValidationGroup="post"/></div>              
            </div>
    <asp:TextBox ID="op" name="op" runat="server" type="hidden"></asp:TextBox>
    
     <script type="text/javascript">
         CKEDITOR.replace('editor1');
         setInterval('guardar()', 1000);
         //function PassValue() {
         //    //var texto = $("#txt").val();
         //    //document.getElementById("#ContentPlaceHolder1_op").Text = "sadas";
         //    //console.log($("#ContentPlaceHolder1_op").val());
         //    //console.log(data);
         //}
         function guardar() {
             //document.getElementById("hf").value = "sdasd";
             //console.log("hola");
             var data = CKEDITOR.instances.editor1.getData();
             $("#ContentPlaceHolder1_op").val(data);
             var anchura = $("cke_173_textInput").val();
             console.log(anchura);
         }
</script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typeahead.js/0.11.1/typeahead.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.2.20/angular.min.js"></script>
    <script src="../../App_Themes/assets/bootstrap-tagsinput-master/dist/bootstrap-tagsinput.js"></script>
    <script src="../../App_Themes/assets/bootstrap-tagsinput-master/dist/bootstrap-tagsinput-angular.js"></script>
    <asp:Label id="Lpopup" runat="server" Text=""></asp:Label>
</asp:Content>

