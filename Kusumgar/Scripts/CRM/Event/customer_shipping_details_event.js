
$(function () {

    $("#hdn_Customer_shipping_Address_Id").val(0);

    $("#btnSaveShippingAddressDetails").click(function () {

        if ($("#frmShipping").valid()) {
            Save_Customer_shipping_details();
        }

    });

    $('.btn-Shipping').click(function () {
        $("#hdn_Customer_shipping_Address_Id").val($(this).parent().parent().find(".hdn_Customer_shipping_Address_Id").val());

        $("#txtShippingOfficeAddress").val($(this).parent().parent().find(".shipping_Address").val());
        $("#txtShippingOfficeLandline1").val($(this).parent().parent().find(".shipping_Landline1").val());
        $("#txtShippingOfficeLandline2").val($(this).parent().parent().find(".shipping_Landline2").val());
        $("#txtShippingOfficeFaxNo").val($(this).parent().parent().find(".shipping_FaxNo").val());

    });

   
});