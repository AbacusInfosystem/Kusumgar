

function Save_Contact()
{
    var cViewModel = Set_Contact();


    if ($("#hdnContact_Id").val() == 0) {
        CallAjax("/crm/contact-insert/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Contact_CallBack, "", null);
    }
    else {
        CallAjax("/crm/contact-update/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Contact_CallBack, "", null);
    }
}

function Contact_CallBack(data)
{
    $("#tabcustom_fields").show();
    $("#hdnContact_Id").val(data.Contact.Contact_Id);
    Friendly_Message(data);
}

function Set_Contact()
{
    var cViewModel = 
        {
            contact: 
                {
                    
                            Contact_Id: $("#hdnContact_Id").val(),

                            Contact_Name: $("#txtContact_Name").val(),

                            Contact_Type: 1,

                            Customer_Id: $("#hdnCustomer_Id").val(),

                            Customer_Contact_Type_Id: $("#drpContactType").val(),

                            Designation: $("#txtDesignation").val(),

                            DMU_Status_Influence: $("#drpDMU_Status_Influence").val(),

                            DMU_Status_Role: $("#drpDMU_Status_Role").val(),

                            Is_Active: $("#hdnIs_Active").val(),

                            Is_Billing_Contact: $("#hdnBilling_Contact").val(),

                            Mobile1: $("#txtMobile1").val(),

                            Mobile2: $("#txtMobile2").val(),

                            Office_Address: $("#txtOffice_Address").val(),

                            Office_Landline1: $("#txtOffice_Landline1").val(),

                            Office_Landline2: $("#txtOffice_Landline2").val(),

                            Official_Email: $("#txtOffice_Email").val(),

                            Personal_Email: $("#txtPersonal_Email").val(),

                            Supplier_Id:0

                        
                }
        }

    return cViewModel;
}

function Get_Contact_Types(Customer_Id)
{
    $.ajax({
        url: '/crm/contact-type-by-customer-id',
        data: { customer_Id: $("#hdnCustomer_Id").val() },
        method: 'GET',
        async: false,
        success: function (data) {

            if (data != null) {
                Bind_Contact_Types(data);
            }
        }
    });
}

function Bind_Contact_Types(data) {
    $("#drpContactType").html("");

    var htmltext = "";

    htmltext += "<option>-Select Contact Type-</option>";

    if (data.length > 0) {
        for (var i = 0; i < data.length ; i++) {
            var id = $("#hdnContact_Type_Id").val();
            if (id == data[i].Customer_Contact_Type_Id)
            {
                htmltext += "<option value='" + data[i].Customer_Contact_Type_Id + "' selected='selected'>" + data[i].Contact_Type + "</option>";
            }
            else
            {
                htmltext += "<option value='" + data[i].Customer_Contact_Type_Id + "'>" + data[i].Contact_Type + "</option>";
            }            
        }
    }
    $("#drpContactType").html(htmltext);
}