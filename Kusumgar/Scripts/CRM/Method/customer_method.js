

function Save_Customer_Details()
{
    var cViewModel = Set_Customer();

   
    if($("#hdnCustomer_Id").val() == 0)
    {
        CallAjax("/crm/insert-customer/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Customer_CallBack, "", null);
    }
    else
    {
        CallAjax("/crm/update-customer/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Customer_CallBack, "", null);
    }

}

function Customer_CallBack(data)
{

    $("#hdnCustomer_Id").val(data.Customer.Customer_Id);

    $("#tabFinancial").show();
    $("#tabBilling").show();
    $("#tabShipping").show();
    $("#tabOther").show();
    $("#tabContactType").show();
    $("#hdnCustomer_Name").val($("#txtCustomer_Name").val());

    Friendly_Message(data);
}




function Set_Customer()
{
    var cViewModel =
        {
            Customer: 
                {
                    
                            Customer_Id: $("#hdnCustomer_Id").val(),

                            Customer_Name: $("#txtCustomer_Name").val(),

                            Company_Email: $("#txtEmail_Id").val(),

                            Head_Office_Address: $("#txtHead_Office_Address").val(),

                            Head_Office_State: $("#drpHead_Office_State").val(),

                            Head_Office_ZipCode: $("#txtHead_Office_ZipCode").val(),

                            Head_Office_Nation: $("#drpHead_Office_Nation").val(),

                            Head_Office_Landline1: $("#txtHead_Office_Landline1").val(),

                            Head_Office_Landline2: $("#txtHead_Office_Landline2").val(),

                            Head_Office_FaxNo: $("#txtHead_Office_FaxNo").val(),

                            Company_Turnover: $("#txtCompany_Turnover").val(),

                            Public_Private_Sector: $("#hdnPublic_Private_Sector").val(),

                            Organised_UnOrganised_Sector: $("#hdnOrganised_UnOrganised_Sector").val(),

                            Proprietary_Private_Limited: $("#hdnProprietary_Private_Limited").val(),

                            Progressive_Stable_Turmoil: $("#hdnProgressive_Stable_Turmoil").val(),

                            Expiration_Date_Of_Contract: $("#dtpExpiration_Date_Of_Contract").val(),

                            Credit_limit: $("#txtCredit_Limit").val(),

                            Auto_Mail_Delivery: $("#hdnAuto_Mail_Delivery").val(),

                            Order_Minimum_Value: $("#txtOrder_Minimum_Value").val(),

                            Order_Maximum_Value: $("#txtOrder_Maximum_Value").val(),

                            Is_Approved_By_Director: $("#hdnIs_Approved_By_Director").val(),

                            Block_Order: $("#hdnBlock_Order").val(),

                            Is_Active: $("#hdnIs_Active").val()
                        
                }
        }

    return cViewModel;
}


function Bind_States(data)
{
    $("#drpHead_Office_State").html("");

    var htmltext = "";

    htmltext += "<option>-Select State-</option>";

    if(data.length > 0)
    {
        for (var i = 0; i < data.length ; i++)
        {
            htmltext += "<option value='" + data[i].StateId + "'>" + data[i].StateName + "</option>";
        }
    }
    $("#drpHead_Office_State").html(htmltext);

}

function Save_Customer_Contact_Type() {
    var cViewModel = Set_Customer_Contact_Type();

    if ($("#hdnCustomer_Contact_Type_Id").val() == 0) {
        CallAjax("/master/insert-customer-contact-type/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Contact_Type_Data_Callback, "", null);
    }    
}

function Bind_Customer_Contact_Type_Data_Callback(data) {
        
    var htmlText = "";

    for (i = 0; i < data.Customer.Customer_Contact_Types.length; i++) {

        htmlText += "<tr id='tr_ctype_" + data.Customer.Customer_Contact_Types[i].Customer_Contact_Type_Id + "'>";

        htmlText += "<td>";

        htmlText += data.Customer.Customer_Contact_Types[i].Contact_Type;

        htmlText += "</td>";        

        htmlText += "<td>";

        htmlText += "<div class='btn-group pull-right'>";

        htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-xs' onclick='RemoveContactType(" + data.Customer.Customer_Contact_Types[i].Customer_Contact_Type_Id + ")'><i class='fa fa-times'></i></button>";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblConTypeGrid").find("tr:gt(0)").remove();

    $('#tblConTypeGrid tr:first').after(htmlText);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    $("#divSearchGridOverlay").hide();

    $("#hdnCustomer_Contact_Type_Id").val(0);

    $("#txtContactType").val("");    

    Friendly_Message(data);
}

function Set_Customer_Contact_Type() {
    var cViewModel =
        {
            Customer:
            {
                Customer_Contact_Type:
                {

                    Customer_Contact_Type_Id: $("#hdnCustomer_Contact_Type_Id").val(),

                    Customer_Id: $("#hdnCustomer_Id").val(),

                    Contact_Type: $("#txtContactType").val(),                    

                }
            }
        }
    return cViewModel;
}

function RemoveContactType(id) {

    $.ajax({
        url: '/master/delete-customer-contact-type',
        data: { customer_Contact_Type_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {

            $("#tr_ctype_" + id).html("");
            Friendly_Message(data);
        }
    });
}