<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SOA.aspx.cs" Inherits="SaleOrderBooking.SOA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




 <div class="card border-success mb-3">
  <div class="card-header bg-transparent border-success">
    <h3 text-align: center:>Sale Order Approval</h3>
  </div>

     
  <div class="card-body">
  <div class="box box-default">
  <div class="box-header with-border">
  
           <section class="content">
		    	<div class="container-fluid">
		    		<div class="row">
		    			<div class="col-md-12">
		    				<div class="card card-success">
					            <div class="card-header">
					             	<h6 class="text-center">Select Salesman From List</h6>
					            </div>
					            <div class="card-body">                
		                     		<div class="row text">
		                    			<div class="col-sm-12">
		                      				<div class="form-group">
		                      					<div class="form-group" align="center">      
		                         					<div class="col-sm-8">
		                                				<div class="form-group">
		                  									<select class="form-control select2" id="DDSALMAN" name="DDSALMAN" ClientIDMode="Static" runat ="server" style="width:100%;"></select>
		                								</div>
		               								</div>
		             							</div>
		           							</div>
		         						</div>
		         					</div>
		         				</div>		
					        </div>    
		    			</div>
		    		</div>
		    	</div>
		    </section> 	
		    <section class="content">

		    			<div class="col-md-12">
		    				<div class="card card-success">

					            <div class="card-body">                
		                     		<div class="row">
		                    		<%--	<div class="col-sm-5">
		                      				<div class="form-group">
          										<label>Name of Party</label>
    											<select class="form-control select2"  id="TXTPCOD" ClientIDMode="Static" runat ="server" name="partyname" style="width:100%;"></select>
    											<label class="text-danger" id="partynameerror"></label>
		           							</div>
		         						</div>
		         						<div class="col-sm-5">
		                      				<div class="form-group">
          										<label>Agent Name</label>
    											<select class="form-control select2"  id="TXTAGCD" ClientIDMode="Static" runat ="server" name="agentname" style="width:100%;"></select>
    											<label class="text-danger" id="agentnameerror"></label>
		           							</div>
		         						</div>
		         						<div class="col-sm-2 mt-4">
		         							<div class="form-group">
		         								<button type="button" id="search" class="btn btn-info">Search</button>
		         							</div>
		         						</div>		         						
		         					--%>	<div class="col-sm-12">
		                      			
                                                   <table id = "datatable" Class="small table table-striped table-hover" style="width:100%"> 
									            <!--table class="table table-head-fixed"-->
                  									<thead>
                    									<tr>
														  <th> <input type="checkbox" id="chkAll" /></th>
                      										<th>Order No.</th>
									                      	<th>Date</th>
									                      	<th>Party Name</th>
									                      	<th>Agent Name</th>
									                      	<th>Item Name</th>
									                      	<th>Quantity</th>
									                      	<th>Rate</th>
									                        <th>Grade</th>
									                        <th>Tax</th>
									                      	<th>Party Order</th>
									                     
									                    
                    									</tr>	
                  									</thead>
                  								
                								</table>
		                      				
						  
                <!--ul class="pagination pagination-sm m-0 float-right">                  
                </!--ul-->
            

		         						</div>

				


		         						<div class="col-sm-6">
		         							<div id="message"></div>
							              	<div class="float-right" id="submitquery">
							                	<button type="button" id="update" class="btn btn-primary">Update</button>
							                	<button type="button" id="cancel" class="btn btn-danger">Cancel</button>
							              	</div>
		         						</div>
		         					</div>
		         				</div>		
					        </div>    
		    			
		    	</div>
		    </section>
	    </div>
    </div>
 <script type ="text/javascript">

     function ToJavaScriptDate(value) {
         var pattern = /Date\(([^)]+)\)/;
         var results = pattern.exec(value);
         var dt = new Date(parseFloat(results[1]));
         return (dt.getDate() + "/" + dt.getMonth() )  +"/" + dt.getFullYear();
	 }
  

     $("[id*='search123']").on("click", function () {
		 alert("SEARCH");
              var UNITNUM = $('#DDUNIT').val();
		      var SALMANDB = $('#DDSALMAN').val();
		              $.ajax({
                            url: 'SearchOrder.asmx/OrderSearch',
                            type: 'POST',
                            dataType: 'json',
                            data: {UNITNUM: UNITNUM , SALMANDB: SALMANDB},
                            beforeSend: function () {
                              $('#mytable').html('');
                              $('#mytable').append('<tr><td colspan="2" class="text-center font-weight-bold">Loading Data Please wait...</td></tr>');
                             },
                             success: function (data) {
								 alert("success proceed");
                                 
                                for (i = 0; i < data.length; i++) {
                                    $('#mytable').append('<tr id="orderno-' + data[i].ORDN + data[i].TRCD + '"> <td <input type="checkbox" name ="chk1"/></td> <td id="ORDN-' + data[i].ORDN + '" data-id=' + data[i].ICOD
                                         + '>' + data[i].ORDN +  '</td><td id="order-' + data[i].ORDN + '" data-id=' + data[i].TRCD
                                         + '>' + ToJavaScriptDate(data[i].ORDT) + '</td><td id="orderdate-' + data[i].ORDT
                                         + '">' + data[i].PARTY + '</td><td id="partycode-' + data[i].PCOD
                                         + '">' + data[i].AGENT + '</td><td id="agent-' + data[i].ICOD
                                         + '">' + data[i].ITEM + '</td><td id="item-' + data[i].ICOD
										 + '">' + data[i].QNTY + '</td> <td id="quantity-' + data[i].QNTY
										 + '">' + data[i].RATE + '</td> <td id="rate-' + data[i].TRCD
										 + '">' + data[i].GRADE + '</td> <td id="grade-' + data[i].TRCD
										 + '">' + data[i].TXCD + '</td> <td id="tax-' + data[i].TXCD
									 + '">' + data[i].PORD + '</td></tr>');

                                       $('th:nth-child(9), tr td:nth-child(9)').hide();
                                   
                                    
								 }

                              
                                 
                            },
                             error: function (response) {
                                 alert("Search Request Not Processed");
                                
                             }

					  });
	 });

</script>

<script>
	     function loadorder11() {
             alert("check");
              $.ajax({
                  url: 'SearchOrder.asmx/OrderSearch',
                  method: 'post',
                  dataType: 'json',
                  success: function (data) {
                      var abc = $('[id*=datatable]').DataTable({
                         
                        
                           data: data,
                          'targets': 0,
                          'searchable': false,
                          'orderable': false,
                          'className': 'dt-body-center',

                          columns: [{
                              'render': function (data, type, full, meta) {
                                  return '<input type="checkbox" name="checkbox" value="'
                                      + $('<div/>').text(data).html() + '">';
                              }
                          },
                              { 'data': 'ORDN' },
                              {   
                                  'data': 'ORDT',
                                  'render': function (jsonDate) {
                                      var date = new Date(parseInt(jsonDate.substr(6)));
                                      var month = date.getMonth() + 1;
                                      return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                                   
                                  }
                              },
                             
                              { 'data': 'PARTY' },
                              { 'data': 'AGENT' },
                              { 'data': 'ITEM' },
                              { 'data': 'QNTY',  },
                              { 'data': 'RATE',  },
                              { 'data': 'GRADE',  },
                              { 'data': 'TXCD',  },
                              { 'data': 'PORD',  },
                             

                             
                          ],
                          'order': [1, 'asc']
                        
                       });
                   }
              });
    }


    function loadorder() {
        var SALMANDB = $("#DDSALMAN").val();
        var PCOD = $("#TXTPCOD").val();
        var AGCD = $("#TXTAGCD").val();
        $.ajax({
            url: 'SearchOrder.asmx/OrderSearch',
            method: 'post',
          //  data: "{'SALMANDB':'" + dbcd + "','PCOD':'" + PCOD + "','AGCD':'" + AGCD + "'}",
            dataType: 'json',
            success: function (data) {
                var abc = $('[id*=datatable]').DataTable({


                    data: data,
                    'targets': 0,
                    'searchable': true,
                    'orderable': true,
                    'className': 'dt-body-center',

                    columns: [{
                        'render': function (data, type, full, meta) {
                            return '<input type="checkbox" name="checkbox" value="'
                                + $('<div/>').text(data).html() + '">';
                        }
                    },
                    { 'data': 'ORDN' },
                    {
                        'data': 'ORDT',
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();

                        }
                    },

                    { 'data': 'PARTY' },
                    { 'data': 'AGENT' },
                    { 'data': 'ITEM' },
                    { 'data': 'QNTY', },
                    { 'data': 'RATE', },
                    { 'data': 'GRADE', },
                    { 'data': 'TXCD', },
                    { 'data': 'PORD', },
                    ],
                    'order': [1, 'asc']
                });
            }
        });
    }


    function loadorderList() {
        var SALMANDB = $("#DDSALMAN").val();
        var PCOD = $("#TXTPCOD").val();
        var AGCD = $("#TXTAGCD").val();
        $.ajax({
            url: 'SearchOrder.asmx/OrderSearch',
            method: 'post',
            data: "{'SALMANDB':'" + SALMANDB + "','PCOD':'" + PCOD + "','AGCD':'" + AGCD + "'}",
            dataType: 'json',
            success: function (data) {

             

               var abc = $('[id*=datatable]').DataTable({


                    data: data,
                    'targets': 0,
                    'searchable': true,
                    'orderable': true,
                    'className': 'dt-body-center',

                    columns: [{
                        'render': function (data, type, full, meta) {
                            return '<input type="checkbox" name="checkbox" value="'
                                + $('<div/>').text(data).html() + '">';
                        }
                    },
                    { 'data': 'ORDN' },
                    {
                        'data': 'ORDT',
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();

                        }
                    },

                    { 'data': 'PARTY' },
                    { 'data': 'AGENT' },
                    { 'data': 'ITEM' },
                    { 'data': 'QNTY', },
                    { 'data': 'RATE', },
                    { 'data': 'GRADE', },
                    { 'data': 'TXCD', },
                    { 'data': 'PORD', },
                    ],
                    'order': [1, 'asc']
                });
            }
        });
    }

    

    $(function () {
        $('[id*=chkAll]').click(function () {
            $("input[name='checkbox']").attr("checked", this.checked);
        });
       
    });

    $("[id*='update']").on("click", function () {

       var n = $("#datatable").find("tr").length;
       $("#datatable").find("tr").each(function () {
     
            var rowSelector = $(this);
                 if (rowSelector.find("input[type='checkbox']").prop('checked')) {

          var tableData = $(this).children("td").map(function () {
                    return $(this).text();
                }).get();

               var ordnn = $.trim(tableData[1]);
               var dbcd = $("#DDSALMAN").val();
               

        $.ajax({
            url: 'TEST.asmx/UpdateOrder',
            method: 'post',
            data: "{'DBCD':'" + dbcd + "','ORDN':'" + ordnn + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (response) {
                      
                        if (response != 0) {
                            alert("Data Update Successfully!!!!");
                            location.reload();
                        }
                    },
                    error: function (response) {
                        if (response != 1) {
                            alert("Error!!!!");
                        }
                    },
                });
            }

            });
    
    });
    
    $("[id*='search']").on("click", function () {
       // $("[id*=datatable]").DataTable().fnDestroy();



        //var table = $("[id*=datatable]").DataTable({
            
        //    destroy: true,
           
        //});
    //   loadorderList();

    });

    $(function () {
        $("[id*=update22]").click(function () {
            var obj = {};
            var color = $("#DDSALMAN").val();
            var jcolor = { "color": color };
            alert(jcolor.color);

            $.ajax({
               // type: "POST",
               // url: "SOA.aspx/SendParameters",
             //   data: JSON.stringify(jcolor),
                type: "POST",
                url: "TEST.asmx/HelloWorld",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert("oookkk");
                },  
                failure: function (response) {
                    alert(response.d);
                }  
              
            });
            return false;
        });
    });


  
   



</script>

 <script type="text/javascript">
     $(document).ready(function () {

         loadorder();

    });
</script>
	

</asp:Content>
