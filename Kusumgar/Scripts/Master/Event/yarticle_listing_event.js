$(function () {
    InitializeAutoComplete($('#txtYArticle_Full_Code'));

    $('#hdfCurrentPage').val(0);

    SearchYArticle();

    $("#btnEdit").click(function () {

        $("#frmSearch_YArticle").attr("action", "/master/y-article/get-by-id");

        $("#frmSearch_YArticle").attr("method", "POST");

        $("#frmSearch_YArticle").submit();
    });

   

    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchYArticle();
    });
});