<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndApr.aspx.cs" Inherits="SaleOrderBooking.IndApr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="card border-success mb-3">
  <div class="card-header bg-transparent border-success">
    <h3 text-align: center:></h3>
  </div>

     
  <div class="card-body">
  <div class="box box-default">
  <div class="box-header with-border">

      

     <div class="form-row">

          <div class="form-group col-md-6">
               <label for="txtcode" class="col-sm-6 control-label">
                  Department
                                </label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlDept" runat="server" class ="form-control"  Width="100%" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>      
             
          </div>

    <div style="height: 97px">



        <br />
        <asp:GridView ID="GridList"  runat ="server"  AutoGenerateColumns="false" ViewStateMode="Enabled" OnSelectedIndexChanged="GridList_SelectedIndexChanged">
            <Columns>
                
                <asp:BoundField DataField="INDNO" HeaderText="Indent No." ReadOnly="True" SortExpression="INDNO" />
                <asp:BoundField DataField="INDDT" HeaderText="Indent Date" ReadOnly="True" SortExpression="INDDT" />
                <asp:BoundField DataField="REQDT" HeaderText="Required Date" ReadOnly="True" SortExpression="REQDT" />
                <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" ReadOnly="True" SortExpression="DEPARTMENT" />
                <asp:BoundField DataField="ITEMNAME" HeaderText="Item Name" ReadOnly="True" SortExpression="ITEMNAME" />
                <asp:BoundField DataField="QTY" HeaderText="Quantity" ReadOnly="True" SortExpression="QTY" />
                <asp:BoundField DataField="APPROVEDQTY" HeaderText="Approved Qty." SortExpression="APPROVEDQTY" />
            </Columns>
        </asp:GridView>



</div>
</div>
</div>

</div>
    

</asp:Content>
