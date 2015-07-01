$(document).ready(function () {

    GetAllTests();

    $("#btnSearch").click(function () {
        SearchTests();
    });

    $('#btnEdit').click(function () {

        $("#frmTestSearch").attr("action", "/Test/Get_Test_By_Id");

        $("#frmTestSearch").attr("method", "post");

        $("#frmTestSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#drpProcesssId').change(function () {

        $('#hdfProcessId').val($('#drpProcesssId :selected').val());
       
    })

    if ($("#hdfProcessId").val() != 0) {
       
        $('#drpProcesssId').val($("#hdfProcessId").val());
    }

});