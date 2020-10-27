<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NEWSALORDER.aspx.cs" Inherits="SaleOrderBooking.NEWSALORDER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




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
              <label class="text-danger" id="lblordt"></label>
    </div>
   
         <script type="text/javascript">
             $(function () {
                 $("[id*=ordt]").datepicker({
                 dateFormat: 'dd/mm/yy' 
                 });
             });
         </script>

      
       <div class="form-group col-md-2">
              <label for="inputEmail4">Party Order No. </label>
              <input type="text" class="form-control" id="TXTPORD" aria-describedby="emailHelp" placeholder="Party Order No." ClientIDMode="Static" runat ="server">
           
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

  
    <div class="card border-success mb-3">
   <div class="card-body">
       <div class="box box-default">
       <div class="box-header with-border">

     <div class="form-row">

          <div class="form-group col-md-6">
              <label for="inputEmail4">Party </label>
              <select class="form-control select2" style="width: 100%;" id="TXTPCOD" ClientIDMode="Static" runat ="server" >                    
                   
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
</div>
</div>
 </div>

      <div class="card border-success mb-3">
      <div class="card-body">
       <div class="box box-default">
       <div class="box-header with-border">

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

         <div class="form-group col-md-1">
         <p style="padding:8px;"></p>
        
        <button type="button" id="CMDADD"  class="btn btn-success">Add   </button>       
     </div>
       </div>  


</div>
</div>
</div>
       <!-- Table Data ---------------------------------------->
   
       <table class="table table-bordered data-table" >
                  <thead>
                      <tr>
                      <th>Sr.No.</th>
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
<%-- 
                <div class="col text-center">

                <button type="submit" id ="Save" runat ="server"   class="btn btn-primary"> Save </button>
                <button type="button" class="btn btn-info"> Cancel</button>
                 
              </div>--%>

                      <div class="modifiable">
                      <div class="col text-center">
                      <button type="button" class="btn btn btn-primary" id="Save">Save</button> 
                      <button type="button" class="btn btn btn-primary" id="Update">Update</button> 
                      <button type="button" class="btn btn btn-danger"  id="Cancel">Cancel</button>
                    
                      <p id="salordermessage"></p>
                       </div>
                    </div>

             <br/> 
  
       <div class="form-row">
       <div class="form-group col-md-12">
     
              <table id = "datatable" class="table table-striped table-bordered" style="width:100%"> 
              <!--table id = "datatable" class="display" style="width:100%"-->     
                 <thead>
                    <tr>
                      
                      <th>Order Dt.</th>
                      <th>Order No.</th>
                      <th>Party</th>
                      <th>Quantity</th>
                      <th>Broker</th>
                      <th>Unit</th>
                      <th>Division</th>
                      <th>Salesman</th>
                      <th>Brokercode</th>
                      <th>Tax Category</th>
                      <th>Consignee</th>
                      <th>Address</th>
                      <th>PartyOrderNo</th>
                      <th>PCOD</th>
                      <th>Action</th>
                    
             
                     
                     
                  </thead>

              </table>
            </div> 
        
          </div>
          
          
          
<%--</div>--%>


 

  
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
                  var unit = $("#DDUNIT").val();
                  var dvcd = $("#DDDVCD").val();
                  var dbcd = $("#DDSALMAN").val();
                  var ordn = $("#TXTORDN").val();
                  var pcode = $("#TXTPCOD").val();
                  var txcd = $("#TXTTXCD").val();
                  var brcd = $("#TXTAGCD").val();
                  var ordt = $("#TXTORDT").val();
                  var pord = $("#TXTPORD").text();

                
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
              $('#lblordt').html('');

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

              if ($('#ordt').val() == "") {
                  $('#lblordt').html('Order Date Required');
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

                  console.log(ddresult);

                  if (tabresult != "") {
                      console.log(tabresult + ":" + ddresult);
                      console.log(tabresult);
                      console.log(ddresult);

                      if (ddresult.trim() == tabresult) {
                          alert("Item already inserted !!");
                          ddresult = "";
                          ittm = "";
                          grd = "";
                          exit = true;
                          return false;
                      }

                  }

              });

              if (exit) return false;

              val = staticvalidation();


              var aa = $("#TXTGRAD").find(':selected').text();

              if (val == 1) {
                  if ($("#mytable tr").length > 0) {
                      rowno = $("#mytable tr").length +1
                  }

                  $('#mytable').append('<tr id="orderdata-' + $("#TXTICOD").val() + $("#TXTGRAD").val() + '"> <td id="sr-' + $("#TXTICOD").val()
                      + '">' + rowno + '</td> <td id="ITEM-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTICOD").val()
                      + '>' + $("#TXTICOD").find(':selected').text() + '</td><td id="grade-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTGRAD").val()
                      + '>' + $("#TXTGRAD").find(':selected').text() + '</td><td id="quantity-' + $("#TXTICOD").val()
                      + '">' + $("#TXTQNTY").val() + '</td><td id="netrate-' + $("#TXTICOD").val()
                      + '">' + $("#TXTRATE").val() + '</td><td id="assrate-' + $("#TXTICOD").val()
                      + '">' + $("#TXTARAT").val() + '</td> <td> <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a></td><td id="ICOD-' + $("#TXTICOD").val()
                      + '">' + $("#TXTICOD").val() + '</td> <td id="ICOD-' + $("#TXTGRAD").val()
                      + '">' + $("#TXTGRAD").val() + '</td></tr>');

                  //$('#mytable').append('<tr id="orderdata-' + $("#TXTICOD").val() + $("#TXTGRAD").val() + '"> <td id="sr-' + $("#TXTICOD").val()
                  //    + '">' + rowno + '</td> <td id="ITEM-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTICOD").val()
                  //    + '>' + $("#TXTICOD").find(':selected').text() + '</td><td id="grade-' + $("#TXTICOD").val() + '" data-id=' + $("#TXTGRAD").val()
                  //    + '>' + $("#TXTGRAD").find(':selected').text() + '</td><td id="quantity-' + $("#TXTICOD").val()
                  //    + '">' + $("#TXTQNTY").val() + '</td><td id="netrate-' + $("#TXTICOD").val()
                  //    + '">' + $("#TXTRATE").val() + '</td><td id="assrate-' + $("#TXTICOD").val()
                  //    + '">' + $("#TXTARAT").val() + '</td> <td> <a href="sdelete" id="sdelete" data-value="' + rowno + '" data-id="sdelete-' + rowno +'"><i class="fas fa-trash"></i></a></td><td id="ICOD-' + $("#TXTICOD").val()
                  //    + '">' + $("#TXTICOD").val() + '</td> <td id="ICOD-' + $("#TXTGRAD").val()
                  //    + '">' + $("#TXTGRAD").val() + '</td></tr>');
                  rowno++;
                  addSerialNumber();


                  $('#grade').val("1").trigger('change.select2');
                  $('#TXTQNTY').val('');
                  $('#TXTRATE').val('');
                  $('#TXTARAT').val('');

                  $('th:nth-child(8), tr td:nth-child(8)').hide();
                  $('th:nth-child(9), tr td:nth-child(9)').hide();

                  //  editord();
              }
              $("[id*='DDDVCD']").prop('disabled', true);
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

          //$(document).on("click", '#sdelete', function () {

          //    $(this).closest('tr').remove();
          //    rowno--;
          //    addSerialNumber();

          //});



          $("[id*='Update']").on("click", function () {
              DeleteOrder();
              var n = $("#mytable").find("tr").length;
              $("[id*='mytable'] tr").each(function () {

                  var self = $(this);
                  var osrc = self.find("td:eq(0)").text().trim();
                  var ittm = self.find("td:eq(7)").text().trim();
                  var grdcod = self.find("td:eq(8)").text().trim();
                  var qnty = self.find("td:eq(3)").text().trim();
                  var rate = self.find("td:eq(4)").text().trim();
                  var arat = self.find("td:eq(5)").text().trim();
                  var unit = $("#DDUNIT").val();
                  var dvcd = $("#DDDVCD").val();
                  var dbcd = $("#DDSALMAN").val();
                  var ordn = $("#TXTORDN").val();
                  var pcode = $("#TXTPCOD").val();
                  var txcd = $("#TXTTXCD").val();
                  var brcd = $("#TXTAGCD").val();
                  var ordt = $("#ordt").val();
                  var pord = $("#TXTPORD").val();


                  $.ajax({
                      url: 'NEWSALORDER.aspx/Insert',
                      type: 'POST',
                      dataType: 'json',
                      contentType: 'application/json; charset=utf-8',
                      data: "{'QNTY':" + qnty + ",'RATE':" + rate + ",'ARAT':" + arat + ",'OSRC':'" + osrc + "','ICOD':'" + ittm + "','TRCD':" + grdcod + ",'UNIT':'" + unit + "','DVCD':'" + dvcd + "','DBCD':'" + dbcd + "','ORDN':'" + ordn + "','PCOD':'" + pcode + "','TXCD':'" + txcd + "','BRCD':'" + brcd + "','PORD':'" + pord + "','COMP':'0001','ORDT':'" + ordt + "'}",
                      success: function () {
                      
                      },
                      error: function (req, status, error) {
                          alert("Your Edit Request Not Processed");
                          console.log(data);
                      }

                  });

              });
                 $("#mytable tr").remove();
                $('label[id*=salordermessage]').html('');
                $('#salordermessage').addClass("text-center font-weight-bold text-green");
                $('#salordermessage').append("Order Edited Succesfully !").fadeOut(10000);

            //  $("[id*='Save']").Show();
              $("[id*='Save']").eq(0).show();
              $("[id*='Update']").hide();
          });



          
          $("[id*='Save']").on("click", function () {
              UpdateOrder();
              DeleteOrder();
             // alert("check delete");
              var n = $("#mytable").find("tr").length;
              $("[id*='mytable'] tr").each(function () {

                  var self = $(this);
                  var osrc = self.find("td:eq(0)").text().trim();
//                  alert(osrc);
                  var ittm = self.find("td:eq(7)").text().trim();
                  var grdcod = self.find("td:eq(8)").text().trim();
                  var qnty = self.find("td:eq(3)").text().trim();
                  var rate = self.find("td:eq(4)").text().trim();
                  var arat = self.find("td:eq(5)").text().trim();
                  var unit = $("#DDUNIT").val();
                  var dvcd = $("#DDDVCD").val();
                  var dbcd = $("#DDSALMAN").val();
                  var ordn = $("#TXTORDN").val();
                  var pcode = $("#TXTPCOD").val();
                  var txcd = $("#TXTTXCD").val();
                  var brcd = $("#TXTAGCD").val();
                  var ordt = $("#ordt").val();
                  var pord = $("#TXTPORD").val();


                     $.ajax({
                      url: 'NEWSALORDER.aspx/Insert',
                      type: 'POST',
                      dataType: 'json',
                      contentType: 'application/json; charset=utf-8',
                      data: "{'QNTY':" + qnty + ",'RATE':" + rate + ",'ARAT':" + arat + ",'OSRC':'" + osrc + "','ICOD':'" + ittm + "','TRCD':" + grdcod + ",'UNIT':'" + unit + "','DVCD':'" + dvcd + "','DBCD':'" + dbcd + "','ORDN':'" + ordn + "','PCOD':'" + pcode + "','TXCD':'" + txcd + "','BRCD':'" + brcd + "','PORD':'" + pord + "','COMP':'0001','ORDT':'" + ordt + "'}",
                         success: function () {
                            $('label[id*=salordermessage]').html('');
                            $('#salordermessage').addClass("text-center font-weight-bold text-green");
                            $('#salordermessage').append("Order Saved Succesfully !").fadeOut(10000);   
                                                                 
                      },
                      error: function (req, status, error) {
                          alert("Your Insert Request Not Processed");
                          console.log(data);
                         }
                     
                     });
             
               });
                 
                  
                 
              $("#mytable tr").remove(); 
           
                //   GenerateOrder();
              //location.reload();
              });

        
        //  location.reload();

          function DeleteOrder() {

              var self = $(this);
              var unit = $("#DDUNIT").val();
              var dvcd = $("#DDDVCD").val();
              var dbcd = $("#DDSALMAN").val();
              var ordn = $("#TXTORDN").val();
              
              $.ajax({
                  url: 'NEWSALORDER.aspx/DeleteOrder',
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json; charset=utf-8',
                  data: "{'UNIT':'" + unit + "','DBCD':'" + dbcd + "','ORDN':'" + ordn + "'}",
                  success: function () {
                  
                  },
                  error: function (req, status, error) {
                      alert("Delete Order Request Not Processed");
                      console.log(data);
                  }
              });
        

          }

          function UpdateOrder() {

              var self = $(this);
             
              var dbcd = $("#DDSALMAN").val();
              var ordn = $("#TXTORDN").val();

              $.ajax({
                  url: 'NEWSALORDER.aspx/UpdateOrder',
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json; charset=utf-8',
                  data: "{'DBCD':'" + dbcd + "','ORDN':'" + ordn + "'}",
                  success: function () {

                  },
                  error: function (req, status, error) {
                      alert("Update Order Request Not Processed");
                      console.log(data);
                  }
              });


          }


          function GenerateOrder() {
              var dbcd = $("#DDSALMAN").val();
              $.ajax({
                  url: 'NEWSALORDER.aspx/genordnew',
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json; charset=utf-8',
                  data: "{'DBCD':'" + dbcd + "'}",
                  success: function () {
                      $('#TXTORDN').val(trim(data[0]['ORDN']));
                  },
                  error: function (req, status, error) {
                      alert("Update Order Request Not Processed");
                      console.log(data);
                  }
              });


          }


          function loadorder() {

              $.ajax({
                  url: 'SALORD.asmx/GetOrderData',
                  method: 'post',
                  dataType: 'json',
                  success: function (data) {
                      var abc = $('[id*=datatable]').DataTable({
                          autoWidth: false,
                          paging: true,
                          sort: true,
                          searching: true,
                          scrollY: 200,
                          data: data,

                          columns: [
                              {
                                  'data': 'ORDT',
                                  'render': function (jsonDate) {
                                      var date = new Date(parseInt(jsonDate.substr(6)));
                                      var month = date.getMonth() + 1;
                                      return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                                   
                                  }
                              },
                              { 'data': 'ORDN' },
                              { 'data': 'PARTY' },
                              { 'data': 'QNTY' },
                              { 'data': 'AGENT' },
                              { 'data': 'UNIT' },
                              { 'data': 'DCOD', "visible": false },
                              { 'data': 'DBCD', "visible": false },
                              { 'data': 'BRCD', "visible": false },
                              { 'data': 'TXCD', "visible": false },
                              { 'data': 'DCODE', "visible": false },
                              { 'data': 'ADDR', "visible": false },
                              { 'data': 'PORD', "visible": false },
                              { 'data': 'PCOD', "visible": false },
                              {
                                  "data": null,
                                  //   'defaultContent': '<button type="button" class="btn btn-primary btn-edit">Edit</button>'
                                  "bSortable": false,
                                  "mRender": function (data, type, full) {

                                      return '<button type="button" id ="edit" class="btn btn-primary btn-edit">Edit</button>'
                                  }
                              }
                          ]

                       });
                   }
              });
          }
     
      </script>
     
     <script type="text/javascript">
     
         $(document).ready(function () {
             $("[id*='Update']").hide();
          
             $.ajax({
                 url: 'SALORD.asmx/GetOrderData',
                 method: 'post',
                 dataType: 'json',
                 success: function (data) {
                     var abc = $('[id*=datatable]').DataTable({
                         autoWidth: false, 
                         paging: true,
                         sort: true,
                         searching: true,
                         scrollY: 200,
                         data: data,

                         columns: [
                             {
                                 'data': 'ORDT',
                                 'render': function (jsonDate) {
                                     var date = new Date(parseInt(jsonDate.substr(6)));
                                     var month = date.getMonth() + 1;
                                     return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                                  }
                             },

                             { 'data': 'ORDN' },
                             { 'data': 'PARTY' },
                             { 'data': 'QNTY' },
                             { 'data': 'AGENT' },
                             { 'data': 'UNIT'},
                             { 'data': 'DCOD', "visible": false},
                             { 'data': 'DBCD', "visible": false},
                             { 'data': 'BRCD', "visible": false},
                             { 'data': 'TXCD', "visible": false},
                             { 'data': 'DCODE', "visible": false},
                             { 'data': 'ADDR', "visible": false},
                             { 'data': 'PORD', "visible": false},
                             { 'data': 'PCOD',"visible": false},
                             {
                                 "data": null,
                                 "bSortable": false,
                                 "mRender": function (data, type, full) {
                                  return '<button type="button" id ="edit" class="btn btn-primary btn-edit">Edit</button>'
                                 }
                             }
                         ]
                      });

                    
                     $('#datatable tbody').on('click', 'tr', function () {
                         var tableData = $(this).children("td").map(function () {
                             return $(this).text();
                         }).get();

                        var ordnn = $.trim(tableData[1])
                         var ordt = $.trim(tableData[0])
                         var ddsalmn = $.trim(tableData[5])
                         var dcod = $.trim(tableData[6])
                         
                         $('#TXTORDN').val(ordnn);
                         $('#ordt').val(ordt);
                         $('#DDSALMAN').val(ddsalmn).trigger('change');
                   //      alert("aa");
                         var ORDNUM = $('#TXTORDN').val();
                         var UNITNUM = $('#DDUNIT').val();
                       
                         $.ajax({
                             url: 'EditOrder.asmx/Getorddatt',
                             type: 'POST',
                             dataType: 'json',
                             //dataType: 'text',
                             // contentType: 'application/json; charset=utf-8',
                             data: {ORDNUM: ORDNUM , UNITNUM: UNITNUM },
                             success: function (data) {

                                 $('#TXTPCOD').val($.trim(data[0]['PCOD'])).trigger('change.select2');   
                                 $('#TXTBRCD').val($.trim(data[0]['BRCD'])).trigger('change.select2');   
                                 $('#TXTTXCD').val($.trim(data[0]['TXCD'])).trigger('change.select2');   
                                 $('#TXTDCODE').val($.trim(data[0]['DCODE'])).trigger('change.select2');   
                                 $('#TXTADDR').val($.trim(data[0]['ADDR'])).trigger('change.select2');   
                                 $('#DDDVCD').val($.trim(data[0]['DCOD'])).trigger('change.select2');   
                               
                                 $('#DDSALMAN').val($.trim(data[0]['DBCD'])).trigger('change.select2');   
                                 $('#TXTPORD').val($.trim(data[0]['PORD']));
                                
                                 $("#mytable tr").remove();
                                 var rowno =1
                                 for (i = 0; i < data.length; i++) {

                                       
                                     $('#mytable').append('<tr id="orderdata-' + data[i].ICOD + data[i].TRCD + '"> <td id="sr-' + data[i].ICOD
                                         + '">' + rowno + '</td> <td id="ITEM-' + data[i].ICOD + '" data-id=' + data[i].ICOD
                                         + '>' + data[i].ITEM +  '</td><td id="grade-' + data[i].ICOD + '" data-id=' + data[i].TRCD
                                         + '>' + data[i].GRADE + '</td><td id="quantity-' + data[i].ICOD
                                         + '">' + data[i].QNTY + '</td><td id="netrate-' + data[i].ICOD
                                         + '">' + data[i].RATE + '</td><td id="assrate-' + data[i].ICOD
                                         + '">' + data[i].ARAT + '</td> <td> <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a></td><td id="ICOD-' + data[i].ICOD
                                         + '">' + data[i].ICOD + '</td> <td id="ICOD-' + data[i].TRCD
                                         + '">' + data[i].TRCD + '</td></tr>');

                                     $('th:nth-child(8), tr td:nth-child(8)').hide();
                                     $('th:nth-child(9), tr td:nth-child(9)').hide();
                                     rowno ++;
                                 }
                               
                              //   $('.modifiable').html('<button type="button" class="btn btn btn-primary" id="USave" value ="Update" name ="Update">Update</button>\
                              //               <button type="button" class="btn btn btn-danger" id="cancel">Cancel</button>\
                              //               <p id="salordermessage"></p>');
                              
                             //    window.scrollTo(0, 0);  
                               
                                 $("[id*='Save']").hide();
                                 $("[id*='Update']").show();
                                 
                             },
                             error: function (response) {
                                 alert("Request Not Processed");
                                
                             }

                         });

                      });
                 }
             });
          
          });

     </script>

    <script>

        $("[id*='TXTPCOD']").on('change', function () {
            $.ajax({
                url: 'CONSADD.asmx/GetPartyInfo',
                method: 'post',
                dataType: 'json',
                data: { pcod: $(this).val() },

                success: function (data) {
                    $(data).each(function (index, item) {
                      
                        $("[id*='TXTAGCD']").val(item.BRCD).trigger('change.select2');
                        $("[id*='TXTTXCD']").val(item.TXCD).trigger('change.select2');
                    });
                },
                error: function (err) {
                    alert("Prcess Data Error");
                }
            });

        });

    </script>

    <script>
        $("[id*='DDDVCD']").on('change', function () {

            $("[id*='DDUNIT']").prop('disabled', true);
            var unit = $("#DDUNIT").val();
            var dvcd = $("#DDDVCD").val();

                $.ajax({
                    url: 'CONSADD.asmx/GetFinItem',
                    method: 'post',
                    dataType: 'json',
                    data: { dvcd: $(this).val() },
                   // data: "{'unit':'" + unit + "','dvcd':'" + dvcd + "'}",
                    success: function (data) {
                        $("[id*='TXTICOD']").empty();

                        $(data).each(function (index, item) {
                            $("[id*='TXTICOD']").append($('<option>',

                                {   value: item.CODE,
                                    text: item.NAME
                                }));
                        });
                    },
                    error: function (err) {
                        alert("Data Process Error");
                    }
                });
            
        });
    </script>

     <script>
        $("[id*='TXTCONCOD']").on('change', function () {
                    $.ajax({
                    url: 'CONSADD.asmx/GetConsaddr',
                    method: 'post',
                    dataType: 'json',
                    data: { CONCOD: $(this).val() },
                  
                    success: function (data) {
                       $("[id*='TXTCONADDR']").empty();
                   
                        $(data).each(function (index, item) {
                           $("[id*='TXTCONADDR']").append($('<option>',
                                {
                                    value: item.SRNO,
                                    text: item.ADDR
                                }));
                        });
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            
        });

</script>


          
   
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#datatable").delegate("tbody tr", "click", function (event) {
            });

            $('#datatable').on('click', '.btn-edit', function () {
            });
        }

    </script>

   <script>--%>

    <%--//    $('#datatable').on('click', 'tbody tr', function () {
    //       console.log("check data");   //full row of array data
    //       console.log("check data");   //full row of array data
    //   });--%>

<%--</script>--%>
</asp:Content>
