$(document).ready(function () {    

    if ($("#hdnProduct_Id").val() == 0) {
        $("#tabProductVendor").hide();
    }

    $("#btnSave").click(function () {

        if ($("#frmProduct").valid()) {

            Save_Product_Details();

        }
    });

    $('[name="chkIsOrigMan"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_OrigMan").val(true);
        }
        else {
            $("#hdnIs_OrigMan").val(false);
        }
    });

    $("#drpProdCatName").change(function () {

        $.ajax({
            url: '/master/product-subcategory-by-category-id',
            data: { product_Category_Id: $("#drpProdCatName").val() },
            method: 'GET',
            async: false,
            success: function (data) {

                if (data != null) {
                    Bind_SubCategories(data);
                }
            }
        });
    });

    InitializeAutoComplete($('#txtVendorName'));

    $("#btnSavePV").click(function () {

        if ($("#frmProduct").valid()) {

            Save_Product_Vendor();
        }
    });
});