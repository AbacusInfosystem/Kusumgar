$(function () {

    $('#hdfCurrentPage').val(0);

    InitializeAutoComplete($('#txtRole_Name'));

    SearchRole();

    $("#btnEdit").click(function () {

        $("#frmSearch_role").attr("action", "/master/edit-role");

        $("#frmSearch_role").attr("method", "POST");

        $("#frmSearch_role").submit();
    });
    
    $("#btnSearch").click(function () {
        SearchRole();
    });
   

});