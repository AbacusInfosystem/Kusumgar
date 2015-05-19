$(function () {

    $("#btnSaveProductServicesDetails").click(function () {

        if ($("#frmProductServices").valid()) {

            Save_Product_Service_Details();
        }
    });


    $('[name="Product_Vendor.Product_Vendor_Entity.Original_Manufacturer"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {

            if (this.id == "rdOriginalManufacturer") {
                $("#hdnOriginalManufacture").val(true);
            }
            else {
                $("#hdnOriginalManufacture").val(false);
            }
        }
    });
});

