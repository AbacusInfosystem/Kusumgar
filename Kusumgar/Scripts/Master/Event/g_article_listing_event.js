
$(function () {
    InitializeAutoComplete($('#txtGArticle_Full_Code'));
    
    $('#hdfCurrent_Page').val(0);

    Search_G_Article();

    $("#btnEdit").click(function () {

        $("#frmSearch_G_Article").attr("action", "/master/g-article/get-by-id");

        $("#frmSearch_G_Article").attr("method", "POST");

        $("#frmSearch_G_Article").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearch_G_Article").attr("action", "/master/view-g-article");

        $("#frmSearch_G_Article").attr("method", "POST");

        $("#frmSearch_G_Article").submit();
    });


    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        Search_G_Article();
    });
});