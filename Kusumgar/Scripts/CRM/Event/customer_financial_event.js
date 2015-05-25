$(function () {

    $("#btnFinancial_Save").click(function () {

        if ($("#frmFinancial_Details").valid()) {
            Save_bank_Details();
        }
    });

    
});