// Start : Enquiry 
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

function Enquiry_CallBack(data) {
    $("#tabStaggered").show();
    if (data.Enquiry.Quality_Id == 0) {
        $("#tabCustomer_Quality").show();
    }
    $("#tabQuality_Supporting").show();
    $("#tabFuncational_Visual").show();
    $("#hdnEnquiry_Id").val(data.Enquiry.Enquiry_Id);
    $("#hdnEnquiry_No").val(data.Enquiry.Enquiry_No);

    Friendly_Message(data);
}

// End : Enquiry 


// Start : Staggered Order 
function Save_Staggered_Order()
{
    var eViewModel = Set_Enquiry();

    if($("#hdnStaggered_Order_Id").val() ==0)
    {
        CallAjax("/sales/insert-staggered-order/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Staggered_CallBack, "", null);
    }
    else
    {
        CallAjax("/sales/update-staggered-order/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Staggered_CallBack, "", null);
    }
}

function Get_Staggered_Order()
{
    var eViewModel = Set_Enquiry();

    if ($("#hdnEnquiry_Id").val() != 0) {

        CallAjax("/sales/get-staggered-orders/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Staggered_Order_Grid, "", null);
    }
}

function Staggered_CallBack(data)
{
    Friendly_Message(data);
    Get_Staggered_Order();

}

function Bind_Staggered_Order_Grid(data)
{
    var htmlText = "";

    

    if (data.Enquiry.Staggered_Orders.length > 0) {

        for (var i = 0; i < data.Enquiry.Staggered_Orders.length ; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.Enquiry.Staggered_Orders[i].Quantity;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.Enquiry.Staggered_Orders[i].Delivery_Date);

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += " <button type='button' id='btnRemove' class='btn btn-danger btn-xs' onclick='Remove_Staggered_Order(" + data.Enquiry.Staggered_Orders[i].Staggered_Order_Id + ")'><i class='fa fa-remove'></i></button>";

            htmlText += "</td>";

            htmlText += "</tr>";
        }

        $("#tblStaggered_Order").find("tr:gt(0)").remove();

        $('#tblStaggered_Order tr:first').after(htmlText);

        $("#hdnOrder_No").val("");

        $("#hdnOrder_Status").val("");

        $("#txtQuantity").val("");

        $("#DtDelivery_Date").val("");

    }
    else
    {
        $("#tblStaggered_Order").find("tr:gt(0)").remove();
    }

}

function Remove_Staggered_Order(id)
{
    $.ajax({
        url: '/sales/delete-staggered-order-by-id',
        data: { staggered_Order_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            Get_Staggered_Order();
            Friendly_Message(data);
        }
    });
}
 
// End : Staggered Order

function Set_Enquiry()
{
    var eViewModel =
    {
        Enquiry:
            {
                Enquiry_Id: $("#hdnEnquiry_Id").val(),

                Enquiry_No: $("#hdnEnquiry_No").val(),

                Enquiry_Type_Id: $("#hdnEnquiry_Type_Id").val(),

                Enquiry_Status_Id: $("#hdnEnquiry_Status_Id").val(),

                Customer_Id: $("#hdnCustomer_Id").val(),

                Quality_Id: $("#hdnQuality_Id").val(),

                PPC_Article_Type_Id:0,

                Quality_Set_Id: 0,

                Is_Active: $("#hdnStatus").val(),

                Staggered_Order:
                    {
                        Enquiry_Id: $("#hdnEnquiry_Id").val(),

                        Order_No: $("#hdnOrder_No").val(),

                        Order_Status: $("#hdnOrder_Status").val(),

                        Quantity: $("#txtQuantity").val(),

                        Delivery_Date: $("#DtDelivery_Date").val(),

                        Is_Active: $("#hdnStatus").val()
                    }
            }
    }

    return eViewModel;
}

