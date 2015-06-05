$(function () {
    $("#frmFinancial_Details").validate({

        rules: {

            "Customer.Bank_Details.Bank_Account_No":
            {
                required:true
            },
        "Customer.Bank_Details.Ifsc_Code":
            {

            },
            "Customer.Bank_Details.Swift_Code":
            {

            },
            "Customer.Bank_Details.Rtgs_No":
            {

            },
            "Customer.Bank_Details.Bank_Name":
            {
                required: true
            },
            "Customer.Bank_Details.Branch_Name":
            {
                required: true
            },
            "Customer.Bank_Details.Bank_Address":
            {
                required: true
            },
            "Customer.Bank_Details.Tax_Excemption_Code":
            {

            },
            "Customer.Bank_Details.Vat":
            {

            },
            "Customer.Bank_Details.Currency_Id":
            {

            },
            "Customer.Bank_Details.Payment_Term_Id":
            {

            },
        },
        messages:
            {
                "Customer.Bank_Details.Bank_Account_No":
            {
                required: "Account no is required."
            },
                "Customer.Bank_Details.Ifsc_Code":
                    {

                    },
                "Customer.Bank_Details.Swift_Code":
                {

                },
                "Customer.Bank_Details.Rtgs_No":
                {

                },
                "Customer.Bank_Details.Bank_Name":
                {
                    required: "Bank name is required."
                },
                "Customer.Bank_Details.Branch_Name":
                {
                    required: "Branch name is required."
                },
                "Customer.Bank_Details.Bank_Address":
                {
                    required: "Bank address is required."
                },
                "Customer.Bank_Details.Tax_Excemption_Code":
                {

                },
                "Customer.Bank_Details.Vat":
                {

                },
                "Customer.Bank_Details.Currency_Id":
                {

                },
                "Customer.Bank_Details.Payment_Term_Id":
                {

                },
            },
    });
});