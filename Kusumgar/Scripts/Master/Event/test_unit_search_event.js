$(document).ready(function () {
    
    GetAllTestUnits();

    $("#btnSearch").click(function () {
     
           SearchTestUnits();
    });

    $('#btnEdit').click(function () {

        $("#frmTestUnitSearch").attr("action", "/TestUnit/Get_Test_Unit_By_Id");

        $("#frmTestUnitSearch").attr("method", "post");

        $("#frmTestUnitSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    $('#btnView').click(function () {

        $("#frmTestUnitSearch").attr("action", "/TestUnit/ViewTests");

        $("#frmTestUnitSearch").attr("method", "post");

        $("#frmTestUnitSearch").submit();
    });

});