<%@ Page Title="" Language="C#" MasterPageFile="~/MAIN.Master" AutoEventWireup="true" CodeBehind="SALORDER.aspx.cs" Inherits="SaleOrderBooking.SALORDER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link href="jquery-ui-1.12.1/jquery-ui.min.css" rel="stylesheet" />
     <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="jquery-ui-1.12.1/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdditionalTopJSCSS" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
  <form id="SALEORDER" runat="server">

  <div class="card border-success mb-3">
  <div class="card-header bg-transparent border-success">
    <h3 text-align: center:>Sale Order Booking</h3>
  </div>

     
  <div class="card-body">
  <div class="box box-default">
  <div class="box-header with-border">

      

     <div class="form-row">

          <div class="form-group col-md-6">
              <label for="inputEmail4">Sales Man </label>
              <select class="form-control select2" style="width: 100%;" id="DDSALMAN" ClientIDMode="Static" runat ="server" >                    
              </select>
          </div>

       <div class="form-group col-md-2">
              <label for="inputEmail4">Order No.</label>
              <input class="form-control" type="text" id="TXTORDN" ClientIDMode="Static" placeholder="XXXXXXXXXX" readonly runat ="server">
          </div>

       
    <div class="form-group col-md-2">
              <label for="inputEmail4">Order Date </label>
             <input class="form-control" type="text" id="ordt" ClientIDMode="Static" runat ="server" autocomplete="off">

    </div>
   
         <script type="text/javascript">
             $(function () {
                 $("[id*=ordt]").datepicker({

                 });
             });
         </script>

      
       <div class="form-group col-md-2">
              <label for="inputEmail4">Party Order No. </label>
              <input type="text" class="form-control" id="TXTPORD" aria-describedby="emailHelp" placeholder="Party Order No." runat ="server">
       </div>
     
          <div class="form-group col-md-6">
            <label for="inputEmail4">Unit </label>
            <select class="form-control select2" style="width: 100%;" id="DDUNIT" ClientIDMode="Static" runat ="server">                    
            </select>
          </div>

           <div class="form-group col-md-6">
             <label for="inputEmail4">Division</label>
             <select class="form-control select2" style="width: 100%;" id="DDDVCD" runat ="server" ClientIDMode="Static"  onselectedindexchanged="DDSALMAN_SelectedIndexChanged">                    
             </select>
          </div>

</div>
</div>
</div>
</div>
</div>
    <div class="card-footer bg-transparent border-success"></div>

   <div class="card-body">
       <div class="box box-default">
       <div class="box-header with-border">

     <div class="form-row">

          <div class="form-group col-md-6">
              <label for="inputEmail4">Party </label>
              <select class="form-control select2" style="width: 100%;" id="TXTPCOD" ClientIDMode="Static" runat ="server" onchange="GetSelectedTextValue(this)">                    
                   
               </select>
          </div>



        <div class="form-group col-md-6">
              <label for="inputEmail4">Tax Category </label>
              <select class="form-control select2" style="width: 100%;" id="TXTTXCD" ClientIDMode="Static" runat ="server">                    
              </select>
          </div>

        <div class="form-group col-md-6">
              <label for="inputEmail4">Agent </label>
              <select class="form-control select2" style="width: 100%;" id="TXTAGCD" ClientIDMode="Static" runat ="server">                    
              </select>
          </div>
     
          <div class="form-group col-md-6">
            <label for="inputEmail4">Consignee </label>
            <select class="form-control select2" style="width: 100%;" id="TXTCONCOD" ClientIDMode="Static" runat ="server">                    
            </select>
          </div>

           <div class="form-group col-md-12">
             <label for="inputEmail4">Consignee Address</label>
             <select class="form-control select2" style="width: 100%;" id="TXTCONADDR" ClientIDMode="Static" runat ="server">                    
             </select>
          </div>

</div>
</div>
          <div class="form-row">

       <div class="form-group col-md-6">
              <label for="inputEmail4">Item </label>
              <select class="form-control select2" style="width: 100%;" id="TXTICOD" ClientIDMode="Static" runat ="server">                    
              </select>
           <label class="text-danger" id="itemnameerror"></label>
       </div>

       <div class="form-group col-md-2">
              <label for="inputEmail4">Grade</label>
              <select class="form-control select2" style="width: 100%;" id="TXTGRAD" ClientIDMode="Static" runat ="server"> 
              </select>
           <label class="text-danger" id="gradeerror"></label>
       </div>

      <div class="form-group col-md-1">
              <label for="inputEmail4">Quantity</label>
              <input type="text" class="form-control" id="TXTQNTY" ClientIDMode="Static" aria-describedby="emailHelp" runat ="server">
          <label class="text-danger" id="quantityerror"></label>
       </div> 
   
       <div class="form-group col-md-1">
              <label for="inputEmail4">Rate</label>
              <input type="text" class="form-control" id="TXTRATE" ClientIDMode="Static" aria-describedby="emailHelp" runat ="server">
              <label class="text-danger" id="netrateerror"></label>
       </div> 
     
       <div class="form-group col-md-1">
              <label for="inputEmail4">Ass. Rate</label>
              <input type="text" class="form-control" id="TXTARAT" ClientIDMode="Static" aria-describedby="emailHelp" readonly runat ="server">
             <label class="text-danger" id="assrateerror"></label>
       </div>  

            <!--div class="col-sm-12">
		    <div class="form-group">
		    <label id="staticmessage"></label>
            </div-->

       
       <div class="form-group col-md-1">
         <p style="padding:8px;"></p>
         
        <button type="button" id="CMDADD"  class="btn btn-success">Add Detail </button>       
       
       </div>  
     
    <!-- Table Data ---------------------------------------->
       <div class="card-body table-responsive p-0">
                <!--table class="table table-hover"-->
                  <table class="table table-bordered data-table" >
                  <thead>
                    <tr>
                       <th>#</th>
                      <th>Item</th>
                      <th>Grade</th>
                      <th>Quantity</th>
                      <th>Rate</th>
                      <th>Ass. Rate</th>
                      <th>Actions</th>      
                     
                        
                    </tr>
                  </thead>

                  <tbody id="mytable" >
                    
                  <tbody> 
                  </table>
      <!------------------------------------------------------>
   </div>

                <div class="col text-center">
                <button type="submit" id ="Save" runat ="server"   class="btn btn-primary"> Save </button>
                <button type="button" class="btn btn-info"> Cancel</button>
              </div>

              </div>              
  

              <div style ="border:1px solid black"; padding: 3px; width:12px>

              <table id = "datatable">
                 <thead>
                    <tr>
                      <th>ORDT</th>
                      <th>ORDN</th>
                      <th>PCOD</th>
                      <th>TXCD</th>
                      <th>BRCD</th>
                       
                     
                        
                    </tr>
                  </thead>

              </table>
            </div> 
           </div>
</div>
          
<%--</div>--%>
</form>

 

  
            <script>
                $('#TXTRATE').keypress(function (event) {
                    $('#TXTARAT').val($('#TXTRATE').val() + String.fromCharCode(event.keyCode));
                });

                $(document).on('keyup', '#TXTRATE', function () {
                    var preg = /^\d*\.?(?:\d{1,4})?$/;
                    if (!$('#TXTRATE').val().match(preg)) {
                        $('#TXTARAT').val($.trim($('#TXTRATE').val().substring(0, ($('#TXTRATE').val().length - 1))))
                    }
                    $('#TXTARAT').val($('#TXTRATE').val());
                });

                $(document).on('keydown', '#TXTRATE', function () {
                    var preg = /^\d*\.?(?:\d{1,4})?$/;
                    if (!$('#TXTRATE').val().match(preg)) {
                        $('#TXTRATE').val($.trim($('#TXTRATE').val().substring(0, ($('#TXTRATE').val().length - 1))))
                    }
                    $('#TXTARAT').val($('#TXTRATE').val());
                });



      </script>

      

      <script>


          function getAllEmpData() {
              var data = [];
              var cntr = 1;
              // $('tr.data-table').each(function () {
             
              $("[id*=mytable]").each(function () {
                  var self = $(this);

                  var osrc = self.find("td:eq(0)").text().trim();
                  var ittm = self.find("td:eq(7)").text().trim();
                  var grdcod = self.find("td:eq(8)").text().trim();
                  var qnty = self.find("td:eq(3)").text().trim();
                  var rate = self.find("td:eq(4)").text().trim();
                  var arat = self.find("td:eq(5)").text().trim();

                  cntr++;
                  var unit = $("#DDDVCD").val();
                  var dvcd = $("#DDDVCD").val();
                  var dbcd = $("#DDSALMAN").val();
                  var ordn = $("#TXTORDN").val();
                  var pcode = $("#TXTPCOD").val();
                  var txcd = $("#TXTTXCD").val();
                  var brcd = $("#TXTAGCD").val();
                  var ordt = $("#TXTORDT").val();
                  var pord = $("#TXTPORD").text();

                  // var firstName = $(this).find('.f-name01').val();
                  // var lastName = $(this).find('.l-name01').val();
                  // var emailId = $(this).find('.email01').val();
                  var alldata1 = {
                      'FName': unit,
                      'LName': dvcd,
                      'EmailId': ordn
                  }


                  var alldata = {
                      'COMP': "0001",
                      'UNIT': unit,
                      'DCOD': dvcd,
                      'DBCD': dbcd,
                      'ORDN': ordn,
                      'ORDT': "05/09/2020",
                      'PORD': pord,
                      'PCOD': pcode,
                      'TXCD': txcd,
                      'BRCD': brcd,
                      'ICOD': ittm,
                      'TRCD': grdcod,
                      'QNTY': qnty,
                      'RATE': rate,
                      'ARAT': arat,
                      'OSRC': osrc

                  }
                  data.push(alldata);
              });
              console.log(data);
              return data;
          }




          function staticvalidation() {
              val = 1;
              $('#itemnameerror').html('');
              $('#quantityerror').html('');
              $('#netrateerror').html('');


              if ($('#TXTICOD').val() == "") {
                  $('#itemnameerror').html('Item Name Required');
                  val = 0;
              }

              if ($('#TXTQNTY').val() == "") {
                  $('#quantityerror').html('Qty. Required');
                  val = 0;
              }

              if ($('#TXTQNTY').val() <= 0) {
                  $('#quantityerror').html('Qty. Required');
                  val = 0;
              }

              if ($('#TXTRATE').val() == "") {
                  $('#netrateerror').html('Net Rate Required');
                  val = 0;
              }

              if ($('#TXTRATE').val() <= 0) {
                  $('#netrateerror').html('Net Rate Required');
                  val = 0;
              }
              if ($('#TXTRATE').val() != $('#TXTARAT').val()) {
                  // $('#staticmessage').removeClass("text-success").addClass('text-danger');
                  // $('#staticmessage').html('Net Rate and Ass. Rate are not same.');
                  $('#netrateerror').html('Net Rate and Ass. Rate are not same.');
                  val = 0;
              }

              return val;
          }

          var rowno = 1;
          $("#CMDADD").click(function (e) {
              e.preventDefault();

              var exit = false;

              $("#mytable tr").each(function () {
                  var self = $(this);

                  var ittm = self.find("td:eq(1)").text().trim();
                  var grd = self.find("td:eq(2)").text().trim();

                  var tabresult = ittm + grd;

                  var dditm = $("#TXTICOD").find(':selected').text();
                  var ddgrd = $("#TXTGRAD").find(':selected').text();
                  var ddresult = dditm + ddgrd;



                  if (tabresult != "") {
                      console.log(tabresult + ":" + ddresult);
                      console.log(tabresult);
                      console.log(ddresult);

                      if (ddresult.trim() == tabresult) {
                          alert("Item already inserted !!");
                          exit = true;
                          return false;
                      }

                  }

              });

              if (exit) return false;

              val = staticvalidation();

              var aa = $("#TXTGRAD").find(':selected').text();


              if (val == 1) {
                  $('#mytable').append('<tr id="orderdata-' + $("#TXTICOD").val() + $("#TXTGRAD").val() + '"> <td id="sr-' + $("#TXTICOD").val()
                      + '">' + rowno + '</td> <td id="ITEM-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTICOD").val()
                      + '>' + $("#TXTICOD").find(':selected').text() + '</td><td id="grade-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTGRAD").val()
                      + '>' + $("#TXTGRAD").find(':selected').text() + '</td><td id="quantity-' + $("#TXTICOD").val()
                      + '">' + $("#TXTQNTY").val() + '</td><td id="netrate-' + $("#TXTICOD").val()
                      + '">' + $("#TXTRATE").val() + '</td><td id="assrate-' + $("#TXTICOD").val()
                      + '">' + $("#TXTARAT").val() + '</td> <td> <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a></td><td id="ICOD-' + $("#TXTICOD").val()
                      + '">' + $("#TXTICOD").val() + '</td> <td id="ICOD-' + $("#TXTGRAD").val()
                      + '">' + $("#TXTGRAD").val() + '</td></tr>');
                  rowno++;



                  $('#grade').val("1").trigger('change.select2');
                  $('#TXTQNTY').val('');
                  $('#TXTRATE').val('');
                  $('#TXTARAT').val('');

                  $('th:nth-child(8), tr td:nth-child(8)').hide();
                  $('th:nth-child(9), tr td:nth-child(9)').hide();

                  //  editord();
              }
          });

      </script>

      <script>
          var addSerialNumber = function () {
              var i = 0

              $('table tbody tr').each(function (idx) {
                  $(this).children(":eq(0)").html(idx + 1);
              });
          };



          $(document).on("click", ".delete", function () {

              $(this).closest('tr').remove();
              rowno--;
              addSerialNumber();

          });

          $("[id*=Save]").click(function () {
          
              alert("save clicked");
              var data = JSON.stringify(getAllEmpData());
              console.log(data);
             
              $.ajax({
                  url: 'SALORDER.aspx/SaveData',
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json; charset=utf-8',
                  data: JSON.stringify({ 'ordman': data }),
                  success: function () {
                      alert("Data Added Successfully");
                  },
                  error: function () {
                      alert("Error while inserting data");
                  }
              });


          });


      </script>
  
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderAditionalBottomJSCSS" runat="server">
</asp:Content>
  