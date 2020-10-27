<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accledger.aspx.cs" Inherits="SaleOrderBooking.Accledger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <script type="text/javascript">

            $(document).ready(function () {
             
             $(function () {
                 
                    $('#<%=AcGrid.ClientID%>').prepend($("<thead></thead>").append($("#<%= AcGrid.ClientID%>").find("tr:first"))).DataTable({
                     stateSave: true,
                      
                        dom: 'lBfrtip',
                        buttons: [
                            'copy',  'excel', 'pdf', 'print'
                        ]
                    });  
                  }); 

       
            });
    </script>
        <%--<style type="text/css">
            .ddl
            {
                height: 30px;
                margin-top: 5px;
            }
        </style>--%>
      
                        <div class="container">
                           		 <div class="row">

                                  <label for="inputEmail4">From Date </label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="DTFROM" name="DTFROM"  runat="server" class ="form-control" AutoCompleteType="Disabled"  ></asp:TextBox>
                                    
                                </div>

                                <script type="text/javascript">
                                    $(function () {
                                        $("[id*=DTFROM]").datepicker({
                                            dateFormat: 'dd/mm/yy',
                                            autoclose: true, // It is false, by default

                                            required: true,
                                            message: "This is a required field",
                                        });
                                    });
                                </script>

                                <label for="inputEmail4">To Date </label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="DTTO" name="DTTO"  runat="server" class ="form-control" AutoCompleteType="Disabled"  ></asp:TextBox>

                               </div>

                                  <script type="text/javascript">


                                      $(function () {
                                          $("[id*=DTTO]").datepicker({
                                              dateFormat: 'dd/mm/yy',
                                              autoclose: true, // It is false, by default

                                              required: true,
                                              message: "This is a required field",
                                          })
                                      });
                                  </script>


                               <label for="inputEmail4">Account </label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="DDPCOD" name ="DDPCOD" runat="server" class ="form-control"    AutoPostBack="True"     ></asp:DropDownList>
                               </div>
                                 
                                
                                <label for="inputEmail4">Opening Bal.</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="TXTOPN" name="TXTOPN"  runat="server" class ="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                        <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Search" OnClick="Button1_Click" />

                                </div>
                            </div>


                          
                                <div class="form-group">
                                <div class="col-lg-12" style="margin-top: 25px; top: 0px; left: 0px; height: 259px;" >
                                  
                                    
                                  
                                    <asp:GridView ID="AcGrid" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"  CssClass="small table table-striped table-hover"
                                        HorizontalAlign="Center" OnRowDataBound="AcGrid_RowDataBound"  ShowFooter="True"   >
                                        <Columns>
                                         

                                            <asp:BoundField DataField="VTYP" HeaderText="Vou.Type" />
                                            <asp:BoundField DataField="DATE" HeaderText="Vou. Date" DataFormatString="{0:dd/MM/yy}" />
                                            <asp:BoundField DataField="VBNO" HeaderText="Vou. No." />
                                            <asp:BoundField DataField="NAME" HeaderText="Account Name" />
                                             <asp:BoundField DataField="DAMT" HeaderText="Debit" />
                                            <asp:BoundField DataField="CAMT" HeaderText="Credit" />
                                            <asp:BoundField DataField="BALAMT" HeaderText="Bal. Amt." DataFormatString="{0:N2}" />
                                            <asp:BoundField DataField="NARR" HeaderText="Narration" />
                                            
                                        </Columns>
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                     </div>


             <script type="text/javascript">

                 $("#Button1").click(function (e) {

                     if ($('#ordt').val() == "") {
                         alert("Please Select From Date");
                     }

                     if ($('#ordt').val() == "") {
                         alert("Please Select From Date");
                         
                     }


                     });
             
             </script>
     
</asp:Content>






