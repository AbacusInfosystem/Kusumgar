$(document).ready(function () {

    GetQualities();

    $("#btnSearch").click(function () {
        SearchQuality();
    });

    $('#btnEdit').click(function () {

        $("#frmQualitySearch").attr("action", "/Quality/Get_Quality_By_Id");

        $("#frmQualitySearch").attr("method", "post");

        $("#frmQualitySearch").submit();
    });

    $("#btnView").click(function () {

        $("#frmQualitySearch").attr("action", "/master/view-quality");

        $("#frmQualitySearch").attr("method", "POST");

        $("#frmQualitySearch").submit();
    });

    $("#divSearchGridOverlay").hide();

});