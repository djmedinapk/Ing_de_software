<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="~/Controller/home2.aspx.cs" Inherits="home2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">    

   
   <style>
    .div_div_perfil{

	height: 600px;
	background-color:#fff;


    }
    .btn-outline-success.active{
			background-color: #FFFFFF;
			color: #28a745;
			border-right-color: #FFFFFF;
    }
   
		
		.flex-column{
			
			border-right: 1px solid;
			border-right-color: #fff;
		}
		.panel-izquierda{
			
			padding-top: 20px;
            padding-bottom:200px;
		}
		.panel-derecho{
			padding-right: 0px;

		}

	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div class="tabs">
		<div class="row">
		    <div class="col-3 panel-izquierda">
		    	<div class="nav flex-column nav-pills " id="v-pills-tab" role="tablist">
			        <img src="img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">
			        <h5>
					  DJMEDINA<br>
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
					    	 <button  type="button" class="btn btn-outline-success  btn-block active"  id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" >Publicaciones</button>
							  <button type="button"  class="btn btn-outline-success  btn-block"  id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false" >Configuracion Perfil</button>
							  <button type="button"  class="btn btn-outline-success  btn-block" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-expanded="false" >Ajustes</button>
					</div>
		     	</div>
		    </div>
		    <div class="col-9 panel-derecho">
		      	<div class="tab-content" id="v-pills-tabContent">
			        <div class="tab-pane fade active show" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab" aria-expanded="true">
				        <div class="list-group">
								<a href="#" class="list-group-item list-group-item-action flex-column align-items-start ">
								    <div class="d-flex w-100 justify-content-between">
								      <h6 class="mb-1">List group item heading</h6>
								      <small>3 days ago</small>
								    </div>
								    <p class="mb-0">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>								   
								</a>
								<a href="#" class="list-group-item list-group-item-action flex-column align-items-start ">
								    <div class="d-flex w-100 justify-content-between">
								      <h6 class="mb-1">List group item heading</h6>
								      <small>3 days ago</small>
								    </div>
								    <p class="mb-0">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>								    
								</a>
								<a href="#" class="list-group-item list-group-item-action flex-column align-items-start ">
								    <div class="d-flex w-100 justify-content-between">
								      <h6 class="mb-1">List group item heading</h6>
								      <small>3 days ago</small>
								    </div>
								    <p class="mb-0">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>								   
								</a>								
						</div>
			         </div>

			        <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab" aria-expanded="false">
				        <dl class="row">

							<dt class="col-sm-3 text-right">Imagen de Perfil</dt>
							<dd class="col-sm-9">
							  	<dl class="row">
								    <dt class="col-sm-4">
								      	 <img src="img/123.jpg" alt="..." class="img-thumbnail" width="200px" height="20px">
								    </dt>
								    <dd class="col-sm-8">
								       <input class="form-control input-lg" id="inputlg" type="file" placeholder="Apellido">
								       <span class="badge badge-secondary">tamaño maximo 4MB</span>
								    </dd>
							    </dl>
							</dd>

							<dt class="col-sm-3 mt-5 text-right">Usuario</dt>
							<dd class="col-sm-9 mt-5">
							  	 <input class="form-control input-lg" id="inputlg" type="text" placeholder="Usuario">
							</dd>

							<dt class="col-sm-3 mt-5 text-right">Nombre</dt>
							<dd class="col-sm-9 mt-5">
							  	 <input class="form-control input-lg" id="inputlg" type="text" placeholder="Nombre">
							</dd>

							<dt class="col-sm-3 mt-5 text-right">Apellido</dt>
							<dd class="col-sm-9 mt-5">
							     <input class="form-control input-lg" id="inputlg" type="text" placeholder="Apellido">
							 </dd>

							<dt class="col-sm-3 mt-5 text-right">Edad</dt>
							<dd class="col-sm-9 mt-5">
							  	 <input class="form-control input-lg" id="inputlg" type="text" placeholder="Edad">
							</dd>

							<dt class="col-sm-3 mt-5 text-right">correo</dt>
							<dd class="col-sm-9 mt-5">
							    <dl class="row">
								    <dt class="col-sm-4"></dt>
								    <dd class="col-sm-8">
								    	<input class="form-control input-lg" id="inputlg" type="text" placeholder="Correo">
								     </dd>
							    </dl>
							</dd>
						</dl>
					</div>
		        </div>       		        
		    </div>
		</div>
	</div>
	  
			
		

			
	  		
	    <!-- Optional JavaScript -->
	    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
	    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
	    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</asp:Content>

