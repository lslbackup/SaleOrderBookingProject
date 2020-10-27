<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancialYr.aspx.cs" Inherits="SaleOrderBooking.FinancialYr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Log in</title>
  <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
  
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/adminlte.min.css">

    <style>
    .DDFINYR
{
color: #fff;
font-size: 50px;
padding: 10px 20px;
border-radius: 10px 22px;
background-color: #292929;
font-weight: bold;
}

    </style>

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
       <div class="login-logo">
   
  
  <!-- /.login-logo -->
  <div class="card" id="login-panel">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Financial Year</p>      
        <div class="input-group mb-3">
       
              <select class="form-control select2" style="width: 100%;" id="DDFINYR" runat ="server" onselectedindexchanged="DDCOMPSELECT_SelectedIndexChanged" >                    
              </select>
          <div class="input-group-append">
            <div class="input-group-text">
            
            </div>
          </div>
        </div>

        <div class="row call-button">
           <div class="col-3">
            
          </div>


          <div class="col-3">
            
                <asp:Button ID="Button1" Value ="Select" runat="server" Text="Select" class="btn btn-primary btn-block" OnClick="Button1_Click1" />
          </div>

          <div class="col-3">
            <input type="button" class="btn btn-primary btn-block" value="Cancel" name="Cancel" id="Cancel" runat ="server">
          </div>
          
          </div>

    </div>
       
           </div>
        </div>       

    </form>
    
  
      
      <%-- <script type="text/javascript">
           $(document).ready(function () {

                $("#Continue").click(function () {
                    window.location.href = "CompSelection.aspx";

                  alert("Select Company");
                });
            });

    </script>

  <script src="jquery-3.5.1.min.js"></script>--%>

</body>
</html>
