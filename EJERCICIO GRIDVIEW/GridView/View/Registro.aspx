<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Registro.aspx.cs" Inherits="View_Registro" %>

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
            width: 25%;
             text-align: right;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            width: 25%;
        }
        .auto-style5 {
             width: 25%;
             text-align: right;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
            width: 25%;
            text-align: right;
            height: 91px;
        }
        .auto-style8 {
            width: 25%;
            height: 91px;
        }
        .auto-style9 {
            height: 91px;
        }
        .auto-style10 {
            width: 25%;
            text-align: right;
            height: 36px;
        }
        .auto-style11 {
            width: 25%;
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3" colspan="4">
                    <h1>Registro de computadores</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="L_Nombre" runat="server" Text="Digite Su Nombre:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_Nombre" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Nombre" ErrorMessage="*" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="L_Departamento" runat="server" Text="Marca "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Marca" runat="server" AutoPostBack="True" DataSourceID="ODS_marca" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_marca" runat="server" SelectMethod="obtenerMarca" TypeName="DAOLugares"></asp:ObjectDataSource>
                    <asp:Label ID="LabelMarca" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="L_Apellido" runat="server" Text="Digite su Apellido:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_Apellido" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_Apellido" runat="server" ControlToValidate="TB_Apellido" ErrorMessage="*" Font-Names="Arial Black" Font-Size="Small" ForeColor="#CC0099" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="L_Ciudad" runat="server" Text="Referencia"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Ref" runat="server" DataSourceID="ODS_referencia" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_referencia" runat="server" SelectMethod="obtenerRefencia" TypeName="DAOLugares">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DDL_Marca" DefaultValue="0" Name="marca" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:Label ID="LabelRef" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="L_Corroe" runat="server" Text="Digite su Correo:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_Correo" runat="server" style="height: 22px" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_Correo" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5" rowspan="2">
                    <asp:Label ID="L_Foto" runat="server" Text="Foto:"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:FileUpload ID="FU_Foto" runat="server" />
                    <asp:Label ID="LabelFoto" runat="server" ForeColor="#CC3300" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="L_Contrasena" runat="server" Text="Digite su  Contraseña_"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_Contrasena" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_R_Contrasena" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="L_R_Contrasena" runat="server" Text="Repita su contraseña:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TB_R_Contrasena" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_Contrasena" ControlToValidate="TB_R_Contrasena" ErrorMessage="Las contraseñas Son diferentes" SetFocusOnError="True" ForeColor="#CC3300"></asp:CompareValidator>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="L_Edad" runat="server" Text="garantía (años)"></asp:Label>
                </td>
                <td class="auto-style9" rowspan="2">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" Width="170px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label1" runat="server" Text="Sexo"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:RadioButtonList ID="Sexo" runat="server">
                        <asp:ListItem Value="0">Masculino</asp:ListItem>
                        <asp:ListItem Value="1">Femenino</asp:ListItem>
                        <asp:ListItem Value="1">Otro</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Sexo" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="4">
                    <asp:Button ID="B_Completo" runat="server" OnClick="B_Completo_Click" Text="Completo" />
                    <asp:Label ID="Resultado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
