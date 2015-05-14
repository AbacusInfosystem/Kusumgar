$(document).ready(function () {

    GetAllDefects();

    $("#btnSearch").click(function () {
        SearchDefects();
    });

    $('#btnEdit').click(function () {

        $("#frmDefectSearch").attr("action", "/Defect/GetDefectById");

        $("#frmDefectSearch").attr("method", "post");

        $("#frmDefectSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#drpDefectTypeName').change(function () {

        $('#hdfDefectTypeId').val($('#drpDefectTypeName :selected').val());
        
    })
 
    if ($("#hdfDefectTypeId").val() != 0) {
        
        $('#drpDefectTypeName').val($("#hdfDefectTypeId").val());
                                          }
    
});

