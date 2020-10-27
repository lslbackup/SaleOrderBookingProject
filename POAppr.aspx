<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="POAppr.aspx.cs" Inherits="SaleOrderBooking.POAppr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



 <div class="card border-success mb-3">
  <div class="card-header bg-transparent border-success">
    <h3 text-align: center:>Purchase Order Approval</h3>
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
					             	<h5 class="text-left" id="ssfl"> </h5>
					            </div>
					            <div class="card-body">                
		                     		<div class="row">
		                    			<div class="col-sm-5">
		                      				<div class="form-group">
          										<label>Select P.O. Type</label>
    											<select class="form-control select2"  id="DDPOTYPE" ClientIDMode="Static" runat ="server" name="POTYPE" style="width:100%;">
                                                   
    											</select>
    											<label class="text-danger" id="partynameerror"></label>
		           							</div>
		         						</div>
		         						<div class="col-sm-5">
		                      				<div class="form-group">
          										<label>Staus</label>
    											<select class="form-control select2"  id="DDSTATUS" ClientIDMode="Static" runat ="server" name="Status" style="width:100%;">
                                                      <option value="A">Approved</option>
                                                     <option value="C">Cancel</option>
                                                     <option value="R">Reset</option>
    											</select>
                                             
    											<label class="text-danger" id="agentnameerror"></label>
		           							</div>
		         						</div>
		         						<div class="col-sm-2 mt-4">
		         							<div class="form-group">
		         								<button type="button" id="search" class="btn btn-info">Search</button>
		         							</div>
		         						</div>		         						
		         						<div class="col-sm-12">
		                      				<div class="card  table-responsive p-0" style="height:500px;">	
                                                   <table id = "datatable" Class="small table table-striped table-hover" style="width:100%"> 
									            <!--table class="table table-head-fixed"-->
                  									<thead>
                    									<tr>
														  <th> <input type="checkbox" id="chkAll" /></th>
                      										<th>P.O. No.</th>
									                      	<th>P.O. Date</th>
									                      	<th>Department</th>
									                      	<th>Item Code</th>
									                      	<th>Item Name</th>
									                      	<th>Quantity</th>
									                      	<th>Rate</th>
									                        <th>Remark</th>
									                        <th>Party</th>
									                      	
									                     
									                    
                    									</tr>	
                  									</thead>
                  								
                								</table>
		                      				</div>
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
  

  

</script>

<script type="text/javascript">

    function loadorder() {
        var POTYPE = $("#DDPOTYPE").val();
        var STATUS = $("#DDSTATUS").val();
     
        $.ajax({
            url: 'SearchPO.asmx/POSearch',
            method: 'post',
          //  data: "{'SALMANDB':'" + dbcd + "','UNITNUM':'" + UNITNUM + "'}",
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
                    { 'data': 'PONO' },
                    {
                        'data': 'PODATE',
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();

                        }
                    },

                    { 'data': 'DEPARTMENT' },
                    { 'data': 'ICOD' },
                    { 'data': 'ITEM' },
                    { 'data': 'QTY', },
                    { 'data': 'RATE', },
                    { 'data': 'REMARKS', },
                    { 'data': 'PARTY', },
                    
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
               var dbcd = $("#DDPOTYPE").val();
               

        $.ajax({
            url: 'PO.asmx/UpdatePO',
            method: 'post',
            data: "{'DBCD':'" + dbcd + "','PONO':'" + ordnn + "'}",
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
     //   alert("start");
    var table = $('[id*=datatable]').DataTable({
        data: rows,
        destroy: true,
        columns: columns
    });
     //   alert("end");
     loadorder();

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


