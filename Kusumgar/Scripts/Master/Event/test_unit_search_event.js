$(document).ready(function () {

    $("#btnSearch").click(function () {
     
           SearchTestUnits();
    });

    $('#btnEdit').click(function () {

        $("#frmTestUnitSearch").attr("action", "/TestUnit/GetTestUnitById");

        $("#frmTestUnitSearch").attr("method", "post");

        $("#frmTestUnitSearch").submit();
    });

    $("#divSearchGridOverlay").hide();

    GetAllTestUnits();

    $('#btnView').click(function () {

        //alert("hmm");
        $("#frmTestUnitSearch").attr("action", "/TestUnit/ViewTests");

        $("#frmTestUnitSearch").attr("method", "post");

        $("#frmTestUnitSearch").submit();
    });

});