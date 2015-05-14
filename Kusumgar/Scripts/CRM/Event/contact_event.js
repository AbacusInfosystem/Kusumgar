
$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'), autoCustomerCallback);

    if ($("#hdnContact_Id").val() == 0) {
        $("#tabcustom_fields").hide();
        $("#hdnIs_Active").val(true);
        $("#hdnBilling_Contact").val(true);
    }

    $("#btnCustomer_Contact").click(function () {

        if ($("#frmContact").valid()) {

            Save_Contact();
        }
    });
});