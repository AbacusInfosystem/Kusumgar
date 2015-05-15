$(function () {

    $('#hdfCurrentPage').val(0);

    SearchCustomer();

    $("#btnEdit").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/edit-customer");

        $("#frmSearch_customer").attr("method", "POST");

        $("#frmSearch_customer").submit();
    });

    $("#btnSearch").click(function () {
        SearchCustomer();
    });

    $("#AdvSearch").click(function () {
        if ($("#frmSearch_customer").valid()) {


            AdvanceSearch();
        }
    });

    $("#btnViewContact").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/contact/search");

        $("#frmSearch_customer").attr("method", "POST");

        $("#frmSearch_customer").submit();
    });


});