$(function () {

    $('#hdfCurrentPage').val(0);

    SearchProduct();

    $("#btnEdit").click(function () {

        $("#frmSearch_Prod").attr("action", "/master/edit-product");

        $("#frmSearch_Prod").attr("method", "POST");

        $("#frmSearch_Prod").submit();
    });

    InitializeAutoComplete($('#txtProductName'));

    //$("#drpProdCatName").change(function () {

    //    $.ajax({
    //        url: '/master/product-subcategory-by-category-id',
    //        data: { product_Category_Id: $("#drpProdCatName").val() },
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
        SearchProduct();

    });


});