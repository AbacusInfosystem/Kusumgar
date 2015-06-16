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

    $("#divSearchGridOverlay").hide();

});