$(document).ready(function () {
    
    InitializeAutoComplete($('#txtCustName'), autoComplaintCallback);

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