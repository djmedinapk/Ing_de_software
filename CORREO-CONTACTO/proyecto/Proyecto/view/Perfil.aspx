﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/view/Perfil.aspx.cs" Inherits="view_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" type="text/css" href="../App_Themes/css/modificar_perfil.css">
    <style>
        .flex-column {
            border-right: 1px solid;
            border-right-color: #fff;
        }

        .panel-izquierda {
            padding-left: 30px;
            padding-top: 20px;
        }

        .panel-derecho {
            padding-right: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tabs">
        <div class="row">
            <div class="col-3 panel-izquierda">
                <div class="nav flex-column nav-pills " id="v-pills-tab" role="tablist">
                    <div style="width: 200px; min-height: 200px;">
                        <img src="../img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">
                    </div>

                    <h5>DJMEDINA<br>
                        <small class="text-muted">Never use to be</small>
                    </h5>
                    <h6 class="text-muted">
                        <ul>
                            <li>estado: <span style="color: #02FF32">online</span></li>
                            <li>total mensajes: 12</li>
                            <li>total Post: 12</li>

                        </ul>
                    </h6>
                    <div style="height: 100px"></div>
                    <div class="btn-group-vertical">
                        <button type="button" class="btn btn-outline-success  btn-block active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home">Publicaciones</button>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">perfil</button>
                        <button type="button" class="btn btn-outline-success  btn-block" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false">Ajustes</button>
                    </div>
                </div>
            </div>
            <div class="col-9 panel-derecho">
                <div class="tab-content" id="v-pills-tabContent">
                    <div class="tab-pane fade active show" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab" aria-expanded="true">
                        <div class="d-flex flex-row-reverse">
                            <asp:hyperlink id="HLperfilCrear" runat="server" Font-Size="34pt" NavigateUrl="~/view/CrearPublicacion.aspx" ><i class="fa fa-pencil-square-o text-success" aria-hidden="true" class="btn btn-warning"></i></asp:hyperlink>
                            <%--<asp:Button ID="BperfilCrearpost" runat="server" Text="Crear Publicacion" class="btn btn-warning"/>--%>
                        </div>
                        <div class="list-group">
                            <asp:datalist runat="server" repeatlayout="Flow">
                                <ItemTemplate>
                                    <a href="#" class="list-group-item list-group-item-action flex-column align-items-start ">
								    <div class="d-flex w-100 justify-content-between">
								      <h6 class="mb-1">List group item heading</h6>
								      <small>3 days ago</small>
								    </div>
								    <p class="mb-0">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>								   
								</a>
                                </ItemTemplate>
                            </asp:datalist>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab" aria-expanded="false">
                        <dl class="row">

                            <dt class="col-sm-3 text-right">Imagen de Perfil</dt>
                            <dd class="col-sm-9">
                                <dl class="row">
                                    <dt class="col-sm-4">
                                        <img src="../img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">
                                    </dt>
                                    <dd class="col-sm-8">
                                        <asp:fileupload id="FUperfilImagen" runat="server" class="form-control input-lg"></asp:fileupload>
                                        <%--<input class="form-control input-lg" id="inputlg" type="file" >--%>
                                        <span class="badge badge-secondary">tamaño maximo 4MB</span>
                                    </dd>
                                </dl>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Usuario</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilUsuario" placeholder="Usuario"></asp:textbox>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Nombre</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilNombre" placeholder="Nombre"></asp:textbox>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Apellido</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilApellido" placeholder="Apellido"></asp:textbox>
                                <%-- <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">Edad</dt>
                            <dd class="col-sm-9 mt-5">
                                <asp:textbox runat="server" class="form-control input-lg" id="TperfilEdad" placeholder="Edad" textmode="Number"></asp:textbox>
                                <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Edad">--%>
                            </dd>

                            <dt class="col-sm-3 mt-5 text-right">correo</dt>
                            <dd class="col-sm-9 mt-5">
                                <dl class="row">
                                    <dt class="col-sm-4"></dt>
                                    <dd class="col-sm-8">
                                        <asp:textbox runat="server" class="form-control input-lg" id="TperfilCorreo" type="text" placeholder="Correo" textmode="Email"></asp:textbox>
                                        <%--<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">--%>
                                    </dd>
                                </dl>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
