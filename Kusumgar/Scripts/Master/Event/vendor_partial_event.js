$(document).ready(function () {

 if ($("#hdnVendorId").val() == 0) {
        $("#tabProductServices").hide();
        $("#tabCertificates").hide();
        $("#tabCentralExciseRegistrationDetails").hide();
        $("#tabOtherDetails").hide();
    }

    $("#btnSave").click(function () {
    if ($("#frmVendor").valid()) {
        Save_Vendors_Details();
    }
});

$('[name="Vendor.Vendor_Entity.Is_Active"]').on('ifChanged', function (event) {
    if ($(this).prop('checked')) {
        $("#hdnStatus").val(true);
    }
    else {
        $("#hdnStatus").val(false);
    }
});

$("#drpHeadOfficeNation").change(function () {

    $.ajax({
        url: '/master/get-state-by-nation-id',
        data: { nation_Id: $("#drpHeadOfficeNation").val() },
        method: 'GET',
        async: false,
        success: function (data) {
            if (data != null) {
                Bind_States(data);
            }
        }
    });
});
});