$(function () {

    $('#hdfCurrentPage').val(0);

    SearchUser();

    $("#btnEdit").click(function () {

        $("#frmSearch_user").attr("action", "/master/edit-employee");

        $("#frmSearch_user").attr("method", "POST");

        $("#frmSearch_user").submit();
    });
    
    $("#btnSearch").click(function () {
        SearchUser();
    });
   

});