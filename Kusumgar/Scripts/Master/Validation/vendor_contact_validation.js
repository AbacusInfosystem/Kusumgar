$(function () {
    $("#frmVendor_Contact").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

        rules: {
            "Vendor_Contact.Contact_Entity.Vendor_Id":
                {
                    required:true
                },
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

            "Vendor_Contact.Contact_Entity.Vendor_Id":
            {
                required: "Vendor name is required."
            },
            "Vendor_Contact.Contact_Entity.Contact_Name":
                {
                    required: "Contact name is required"
                },
            "Vendor_Contact.Contact_Entity.Designation":
                {
                    required: "Designation is required"
                },
            "Vendor_Contact.Contact_Entity.Official_Email":
                {
                    required: "Office Email is required" 
                },
            "Vendor_Contact.Contact_Entity.Personal_Email":
                {
                    required: " Personal Email is required"
                },
            "Vendor_Contact.Contact_Entity.Office_Address":
                {
                    required: " Office Address is required"
                },
            "Vendor_Contact.Contact_Entity.Office_Landline1":
                {
                    required: " Landline no is required"
                },
            "Vendor_Contact.Contact_Entity.Mobile1":
                {
                    required: " Mobile no is required"
                }

        }
    });
});

$(function () {
    $("#frmCustom_Fields").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

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
