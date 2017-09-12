<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/rol_3.aspx.cs" Inherits="View_rol_3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .ItemProducto{
            background-color:floralwhite;
            padding:10px;
        }
        .ItemProductoHeader{
            background-color:yellowgreen;
            padding:10px;
        }
        .ItemProductoFooter{
            background-color:palegreen;
            padding:10px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Nombre</h3><asp:TextBox ID="T1" runat="server" AutoPostBack="True" ></asp:TextBox>
        
        <h3>Precio Maximo</h3>
            <asp:DropDownList ID="D1" runat="server" AutoPostBack="True" Width="200px">
                <asp:ListItem Value="0">Sin Limite</asp:ListItem>
                <asp:ListItem>10000</asp:ListItem>
                <asp:ListItem>20000</asp:ListItem>
                <asp:ListItem>30000</asp:ListItem>
                <asp:ListItem>40000</asp:ListItem>
            </asp:DropDownList>
            <br />
                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="10px" CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Horizontal" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" ShowFooter="False" ShowHeader="False">
                        <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                        <ItemStyle BackColor="White" ForeColor="Black" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                        <ItemTemplate>
                            <div class="ItemProductoHeader">
                                
                                <p><h3><asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label></h3></p>
                               
                            </div>
                            
                            <br />
                            <div class="ItemProducto">
                                <p><h3>Descripcion</h3></p>
                                <p><asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                               
                            </div>
                            <div class="ItemProductoFooter">
                                
                                <p><strong>Precio $</strong><asp:Label ID="Label3" runat="server" Text='<%# Bind("precio") %>'></asp:Label></p>
                               
                            </div>
                            <br />
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                    </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="obtenerProductos" TypeName="DAOuser">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="T1" DefaultValue="ninguno" Name="valor1" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="D1" DefaultValue="0" Name="valor2" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesion" />
        
    </form>
</body>
</html>
