function Save_Vendors_Details() {
    

    if ($("#hdnVendorId").val() == 0) {
        var vViewModel = Set_Vendor();
        CallAjax("/master/insert-vendor/", "json", JSON.stringify(vViewModel), "POST", "application/json", false, Bind_Vendor_Data_Callback, "", null);
    }
    else {
        var vViewModel = Set_Vendor_Details();
        CallAjax("/master/update-vendor/", "json", JSON.stringify(vViewModel), "POST", "application/json", false, Bind_Vendor_Data_Callback, "", null);
    }

}

function Bind_Vendor_Data_Callback(data) {

    $("#hdnVendorId").val(data.Vendor.Vendor_Id);

    $("#tabProductServices").show();
    $("#tabCertificates").show();
    $("#tabCentralExciseRegistrationDetails").show();
    $("#tabOtherDetails").show();

    $("#hdnVendorName").val($("#txtVendorName").val());

    $("#txt_auto_Vendor_Name").val($("#txtVendorName").val());

    $("#hdnVendor_Id").val($("#hdnVendorId").val());

    $("#hdnVendor_Name").val($("#txtVendorName").val());

    InitializeAutoComplete($('#txt_auto_Vendor_Name'));

    Friendly_Message(data);
}

function Set_Vendor() {
    var vViewModel =
        {
            Vendor:
                {
                    
                            Vendor_Id: $("#hdnVendorId").val(),

                            Vendor_Name: $("#txtVendorName").val(),

                            Email: $("#txtEmailId ").val(),

                            HeadOfficeAddress: $("#txtHeadOfficeAddress").val(),

                            Head_Office_State: $("#drpHeadOfficeState").val(),
                            Head_Office_ZipCode: $("#txtHeadOfficeZipCode").val(),
                            Head_Office_Nation: $("#drpHeadOfficeNation").val(),
                            Head_Office_Landline1: $("#txtHeadOfficeLandline1").val(),
                            Head_Office_Landline2: $("#txtHeadOfficeLandline2").val(),
                            Head_Office_FaxNo: $("#txtHeadOfficeFaxNo").val(),
                            Is_Active: $("#hdnStatus").val(),
                            Product_Category: $("#drpProductCategory").val(),
                            Code: $("#txtYarnCode").val(),

                        

                    Material_Category_Entity: {
                        Material_Category_Name: $("#drpProductCategory option:selected").text()
                    }
                },

            Attribute_Code:
                {
                            Name: $("#txtVendorName").val(),
                            Code: $("#txtYarnCode").val()
                }
       }

    return vViewModel;
}

function Bind_States(data) {
    $("#drpHeadOfficeState").html("");

    var htmltext = "";

    htmltext += "<option>-Select State-</option>";

    if (data.length > 0) {
        for (var i = 0; i < data.length ; i++) {
            htmltext += "<option value='" + data[i].StateId + "'>" + data[i].StateName + "</option>";
        }
    }
    $("#drpHeadOfficeState").html(htmltext);

}
