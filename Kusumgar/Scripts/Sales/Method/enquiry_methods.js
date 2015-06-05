
function Save_Enquiry()
{
    var eViewModel = Set_Enquiry();


    if ($("#hdnEnquiry_Id").val() == 0) {
        CallAjax("/sales/insert-enquiry/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Enquiry_CallBack, "", null);
    }
    else {
        CallAjax("/sales/update-enquiry/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Enquiry_CallBack, "", null);
    }
}


function Set_Enquiry()
{
    var eViewModel =
    {
        Enquiry:
            {
                Enquiry_Id: $("#hdnEnquiry_Id").val(),

                //Enquiry_No: $("#").val(),

                Enquiry_Type_Id: $("#hdnEnquiry_Type_Id").val(),

                Enquiry_Status_Id: $("#hdnEnquiry_Status_Id").val(),

                Customer_Id: $("#hdnCustomer_Id").val(),

                Quality_Id: $("#hdnQuality_Id").val(),

                //PPC_Article_Type_Id: $("#").val(),

                //Quality_Set_Id: $("#").val(),

               // Is_Active: $("#").val()
            }
    }
}


function Enquiry_CallBack(data)
{

}