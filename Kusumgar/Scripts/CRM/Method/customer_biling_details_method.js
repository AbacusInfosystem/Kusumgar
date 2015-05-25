
function Save_Customer_billing_details()
{
    var _customerViewModel = Get_Customer_biling_details();

    if ($("#hdn_Customer_Address_Id").val() == 0) {
        CallAjax("/crm/insert-customer-address/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Billing_Details, "", null);
    }
    else {
        CallAjax("/crm/update-customer-address/", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, Bind_Billing_Details, "", null);
    }
}


function Get_Customer_biling_details() {
    var _customerViewModel =
        {
            Customer:
                {
                    Customer_Address:
                        {
                            Customer_Address_Entity:
                                {
                                    Address_Type: 1,

                                    Addresss: $("#txtBillingOfficeAddress").val(),

                                    Customer_Address_Id: $("#hdn_Customer_Address_Id").val(),

                                    Customer_Id: $("#hdnCustomer_Id").val(),

                                    FaxNo: $("#txtBillingOfficeFaxNo").val(),

                                    Landline1: $("#txtBillingOfficeLandline1").val(),

                                    landline2: $("#txtBillingOfficeLandline2").val()
                                }

                        }
                }
        }

    return _customerViewModel;
}

function Bind_Billing_Details(data)
{

    var htmlText = "";

    if (data.Customer.Customer_Address_List.length > 0) {

        for(var i= 0; i < data.Customer.Customer_Address_List.length;i++ )
        {
            if(data.Customer.Customer_Address_List[i].Customer_Address_Entity.Address_Type == 1)
            {
                htmlText += " <tr id='Bill_tr_" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id + "'>";
                
                htmlText +="<td>"+ data.Customer.Customer_Address_List[i].Customer_Address_Entity.Addresss+ "</td>";

                htmlText +="<td>";

                htmlText +="<input type='hidden' class='hdn_Customer_Address_Id' value='"+data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id+"'>";

                htmlText +="<input type='hidden' class='billing_Address' value='"+data.Customer.Customer_Address_List[i].Customer_Address_Entity.Addresss+"'>";

                htmlText +="<input type='hidden' class='billing_Landline1' value='"+data.Customer.Customer_Address_List[i].Customer_Address_Entity.Landline1+"'>";

                htmlText +="<input type='hidden' class='billing_Landline2' value='"+data.Customer.Customer_Address_List[i].Customer_Address_Entity.landline2+"'>";

                htmlText += "<input type='hidden' class='billing_FaxNo' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.FaxNo + "'>";

                htmlText +="<div class='btn-group pull-right'>";

                htmlText +="<button type='button' id='btnEdit' class='btn btn-info btn-sm btn-billing'><i class='fa fa-pencil-square-o'></i></button>";

                htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveBillingAddress(" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id + ")'><i class='fa fa-times'></i></button>";

                htmlText +="</div>";

                htmlText +="</td>";

                htmlText +=" </tr>";
            }
        }
        $("#tblBilling_Details").find("tr:gt(0)").remove();


        $('#tblBilling_Details tr:first').after(htmlText);

        $("#hdn_Customer_Address_Id").val(0);

        $("#txtBillingOfficeAddress").val("");
        $("#txtBillingOfficeLandline1").val("");
        $("#txtBillingOfficeLandline2").val("");
        $("#txtBillingOfficeFaxNo").val("");

        $('.btn-billing').click(function () {

            $("#hdn_Customer_Address_Id").val($(this).parent().parent().find(".hdn_Customer_Address_Id").val());
            $("#txtBillingOfficeAddress").val($(this).parent().parent().find(".billing_Address").val());
            $("#txtBillingOfficeLandline1").val($(this).parent().parent().find(".billing_Landline1").val());
            $("#txtBillingOfficeLandline2").val($(this).parent().parent().find(".billing_Landline2").val());
            $("#txtBillingOfficeFaxNo").val($(this).parent().parent().find(".billing_FaxNo").val());

        });

    }

    Friendly_Message(data)
    

}



Delete_Adress_callBack(data)
{
    
    Friendly_Message(data)
}

function RemoveBillingAddress(id) {
    $.ajax({
        url: '/crm/delete-customer',
        data: { customer_Address_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#Bill_tr_" + id).html("");
            Friendly_Message(data);
        }
    });
}