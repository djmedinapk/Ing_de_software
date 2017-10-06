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
        .auto-style3 {
            margin-right: 3px;
        }
        .auto-style4 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <div class="auto-style2">
                <h3 class="auto-style4"><em>Listado Usuarios</em></h3>
                <br />
                <br />
            </div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <div class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style3" DataSourceID="ODSdatos" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="id" OnRowEditing="GridView1_RowEditing" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="nombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TB_Nombre" runat="server" MaxLength="15"  Text='<%# Bind("nombre") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Nombre" ErrorMessage="*" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="apellido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TB_Apellido" runat="server"  Text='<%# Bind("apellido") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV_Apellido" runat="server" ControlToValidate="TB_Apellido" ErrorMessage="*" Font-Names="Arial Black" Font-Size="Small" ForeColor="#CC0099" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="correo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TB_Correo" runat="server" style="height: 22px" TextMode="Email" Text='<%# Bind("correo") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_Correo" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="contraseña">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TB_Contrasena" runat="server" Text='<%# Bind("contraseña") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_Contrasena" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("contraseña") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="sexo">
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="Sexo" runat="server">
                                            <asp:ListItem Value="0">Masculino</asp:ListItem>
                                            <asp:ListItem Value="1">Femenino</asp:ListItem>
                                            <asp:ListItem Value="2">Otro</asp:ListItem>
                                        </asp:RadioButtonList><br />
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Sexo" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="marca">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DDL_Marca" runat="server" AutoPostBack="True" DataSourceID="ODS_marca" DataTextField="nombre" DataValueField="id">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ODS_marca" runat="server" SelectMethod="obtenerMarca" TypeName="DAOLugares"></asp:ObjectDataSource>
                                        <br />
                                        <asp:Label ID="LabelMarca" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("marca") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="referencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DDL_Ref" runat="server" DataSourceID="ODS_referencia" DataTextField="nombre" DataValueField="id">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ODS_referencia" runat="server" SelectMethod="obtenerRefencia" TypeName="DAOLugares">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DDL_Marca" DefaultValue="0" Name="marca" PropertyName="SelectedValue" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <br />
                                        <asp:Label ID="LabelRef" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="fecha">
                                    <EditItemTemplate>
                                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="imagen">
                                    <EditItemTemplate>
                                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("url") %>' Width="20px"/><br />
                                         <br />
                                         <asp:FileUpload ID="FU_Foto" runat="server" />
                                         <asp:Label ID="LabelFoto" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("url") %>' Width="50px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        </div>
                        <asp:ObjectDataSource ID="ODSdatos" runat="server" SelectMethod="obtenerUsuarios" TypeName="DAOUsuario" DeleteMethod="eliminarUsuario" UpdateMethod="mod" >
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="id" Type="Int32" />
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
