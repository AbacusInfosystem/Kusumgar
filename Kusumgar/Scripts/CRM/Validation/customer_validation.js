$(function () {
    $("#frm_Customer").validate({
      
        rules: {
            "Customer.Customer_Entity.Customer_Name":
                 {
                     required: true,
                     validate_customer:true
                 },
            "Customer.Customer_Entity.Company_Email":
                {
                    required: true,
                    email:true
                },
            "Customer.Customer_Entity.Head_Office_Address":
                {
                    required: true
                },
            "Customer.Customer_Entity.Head_Office_Nation":
                {
                    required: true
                },
            "Customer.Customer_Entity.Head_Office_State":
                {
                    required: true
                },
            "Customer.Customer_Entity.Head_Office_ZipCode":
                {
                    required: true,
                    number:true
                },
            "Customer.Customer_Entity.Head_Office_Landline1":
                {
                    required: true,
                    number: true
                },
            "Customer.Customer_Entity.Head_Office_Landline2":
                {
                    number:true
                },
            "Customer.Customer_Entity.Head_Office_FaxNo":
                {
                    number:true
                },
        },
            messages: {

                "Customer.Customer_Entity.Customer_Name":
                 {
                     required: "Customer Name is required"
                 },
                "Customer.Customer_Entity.Company_Email":
                    {
                        required: "Email is required"
                    },
                "Customer.Customer_Entity.Head_Office_Address":
                    {
                        required: " Office Address is required"
                    },
                "Customer.Customer_Entity.Head_Office_Nation":
                    {
                        required: "Nation is required"
                    },
                "Customer.Customer_Entity.Head_Office_State":
                    {
                        required: "Office State is required"
                    },
                "Customer.Customer_Entity.Head_Office_ZipCode":
                    {
                        required: "Zip Code is required"
                    },
                "Customer.Customer_Entity.Head_Office_Landline1":
                    {
                        required: "Office Landline is required"
                    }
           
        }
    });

    $("#frm_other").validate({

        rules: {
            "Customer.Customer_Entity.Company_Turnover":
            {
                number: true
            },
            "Customer.Customer_Entity.Credit_limit":
                {
                    number: true
                },
            "Customer.Customer_Entity.Order_Minimum_Value":
            {
                number: true
            },
            "Customer.Customer_Entity.Order_Maximum_Value":
            {
                number: true
            },
            "Customer.Customer_Entity.Expiration_Date_Of_Contract":
            {
                date: true
            },
        }
    });


    jQuery.validator.addMethod("validate_customer", function (value, element) {
        var result = true;

        if ($("#txtCustomer_Name").val() != "" && $("#hdnCustomer_Name").val() != $("#txtCustomer_Name").val()) {
            $.ajax({
                url: '/crm/check-customer',
                data: { Customer_Name: $("#txtCustomer_Name").val() },
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

    }, "Customer is already exists.");


});