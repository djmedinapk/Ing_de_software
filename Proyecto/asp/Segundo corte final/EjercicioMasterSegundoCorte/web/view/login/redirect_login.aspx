<%@ Page Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/redirect_login.aspx.cs" Inherits="view_login_redirect_login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
		    <div class="row " style="padding-bottom:200px;">		    
		     		<h2 style="color:forestgreen;font-style:italic"><asp:Label ID="L_restaurada" runat="server" Text="Su contraseña se ha restaurado con éxito! :)"></asp:Label></h2>
                    <h5><asp:Label ID="L_continuar" runat="server" Text="Pulse el siguiente botón para continuar a la página principal"></asp:Label></h5>
                    <dd class="col-sm-5">
                    <asp:Button ID="Bredirect" runat="server" Text="Ir a pagina principal" class="btn btn-block" OnClick="Bredirect_Click" BorderStyle="None" Font-Bold="True" />
                    </dd>
		    </div>
            
</asp:Content>
