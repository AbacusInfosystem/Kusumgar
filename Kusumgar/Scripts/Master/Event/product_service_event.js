//$(function () {

//    $("#btnSaveProductServicesDetails").click(function () {

//        if ($("#frmProductServices").valid()) {

//            Save_Product_Service_Details();
//        }
//    });

//    $('[name="Product_Vendor.Product_Vendor_Entity.Original_Manufacturer"]').on('ifChanged', function (event) {
//        if ($(this).prop('checked')) {

//            if (this.id == "rdOriginalManufacturer") {
//                $("#hdnOriginalManufacture").val(true);
//            }
//            else {
//                $("#hdnOriginalManufacture").val(false);
//            }
//        }
//    });

//    $('.btn-product-service').click(function () {

//        $("#hdnProductVendorId").val($(this).parent().parent().find(".hdn_Product_Vendor_Id").val());

//        $("#txtProductServicesName").val($(this).parent().parent().find(".Product_Service_Name").val());
//        $("#txtTestingFacility").val($(this).parent().parent().find(".Testing_Facility").val());
//        $("#txtInspectionFacility").val($(this).parent().parent().find(".Inspection_Facility").val());
//        $("#drpProductType").val($(this).parent().parent().find(".Product_Type").val());

//        if ($(this).parent().parent().find(".Original_Manufacture").val() =="True") {
           
//            $("#rdOriginalManufacturer").parent().addClass("checked");
//            $("#rdNotOriginalManufacturer").parent().removeClass("checked");
//        }

//        else {
           
//            $("#rdOriginalManufacturer").parent().removeClass("checked");
//            $("#rdNotOriginalManufacturer").parent().addClass("checked");
//        }
//    });

//    });






