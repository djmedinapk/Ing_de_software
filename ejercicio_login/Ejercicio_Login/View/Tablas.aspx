<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/Tablas.aspx.cs" Inherits="View_Tablas" %>

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
            width: 661px;
        }
        .auto-style3 {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
        
            
                    <br />

            <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="200px" Width="281px" AllowPaging="True" AllowSorting="True" DataSourceID="Datos1">
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
        
        
                    <asp:ObjectDataSource ID="Datos1" runat="server" SelectMethod="obtenerUsuario" TypeName="DAOuser">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="filtroA1" DefaultValue="ninguno" Name="condicion1" PropertyName="Text" Type="String" />
                            <asp:Parameter DefaultValue="ninguno" Name="condicion2" Type="String" />
                            <asp:Parameter DefaultValue="ninguno" Name="condicion3" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
        
        
                    <br />
                    <br />
                </td>
                <td class="auto-style3">
        
                    
                    Nombre de usuario<br />
                    <asp:TextBox ID="filtroA1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B1" runat="server" OnClick="B1_Click" Text="Filtrar" />
                    <br />
        
        
            <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="200px" Width="281px" GridLines="None" AllowPaging="True" AllowSorting="True" DataSourceID="Datos2">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        
        
                    <asp:ObjectDataSource ID="Datos2" runat="server" SelectMethod="obtenerUsuario" TypeName="DAOuser">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="filtroA1" DefaultValue="ninguno" Name="condicion1" PropertyName="Text" Type="String" />
                            <asp:Parameter DefaultValue="ninguno" Name="condicion2" Type="String" />
                            <asp:Parameter DefaultValue="ninguno" Name="condicion3" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
        
        
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        
            <br />
                    <asp:TextBox ID="filtroB1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:TextBox ID="filtroB2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B2" runat="server" Text="Button" Width="85px" />
                    <br />
            <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="200px" Width="281px" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="Datos1">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        
        
                    <br />
                    <br />
                </td>
                <td class="auto-style3">
        
                    <asp:TextBox ID="filtroC1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="filtroC2" runat="server"></asp:TextBox>
&nbsp;
                    <asp:TextBox ID="filtroC3" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B3" runat="server" Text="Button" Width="85px" />
        
                <br />
                <br />

            <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" Height="200px" Width="281px" GridLines="None" AllowPaging="True" AllowSorting="True" DataSourceID="Datos1">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        
        
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        
    </form>
</body>
</html>
