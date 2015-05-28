$(document).ready(function () {

    InitializeAutoComplete($('#txtVendorName'));

    GetAllVendors();

    $("#btnSearch").click(function () {
        SearchVendors();
    });

    $('#btnEdit').click(function () {

        $("#frmVendorSearch").attr("action", "/Vendor/Get_Vendor_By_Id");

        $("#frmVendorSearch").attr("method", "post");

        $("#frmVendorSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

});
