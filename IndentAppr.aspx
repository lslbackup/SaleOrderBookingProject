<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndentAppr.aspx.cs" Inherits="SaleOrderBooking.IndentAppr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section class="content-header">
        <h1>
            Indent Approval <small>(Indents)</small>
        </h1>
      
    </section>
    <section class="content">
        <script type="text/javascript">
         
            function openModal() {
                
                $('[id*=myModal]').modal('show');
            }
        </script>

        </section>


        <script type="text/javascript">

            $(document).ready(function () {
             
                $(function () {
                 
                    $('#<%=GVIndentList.ClientID%>').prepend($("<thead></thead>").append($("#<%= GVIndentList.ClientID%>").find("tr:first"))).DataTable({
                       stateSave: true,
                    });  
             //  $('#<%=GVIndentList.ClientID%>').DataTable({ "paging": false, "ordering": false, "searching": false });


            });  

          //      $("#<%= ddlDept.ClientID%>").select2({});
           //     $("#<%= ddlViewStatus.ClientID%>").select2({});
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
                            <div class="form-group">
                                <label for="txtcode" class="col-sm-2 control-label">
                                    Department
                                </label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlDept" runat="server" class ="form-control" CssClass="ddl" Width="220px" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                        
                                    </asp:DropDownList>
                                </div>
                                <label for="txtcode" class="col-sm-2 control-label">
                                    Select Status.
                                </label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlViewStatus" runat="server" Width="227px" CssClass="ddl" OnSelectedIndexChanged="ddlViewStatus_SelectedIndexChanged">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>New</asp:ListItem>
                                        <asp:ListItem>Approved</asp:ListItem>
                                        <asp:ListItem>Cancled</asp:ListItem>
                                    </asp:DropDownList>
                              
                                    <br />
                
                              
                            </div>
                             
                       



                            <div class="form-group">
                                <div class="col-lg-12" style="margin-top: 25px; top: 0px; left: 0px; height: 259px;">
                                  
                                    <asp:GridView ID="GVIndentList" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"  CssClass="small table table-striped table-hover"
                                        HorizontalAlign="Center"  OnSelectedIndexChanged="GVIndentList_SelectedIndexChanged1" GridLines="None" OnRowDataBound="GVIndentList_RowDataBound" >
                                        <Columns>
                                            <asp:ButtonField CommandName="detail"  ControlStyle-CssClass="text-green fa fa-thumbs-up"
                                                HeaderText="" ButtonType="Link" />
                                            <asp:ButtonField CommandName="cancel" ControlStyle-CssClass="text-red fa fa-thumbs-down"
                                                HeaderText="" />

                                            <asp:BoundField DataField="INDNO" HeaderText="Indent No." />
                                            <asp:BoundField DataField="INDDT" HeaderText="Indent Date" DataFormatString="{0:dd/MM/yy}" />
                                            <asp:BoundField DataField="REQDT" HeaderText="Required Date" DataFormatString="{0:dd/MM/yy}" />
                                            <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" />
                                            <asp:BoundField DataField="ITEMNAME" HeaderText="Item Name" />
                                            <asp:BoundField DataField="QTY" HeaderText="Quantity" />
                                            <asp:BoundField DataField="APPROVEDQTY" HeaderText="Approved Qty." />
                                            <asp:BoundField DataField="FIELD1" HeaderText="Cost Center" />
                                            <asp:BoundField DataField="FIELD2" HeaderText="Remark" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

           
        <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblheading" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtcode" class="col-sm-3 control-label">
                                    Indent Quantity
                                </label>
                                <div class ="form-row">
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtapproved" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="col-sm-4">
                                    <asp:TextBox ID="TXTINDNO" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                 <div class="col-sm-4">
                                    <asp:TextBox ID="TXTICOD" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                </div>

                                <div class="col-sm-12">
                                <label for="txtcode" class="text-center control-label" id="lblconfirm" runat="server">
                                </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                   <div class="modal-footer">
                        <asp:Button ID="btnOk" Width="90px" runat="server" Text="Approve" class="btn btn-sm btn-warning"  ViewStateMode="Enabled" OnClick="btnOk_Click"
                            />
                        <asp:Button ID="btnClose" Width="90px" runat="server" class="btn btn-sm btn-danger"
                            Text="Close" />

                    </div>

                </div>
            </div>
        </div>

    

    
</asp:Content>





