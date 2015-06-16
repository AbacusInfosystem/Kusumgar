$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

    InitializeAutoComplete($('#txtQuality_No'));

    $('#hdfCurrentPage').val(0);

    SearchEnquiry();

    $("#hdfEnquiry_Status_Id").val(0);

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

        $("#hdfEnquiry_Status_Id").val(0);

        SearchEnquiry();
    });


    $(".dropdown-menu").find('li a').click(function () {

        $('.fa-remove').trigger("click");

        $('#hdfCurrentPage').val(0);

        $("#hdfEnquiry_Status_Id").val($(this).prop('id'));

        SearchEnquiry();

    });

});