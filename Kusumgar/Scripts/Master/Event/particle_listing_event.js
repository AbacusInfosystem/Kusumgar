$(function () {

    InitializeAutoComplete($('#txtPArticle_Full_Code'));

    $('#hdfCurrentPage').val(0);

    SearchPArticle();

    $("#btnEdit").click(function () {

        $("#frmSearchPArticle").attr("action", "/master/p-article/get-by-id");

        $("#frmSearchPArticle").attr("method", "POST");

        $("#frmSearchPArticle").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearchPArticle").attr("action", "/master/view-p-article");

        $("#frmSearchPArticle").attr("method", "POST");

        $("#frmSearchPArticle").submit();
    });


    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchPArticle();
    });
});