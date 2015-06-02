
$(function () {

    //For Process


    var Process_Ids = "";

    $('[name="ChkProcess"]').each(function (i) {

        if ($(this).prop('checked')) {

            Process_Ids += $(this).val() + ",";
        }
    });

    Process_Ids = Process_Ids.slice(0, Process_Ids.length - 1);

    $("#hdnProcess_Id").val(Process_Ids);



    $("#drpFactory").change(function () {

        $.ajax({
            url: '/master/work-station-by-factory-id',
            data: { factory_Id: $("#drpFactory").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data != null) {
                    Bind_Work_Stations(data);
                }
            }
        });
    });

    $("#btnSave").click(function () {

        if ($("#frmWork_Center").valid()) {
            Save_Work_Center();
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




