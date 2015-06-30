$(function () {
    InitializeAutoComplete($('#txtCArticle_FullCode'));

    $('#hdfCurrentPage').val(0);

    SearchCArticle();

    $("#btnEdit").click(function () {

        $("#frmSearch_CArticle").attr("action", "/master/c-article/get-by-id");

        $("#frmSearch_CArticle").attr("method", "POST");

        $("#frmSearch_CArticle").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearch_CArticle").attr("action", "/master/view-c-article");

        $("#frmSearch_CArticle").attr("method", "POST");

        $("#frmSearch_CArticle").submit();
    });



    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchCArticle();
    });
});