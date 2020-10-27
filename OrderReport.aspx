<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderReport.aspx.cs" Inherits="SaleOrderBooking.OrderReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content-header">
        <h1>
            Pending Sales Report <small>(Pending Order)</small>
        </h1>
      
    </section>
    


        <script type="text/javascript">

            $(document).ready(function () {
             
                $(function () {
                 
                    $('#<%=OrderGrid.ClientID%>').prepend($("<thead></thead>").append($("#<%= OrderGrid.ClientID%>").find("tr:first"))).DataTable({
                     
                    stateSave: true,

                        dom: 'lBfrtip',
                        
                        buttons: [
                            'copy',  'excel', 'pdf', 'print','colvis'
                        ]
                       
                    });  
                  });  

       
            });
    </script>
        <style type="text/css">
            .ddl
            {
                height: 30px;
                margin-top: 5px;
            }
        </style>
        <div class="row">
            <div class="col-lg-12">
                <div class="box">
                    <div class="box-body">
                        <div id="mydiv" runat="server">
                        </div>
                        <div class="form-horizontal">
                           		 <div class="row">

                               <label for="inputEmail4">Sales Man </label>
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="DDSALMAN" name ="Salesman" runat="server" class ="form-control" CssClass="ddl" Width="220px" ></asp:DropDownList>
                               </div>

                            <div class="form-group">
                                <div class="col-lg-12" style="margin-top: 25px; top: 0px; left: 0px; height: 259px;">
                                  
                                    <asp:GridView ID="OrderGrid" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"  CssClass="small table table-striped table-hover"
                                        HorizontalAlign="Center"   >
                                        <Columns>

                                            <asp:BoundField DataField="ORDN" HeaderText="Order No." />
                                            <asp:BoundField DataField="ORDT" HeaderText="Order Date" DataFormatString="{0:dd/MM/yy}" />
                                            <asp:BoundField DataField="PARTY" HeaderText="Party Name" />
                                            <asp:BoundField DataField="ITEM" HeaderText="Item Name" />
                                            <asp:BoundField DataField="GRADE" HeaderText="Grade Name" />
                                            <asp:BoundField DataField="QNTY" HeaderText="Quantity" />
                                            <asp:BoundField DataField="DISPATCHQTY" HeaderText="Dispatchqty Qty." />
                                            <asp:BoundField DataField="CANCELQTY" HeaderText="Cancel Qty." />
                                            <asp:BoundField DataField="BALQTY" HeaderText="Bal. Qty." />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     
</asp:Content>











