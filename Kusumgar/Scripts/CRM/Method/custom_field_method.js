
function Save_Customer_shipping_details() {
    var _contactViewModel = Get_Custom_Fields();


    if ($("#hdnContact_Custom_Field_Id").val() == 0) {
        CallAjax("/crm/contact-custom-field-insert/", "json", JSON.stringify(_contactViewModel), "POST", "application/json", false, Bind_Custom_Fields, "", null);
    }
    else {
        CallAjax("/crm/contact-custom-field-update/", "json", JSON.stringify(_contactViewModel), "POST", "application/json", false, Bind_Custom_Fields, "", null);
    }
}



function Get_Custom_Fields() {
    var _contactViewModel =
        {
            contact:
                {
                    Custom_Fields:
                        {
                            Custom_Fields_Entity:
                                {
                                    Contact_Custom_Field_Id: $("hdnContact_Custom_Field_Id").val(),

                                    Contact_Id: $("#hdnContact_Id").val(),

                                    Field_Name: $("#txtField_Name").val(),

                                    Field_Value: $("#txtField_Value").val(),

                                    Is_Active: $("#hdnIs_Active").val()
                                }

                        }
                }
        }

    return _contactViewModel;
}

function Bind_Custom_Fields(data)
{

}