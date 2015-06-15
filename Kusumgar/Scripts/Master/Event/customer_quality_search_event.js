
$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

    $('#hdfCurrent_Page').val(0);

    Search_Customer_Quality();

    $("#btnSearch").click(function () {
        $('#hdfCurrent_Page').val(0);
        Search_Customer_Quality();
    });


    $("#btnEdit").click(function () {

        $("#frmSearch_Customer_Quality").attr("action", "/master/get-customer-quality-by-id");

        $("#frmSearch_Customer_Quality").attr("method", "POST");

        $("#frmSearch_Customer_Quality").submit();
    });

});