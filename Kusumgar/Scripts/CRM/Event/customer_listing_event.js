$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

    $('#hdfCurrentPage').val(0);

    SearchCustomer();

    $("#btnEdit").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/edit-customer");

        $("#frmSearch_customer").attr("method", "POST");

        $("#frmSearch_customer").submit();
    });

    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);

        SearchCustomer();
    });

    $("#AdvSearch").click(function () {
        if ($("#frmSearch_customer").valid()) {
           // $(".fa-remove").trigger("click");
            $('#hdfCurrentPage').val(0);
            //AdvanceSearch();
            SearchCustomer();
            $("#myModal").hide();
        }
    });

    $("#btnViewContact").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/contact/search");

        $("#frmSearch_customer").attr("method", "POST");

        $("#frmSearch_customer").submit();
    });


});