$(function () {

    InitializeAutoComplete($('#txtVendorName'));

    $('#hdfCurrentPage').val(0);

    SearchMaterial();

    $("#btnEdit").click(function () {

        $("#frmSearch_Prod").attr("action", "/master/edit-material");

        $("#frmSearch_Prod").attr("method", "POST");

        $("#frmSearch_Prod").submit();
    });

    InitializeAutoComplete($('#txtMaterialName'));

    //$("#drpProdCatName").change(function () {

    //    $.ajax({
    //        url: '/master/Material-subcategory-by-category-id',
    //        data: { Material_Category_Id: $("#drpProdCatName").val() },
    //        method: 'GET',
    //        async: false,
    //        success: function (data) {

    //            if (data != null) {
    //                Bind_SubCategories(data);
    //            }
    //        }
    //    });
    //});

    $("#btnSearch").click(function () {

        $('#hdfCurrentPage').val(0);
        SearchMaterial();

    });

    $("#btnView_Vendor").click(function () {

        $("#frmSearch_Prod").attr("action", "/master/vendor/search");

        $("#frmSearch_Prod").attr("method", "POST");

        $("#frmSearch_Prod").submit();
    });

    $("#btnView").click(function () {

        $("#frmSearch_Prod").attr("action", "/master/view-material");

        $("#frmSearch_Prod").attr("method", "POST");

        $("#frmSearch_Prod").submit();
    });


});