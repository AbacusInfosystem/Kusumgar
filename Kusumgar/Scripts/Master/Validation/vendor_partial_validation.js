$(function () {
    $("#frmVendor").validate({

       
        rules: {
            "Vendor.Vendor_Name":
                 {
                     required: true,
                     check_vendor_exists: true

                 },
            "Vendor.Email":
                {
                    required: true,
                    email: true
                },
            "Vendor.HeadOfficeAddress":
                {
                    required: true
                },
            "Vendor.Head_Office_Nation":
                {
                    required: true
                },
            "Vendor.Head_Office_State":
                {
                    required: true
                },
            "Vendor.Head_Office_ZipCode":
                {
                    required: true,
                    number: true
                },
            "Vendor.Head_Office_Landline1":
                {
                    required: true,
                    number: true
                },
            "Vendor.Head_Office_Landline2":
                {
                    number: true
                },
            "Vendor.Head_Office_FaxNo":
                {
                    number: true
                },
            "Vendor.Product_Category":
             {
                 required: true,
             },
            "Vendor.Head_Office_ZipCode":
               {
                   required: true,
               },

        },
        messages: {

            "Vendor.Vendor_Name":
             {
                 required: "Vendor name is required."
             },
            "Vendor.Email":
                {
                    required: "Email is required."
                },
            "Vendor.HeadOfficeAddress":
                {
                    required: " Office address is required."
                },
            "Vendor.Head_Office_Nation":
                {
                    required: "Nation is required."
                },
            "Vendor.Head_Office_State":
                {
                    required: "Office state is required."
                },
            "Vendor.Head_Office_ZipCode":
                {
                    required: "Zip code is required."
                },
            "Vendor.Head_Office_Landline1":
                {
                    required: "Office landline is required."
                },
            "Vendor.Product_Category":
             {
                 required: "Product Category is required."
             },

            "Vendor.Head_Office_ZipCode":
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
