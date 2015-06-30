$(function () {

    
    $('#hdfCurrent_Page').val(0);

    Search_Work_Center();

    $("#btnSearch").click(function () {
        $('#hdfCurrent_Page').val(0);
        Search_Work_Center();
    });


    $("#btnEdit").click(function () {

        $("#frmSearch_Work_Station").attr("action", "/master/get-work-station-by-id");

        $("#frmSearch_Work_Station").attr("method", "POST");

        $("#frmSearch_Work_Station").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearch_Work_Station").attr("action", "/master/view-workstation");

        $("#frmSearch_Work_Station").attr("method", "POST");

        $("#frmSearch_Work_Station").submit();
    });

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

    //Friendly_Message(data);

});