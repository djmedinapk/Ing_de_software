<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/categoria.aspx.cs" Inherits="view_home_categoria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .testimonial-group > .rowd {
            overflow-x: auto;
            white-space: nowrap;
        }

            .testimonial-group > .rowd > .row-fluid {
                display: inline-block;
                float: none;
            }
        table{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row" style="height:50px;"></div>
    <div class="col col-12">
        <h2><asp:Label ID="L_categorias" runat="server" Text="Categorias"></asp:Label></h2>
        <h6>
            <asp:DropDownList ID="DDLbusqueda" runat="server" DataSourceID="ODScategorias" AutoPostBack="True" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
            <asp:ObjectDataSource runat="server" ID="ODScategorias" SelectMethod="listar_categorias" TypeName="Logica.Lpost"></asp:ObjectDataSource>
        </h6>
        
        <hr>
    </div>
    <div class="col col-12">
        <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">
          <asp:Label ID="hver" runat="server" Text="ver"></asp:Label></th>
      <th scope="col">
          <asp:Label ID="htitulo" runat="server" Text="titulo"></asp:Label></th>
      <th scope="col">
          <asp:Label ID="hdescripcion" runat="server" Text="Descripcion"></asp:Label></th>
      <th scope="col">
          <asp:Label ID="hvisitas" runat="server" Text="visitas"></asp:Label></th>
      <th scope="col">
          <asp:Label ID="hfecha" runat="server" Text="Fecha"></asp:Label></th>
    </tr>
  </thead>
  <tbody>
       <asp:ListView ID="ListView1" runat="server" DataSourceID="ODSpost"  >
        <ItemTemplate>
            <tr>
                <td class=" ">
                    <asp:HyperLink ID="hp1" runat="server" NavigateUrl='<%# Bind("id_post") %>'>
                        <asp:Label ID="verr" runat="server" Text="Ver"></asp:Label></asp:HyperLink>
                <td class=" ">
                    <asp:Label ID="tituloo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></td>
                <td class="">
                    <asp:Label ID="descripcionn" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></td>
                <td class="">
                    <asp:Label ID="visitass" runat="server" Text='<%# Bind("visitas") %>'></asp:Label></td>
                <td class="">
                    <asp:Label ID="fechaa" runat="server" Text='<%# Bind("fecha") %>'></asp:Label></td>
            </tr>

        </ItemTemplate>
    </asp:ListView>
  </tbody>
</table>
      
        <asp:ObjectDataSource runat="server" ID="ODSpost" SelectMethod="listar_categorias_home" TypeName="Logica.Lpost">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDLbusqueda" PropertyName="SelectedValue" Name="orden" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>



