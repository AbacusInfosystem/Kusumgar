$(document).ready(function () {

    InitializeAutoComplete($('#txtDefectName'));

    GetAllDefects();

    $("#btnSearch").click(function () {
        SearchDefects();
    });

    $('#btnEdit').click(function () {

        $("#frmDefectSearch").attr("action", "/Defect/Get_Defect_By_Id");

        $("#frmDefectSearch").attr("method", "post");

        $("#frmDefectSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#drpProcessName').change(function () {

        $('#hdfProcessId').val($('#drpProcessName :selected').val());
    })
 
    if ($("#hdfProcessId").val() != 0) {
        
        $('#hdfProcessId').val($("#hdfProcessId").val());
                                          }
    });

