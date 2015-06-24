$(document).ready(function () {

    $("#btnPackingSave").click(function () {

        if ($("#frmPacking").valid()) {

            if ($("#hdnPacking_Id").val() == 0) {
                $("#frmPacking").attr("action", "/master/insert-packing");

                $("#frmPacking").attr("method", "POST");

                $("#frmPacking").submit();
            }
            else {

                $("#frmPacking").attr("action", "/master/update-packing");

                $("#frmPacking").attr("method", "POST");

                $("#frmPacking").submit();
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