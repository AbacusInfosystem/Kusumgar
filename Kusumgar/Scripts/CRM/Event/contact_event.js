
$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

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

    $('[name="chkStatus"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $('[name="chkIsBilling_Contact"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnBilling_Contact").val(true);
        }
        else {
            $("#hdnBilling_Contact").val(false);
        }
    });

});