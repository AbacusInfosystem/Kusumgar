$(function () {
    $("#frmVendor").validate({

        //ignore: [],
        //errorElement: "span",
        //errorClass: "help-block",
        //highlight: function (element, errorClass, validClass) {
        //    $(element).closest('.form-group').addClass('has-error');
        //    $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        //},
        //unhighlight: function (element, errorClass, validClass) {
        //    $(element).closest('.form-group').removeClass('has-error');
        //    $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        //},
        //errorPlacement: function (error, element) {
        //    if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
        //        error.insertAfter(element.parent());
        //    } else {
        //        error.insertAfter(element);
        //    }
        //},
        rules: {
            "Vendor.Vendor_Entity.Vendor_Name":
                 {
                     required: true,
                     check_vendor_exists: true

                 },
            "Vendor.Vendor_Entity.Email":
                {
                    required: true,
                    email: true
                },
            "Vendor.Vendor_Entity.HeadOfficeAddress":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Head_Office_Nation":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Head_Office_State":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Head_Office_ZipCode":
                {
                    required: true,
                    number: true
                },
            "Vendor.Vendor_Entity.Head_Office_Landline1":
                {
                    required: true,
                    number: true
                },
            "Vendor.Vendor_Entity.Head_Office_Landline2":
                {
                    number: true
                },
            "Vendor.Vendor_Entity.Head_Office_FaxNo":
                {
                    number: true
                },
            "Vendor.Vendor_Entity.Product_Category":
             {
                 required: true,
             },
            "Vendor.Vendor_Entity.Head_Office_ZipCode":
               {
                   required: true,
               },

        },
        messages: {

            "Vendor.Vendor_Entity.Vendor_Name":
             {
                 required: "Vendor name is required."
             },
            "Vendor.Vendor_Entity.Email":
                {
                    required: "Email is required."
                },
            "Vendor.Vendor_Entity.HeadOfficeAddress":
                {
                    required: " Office address is required."
                },
            "Vendor.Vendor_Entity.Head_Office_Nation":
                {
                    required: "Nation is required."
                },
            "Vendor.Vendor_Entity.Head_Office_State":
                {
                    required: "Office state is required."
                },
            "Vendor.Vendor_Entity.Head_Office_ZipCode":
                {
                    required: "Zip code is required."
                },
            "Vendor.Vendor_Entity.Head_Office_Landline1":
                {
                    required: "Office landline is required."
                },
            "Vendor.Vendor_Entity.Product_Category":
             {
                 required: "Product Category is required."
             },

            "Vendor.Vendor_Entity.Head_Office_ZipCode":
       {
           required: "Zip code is required."
       },

        }
    });

   jQuery.validator.addMethod("check_vendor_exists", function (value, element) {
        var result = true;

        if ($("#txtVendorName").val() != "" && $("#hdnVendorName").val() != $("#txtVendorName").val()) {
            $.ajax({
                url: '/master/check-vendor',
                data: { vendor_Name: $("#txtVendorName").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Vendor is already exists.");

});
