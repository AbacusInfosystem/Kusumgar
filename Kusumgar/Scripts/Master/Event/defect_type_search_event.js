$(document).ready(function () {

    GetAllDefectTypes();

    $("#btnSearch").click(function () {

        SearchDefectTypes();
    });

    $('#btnEdit').click(function () {

        $("#frmDefectTypeSearch").attr("action", "/DefectType/Get_Defect_Type_By_Id");

        $("#frmDefectTypeSearch").attr("method", "post");

        $("#frmDefectTypeSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#btnViewDefects').click(function () {

        $("#frmDefectTypeSearch").attr("action", "/DefectType/View_Defects");

        $("#frmDefectTypeSearch").attr("method", "post");

        $("#frmDefectTypeSearch").submit();
    });
    
});


