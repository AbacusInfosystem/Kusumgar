$(function () {

    InitializeAutoComplete($('#txtVendor_Name'));

    if ($("#hdnContact_Id").val() == 0) {

        $("#tabCustom_Fields").hide();
        $("#hdnIs_Active").val(true);
       
    }

$("#btnSave_Vendor_Contact").click(function () {

    if ($("#frmVendor_Contact").valid()) {

        Save_Vendor_Contact();
    }
});

$("#btnSave_Custom_Field").click(function () {

    if ($("#frmCustom_Fields").valid()) {

        Save_Custom_Fields();
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

});