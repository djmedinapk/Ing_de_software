<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~//controller//registro.aspx.cs" Inherits="view_registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">      
</head>
<body>
    <form id="form1" runat="server">

    <div class="row">
        <div style="background-color:#e5e5e5;" class="col-md-5">
            <p>
                <ul>
                    <li>Nombre</li>
                    <ul style="padding-bottom:5px;">
                        <asp:TextBox ID="Tnombre" runat="server" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Tnombre" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                    <li>Apellido</li>
                    <ul style="padding-bottom:5px;" >
                        <asp:TextBox ID="Tapellido" runat="server" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Tapellido" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                    <li>Correo</li>
                    <ul style="padding-bottom:5px;">
                        <asp:TextBox ID="Tcorreo" runat="server" TextMode="Email" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Tcorreo" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                     <li>Contraseña</li>
                    <ul style="padding-bottom:5px;">
                        <asp:TextBox ID="Tcontraseña" runat="server"  Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="Tcorreo" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                     <li>Repetir Contraseña</li>
                    <ul style="padding-bottom:5px;">
                        <asp:TextBox ID="Tcontraseña2" runat="server"  Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="Tcorreo" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>
                </ul>
            </p>         
            

        </div>
        <div class="col-md-2"></div>
        <div style="background-color:#e5e5e5;" class="col-md-5">
            <p>
                <ul>
                    <li>Seleccione Seleccion el pais de origen<ul style="padding-bottom:20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="DropDownList1" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ODSlistarPais" DataTextField="nombre" DataValueField="id" AutoPostBack="True">

                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ODSlistarPais" runat="server" SelectMethod="listar_pais" TypeName="DAOusuario"></asp:ObjectDataSource>
                    </ul>
                    <li>Seleccione Depto</li>
                    <ul style="padding-bottom:20px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="DropDownList2" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="ODSlistar_depto" DataTextField="nombre" DataValueField="id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ODSlistar_depto" runat="server" SelectMethod="obtenerDepto" TypeName="DAOusuario">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="depto" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ul>
                    <li>Fecha De Nacimiento</li>
                    <ul style="padding-bottom:20px;">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </ul>
                    <li>Sexo</li>
                    <ul style="padding-bottom:5px;">
                        <asp:RadioButtonList ID="RB1" runat="server">
                            <asp:ListItem Selected="True">Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="RB1" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </ul>   
                </ul>
            </p> 
        </div>
        
        
    </div>
    <div class="row">
        
        <div style="background-color:#e5e5e5;" class="col-12 text-center">
            
                                   
                     <h4>Foto de Perfil</h4>
                 <p style="padding-bottom:5px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="FU1" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        <asp:FileUpload ID="FU1" runat="server" />
                 </p> 
         </div>
         <div style="background-color:#e5e5e5;" class="col">


                
                   
                    <p style="padding-bottom:5px; padding-left: 20px; padding-top: 50px;">
                        <asp:CheckBox ID="CB1" runat="server" Text="Recibir informacion en mi correo" />
                    

                
                    </p>
                     <p style="padding-bottom:5px; padding-left: 20px;">
                         <asp:CheckBox ID="CB2" runat="server" Text="Estoy de acuerdo con los terminos Privacidad" />
                    </p> 
        </div>
    </div>
    <div class="row">
         <div class="col">
             <center>
                <p>
                    <asp:Button ID="Benviar" runat="server" Text="Terminar" Width="300px" Height="30px" OnClick="Benviar_Click"></asp:Button>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </p>
            </center>
         </div>
    </div>
        
        
        <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
    </form>

</body>
</html>
