<%@ Page Title="" Language="C#" MasterPageFile="~/Master1_1.master" AutoEventWireup="true" CodeFile="~/Controller/view/private/search.aspx.cs" Inherits="view_Private_search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row" style="padding:100px;">
        <asp:TextBox ID="Tsearch" runat="server" AutoPostBack="true"></asp:TextBox>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-$ñ " TargetControlID="Tsearch" />
    </div>
    <div class="col col-12">
        <h3><asp:Label ID="L_resultado_busqueda" runat="server" Text="Resultados de la Busqeuda"></asp:Label></h3>
        <hr>
    </div>
    <div class="col col-12">
        <div class="list-group">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ODSbusqueda">
                <ItemTemplate>
                     <div class="d-flex w-10 justify-content-end" style="margin-bottom: 0px;">
                        <asp:HyperLink ID="HLpost" runat="server" class="list-group-item list-group-item-action flex-column align-items-start " NavigateUrl='<%#  Bind("id_post") %>'>
                            <div class="p-10 align-self-end">
                                <div class="d-flex justify-content-between">
                                    <h4 class="mb-1">
                                        <asp:Label ID="LperfilTituloPost" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h4>
                                    <small>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("miniatura") %>'></asp:Label></small>
                                </div>
                                <p class="mb-0">
                                    <small>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                                    </small>
                                </p>
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource runat="server" ID="ODSbusqueda" SelectMethod="listar_busqueda_private" TypeName="Logica.Lpost">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Tsearch" PropertyName="Text" Name="info" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

