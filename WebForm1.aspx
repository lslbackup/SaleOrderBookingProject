<%@ Page Title="" Language="C#" MasterPageFile="~/MAIN.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SaleOrderBooking.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdditionalTopJSCSS" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <input class="form-control" type="text" id="ordt"  runat ="server">
     <script type="text/javascript">
     // $(document).ready(function () {
        //  $("input[id$=ordt]").datepicker({
        //      numberOfMonths: 3,
        //      showButtonPanel: true
        //  });

          $(document).ready(function () {
              $("#ordt").datepicker();
          });
     
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderAditionalBottomJSCSS" runat="server">
</asp:Content>
