<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~//controller//registro.aspx.cs" Inherits="view_registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:50%; background-color:#e5e5e5;">
            <p>
                <ul>
                    <li>Nombre</li>
                    <ul style="padding-bottom:20px;">
                        <asp:TextBox ID="Tnombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Tnombre" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                    <li>Apellido</li>
                    <ul style="padding-bottom:20px;">
                        <asp:TextBox ID="Tapellido" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Tapellido" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                    <li>Correo</li>
                    <ul style="padding-bottom:20px;">
                        <asp:TextBox ID="Tcorreo" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Tcorreo" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                </ul>
            </p>
            <center>
                <p>
                    <asp:Button ID="Benviar" runat="server" Text="Terminar" Width="100%" Height="30px" OnClick="Benviar_Click"></asp:Button>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </p>
            </center>
            

        </div>
    </form>
</body>
</html>
