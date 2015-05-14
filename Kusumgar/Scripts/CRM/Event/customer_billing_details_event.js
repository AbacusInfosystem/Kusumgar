
$(function () {

    $("#hdn_Customer_Address_Id").val(0);

    $("#btnSaveBillingAddressDetails").click(function () {
        if ($("#frm_Billing").valid()) {
            Save_Customer_billing_details();
        }
    });

    $('.btn-billing').click(function () {
        $("#hdn_Customer_Address_Id").val($(this).parent().parent().find(".hdn_Customer_Address_Id").val());
        $("#txtBillingOfficeAddress").val($(this).parent().parent().find(".billing_Address").val());
        $("#txtBillingOfficeLandline1").val($(this).parent().parent().find(".billing_Landline1").val());
        $("#txtBillingOfficeLandline2").val($(this).parent().parent().find(".billing_Landline2").val());
        $("#txtBillingOfficeFaxNo").val($(this).parent().parent().find(".billing_FaxNo").val());
    });
});