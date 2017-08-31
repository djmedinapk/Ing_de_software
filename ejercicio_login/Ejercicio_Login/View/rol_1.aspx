<%@ Page Language="C#" AutoEventWireup="true" CodeFile="../Controller/rol_1.aspx.cs" Inherits="view_rol_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
    --%> <link rel="stylesheet" href="../App_Themes/css/admin.css" >
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="tituloAdmin">
    <marquee direction="down" width="100%" behavior="alternate" style="border-style: solid; border-color: inherit; border-width: medium; font-weight: 700; font-size: xx-large; height: 600px;">
  <marquee behavior="alternate">
    Bienvenido Administrador
  </marquee>
        <h2></h2></marquee>
        </div>

            <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="200px" Width="281px" AllowPaging="True" AllowSorting="True" DataSourceID="datosUsuarios">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        
        
                    <asp:ObjectDataSource ID="datosUsuarios" runat="server" SelectMethod="obtenerUsuario" TypeName="DAOuser"></asp:ObjectDataSource>
    </form>
</body>
</html>
