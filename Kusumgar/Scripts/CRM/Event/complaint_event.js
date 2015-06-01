$(document).ready(function () {
    
    InitializeAutoComplete($('#txtCustomer_Name'));

    $("#btnSave").click(function () {

        if ($("#frmComp").valid()) {

            if ($("#hdnComplaint_Id").val() == 0) {
                $("#frmComp").attr("action", "/crm/insert-complaint");

                $("#frmComp").attr("method", "POST");

                $("#frmComp").submit();
            }
            else {                

                $("#frmComp").attr("action", "/crm/update-complaint");

                $("#frmComp").attr("method", "POST");

                $("#frmComp").submit();
            }
        }
    });

});