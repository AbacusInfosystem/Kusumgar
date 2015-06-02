$(function () {
    //$("#frmVendor").validate({
      
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
      

    //$("#frmProductServices").validate({

    //    rules: {
    //        "Product_Vendor.Product_Vendor_Entity.Name":
    //             {
    //                 required: true,

    //             },
           
    //        "Product_Vendor.Product_Vendor_Entity.Testing_Facility":
    //            {
    //                required: true
    //            },
    //        "Product_Vendor.Product_Vendor_Entity.Inspection_Facility":
    //            {
    //                required: true
    //            },
    //        "Product_Vendor.Product_Vendor_Entity.Product_Type":
    //            {
    //                required: true
    //            },
           
    //    },
    //    messages: {

    //        "Product_Vendor.Product_Vendor_Entity.Name":
    //         {
    //             required: "product service name is required."
    //         },
            
    //        "Product_Vendor.Product_Vendor_Entity.Testing_Facility":
    //            {
    //                required: " Testing Facility is required."
    //            },
    //        "Product_Vendor.Product_Vendor_Entity.Inspection_Facility":
    //            {
    //                required: "Inspection Facility is required."
    //            },
    //        "Product_Vendor.Product_Vendor_Entity.Product_Type":
    //            {
    //                required: "Product Type is required."
    //            },
    //     }
    //});


    $("#frmCertificationDetails").validate({

        rules: {
            "Vendor.Vendor_Entity.Performance_Certification":
                 {
                     required: true,
                     
                 },
            "Vendor.Vendor_Entity.Quality_Certification_Year":
                {
                    required: true,
                   
                },
            "Vendor.Vendor_Entity.Performance_Certification_Year":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Quality_Certification":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Quality_Certification_Category":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Performance_Certification_Category":
                {
                    required: true,
                   
                },
            
        },
        messages: {

            "Vendor.Vendor_Entity.Performance_Certification":
             {
                 required: "Performance Certification is required."
             },
            "Vendor.Vendor_Entity.Quality_Certification_Year":
                {
                    required: "Quality Certification Year is required."
                },
            "Vendor.Vendor_Entity.Performance_Certification_Year":
                {
                    required: " Performance Certification Year address is required."
                },
            "Vendor.Vendor_Entity.Quality_Certification":
                {
                    required: "Quality Certification is required."
                },
            "Vendor.Vendor_Entity.Quality_Certification_Category":
                {
                    required: "Quality Certification Category is required."
                },
            "Vendor.Vendor_Entity.Performance_Certification_Category":
                {
                    required: "Performance Certification Category is required."
                },
           

        }
    });



    $("#frmCentralRegistrationDetails").validate({

        rules: {
            "Vendor.Vendor_Entity.Registration_No":
            {
                required: true,
            },
            "Vendor.Vendor_Entity.Range":
                {
                    required: true
                },
            "Vendor.Vendor_Entity.Division":
            {
                required: true
            },
            "Vendor.Vendor_Entity.PAN":
            {
                required: true,
                validate_PAN: true
            },
            "Vendor.Vendor_Entity.TAN":
            {
                required: true
            },


            "Vendor.Vendor_Entity.Tax_Excemption_Code":
           {
               required: true
           },


            "Vendor.Vendor_Entity.Currency_Code":
           {
               required: true
           },

  
            "Vendor.Vendor_Entity.VAT":
         {
             required: true
         },
            "Vendor.Vendor_Entity.PaymentTerms":
         {
             required: true
         }

  },

        messages: {

            "Vendor.Vendor_Entity.Registration_No":
            {
                required: "Registration No is required" ,
            },
            "Vendor.Vendor_Entity.Range":
                {
                    required: "Division is required"
                },
            "Vendor.Vendor_Entity.Division":
            {
                required: "Registration No is required"
            },
            "PAN":
            {
                required: "PAN is required"
            },
            "Vendor.Vendor_Entity.TAN":
            {
                required: "TAN is required"
            },


            "Vendor.Vendor_Entity.Tax_Excemption_Code":
           {
               required: "Tax Excemption Code is required"
           },


            "Vendor.Vendor_Entity.Currency_Code":
           {
               required: "Currency Code is required"
           },


            "Vendor.Vendor_Entity.VAT":
         {
             required: "VAT is required"
         },
            "Vendor.Vendor_Entity.PaymentTerms":
         {
             required: "PaymentTerms is required"
         },

        }

    });


    jQuery.validator.addMethod("validate_PAN", function (value, element) {
        return this.optional(element) || /^[A-Z]{5}\d{4}[A-Z]{1}$/.test(value);
    }, "Invalid Pan Number");
 

});



