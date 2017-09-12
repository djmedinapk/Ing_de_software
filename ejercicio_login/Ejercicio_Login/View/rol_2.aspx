<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/rol_2.aspx.cs" Inherits="view_rol_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuario</title>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
    --%> <link rel="stylesheet" href="../App_Themes/css/user.css" >
    
</head>
<body>
   
    <form id="form1" runat="server">
      
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <h4>Nombre Empresa: </h4><asp:TextBox ID="T1" runat="server" AutoPostBack="True"></asp:TextBox>
        </p>

            <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="200px" Width="281px" AllowPaging="True" AllowSorting="True" DataSourceID="datosEmpresa">
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
        
        
                    <asp:ObjectDataSource ID="datosEmpresa" runat="server" SelectMethod="obtenerEmpresa" TypeName="DAOuser">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="T1" DefaultValue="ninguno" Name="valor1" PropertyName="Text" Type="String" />
                        </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesion" />
    </form>
    
</body>
</html>

