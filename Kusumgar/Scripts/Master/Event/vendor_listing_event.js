$(document).ready(function () {

    InitializeAutoComplete($('#txtVendorName'));

    InitializeAutoComplete($('#txtMaterialName'));

    GetAllVendors();

    $("#btnSearch").click(function () {
        SearchVendors();
    });

    $('#btnEdit').click(function () {

        $("#frmVendorSearch").attr("action", "/Vendor/Get_Vendor_By_Id");

        $("#frmVendorSearch").attr("method", "post");

        $("#frmVendorSearch").submit();
    });

    $('#btnView_Material').click(function () {

        $("#frmVendorSearch").attr("action", "/master/material/search");

        $("#frmVendorSearch").attr("method", "post");

        $("#frmVendorSearch").submit();
    });


    $("#divSearchGridOverlay").hide();

});
