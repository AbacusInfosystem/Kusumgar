$(function () {

    $('#hdfCurrentPage').val(0);

    SearchProcess();

    $("#btnEdit").click(function () {

        $("#frmSearch_Proc").attr("action", "/master/edit-process");

        $("#frmSearch_Proc").attr("method", "POST");

        $("#frmSearch_Proc").submit();
    });

    InitializeAutoComplete($('#txtProcessName'));    

    $("#btnSearch").click(function () {

        $('#hdfCurrentPage').val(0);
        SearchProcess();

    });


});