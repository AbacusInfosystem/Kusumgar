
$(function () {

    $("#btnSaveCustomField").click(function () {
        if ($("#frmCustom_Fields").valid()) {
            Save_Custom_Fields();
        }
    });

});