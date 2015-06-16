$(document).ready(function () {    

    if ($("#hdnMaterial_Id").val() == 0) {
        $("#tabMaterialVendor").hide();
    }

    $("#btnMaterialSave").click(function () {

        if ($("#frmMaterial").valid()) {

            Save_Material_Details();

        }
    });

    $("#btnNew").click(function () {

        $("#myModal").find(".modal-body").load("/master/partial-vendor", null, Append);
       
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
            url: '/master/material-subcategory-by-category-id',
            data: { Material_Category_Id: $("#drpProdCatName").val() },
            method: 'GET',
            async: false,
            success: function (data) {

                if (data != null) {
                    Bind_SubCategories(data);
                }
            }
        });
    });

    InitializeAutoComplete($('#txt_auto_Vendor_Name'));

    $("#btnSavePV").click(function () {

        if ($("#frmMaterial_Vendors").valid()) {

            Save_Material_Vendor();
        }
    });
});

function Append()
{
    $("#myModal").find(".modal-body").append(Initialize_ICheck);
}
