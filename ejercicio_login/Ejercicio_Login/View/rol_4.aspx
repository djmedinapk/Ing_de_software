<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/rol_4.aspx.cs" Inherits="View_rol_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
    <style type="text/css">

        .ItemProductoHeader{
            background-color:black;
            padding:10px;
            border-top-left-radius:7px;
            border-top-right-radius:7px;
        }
        .ItemProducto{
            background-color:white;                        
            font-family:sans-serif;
            color:black;
            border:solid;
            border-color:black;
            padding-left:5px;
            
                
        }
        .ItemProductoFooter{
            background-color:Black;
            padding:10px;
            border-bottom-left-radius:7px;
            border-bottom-right-radius:7px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <h4>Nombre Del Instituto: <asp:TextBox ID="T1" runat="server" AutoPostBack="True"></asp:TextBox></h4>
    <h4>Tipo de Estudio</h4><asp:RadioButtonList ID="R1" runat="server" AutoPostBack="True">
        <asp:ListItem Value="ninguno">Ninguno</asp:ListItem>
        <asp:ListItem>Primaria</asp:ListItem>
        <asp:ListItem>Secundaria</asp:ListItem>
        <asp:ListItem>Tecnico</asp:ListItem>
        <asp:ListItem>Tecnologo</asp:ListItem>
        <asp:ListItem>Universitario</asp:ListItem>
    </asp:RadioButtonList>
    <h4>Año de Finalizado: <asp:DropDownList ID="D1" runat="server" AutoPostBack="True" Width="200px">
        <asp:ListItem Value="ninguno">Todos</asp:ListItem>
        <asp:ListItem>1999</asp:ListItem>
        <asp:ListItem>2000</asp:ListItem>
        <asp:ListItem>2001</asp:ListItem>
        <asp:ListItem>2002</asp:ListItem>
        <asp:ListItem>2003</asp:ListItem>
        <asp:ListItem>2004</asp:ListItem>
        <asp:ListItem>2005</asp:ListItem>
        <asp:ListItem>2005</asp:ListItem>
        <asp:ListItem>2006</asp:ListItem>
        <asp:ListItem>2007</asp:ListItem>
        <asp:ListItem>2008</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
        <asp:ListItem>2017</asp:ListItem>
        <asp:ListItem>2018</asp:ListItem>
    </asp:DropDownList></h4>
        <p>
                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="10px" CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Horizontal" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" ShowFooter="False" ShowHeader="False">
                        <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" />
                        <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                        <ItemStyle BackColor="White" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Font-Names="Comic Sans MS" />
                        <ItemTemplate>
                            <div class="ItemProductoHeader">
                                
                                <p><h3><asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre_instituto") %>'></asp:Label></h3></p>
                               
                            </div>
                            <div class="ItemProducto">
                                <p><h4>Detalles</h4></p>
                                <p><asp:Label ID="Label2" runat="server" Text='<%# Bind("nivel_estudio") %>'></asp:Label></p>
                               <p><asp:Label ID="Label4" runat="server" Text='<%# Bind("ciudad_instituto") %>'></asp:Label></p>
                                <p><asp:Label ID="Label5" runat="server" Text='<%# Bind("ano_fin") %>'></asp:Label></p>
                            </div>
                            <div class="ItemProductoFooter">
                                
                                <p><strong>registro nª</strong><asp:Label ID="Label3" runat="server" Text='<%# Bind("id_estudios") %>'></asp:Label></p>
                               
                            </div>
                            <br />
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="obtenerEstudios" TypeName="DAOuser">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="R1" DefaultValue="ninguno" Name="valor1" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="T1" DefaultValue="ninguno" Name="valor2" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="D1" Name="valor3" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesion" />
    </form>

</body>
</html>
