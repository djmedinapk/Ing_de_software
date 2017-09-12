<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/Registro.aspx.cs" Inherits="View_Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro usuarios</title>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 2px solid #000000;
            background-color: #C0C0C0;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 25%;
        }
        .auto-style4 {
            width: 25%;
        }
        .auto-style5 {
            width: 25%;
        }
        .auto-style6 {
            width: 25%;
        }
        .auto-style7 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style9 {
            text-align: right;
            width: 50%;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" >
            <table  class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="4">DATOS PERSONALES</td>
                </tr>
                <tr>
                    <td class="auto-style3">Nombres</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="nombre" runat="server" Width="178px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">Telefono</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="telefono" runat="server" TextMode="Number" Width="178px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Nombre usuario</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="username" runat="server" Width="178px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">Correo electronico</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="email" runat="server" TextMode="Email" Width="178px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Clave</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="contraseña" runat="server" TextMode="Password" Width="178px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">Profesion</td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="profesion" runat="server">
                            <asp:ListItem Value="0">Estudiante</asp:ListItem>
                            <asp:ListItem Value="1">Empleado</asp:ListItem>
                            <asp:ListItem Value="2">Desempleado</asp:ListItem>
                            <asp:ListItem Value="3">Independiente</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Confirmar clave</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="contraseña2" runat="server" TextMode="Password" Width="178px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Registrar" runat="server" OnClick="registrar" Text="Registrarse" Width="83px" />
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="Lregistro" runat="server" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </asp:Panel>
        <br />
        <br />

        <asp:Panel ID="Panel2" runat="server" >
              <table  class="auto-style1">
                <tr>
                    <td class="auto-style7" colspan="2"><strong>ESTUDIOS</strong></td>
                </tr>
                      <tr>
                          <td class="auto-style9">Nivel educativo</td>
                          <td class="auto-style2">
                              <asp:DropDownList ID="nivel_educativo" runat="server">
                                  <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                  <asp:ListItem Value="1">Primaria</asp:ListItem>
                                  <asp:ListItem Value="2">Secundaria</asp:ListItem>
                                  <asp:ListItem Value="3">Tecnico</asp:ListItem>
                                  <asp:ListItem Value="4">Tecnologo</asp:ListItem>
                                  <asp:ListItem Value="5">Universitario</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td class="auto-style9">Nombre de la institución</td>
                          <td class="auto-style2">
                              <asp:TextBox ID="nombre_instituto" runat="server" Width="178px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="auto-style9">Ciudad</td>
                          <td class="auto-style2">
                              <asp:TextBox ID="ciudad_instituto" runat="server" Width="178px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="auto-style9">Año finalización</td>
                          <td class="auto-style2">
                              <asp:TextBox ID="año_fin" runat="server" Width="178px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="auto-style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:Button ID="registrar_estudios" runat="server" OnClick="Registrar_estudios" Text="Registrar" />
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:Label ID="Lregistro_edu" runat="server"></asp:Label>
                          </td>
                      </tr>
                  
            </table>

            <br />
            <br />
            <br />
                    <table  class="auto-style1">
                <tr>
                    <td class="auto-style7" colspan="2"><strong>EXPERIENCIA PROFESIONAL</strong></td>
                </tr>
                    <tr>
                        <td class="auto-style9">Nombre de la empresa</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="nombre_empresa" runat="server" Width="178px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Cargo o labor</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="cargo_empresa" runat="server" Width="178px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Tiempo trabajado</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="tiempo_empresa" runat="server" Width="178px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Jefe directo</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="jefe_empresa" runat="server" Width="178px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" OnClick="Registrar_empresa" Text="Registrar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Lempresa" runat="server"></asp:Label>
                        </td>
                    </tr>
            </table>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="b_terminar" runat="server" OnClick="b_terminar_Click" Text="Terminar" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />

        </asp:Panel>
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="b_login" runat="server" BorderStyle="Inset" OnClick="b_login_Click" Text="Iniciar sesión" />
            <br />


        </div>
    </form>
</body>
</html>
