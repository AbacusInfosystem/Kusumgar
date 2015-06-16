$(document).ready(function () {
    
    $("#btnProcessSave").click(function () {

        if ($("#frmProcess").valid()) {

            if ($("#hdnProcess_Id").val() == 0) {
                $("#frmProcess").attr("action", "/master/insert-process");

                $("#frmProcess").attr("method", "POST");

                $("#frmProcess").submit();
            }
            else {

                $("#frmProcess").attr("action", "/master/update-process");

                $("#frmProcess").attr("method", "POST");

                $("#frmProcess").submit();
            }

        }
    });    

    $('[name="chkIsActive"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });    
    
});