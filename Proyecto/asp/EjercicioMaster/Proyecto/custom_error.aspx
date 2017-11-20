<%@ Page Language="C#" AutoEventWireup="true" CodeFile="custom_error.aspx.cs" Inherits="view_custom_error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Error| </title>

    <!-- Bootstrap -->
    <link href="App_Themes/assets/colorlib/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="App_Themes/assets/colorlib/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="App_Themes/assets/colorlib/vendors/nprogress/nprogress.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../../App_Themes/assets/colorlib/build/css/custom.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
       <div class="container body">
      <div class="main_container">
        <!-- page content -->
        <div class="col-md-12">
          <div class="col-middle">
            <div class="text-center text-center">
              <h1 class="error-number">UPPPPSSs!</h1>
              <h2>hey! lo sentimos, al parecer algo ha salido mal</h2>
              <p>Por favor contacta al administrador y reporta el problema, con tu ayuda contruiremos una comunidad mejor <a href="view/home/contacto.aspx">Report this?</a>
              </p>
              <div class="mid_center">
                <h3>Volver al inicio</h3>
                  <div class="col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                      <span class="input-group-btn">
                              <a class="btn btn-default" href="view/home/Index.aspx">Go!</a>
                          </span>
                    </div>
                  </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /page content -->
      </div>
    </div>

    <!-- jQuery -->
    <script src="App_Themes/assets/colorlib/vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="App_Themes/assets/colorlib/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="App_Themes/assets/colorlib/vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="App_Themes/assets/colorlib/vendors/nprogress/nprogress.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="App_Themes/assets/colorlib/build/js/custom.min.js"></script>
        </form>
  </body>
</html>