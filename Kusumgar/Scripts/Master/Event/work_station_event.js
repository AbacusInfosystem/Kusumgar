
$(function () {

  
    $("#drpFactory").change(function () {

        $.ajax({
            url: '/master/work-center-by-factory-id',
            data: { factory_Id: $("#drpFactory").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data != null) {
                    Bind_Work_Centers(data);
                }
            }
        });
    });

    $("#btnSave").click(function () {

        //For Process
        var Process_Ids = "";

        $('[name="ChkProcess"]').each(function (i) {

            if ($(this).prop('checked')) {

                Process_Ids += $(this).val() + ",";
            }
        });

        Process_Ids = Process_Ids.slice(0, Process_Ids.length - 1);

        $("#hdnProcess_Id").val(Process_Ids);

        if ($("#frmWork_Station").valid()) {
            //Save_Work_Station();

            if ($("#hdnWork_Station_Id").val() == 0) {
                $("#frmWork_Station").attr("action", "/master/insert-work-station");

                $("#frmWork_Station").attr("method", "POST");

                $("#frmWork_Station").submit();
            }
            else {
                $("#frmWork_Station").attr("action", "/master/update-work-station");

                $("#frmWork_Station").attr("method", "POST");

                $("#frmWork_Station").submit();
            }

        }
    });

    $('[name="chkUnder_Maintainance"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnUnder_Maintainance").val(true);
        }
        else {
            $("#hdnUnder_Maintainance").val(false);
        }
    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

   

});




