<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/correoInstitucional.aspx.cs" Inherits="view_perfil_correoInstitucional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Lalert" runat="server" Text=""></asp:Label>
    <asp:Panel ID="panelM" runat="server">
        <div class="d-flex justify-content-center">
        <div class="p-4 card">
            <div class="">
                <h2>Registrar Correo Institucional</h2>
            </div>
           <div class="card-body">
               <asp:TextBox ID="Tcorreo" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
            <div class="card-footer">
                <asp:Button ID="Bterminar" runat="server" Text="Button" CssClass="btn btn-outline-success btn-block btn-lg" OnClick="Bterminar_Click" />
                <asp:HyperLink runat="server" ID="HL1" NavigateUrl="~/view/perfil/Perfil.aspx"><span class="text-info">Volver</span></asp:HyperLink>
            </div>
        </div>
    </div>
    </asp:Panel>
    <asp:Panel ID="panelV" runat="server">
        <div class="d-flex justify-content-center">
        <div class="p-4 card">
            <div class="">
                <h2>Verificar Correo Institucional</h2>
            </div>
           <div class="card-body">
               <asp:TextBox ID="Tcodigo" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
            <div class="card-footer">
                <asp:Button ID="Bcodigo" runat="server" Text="Button" CssClass="btn btn-outline-success btn-block btn-lg" OnClick="Bcodigo_Click"  />
                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/view/perfil/Perfil.aspx"><span class="text-info">Volver</span></asp:HyperLink>
            </div>
        </div>
    </div>
    </asp:Panel>
    <asp:TextBox ID="clave" runat="server" Visible="false"></asp:TextBox>
    
</asp:Content>

