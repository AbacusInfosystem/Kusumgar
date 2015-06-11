$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

    InitializeAutoComplete($('#txtQuality_No'));

    $('#hdfCurrentPage').val(0);

    SearchEnquiry();

    $("#btnEdit").click(function () {

        $("#frmSearch_Enquiry").attr("action", "/sales/enquiry-by-id");

        $("#frmSearch_Enquiry").attr("method", "POST");

        $("#frmSearch_Enquiry").submit();
    });

    $("#btnViewEnquiry").click(function () {

        $("#frmSearch_Enquiry").attr("action", "/crm/edit-customer");

        $("#frmSearch_Enquiry").attr("method", "POST");

        $("#frmSearch_Enquiry").submit();
    });

    $("#btnSearch").click(function () {
        $('#hdfCurrentPage').val(0);
        SearchEnquiry();
    });
});