<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Ejercicio_Login/Controller/Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style3 {
            text-align: left;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
            <div class="auto-style1">
                <strong><span class="auto-style2">LOGIN PRINCIPAL</span></strong><br />
            </div>
            <div>


&nbsp;


            </div>
        <div class="auto-style3">


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="142px" OnAuthenticate="Login1_Authenticate" Width="333px">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
            <br />
            <br />
            <asp:Label ID="Lerror" runat="server"></asp:Label>


        </div>
    </form>
    <p>
        rol:1  usuario:Torrado      clave:123 <br />
        rol:2  usuario:CYRO         clave:123<br />
        rol:3  usuario:Yesid123     clave:123<br />
        rol:4  usuario:David22      clave:123<br />
    </p>
</body>
</html>
