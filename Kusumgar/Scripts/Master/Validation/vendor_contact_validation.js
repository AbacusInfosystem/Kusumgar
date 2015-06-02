$(function () {
    $("#frmVendor_Contact").validate({

        rules: {
            
            "Vendor_Contact.Contact_Entity.Contact_Name":
                {
                    required: true
                },
            "Vendor_Contact.Contact_Entity.Designation":
                {
                    required: true
                },
            "Vendor_Contact.Contact_Entity.Official_Email":
                {
                    required: true,
                    email:true
                },
            "Vendor_Contact.Contact_Entity.Personal_Email":
                {
                    required: true,
                    email: true
                },
            "Vendor_Contact.Contact_Entity.Office_Address":
                {
                    required: true
                },
            "Vendor_Contact.Contact_Entity.Office_Landline1":
                {
                    required: true,
                    number:true
                },
            "Vendor_Contact.Contact_Entity.Office_Landline2":
               {
                   number: true
               },
            "Vendor_Contact.Contact_Entity.Mobile1":
                {
                    required: true,
                    number: true
                },
            "Vendor_Contact.Contact_Entity.Mobile2":
                {
                    number: true
                }

        },
        messages: {

            "Vendor_Contact.Contact_Entity.Contact_Name":
                {
                    required: "Contact name is required."
                },
            "Vendor_Contact.Contact_Entity.Designation":
                {
                    required: "Designation is required."
                },
            "Vendor_Contact.Contact_Entity.Official_Email":
                {
                    required: "Office email is required." 
                },
            "Vendor_Contact.Contact_Entity.Personal_Email":
                {
                    required: " Personal email is required."
                },
            "Vendor_Contact.Contact_Entity.Office_Address":
                {
                    required: " Office address is required."
                },
            "Vendor_Contact.Contact_Entity.Office_Landline1":
                {
                    required: " Landline no is required."
                },
            "Vendor_Contact.Contact_Entity.Mobile1":
                {
                    required: " Mobile no is required."
                }

        }
    });
});

$(function () {
    $("#frmCustom_Fields").validate({
       

        rules: {
            "Field_Name":
                {
                    required: true
                },
            "Field_Value":
                {
                    required: true
                }

        },
        messages: {

            "Field_Name":
                {
                    required: "Field name is required."
                },
            "Field_Value":
                {
                    required: "Field value is required."
                }
        }
    });
});
