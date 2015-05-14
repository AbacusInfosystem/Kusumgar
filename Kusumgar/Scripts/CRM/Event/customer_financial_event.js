$(function () {

    $("#btnFinancial_Save").click(function () {

        if ($("#frm_financial_Details").valid()) {
            Save_bank_Details();
        }
    });

    
});