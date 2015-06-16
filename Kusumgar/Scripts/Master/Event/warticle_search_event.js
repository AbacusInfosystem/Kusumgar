$(function () {
    InitializeAutoComplete($('#txtFullCode'));

    $('#hdfCurrentPage').val(0);

    SearchWArticle();

    $("#btnEdit").click(function () {

        $("#frmSearch_WArticle").attr("action", "/master/w-article/get-by-id");

        $("#frmSearch_WArticle").attr("method", "POST");

        $("#frmSearch_WArticle").submit();
    });



    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchWArticle();
    });
});