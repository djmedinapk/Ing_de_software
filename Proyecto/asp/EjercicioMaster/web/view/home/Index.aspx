<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Index.aspx.cs" Inherits="view_home_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="d-flex flex-row" style="padding-top: 20px;">
        <div class="p-3"> 
            <div class="card" style="width: 100%; border-color: #FFDF05; ">
              <div class="card-header" style="font-size: 20px; background-color: #FFDF05;">
                Mas Vistos
               </div>
              <div class="card-body">
                <!--- datalist here my friends-->
                  <asp:datalist runat="server" DataSourceID="ODSvisitas">
                      <ItemTemplate>
                          <div class="card" style="width: 20rem;">
                              <div class="card-body">
                                <h4 class="card-title"><asp:Label id="Ltitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h4>
                                <p class="card-text"><asp:Label id="Label1" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                                <asp:HyperLink runat="server" id="HyperLink2" class="btn btn-primary" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                              </div>
                            </div>
                      </ItemTemplate>
                  </asp:datalist>
                  <asp:ObjectDataSource ID="ODSvisitas" runat="server" SelectMethod="ver_post_home" TypeName="DAOpost">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="1" Name="orden" Type="String" />
                      </SelectParameters>
                  </asp:ObjectDataSource>
                <!--- datalist here my friends-->
              </div>
              <div class="card-footer text-muted">
               
              </div>
            </div>
         </div>
        <div class="d-flex flex-row ">
        <div class="p-3"> 
            <div class="card" style="width: 100%; border-color: #E4E056; ">
              <div class="card-header" style="font-size: 20px; background-color: #E4E056;">
                Mas Votados
               </div>
              <div class="card-body">
                 <!--- datalist here my friends-->
                    <asp:datalist runat="server" DataSourceID="ODSranking">
                      <ItemTemplate>

                          <div class="card" style="width: 20rem;">
                              <div class="card-body">
                                <h4 class="card-title"><asp:Label id="Label4" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h4>
                                <p class="card-text"><asp:Label id="Label5" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                                 <asp:HyperLink runat="server" id="HLhome" class="btn btn-primary" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                                
                              </div>
                            </div>
                      </ItemTemplate>
                  </asp:datalist>
                  <asp:ObjectDataSource ID="ODSranking" runat="server" SelectMethod="ver_post_home" TypeName="DAOpost">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="3" Name="orden" Type="String" />
                      </SelectParameters>
                  </asp:ObjectDataSource>
                <!--- datalist here my friends-->
              </div>
              <div class="card-footer text-muted">
               
              </div>
            </div>
         </div><div class="d-flex flex-row ">
        <div class="p-3"> 
            <div class="card" style="width: 100%; border-color: #84E41F;">
              <div class="card-header" style="font-size: 20px; background-color: #84E41F;"">
                Recientes
               </div>
              <div class="card-body">
                 <!--- datalist here my friends-->
                  <asp:datalist runat="server" DataSourceID="ODSfecha">
                      <ItemTemplate>
                          <div class="card" style="width: 20rem;">
                              <div class="card-body">
                                <h4 class="card-title"><asp:Label id="Label2" runat="server" Text='<%# Bind("titulo") %>'></asp:Label></h4>
                                <p class="card-text"><asp:Label id="Label3" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label></p>
                                <asp:HyperLink runat="server" id="HyperLink1" class="btn btn-primary" NavigateUrl='<%# Bind("id_post") %>' > Ir a</asp:HyperLink>
                              </div>
                            </div>
                      </ItemTemplate>
                  </asp:datalist>
                  <asp:ObjectDataSource ID="ODSfecha" runat="server" SelectMethod="ver_post_home" TypeName="DAOpost">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="2" Name="orden" Type="String" />
                      </SelectParameters>
                  </asp:ObjectDataSource>


                <!--- datalist here my friends-->
              </div>
              <div class="card-footer text-muted">
                
              </div>
            </div>
         </div>                 
     </div>
     </div></div>
</asp:Content>

