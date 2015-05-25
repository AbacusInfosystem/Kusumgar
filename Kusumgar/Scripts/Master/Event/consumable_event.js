$(document).ready(function () {

    InitializeAutoComplete($('#txtSupplierName'));

    if ($("#hdnConsumable_Id").val() == 0) {
        $("#Vendor_Tab").hide();

    }
    
    $("#btnSave").click(function () {
        
        if ($("#frmConsumableMaster").valid()) {
            Save_Consumable_Details();
        }
    });

    $("#btnSave_Vendor").click(function () {

        if ($("#frmConsumableMaster").valid()) {

            Save_Consumable_Vendor_Details();
        }
    });

    $("#chkStatus").on('ifChanged', function (event) {
       
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

});