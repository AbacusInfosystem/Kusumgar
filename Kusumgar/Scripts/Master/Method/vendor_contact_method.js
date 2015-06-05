

function Save_Vendor_Contact() {
    var vcViewModel = Set_Vendor_Contact();


    if ($("#hdnContact_Id").val() == 0) {
        CallAjax("/master/vendor-contact-insert/", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Vendor_Contact_CallBack, "", null);
    }
    else {
        CallAjax("/master/vendor-contact-update/", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Vendor_Contact_CallBack, "", null);
    }
}

function Vendor_Contact_CallBack(data) {
    $("#tabcustom_fields").show();
   
    $("#hdnContact_Id").val(data.Vendor_Contact.Contact_Entity.Contact_Id);

    Friendly_Message(data);
}

function Set_Vendor_Contact() {
    var vcViewModel =
        {
            Vendor_Contact:
                {
                    Contact_Entity:
                        {
                            Contact_Id: $("#hdnContact_Id").val(),

                            Contact_Type: 2,

                            Customer_Id: 0,

                            Vendor_Id: $("#hdnVendor_Id").val(),

                            Contact_Name: $("#txtContact_Name").val(),

                            Designation: $("#txtDesignation").val(),

                            Office_Address: $("#txtOffice_Address").val(),

                            Office_Landline1: $("#txtOffice_Landline1").val(),

                            Office_Landline2: $("#txtOffice_Landline2").val(),

                            Mobile1: $("#txtMobile1").val(),

                            Mobile2: $("#txtMobile2").val(),

                            Official_Email: $("#txtEmail_Id").val(),

                            Personal_Email: $("#txtPersonal_Email_Id").val(),

                            Is_Billing_Contact: 0,

                            DMU_Status_Role: 0,

                            DMU_Status_Influence: 0,

                            Is_Active: $("#hdnIs_Active").val()


                        }
                }
        }

    return vcViewModel;
}

//For Costom Field
    function Save_Custom_Fields() {
        var vcViewModel = Get_Vendor_Contact_Custom_Fields();

        if ($("#hdnVendor_Contact_Custom_Field_Id").val() == 0) {

            CallAjax("/master/vendor-contact-custom-field-insert/", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Bind_Vendor_Contact_Custom_Fields, "", null);
        }
        else {
            CallAjax("/master/vendor-contact-custom-field-update/", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Bind_Vendor_Contact_Custom_Fields, "", null);
        }
    }

    function Get_Vendor_Contact_Custom_Fields() {
        var vcViewModel =
            {
                Vendor_Contact:
                    {
                        Vendor_Custom_Field:
                            {
                                
                                        Contact_Custom_Field_Id: $("#hdnVendor_Contact_Custom_Field_Id").val(),

                                        Contact_Id: $("#hdnContact_Id").val(),

                                        Field_Name: $("#txtField_Name").val(),

                                        Field_Value: $("#txtField_Value").val(),

                                        Is_Active: $("#hdnIs_Active").val()
                                    

                            }
                    }
            }

        return vcViewModel;
    }

    function Bind_Vendor_Contact_Custom_Fields(data) {
        var htmlText = "";

        if (data.Vendor_Contact.Vendor_Custom_Fields.length > 0) {

            for (var i = 0; i < data.Vendor_Contact.Vendor_Custom_Fields.length; i++) {

                htmlText += " <tr id='cust_tr_" + data.Vendor_Contact.Vendor_Custom_Fields[i].Contact_Custom_Field_Id + "'>";
              
                htmlText += "<td>" + data.Vendor_Contact.Vendor_Custom_Fields[i].Field_Name + "</td>";

                htmlText += "<td>" + data.Vendor_Contact.Vendor_Custom_Fields[i].Field_Value + "</td>";

                htmlText += "<td>";

                htmlText += "<input type='hidden' class='hdn_Contact_Custom_Field_Id' value='" + data.Vendor_Contact.Vendor_Custom_Fields[i].Contact_Custom_Field_Id + "'>";

                htmlText += "<input type='hidden' class='Field_Name' value='" + data.Vendor_Contact.Vendor_Custom_Fields[i].Field_Name + "'>";

                htmlText += "<input type='hidden' class='Field_Value' value='" + data.Vendor_Contact.Vendor_Custom_Fields[i].Field_Value + "'>";

                htmlText += "<div class='btn-group pull-right'>";

                htmlText += "<button type='button' id='btnEdit' class='btn btn-info btn-sm' onclick='Edit_Custom_Fields(" + data.Vendor_Contact.Vendor_Custom_Fields[i].Contact_Custom_Field_Id + ")'><i class='fa fa-pencil-square-o'></i></button>";

                htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm ' onclick='Remove_Custom_Fields(" + data.Vendor_Contact.Vendor_Custom_Fields[i].Contact_Custom_Field_Id + ")'><i class='fa fa-times'></i></button>";

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

        $("#hdnVendor_Contact_Custom_Field_Id").val(0);

        $("#txtField_Name").val("");
        $("#txtField_Value").val("");
        $("#hdnVendor_Contact_Custom_Field_Id").val(0);

        Friendly_Message(data);

    }

    function Edit_Custom_Fields(id) {
        $("#txtField_Name").val($("#cust_tr_" + id).find(".Field_Name").val());
        $("#txtField_Value").val($("#cust_tr_" + id).find(".Field_Value").val());
        $("#hdnVendor_Contact_Custom_Field_Id").val($("#cust_tr_" + id).find(".hdn_Contact_Custom_Field_Id").val());
    }

    function Remove_Custom_Fields(id) {
        $.ajax({
            url: '/master/delete-vendor-contact-custom-field',
            data: { contact_Custom_Field_Id: id },
            method: 'GET',
            async: false,
            success: function (data) {
                $("#cust_tr_" + id).html("");
                Friendly_Message(data);
            }
        });
    }
