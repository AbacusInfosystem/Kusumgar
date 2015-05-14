$(document).ready(function () {

    $("#btnSearch").click(function () {

        SearchDefectTypes();
    });

    $('#btnEdit').click(function () {

        $("#frmDefectTypeSearch").attr("action", "/DefectType/GetDefectTypeById");

        $("#frmDefectTypeSearch").attr("method", "post");

        $("#frmDefectTypeSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    GetAllDefectTypes();

    $('#btnViewDefects').click(function () {

        $("#frmDefectTypeSearch").attr("action", "/DefectType/ViewDefects");

        $("#frmDefectTypeSearch").attr("method", "post");

        $("#frmDefectTypeSearch").submit();
    });
    
});


