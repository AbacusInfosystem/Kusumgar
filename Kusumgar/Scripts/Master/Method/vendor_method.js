function Save_Vendors_Details() {
    var vViewModel = Set_Vendor();


    if ($("#hdnVendorId").val() == 0) {
        CallAjax("/Vendor/Insert", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Vendor_Data_Callback, "", null);
    }
    else {
        CallAjax("/Vendor/Update", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Vendor_Data_Callback, "", null);
    }

}

function Bind_Vendor_Data_Callback(data) {

    $("#hdnVendorId").val(data.Vendor.Vendor_Entity.Vendor_Id);

    $("#tabProductServices").show();
    $("#tabCertificates").show();
    $("#tabCentralExciseRegistrationDetails").show();
    $("#tabOtherDetails").show();

    Friendly_Message(data);
}

function Set_Vendor() {                      
    var vViewModel =                              
        {
            Vendor:
                {
                    Vendor_Entity:
                        {
                            Vendor_Id: $("hdnVendorId").val(),

                            Vendor_Name : $("txtVendorName").val(),

                                Email   :  $("txtEmailId ").val(),
                          
                                HeadOfficeAddress:    $("txtHeadOfficeAddress").val(),
                                 
                                Head_Office_State: $("drpHeadOfficeState").val(),
                                Head_Office_ZipCode: $("txtHeadOfficeZipCode").val(),
                                Head_Office_Nation: $("drpHeadOfficeNation").val(),
                                Head_Office_Landline1: $("txtHeadOfficeLandline1").val(),
                                Head_Office_Landline2: $("txtHeadOfficeLandline2").val(),
                                Head_Office_FaxNo: $("txtHeadOfficeFaxNo").val(),
                                Performance_Certification: $("txtPerformanceCertification").val(),
                                Performance_Certification_Year: $("drpPerformanceCertificationYear").val(),
                                Performance_Certification_Category: $("txtPerformanceCertificationCategory").val(),
                                Quality_Certification: $("txtQualityCertification").val(),
                                Quality_Certification_Year:$("drpQualityCertificationYear").val(),
                                Quality_Certification_Category: $("txtQualityCertificationCategory").val(),
                                Central_Excise_Registration_Details: $("txtCentralExciseRegistrationDetails").val(),
                                Registration_No: $("txtRegistrationNo").val(),
                                Range: $("txtRange").val(),
                                Division: $("txtDivision").val(),
                                PAN: $("txtPAN").val(),
                                TAN: $("txtTAN").val(),
                                Tax_Excemption_Code: $("txtTaxExcemptionCode").val(),
                                Currency_Code: $("drpCurrencyCode").val(),
                                VAT_Type: $("txtVatType").val(),
                                PaymentTerms: $("drpPaymentTerm").val(),

                                Remark_about_Supplier: $("txtRemarkaboutSupplier").val(),
                                Block_Payment: $("hdnBlockPayment").val(),

                                Shipment_Methods: $("drpSupplierMethod").val(),
                                Flagged_Supplier: $("txtSupplierName").val(),
                                Is_Approved_By_Director: $("hdnApprovedByDirector").val(),
                                Delivary_Term_Code: $("txtDelivaryTermCode").val(),
                                Is_Active: $("hdnStatus").val()
                              
                        }
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
            htmltext += "<option value='" + data[i].State_Entity.StateId + "'>" + data[i].State_Entity.StateName + "</option>";
        }
    }
    $("#drpHeadOfficeState").html(htmltext);

}