<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logina.aspx.cs" Inherits="SaleOrderBooking.Logina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <%--<meta charset="utf-8">--%>
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Log in</title>
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
  
  <!-- icheck bootstrap -->

  <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">

  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/adminlte.min.css">

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
       <div class="login-box">
       <div class="login-logo">
   
  
  <!-- /.login-logo -->
  <div class="card" id="login-panel">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Login</p>      
        <div class="input-group mb-3">
       
             <asp:TextBox ID="Username"  placeholder="Username" name="Username" class="form-control" runat="server"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>


        <div class="input-group mb-3">
         
          <asp:TextBox ID="Password" TextMode="Password" placeholder="Password" class="form-control" runat="server"></asp:TextBox>

          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="mb-3 error-class">          
        </div>
        <div class="row call-button">
          <div class="col-6">
          
              <asp:Button ID="Button1" Value ="Button1" runat="server" Text="Sign In" class="btn btn-primary btn-block" OnClick="Button1_Click1" />

          </div>
          <div class="col-6">
           
              <asp:Button ID="button" Value ="button" runat="server" Text="Cancel" name="Cancel" class="btn btn-primary btn-block" />
          </div>
            <br />
            <h2 id ="result"> </h2> 
            
        </div>
<%--        <div class="col-12 loader">        
        </div>        --%>
      <!-- /.social-auth-links -->        
  </div>
</div>

  </div>
</div>   

  </form>
    <script src="jquery-3.5.1.min.js"></script>
  
  <script type="text/javascript">
   

</script>
</body>


</html>
