$(function () {



    //$('.iradio-list').initialize(function () {

    //    $(this).iCheck({
    //        radioClass: 'iradio_square-green',
    //        increaseArea: '20%' // optional
    //    });
    //});

    //$('input:not(.non-iCheck input:checkbox)').initialize(function () {


    //    $(this).iCheck({
    //        checkboxClass: 'icheckbox_square-green',
    //        radioClass: 'iradio_square-green',
    //        increaseArea: '20%'
    //    });

    //});

    InitializeAutoComplete($('#txtCustomer_Name'));

    $("#hdfCustomer_Id").val(0);

    $("#hdCustomer_Id").val(0);

    $('#hdfCurrentPage').val(0);

    SearchCustomer();

    $("#hdfCustomer_Status_Id").val(0);

    $("#drpNation_Id").change(function () {

        if ($("#drpNation_Id").val() != "") {

            $.ajax({
                url: '/crm/states-by-nation',
                data: { nation_Id: $("#drpNation_Id").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data != null) {
                        Bind_States(data);
                    }
                }
            });

        }
        else
        {
            Remove_Bind_States();
        }

    });
    
    $("#btnEdit").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/edit-customer");

        $("#frmSearch_customer").attr("method", "POST");

        $("#frmSearch_customer").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearch_customer").attr("action", "/crm/view-customer");

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


    $(".dropdown-menu").find('li a').click(function () {

        $('.fa-remove').trigger("click");

        $('#hdfCurrentPage').val(0);

        $("#hdfCustomer_Status_Id").val($(this).prop('id'));

        SearchCustomerByStatus();

    });


    $("#btnBlock").click(function () {
       
        if ($("#btnBlock").text() == "Block") {
            $('#hdfBlockOrder').val(true);
        }
        else {
            $('#hdfBlockOrder').val(false);
        }

       // alert($('#hdfBlockOrder').val());
        Save_Customer_Order();
        //$("#btnBlock").hide();
        //$("#btnUnblock").show();

        if($("#btnBlock").text() == "Block")
        {
            $('#btnBlock').text("UnBlock");
        }
        else
        {
            $('#btnBlock').text("Block");
        }
       
        
    });

    //$("#btnUnblock").click(function () {
       
    //    $('#hdfBlockOrder').val(false);
    //    Save_Customer_Order();
    //    $("#btnUnblock").hide();
    //    $("#btnBlock").show();
      
    //});

});


