$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));

    $("#hdfCustomer_Id").val(0);

    $("#hdCustomer_Id").val(0);

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


    $("#btnBlock").click(function () {
       
        $('#hdfBlockOrder').val(true);

       // alert($('#hdfBlockOrder').val());
        Save_Customer_Order();
        $("#btnBlock").hide();
        $("#btnUnblock").show();
       
        
    });

    $("#btnUnblock").click(function () {
       
        $('#hdfBlockOrder').val(false);
        Save_Customer_Order();
        $("#btnUnblock").hide();
        $("#btnBlock").show();
      
    });

});