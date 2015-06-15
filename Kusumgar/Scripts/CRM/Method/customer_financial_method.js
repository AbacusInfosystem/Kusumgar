


function Save_bank_Details() {
    var cViewModel = Get_Bank_Details_Values();

    if ($("#hdnBank_Detail_Id").val() == 0) {
        CallAjax("/crm/insert-bank-details/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bank_Details_CallBack, "", null);
    }
    else {
        CallAjax("/crm/update-bank-details/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bank_Details_CallBack, "", null);
    }
}


function Get_Bank_Details_Values() {
    var cViewModel =
        {
            Customer:
                {
                    Bank_Details:
                        {
                            
                                    Bank_Account_No: $("#txtBank_Account_No").val(),

                                    Bank_Address: $("#txtBank_Address").val(),

                                    //Bank_Code:$("#").val(),

                                    Bank_Details_Id: $("#hdnBank_Detail_Id").val(),

                                    Bank_Name: $("#txtBank_Name").val(),

                                    Branch_Name: $("#txtBranch_Name").val(),

                                    Customer_Id: $("#hdnCustomer_Id").val(),

                                    Ifsc_Code: $("#txtIFSCCode").val(),

                                    Is_Active: $("#hdnIs_Active").val(),

                                    Rtgs_No: $("#txtRtgs_No").val(),

                                    Swift_Code: $("#txtSwift_Code").val(),

                                    Tax_Excemption_Code: $("#txtTaxExcemptionCode").val(),

                                    Vat: $("#txtVAT").val(),

                                    Currency_Id: $("#drpCurrency").val(),

                                    Payment_Term_Id: $("#drpPaymentTerms").val()
                                
                        }
                }
        }

    return cViewModel;

}

function Bank_Details_CallBack(data)
{
    Friendly_Message(data);

}