
function Save_Custom_Fields() {
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
                                    Contact_Custom_Field_Id: $("#hdnContact_Custom_Field_Id").val(),

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
    var htmlText = "";

    if (data.contact.Contact_Custom_Fields_List.length > 0) {

        for (var i = 0; i < data.contact.Contact_Custom_Fields_List.length; i++) {
            htmlText += " <tr id='cust_tr_" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Contact_Custom_Field_Id + "'>";

            htmlText += "<td>" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Field_Name + "</td>";

            htmlText += "<td>" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Field_Value + "</td>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' class='hdn_Contact_Custom_Field_Id' value='" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Contact_Custom_Field_Id + "'>";

            htmlText += "<input type='hidden' class='Field_Name' value='" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Field_Name + "'>";

            htmlText += "<input type='hidden' class='Field_Value' value='" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Field_Value + "'>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnEdit' class='btn btn-info btn-sm' onclick='EditCustomFields(" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Contact_Custom_Field_Id + ")'><i class='fa fa-pencil-square-o'></i></button>";

            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm ' onclick='RemoveCustomFields(" + data.contact.Contact_Custom_Fields_List[i].Custom_Fields_Entity.Contact_Custom_Field_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else
    {

    }

    $("#tblCustom_Fields").find("tr:gt(0)").remove();

    $('#tblCustom_Fields tr:first').after(htmlText);

    $("#hdnContact_Custom_Field_Id").val(0);

    $("#txtField_Name").val("");
    $("#txtField_Value").val("");
    $("#hdnContact_Custom_Field_Id").val(0);
    friendly_message(data);

}

function EditCustomFields(id)
{
    $("#txtField_Name").val($("#cust_tr_" + id).find(".Field_Name").val());
    $("#txtField_Value").val($("#cust_tr_" + id).find(".Field_Value").val());
    $("#hdnContact_Custom_Field_Id").val($("#cust_tr_" + id).find(".hdn_Contact_Custom_Field_Id").val());
}

function RemoveCustomFields(id) {
    $.ajax({
        url: '/crm/delete-contact-custom-field',
        data: { Contact_Custom_Field_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#cust_tr_" + id).html("");
            friendly_message(data);
        }
    });
}
