
function Save_Customer_Quality() {
    var cqViewModel = Set_Customer_Quality();

    if ($("#hdnCustomer_Quality_Id").val() == 0) {

        CallAjax("/master/customer-quality-insert/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Quality_CallBack, "", null);
    }
    else {
        CallAjax("/master/customer-quality-update/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Quality_CallBack, "", null);
    }
}

function Customer_Quality_CallBack(data) {
    $("#tbCustomer_Specific_Information").show();
    $("#tbAttachment").show();
    $("#tabFuncational_Visual").show();

    $("#hdnCustomer_Quality_Id").val(data.Customer_Quality.Customer_Quality_Id);
    $("#hdnCustomer_Id").val(data.Customer_Quality.Customer_Id);
    $("#hdnQuality_Id").val(data.Customer_Quality.Quality_Id);
   
    Friendly_Message(data);
}


function Set_Customer_Quality() {
    var cqViewModel =
        {
            Customer_Quality:
                {
                            
                            Customer_Quality_Id: $("#hdnCustomer_Quality_Id").val(),

                            Customer_Id: $("#hdnCustomer_Id").val(),

                            Quality_Id: $("#drpQuality_No").val(),

                            Customer_Roll_Length: $("#txtCustomer_Roll_Length").val(),

                            Storage: $("#txtStorage").val(),

                            Transport: $("#txtTransport").val(),

                            Lot_Testing: $("#txtLot_Testing").val(),

                            End_Product_Criteria: $("#txtEnd_Product_Criteria").val(),

                            Testing_Requirements: $("#txtTesting_Requirements").val(),

                            Inspection_Requirements: $("#txtInspection_Requirements").val(),

                            Process_Control: $("#txtProcess_Control").val(),

                            Sample_Id: $("#hdnSample_Id").val(),
                          
                            Special_Care_Details: $("#txtSpecial_Care_Details").val(),

                            Special_Requirements_Material_Handling: $("#txtSpecial_Requirements_Material_Handling").val(),

                            Special_Requirements_Packaging: $("#txtSpecial_Requirements_Packaging").val(),

                            Special_Requirements_Defect_Defination: $("#txtSpecial_Requirements_Defects_Defination").val(),

                            Special_Requirements_Verdicting: $("#txtSpecial_Requirements_Verdicting").val(),

                            Is_Active: $("#hdnIs_Active").val(),

                            Customer_Quality_Functional_Parameter:
                                {
                                    Customer_Quality_Id: $("#hdnCustomer_Quality_Id").val(),

                                    Test_Id: $("#hdnFunctional_Parameters").val()
                                },
                            Customer_Quality_Visual_Parameter:
                                {
                                    Customer_Quality_Id: $("#hdnCustomer_Quality_Id").val(),

                                    Defect_Id: $("#hdnVisual_Parameters").val()
                                }

                }

        }

    return cqViewModel;
}


function Callback(data) {
    //alert($('#drpRef_Type').val());
    //alert($('#txtRemark').val());
    Friendly_Message(data);
   
    Bind_Attachments();
}

function Delete_Attachment(id) {

    $.ajax({
        url: '/ajax/delete-attachments',
        data: { attachment_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            Friendly_Message(data);
        }
    });
}


function Bind_Attachments() {
    $.ajax({
        url: '/ajax/get-attachments-by-ref-type-id',
        data: { ref_Type: $('#drpRef_Type').val(), ref_Id: $('#hdnCustomer_Quality_Id').val() },
        method: 'GET',
        async: false,
        success: function (data) {
            Multiple_Autocomplete($("#drag_drop_file"), data.Attachments, Delete_Attachment);
        }
    });
}

//
function Save_Customer_Quality_Functional_Parameters() {
    var cqViewModel = Set_Customer_Quality();

    CallAjax("/master/insert-customer-quality-functional-parameters/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Quality_Functional_Parameters_CallBack, "", null);
}

function Customer_Quality_Functional_Parameters_CallBack(data) {
    $("#txtFunctional_Parameters").val("");

    $("#hdnFunctional_Parameters").val("");

    Bind_Customer_Quality_Functional_Parameters();

    Friendly_Message(data);
}

function Delete_Customer_Quality_Functional_Parameters(id) {
    $.ajax({
        url: '/master/delete_customer-quality_functional_parameters_by_id',
        data: { customer_Quality_Functional_Parameters_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            Friendly_Message(data);
        }
    });
}

function Bind_Customer_Quality_Functional_Parameters() {
    $.ajax({
        url: '/master/get-customer-quality-functional-parameters-by-customer-quality-id',
        data: { customer_Quality_Id: $("#hdnCustomer_Quality_Id").val() },
        method: 'GET',
        async: false,
        success: function (data) {

            Multiple_Autocomplete($("#txtFunctional_Parameters"), data.customer_Quality_Functional_Parameters, Delete_Customer_Quality_Functional_Parameters);

            Friendly_Message(data);
        }
    });
}


function Save_Customer_Quality_Visual_Parameters() {
    var cqViewModel = Set_Customer_Quality();

    CallAjax("/master/insert-customer-quality-visual-parameters/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Quality_Visual_Parameters_CallBack, "", null);
}

function Customer_Quality_Visual_Parameters_CallBack(data) {
    $("#txtVisual_Parameters").val("");

    $("#hdnVisual_Parameters").val("");

    Bind_Customer_Quality_Visual_Parameters();

    Friendly_Message(data);
}

function Delete_Customer_Quality_Visual_Parameters(id) {
    $.ajax({
        url: '/master/delete_customer-quality_visual_parameters_by_id',
        data: { customer_Quality_Visual_Parameters_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            Friendly_Message(data);
        }
    });
}

function Bind_Customer_Quality_Visual_Parameters() {
    $.ajax({
        url: '/master/get-customer-quality-visual-parameters-by-customer-quality-id',
        data: { customer_Quality_Id: $("#hdnCustomer_Quality_Id").val() },
        method: 'GET',
        async: false,
        success: function (data) {

            Multiple_Autocomplete($("#txtVisual_Parameters"), data.customer_Quality_Visual_Parameters, Delete_Customer_Quality_Visual_Parameters);

            Friendly_Message(data);
        }
    });
}
//


//function Save_Customer_Quality_Attachment()
//{
//    var cqViewModel = Set_Attachment();

//        CallAjax("/master/insert-customer-quality-attachment/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Attachment_CallBack, "", null);
   
//        //CallAjax("/master/update-customer-quality-attachment/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Attachment_CallBack, "", null);
    
//}

//function Set_Attachment()
//{
//    var cqViewModel =
//        {
//            Attachment:
//                {

//                    Ref_Id: $("#hdnCustomer_Quality_Id").val(),

//                    Ref_Type: $("#drpRef_Type").val(),

//                    Document_Name: $("#drag_drop_file").val(),

//                    Remark: $("#txtRemark").val()

//                }
//        }

//    return cqViewModel;
//}

//function Attachment_CallBack(data) {
//    $("#tbCustomer_Specific_Information").show();
//    $("#tbAttachment").show();
//    $("#tabFuncational_Visual").show();

//    $("#hdnCustomer_Quality_Id").val(data.Customer_Quality.Customer_Quality_Id);
//    $("#hdnCustomer_Id").val(data.Customer_Quality.Customer_Id);
//    $("#hdnQuality_Id").val(data.Customer_Quality.Quality_Id);

//    var htmlText = "";

//    if (data.Attachments.length > 0) {

//        for (var i = 0; i < data.Attachments.length; i++) {

//            htmlText += " <tr id='att_tr_" + data.Attachments[i].Attachment_Id + "'>";

//            htmlText += "<td>" + data.Attachments[i].Document_Name + "</td>";

//            htmlText += "<td>" + data.Attachments[i].Ref_Type + "</td>";

//            htmlText += "<td>";

//            htmlText += "<div class='btn-group pull-right'>";

//            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm ' onclick='Remove_Attachment(" + data.Attachments[i].Attachment_Id + ")'><i class='fa fa-times'></i></button>";

//            htmlText += "</div>";

//            htmlText += "</td>";

//            htmlText += "</tr>";
//        }
//    }
//    else {

//    }

//    $("#tblCustomer_Quality_Attachment").find("tr:gt(0)").remove();

//    $('#tblCustomer_Quality_Attachment tr:first').after(htmlText);

    
//    //$("#hdnAttachment_Id").val(0);
//    //$("#drpRef_Type").val(0);
//    //$("#drag_drop_file").val(""); 
//    //$("#txtRemark").val("");

//    Friendly_Message(data);
//}

//function Remove_Attachment(id) {
//    $.ajax({
//        url: '/master/delete-customer-quality-attachment',
//        data: { attachment_Id: id },
//        method: 'GET',
//        async: false,
//        success: function (data) {
//            $("#att_tr_" + id).html("");

//            Friendly_Message(data);
//        }
//    });
//}

