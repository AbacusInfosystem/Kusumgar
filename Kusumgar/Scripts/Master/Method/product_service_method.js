function Save_Product_Service_Details() {
    var vViewModel = Set_Product_Service();

    if ($("#hdnProductVendorId").val() == 0) {
        CallAjax("/master/insert-vendor/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Product_Service_Data_Callback, "", null);
    }
    else {
        CallAjax("/master/update-vendor/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Product_Service_Data_Callback, "", null);
    }

}

function Bind_Product_Service_Data_Callback(data) {

    Friendly_Message(data);
}

function Set_Product_Service() {
    var vViewModel =
        {
            Product_Vendor:
                {
                    Product_Vendor_Entity:
                        {
                            Product_Vendor_Id :$("hdnProductVendorId").val(),
                            Vendor_Id :$("hdnVendorId").val(),
                            Product_Type :$("drpProductType").val(),
                            Name :$("txtProductName").val(),
                            Original_Manufacturer:$("hdnOriginalManufacture").val(),
                           
                            InspectionFacility:$("txtInspectionFacility").val(),
                            TestingFacility: $("txtTestingFacility").val()
                        }
                }
        }
    return vViewModel;
}