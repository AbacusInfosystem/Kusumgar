$(function () {
    $("#frmCustomer").validate({
      
        rules: {
            "Customer.Customer_Name":
                 {
                     required: true,
                     check_customer_exists: true
                 },
            "Customer.Company_Email":
                {
                    required: true,
                    email:true
                },
            "Customer.Head_Office_Address":
                {
                    required: true
                },
            "Customer.Head_Office_Nation":
                {
                    required: true
                },
            "Customer.Head_Office_State":
                {
                    required: true
                },
            "Customer.Head_Office_ZipCode":
                {
                    required: true,
                    number:true
                },
            "Customer.Head_Office_Landline1":
                {
                    required: true,
                    number: true
                },
            "Customer.Head_Office_Landline2":
                {
                    number:true
                },
            "Customer.Head_Office_FaxNo":
                {
                    number:true
                },
        },
            messages: {

                "Customer.Customer_Name":
                 {
                     required: "Customer name is required."
                 },
                "Customer.Company_Email":
                    {
                        required: "Email is required."
                    },
                "Customer.Head_Office_Address":
                    {
                        required: " Office address is required."
                    },
                "Customer.Head_Office_Nation":
                    {
                        required: "Nation is required."
                    },
                "Customer.Head_Office_State":
                    {
                        required: "Office state is required."
                    },
                "Customer.Head_Office_ZipCode":
                    {
                        required: "Zip code is required."
                    },
                "Customer.Head_Office_Landline1":
                    {
                        required: "Office landline is required."
                    }
           
        }
    });

    $("#frmOther").validate({

        rules: {
            "Customer.Company_Turnover":
            {
                number: true
            },
            "Customer.Credit_limit":
                {
                    number: true
                },
            "Customer.Order_Minimum_Value":
            {
                number: true
            },
            "Customer.Order_Maximum_Value":
            {
                number: true
            },
            "Customer.Expiration_Date_Of_Contract":
            {
                date: true
            },
        }
    });


    jQuery.validator.addMethod("check_customer_exists", function (value, element) {
        var result = true;

        if ($("#txtCustomer_Name").val() != "" && $("#hdnCustomer_Name").val() != $("#txtCustomer_Name").val()) {
            $.ajax({
                url: '/crm/check-customer',
                data: { customer_Name: $("#txtCustomer_Name").val() },
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