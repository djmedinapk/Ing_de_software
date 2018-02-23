<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_2.master" AutoEventWireup="true" CodeFile="~/Controller/view/correoInstitucional.aspx.cs" Inherits="view_perfil_correoInstitucional" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
               <asp:TextBox ID="Tcorreo" runat="server" CssClass="form-control"  ValidationGroup="correo"></asp:TextBox><input type="text" disabled class="form-control" value="@ucundinamarca.edu.co" />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcorreo" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="correo"></asp:RequiredFieldValidator>
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="/_.- " TargetControlID="Tcorreo" />
           </div>
            <div class="card-footer">
                <asp:Button ID="Bterminar" runat="server" Text="Enviar" CssClass="btn btn-outline-success btn-block btn-lg" OnClick="Bterminar_Click" ValidationGroup="correo" />
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
               <asp:TextBox ID="Tcodigo" runat="server" CssClass="form-control" ValidationGroup="verificar"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="Tcodigo" ForeColor="Red" Font-Size="XX-Small"  ValidationGroup="verificar"></asp:RequiredFieldValidator>
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="" TargetControlID="Tcodigo" />

           </div>
            <div class="card-footer">
                <asp:Button ID="Bcodigo" runat="server" Text="Terminar" CssClass="btn btn-outline-success btn-block btn-lg" OnClick="Bcodigo_Click" ValidationGroup="verificar" />
                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/view/perfil/Perfil.aspx"><span class="text-info">Volver</span></asp:HyperLink>
            </div>
        </div>
    </div>
    </asp:Panel>
    <asp:TextBox ID="clave" runat="server" Visible="false"></asp:TextBox>
    
</asp:Content>

