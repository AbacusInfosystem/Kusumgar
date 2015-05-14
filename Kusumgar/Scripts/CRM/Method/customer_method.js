

function Save_Customer_Details()
{
    var _customerViewModel = Get_Customer_values();

   
    if($("#hdnCompany_Id").val() == 0)
    {
        CallAjax("/crm/insert-customer/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Customer_CallBack, "", null);
    }
    else
    {
        CallAjax("/crm/update-customer/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Customer_CallBack, "", null);
    }

}

function Customer_CallBack(data)
{

    $("#hdnCompany_Id").val(data.Customer.Customer_Entity.Company_Id);

    $("#Financial_Tab").show();
    $("#Billing_Tab").show();
    $("#Shipping_Tab").show();
    $("#Other_Tab").show();
    $("#hdnCustomer_Name").val($("#txtCustomer_Name").val());

    friendly_message(data);
}




function Get_Customer_values()
{
    var _customerViewModel =
        {
            Customer: 
                {
                    Customer_Entity:
                        {
                            Company_Id: $("#hdnCompany_Id").val(),

                            Customer_Name: $("#txtCustomer_Name").val(),

                            Company_Email: $("#txtEmail_Id").val(),

                            Head_Office_Address: $("#txtHead_Office_Address").val(),

                            Head_Office_State: $("#drpHead_Office_State").val(),

                            Head_Office_ZipCode: $("#txtHead_Office_ZipCode").val(),

                            Head_Office_Nation: $("#drpHead_Office_Nation").val(),

                            Head_Office_Landline1: $("#txtHead_Office_Landline1").val(),

                            Head_Office_Landline2: $("#txtHead_Office_Landline2").val(),

                            Head_Office_FaxNo: $("#txtHead_Office_FaxNo").val(),

                            Company_Turnover: $("#txtCompany_Turnover").val(),

                            Public_Private_Sector: $("#hdnPublic_Private_Sector").val(),

                            Organised_UnOrganised_Sector: $("#hdnOrganised_UnOrganised_Sector").val(),

                            Proprietary_Private_Limited: $("#hdnProprietary_Private_Limited").val(),

                            Progressive_Stable_Turmoil: $("#hdnProgressive_Stable_Turmoil").val(),

                            Expiration_Date_Of_Contract: $("#dtpExpiration_Date_Of_Contract").val(),

                            Credit_limit: $("#txtCredit_Limit").val(),

                            Auto_Mail_Delivery: $("#hdnAuto_Mail_Delivery").val(),

                            Order_Minimum_Value: $("#txtOrder_Minimum_Value").val(),

                            Order_Maximum_Value: $("#txtOrder_Maximum_Value").val(),

                            Is_Approved_By_Director: $("#hdnIs_Approved_By_Director").val(),

                            Block_Order: $("#hdnBlock_Order").val(),

                            Is_Active: $("#hdnIs_Active").val()
                        }
                }
        }

    return _customerViewModel;
}


function Bind_State_Data(data)
{
    $("#drpHead_Office_State").html("");

    var htmltext = "";

    htmltext += "<option>-Select State-</option>";

    if(data.length > 0)
    {
        for (var i = 0; i < data.length ; i++)
        {
            htmltext += "<option value='" + data[i].State_Entity.StateId + "'>" + data[i].State_Entity.StateName + "</option>";
        }
    }
    $("#drpHead_Office_State").html(htmltext);

}