<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Principal.aspx.cs" Inherits="View_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:FileUpload ID="FU_Cliente" runat="server" />
                </td>
                <td>
                    <asp:Button ID="B_Cargar" runat="server" OnClick="B_Cargar_Click" Text="Cargar" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Celulares 1">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="10">
                                    <tr>
                                        <td>
                                            <table border="1" style="border-color: #999999; border-style: solid; background-color: #f5f5f5;"
                                                cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="text-align: center; font-size: 10pt; padding: 20px 30px 2px 30px; border-style: none;">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("[ruta]") %>' Width="200" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; font-size: 10pt; border-style: none; padding: 10px 20px 10px 20px;">
                                                        <strong>
                                                            <asp:Label ID="Label3" runat="server"><%# Eval("[descripcion]") %></asp:Label>
                                                        </strong>
                                                    </td>
                                                </tr>                  
                                                <tr>
                                                    <td style="text-align: center; font-size: 10pt; padding: 0px 0px 5px 0px; border-style: none;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="[Eliminar]" Font-Underline="false"
                                                            CommandName="Delete"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
