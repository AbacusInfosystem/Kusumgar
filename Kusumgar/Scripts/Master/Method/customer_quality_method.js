
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
    $("#Spefic_Functional_Standerds").show();

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

                            Is_Active: $("#hdnIs_Active").val()

                }
        }

    return cqViewModel;
}


//function Save_Customer_Specific_Information() {

//    var cqViewModel = Set_Customer_Quality();

//    if ($("#hdnCustomer_Quality_Id").val() != 0) {

//        CallAjax("/master/customer-quality-details-update/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Customer_Specific_Information_CallBack, "", null);
//    }
//}

//function Customer_Specific_Information_CallBack(data) {

//    $("#hdnCustomer_Quality_Id").val(data.Customer_Quality.Customer_Quality_Id);

//    Friendly_Message(data);
//}

//function Save_Attachment()
//{
   
//    InitializeDragDrop($("#drag_drop_file"), "/ajax/attachments", Callback, { RefId: $('#hdnCustomer_Quality_Id').val(), RefType: $('#drpRef_Type').val(), Remark: $('#txtRemark').val() });
//    Bind_Attachments();
//}
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






function Save_Customer_Quality_Attachment()
{
    var cqViewModel = Set_Attachment();

        CallAjax("/master/insert-customer-quality-attachment/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Attachment_CallBack, "", null);
   
        //CallAjax("/master/update-customer-quality-attachment/", "json", JSON.stringify(cqViewModel), "POST", "application/json", false, Attachment_CallBack, "", null);
    
}

function Set_Attachment()
{
    var cqViewModel =
        {
            Attachment:
                {

                    Ref_Id: $("#hdnCustomer_Quality_Id").val(),

                    Ref_Type: $("#drpRef_Type").val(),

                    Document_Name: $("#drag_drop_file").val(),

                    Remark: $("#txtRemark").val()

                }
        }

    return cqViewModel;
}

function Attachment_CallBack(data) {
    $("#tbCustomer_Specific_Information").show();
    $("#tbAttachment").show();
    $("#Spefic_Functional_Standerds").show();

    $("#hdnCustomer_Quality_Id").val(data.Customer_Quality.Customer_Quality_Id);
    $("#hdnCustomer_Id").val(data.Customer_Quality.Customer_Id);
    $("#hdnQuality_Id").val(data.Customer_Quality.Quality_Id);

    var htmlText = "";

    if (data.Attachments.length > 0) {

        for (var i = 0; i < data.Attachments.length; i++) {

            htmlText += " <tr id='att_tr_" + data.Attachments[i].Attachment_Id + "'>";

            htmlText += "<td>" + data.Attachments[i].Document_Name + "</td>";

            htmlText += "<td>" + data.Attachments[i].Ref_Type + "</td>";

            htmlText += "<td>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm ' onclick='Remove_Attachment(" + data.Attachments[i].Attachment_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

    }

    $("#tblCustomer_Quality_Attachment").find("tr:gt(0)").remove();

    $('#tblCustomer_Quality_Attachment tr:first').after(htmlText);

    
    //$("#hdnAttachment_Id").val(0);
    //$("#drpRef_Type").val(0);
    //$("#drag_drop_file").val(""); 
    //$("#txtRemark").val("");

    Friendly_Message(data);
}

function Remove_Attachment(id) {
    $.ajax({
        url: '/master/delete-customer-quality-attachment',
        data: { attachment_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#att_tr_" + id).html("");

            Friendly_Message(data);
        }
    });
}

