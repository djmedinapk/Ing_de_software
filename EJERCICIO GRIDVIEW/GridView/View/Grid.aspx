<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Grid.aspx.cs" Inherits="View_Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataSourceID="ODS_usuarios" EmptyDataText="No Hay resgistros" ForeColor="Black" GridLines="Vertical" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="correo" HeaderText="Correo" />
                                <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="marca" HeaderText="Marca" />
                                <asp:BoundField DataField="referencia" HeaderText="Referencia" />
                                <asp:ImageField DataImageUrlField="url" HeaderText="Foto">
                                </asp:ImageField>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" />
                                <asp:CommandField ShowEditButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODS_usuarios" runat="server" SelectMethod="obtenerUsuarios" TypeName="DAOUsuario" UpdateMethod="modificarUsuarios">
                            <UpdateParameters>
                                <asp:Parameter Name="nom" Type="String" />
                                <asp:Parameter Name="apell" Type="String" />
                                <asp:Parameter Name="correo" Type="String" />
                                <asp:Parameter Name="sexo" Type="String" />
                                <asp:Parameter Name="marca" Type="String" />
                                <asp:Parameter Name="referencia" Type="String" />
                                <asp:Parameter Name="url" Type="String" />
                                <asp:Parameter Name="fecha" Type="String" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
