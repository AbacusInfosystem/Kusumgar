

function Save_Contact()
{
    var _contactViewModel = Get_Contact_values();


    if ($("#hdnContact_Id").val() == 0) {
        CallAjax("/crm/contact-insert/", "json", JSON.stringify(_contactViewModel), "POST", "application/json", false, Contact_CallBack, "", null);
    }
    else {
        CallAjax("/crm/contact-update/", "json", JSON.stringify(_contactViewModel), "POST", "application/json", false, Contact_CallBack, "", null);
    }
}

function Contact_CallBack(data)
{
    $("#tabcustom_fields").show();
    $("#hdnContact_Id").val(data.contact.contact_Entity.Contact_Id);
    friendly_message(data);
}

function Get_Contact_values()
{
    var _contactViewModel = 
        {
            contact: 
                {
                    contact_Entity:
                        {
                            Contact_Id: $("#hdnContact_Id").val(),

                            Contact_Name: $("#txtContact_Name").val(),

                            Contact_Type: 1,

                            Customer_Id: $("#hdnCustomer_Id").val(),

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
        }

    return _contactViewModel;
}


var autoCustomerCallback = function (paramObj) {

    BindCustomerTags(paramObj.item.label, paramObj.item.value);
}

function BindCustomerTags(label, value)
{
    $('#hdnCustomer_Id').val(value);

    $('#txtCustomer_Name').val(label);
}