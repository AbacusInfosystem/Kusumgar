$(function () {
   
    InitializeAutoComplete($('#txtVendor_Name'));

    $('#hdfCurrent_Page').val(0);

    Search_Vendor_Contact();

    $("#btnSearch").click(function () {
        $('#hdfCurrent_Page').val(0);
        Search_Vendor_Contact();
    });

  
  $("#btnEdit").click(function () {

      $("#frmSearch_Contact").attr("action", "/master/get-vendor-contact-by-id");

      $("#frmSearch_Contact").attr("method", "POST");

      $("#frmSearch_Contact").submit();
  });

  $("#btnView").click(function () {

      $("#frmSearch_Contact").attr("action", "/master/view-vendor-contact");

      $("#frmSearch_Contact").attr("method", "POST");

      $("#frmSearch_Contact").submit();
  });

    
});