$(function () {

    $('#hdfCurrentPage').val(0);

    SearchPacking();

    $("#btnEdit").click(function () {

        $("#frmSearch_Pack").attr("action", "/master/edit-packing");

        $("#frmSearch_Pack").attr("method", "POST");

        $("#frmSearch_Pack").submit();
    });

    InitializeAutoComplete($('#txtPackingName'));

    $("#btnSearch").click(function () {

        $('#hdfCurrentPage').val(0);
        SearchPacking();

    });


});