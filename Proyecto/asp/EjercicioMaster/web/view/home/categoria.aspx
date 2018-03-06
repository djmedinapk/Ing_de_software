<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="categoria.aspx.cs" Inherits="view_home_categoria" %>


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
    <div class="row" style="height:50px;s"></div>
    <div class="col col-12">
        <h2>Categorias</h2>
        <h6>
            <asp:DropDownList ID="DDLbusqueda" runat="server" DataSourceID="ODScategorias" AutoPostBack="True" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
            <asp:ObjectDataSource runat="server" ID="ODScategorias" SelectMethod="listar_categorias" TypeName="Logica.Lpost"></asp:ObjectDataSource>
        </h6>
        
        <hr>
    </div>
    <div class="col col-12">
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ODSpost" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id_post" Text="VER"></asp:HyperLinkField>
                <asp:BoundField DataField="titulo" HeaderText="Titulo"></asp:BoundField>
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion"></asp:BoundField>
                <asp:BoundField DataField="visitas" HeaderText="Visitas"></asp:BoundField>
                <asp:BoundField DataField="fecha" HeaderText="Fecha"></asp:BoundField>
            </Columns>

            <FooterStyle BackColor="White" ForeColor="#333333"></FooterStyle>

            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></PagerStyle>

            <RowStyle BackColor="White" ForeColor="#333333" Width="100%"></RowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#487575"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#275353"></SortedDescendingHeaderStyle>
        </asp:GridView>
        <asp:ObjectDataSource runat="server" ID="ODSpost" SelectMethod="ver_post_home_categoria" TypeName="DAOpost">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDLbusqueda" PropertyName="SelectedValue" Name="orden" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>



