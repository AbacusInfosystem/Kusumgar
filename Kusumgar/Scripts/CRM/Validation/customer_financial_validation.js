$(function () {
    $("#frmFinancial_Details").validate({

        rules: {

            "Customer.Bank_Details.Bank_Details_Entity.Bank_Account_No":
            {
                required:true
            },
        "Customer.Bank_Details.Bank_Details_Entity.Ifsc_Code":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Swift_Code":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Rtgs_No":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Bank_Name":
            {
                required: true
            },
            "Customer.Bank_Details.Bank_Details_Entity.Branch_Name":
            {
                required: true
            },
            "Customer.Bank_Details.Bank_Details_Entity.Bank_Address":
            {
                required: true
            },
            "Customer.Bank_Details.Bank_Details_Entity.Tax_Excemption_Code":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Vat":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Currency_Id":
            {

            },
            "Customer.Bank_Details.Bank_Details_Entity.Payment_Term_Id":
            {

            },
        },
        messages:
            {
                "Customer.Bank_Details.Bank_Details_Entity.Bank_Account_No":
            {
                required: "Account no is required."
            },
                "Customer.Bank_Details.Bank_Details_Entity.Ifsc_Code":
                    {

                    },
                "Customer.Bank_Details.Bank_Details_Entity.Swift_Code":
                {

                },
                "Customer.Bank_Details.Bank_Details_Entity.Rtgs_No":
                {

                },
                "Customer.Bank_Details.Bank_Details_Entity.Bank_Name":
                {
                    required: "Bank name is required."
                },
                "Customer.Bank_Details.Bank_Details_Entity.Branch_Name":
                {
                    required: "Branch name is required."
                },
                "Customer.Bank_Details.Bank_Details_Entity.Bank_Address":
                {
                    required: "Bank address is required."
                },
                "Customer.Bank_Details.Bank_Details_Entity.Tax_Excemption_Code":
                {

                },
                "Customer.Bank_Details.Bank_Details_Entity.Vat":
                {

                },
                "Customer.Bank_Details.Bank_Details_Entity.Currency_Id":
                {

                },
                "Customer.Bank_Details.Bank_Details_Entity.Payment_Term_Id":
                {

                },
            },
    });
});