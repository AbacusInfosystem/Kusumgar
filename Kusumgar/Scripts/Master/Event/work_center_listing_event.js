$(function () {

    
    $('#hdfCurrent_Page').val(0);

    Search_Work_Station();

    $("#btnSearch").click(function () {
        $('#hdfCurrent_Page').val(0);
        Search_Work_Station();
    });


    $("#btnEdit").click(function () {

        $("#frmSearch_Work_Center").attr("action", "/master/get-work-center-by-id");

        $("#frmSearch_Work_Center").attr("method", "POST");

        $("#frmSearch_Work_Center").submit();
    });

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

});