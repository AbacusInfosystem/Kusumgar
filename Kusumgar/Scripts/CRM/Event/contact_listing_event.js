$(function () {

    //InitializeAutoComplete($('#txtCustomer_Name'), autoCustomerCallback);
    InitializeAutoComplete($('#txtCustomer_Name'));

    $('#hdfCurrentPage').val(0);

    SearchContact();

    $("#btnEdit").click(function () {

        $("#frmSearch_contact").attr("action", "/crm/get-contact-by-id");

        $("#frmSearch_contact").attr("method", "POST");

        $("#frmSearch_contact").submit();
    });

    $("#btnViewCompany").click(function () {

        $("#frmSearch_contact").attr("action", "/crm/get-contact-by-id");

        $("#frmSearch_contact").attr("method", "POST");

        $("#frmSearch_contact").submit();
    });

    $("#btnSearch").click(function () {
        SearchContact();
    });
});