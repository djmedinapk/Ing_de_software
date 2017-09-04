<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controlller/home.aspx.cs" Inherits="rol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Farmacia De Valencia - España</title>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="../App_Themes/bootstrap/css/bootstrap.min.css" >
    <script src="../App_Themes/bootstrap/js/bootstrap.min.js" ></script>
    <style type="text/css">
        .carrito{
            background-color:darkgray;
        }
        .item{
            align-content:center;
        }
        .hr-item{
            color:red;
            width:90%;
            text-align:center;
        }
        .espacio{
            padding-top:50px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-dark bg-dark">
    <a class="navbar-brand" href="#"><img src="../img/logo.png" class="img-fluid" width="100px" />Bienvenido</a> 
        <a class="navbar-brand my-2" href="#">
            <asp:Label ID="LUsername" runat="server" Text="Label"></asp:Label><asp:Button ID="Bsalir" runat="server" Text="Cerrar Sesion" CssClass="btn btn-outline-light my-2 my-sm-0" OnClick="Bsalir_Click" /></a>
        
        <asp:Button ID="Blogin" runat="server" Text="Iniciar Sesion" CssClass="btn btn-outline-light my-2 my-sm-0" OnClick="Button2_Click"/>
        
</nav>
        <div class="row">
          <div class="col-md-9 col-xs-12 col-lg-8 col-sm-12 ">
              <div class="espacio"></div>
                             <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%" OnItemCommand="DataList1_ItemCommand">
                                 <ItemTemplate>
                                     <div class="item">
                                         <div class="header-item">
                                             <img src="../img/img.png" width="200px"/>
                                         </div>
                                         <div class="body-item">
                                             <h4><asp:Label ID="label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label></h4>
                                             <p><asp:Label ID="label3" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                                         </div>                                         
                                         <div class="footer-item">
                                             <hr class="hr-item" />
                                               <strong>Precio: $<asp:Label ID="label2" runat="server" Text='<%# Bind("precio") %>'></asp:Label></strong>
                                             <asp:Label ID="Lid" runat="server" Text='<%# Bind("id") %>' Visible="False"></asp:Label>
                                                <p>
                                                    <asp:Button ID="Button1" runat="server" Text="Agregar Al Carrito" CssClass="btn btn-dark btn-lg btn-block" CommandName="agregar" />
                                                </p>
                                         </div>

                                     </div>
                                     
                                 </ItemTemplate>                                 
                             </asp:DataList>
                             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listar_productos" TypeName="DAOtienda"></asp:ObjectDataSource>
   

              </div>
          <div class="col-md-3 col-xs-12 col-lg-4 col-sm-12 carrito">
              
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" ForeColor="Black" GridLines="Horizontal" Width="100%">
                   <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                  <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                  <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F7F7F7" />
                  <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                  <SortedDescendingCellStyle BackColor="#E5E5E5" />
                  <SortedDescendingHeaderStyle BackColor="#242121" />
              </asp:GridView>

              <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listar_carrito" TypeName="DAOtienda">
                  <SelectParameters>
                      <asp:SessionParameter DefaultValue="0" Name="id" SessionField="idusuario" Type="Int32" />
                  </SelectParameters>
              </asp:ObjectDataSource>
              <hr />
              <asp:Button ID="Bcarrito_terminar_compra" runat="server" Text="Terminar Compra" class="btn btn-danger btn-block" OnClick="Bcarrito_terminar_compra_Click"/>
              <asp:Label ID="Lcarrito_login" runat="server" Text="Debe Iniciar Sesion Para Acceder Al Carrito"></asp:Label>
              <asp:Button ID="Bcarrito_login" runat="server" Text="Iniciar Sesion" class="btn btn-danger btn-block" OnClick="Bcarrito_login_Click"/>
          </div>
         </div>
              
        
        
&nbsp;</form>
</body>
</html>
