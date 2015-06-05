$(document).ready(function () {

 if ($("#hdnVendorId").val() == 0) {
        $("#tabProductServices").hide();
        $("#tabCertificates").hide();
        $("#tabCentralExciseRegistrationDetails").hide();
        $("#tabOtherDetails").hide();
    }

    $("#btnSave").click(function () {
        if ($("#frmVendor").valid()) {
            if ($("#hdnIs_Primary").val() == true) {
                Save_Vendors_Details();
            }
            else
            {
                Save_Vendors_Details();
                $("#myModal").modal('toggle');

            }
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