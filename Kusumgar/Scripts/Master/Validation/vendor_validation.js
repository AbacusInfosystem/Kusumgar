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
            "Vendor.Performance_Certification":
                 {
                     required: true,
                     
                 },
            "Vendor.Quality_Certification_Year":
                {
                    required: true,
                   
                },
            "Vendor.Performance_Certification_Year":
                {
                    required: true
                },
            "Vendor.Quality_Certification":
                {
                    required: true
                },
            "Vendor.Quality_Certification_Category":
                {
                    required: true
                },
            "Vendor.Performance_Certification_Category":
                {
                    required: true,
                   
                },
            
        },
        messages: {

            "Vendor.Performance_Certification":
             {
                 required: "Performance certification is required."
             },
            "Vendor.Quality_Certification_Year":
                {
                    required: "Quality certification Year is required."
                },
            "Vendor.Performance_Certification_Year":
                {
                    required: " Performance certification year address is required."
                },
            "Vendor.Quality_Certification":
                {
                    required: "Quality certification is required."
                },
            "Vendor.Quality_Certification_Category":
                {
                    required: "Quality certification category is required."
                },
            "Vendor.Performance_Certification_Category":
                {
                    required: "Performance certification category is required."
                },
           

        }
    });



    $("#frmCentralRegistrationDetails").validate({

        rules: {
            "Vendor.Registration_No":
            {
                required: true,
            },
            "Vendor.Range":
                {
                    required: true
                },
            "Vendor.Division":
            {
                required: true
            },
            "Vendor.PAN":
            {
                required: true,
                validate_PAN: true
            },
            "Vendor.TAN":
            {
                required: true
            },


            "Vendor.Tax_Excemption_Code":
           {
               required: true
           },


            "Vendor.Currency_Code":
           {
               required: true
           },

  
            "Vendor.VAT":
         {
             required: true
         },
            "Vendor.PaymentTerms":
         {
             required: true
         }

  },

        messages: {

            "Vendor.Registration_No":
            {
                required: "Registration no is required." ,
            },
            "Vendor.Range":
                {
                    required: "Division is required."
                },
            "Vendor.Division":
            {
                required: "Registration no is required."
            },
            "PAN":
            {
                required: "PAN is required"
            },
            "Vendor.TAN":
            {
                required: "TAN is required."
            },


            "Vendor.Tax_Excemption_Code":
           {
               required: "Tax excemption code is required."
           },


            "Vendor.Currency_Code":
           {
               required: "Currency code is required."
           },


            "Vendor.VAT":
         {
             required: "VAT is required."
         },
            "Vendor.PaymentTerms":
         {
             required: "Payment terms is required."
         },

        }

    });


    jQuery.validator.addMethod("validate_PAN", function (value, element) {
        return this.optional(element) || /^[A-Z]{5}\d{4}[A-Z]{1}$/.test(value);
    }, "Invalid pan number");
 

});



