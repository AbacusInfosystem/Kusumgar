
function Save_Customer_Specific_Information() {
   
    var cqViewModel = Set_Customer_Specific_Information();
   
    if ($("#hdnCustomer_Quality_Id").val() != 0) 
    {
       
        CallAjax("/master/customer-quality-details-update/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Specific_Information_CallBack, "", null);
    }
}
function Set_Customer_Specific_Information() {
    
    var cqViewModel =
        {
            Customer_Quality:
                {

                    Customer_Quality_Id: $("#hdnCustomer_Quality_Id").val(),

                    Customer_Id: $("#hdnCustomer_Id").val(),

                    Quality_Id: $("#hdnQuality_Id").val(),

                    Customer_Roll_Length: $("#txtCustomer_Roll_Length").val(),

                    Storage: $("#txtStorage").val(),

                    Transport: $("#txtTransport").val(),

                    Lot_Testing: $("#txtLot_Testing").val(),

                    End_Product_Criteria: $("#txtEnd_Product_Criteria").val(),

                    Testing_Requirements: $("#txtTesting_Requirements").val(),

                    Inspection_Requirements: $("#txtInspection_Requirements").val(),

                    Process_Control: $("#txtProcess_Control").val(),

                    //Customer_Sample_No: $("#txtCustomer_Sample_No").val(),
                    Sample_Id: $("#hdnSample_Id").val(),

                    Special_Care_Details: $("#txtSpecial_Care_Details").val(),

                    Special_Requirements_Material_Handling: $("#txtSpecial_Requirements_Material_Handling").val(),

                    Special_Requirements_Packaging: $("#txtSpecial_Requirements_Packaging").val(),

                    Special_Requirements_Defect_Defination: $("#txtSpecial_Requirements_Defects_Defination").val(),

                    Special_Requirements_Verdicting: $("#txtSpecial_Requirements_Verdicting").val(),

                    Is_Active: $("#hdnIs_Active").val()


                }
        }

    return cqViewModel;
}

function Customer_Specific_Information_CallBack(data) {

    $("#hdnCustomer_Quality_Id").val(data.Customer_Quality.Customer_Quality_Id);
    
    Friendly_Message(data);
}