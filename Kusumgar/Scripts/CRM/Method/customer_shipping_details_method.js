
function Save_Customer_shipping_details() {
    var cViewModel = set_Customer_Shipping_details();


    if ($("#hdn_Customer_shipping_Address_Id").val() == 0) {
        CallAjax("/crm/insert-customer-address/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Shipping_Details, "", null);
    }
    else {
        CallAjax("/crm/update-customer-address/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Shipping_Details, "", null);
    }
}


function set_Customer_Shipping_details() {
    var cViewModel =
        {
            Customer:
                {
                    Customer_Address:
                        {
                            Customer_Address_Entity:
                                {
                                    Address_Type: 2,

                                    Addresss: $("#txtShippingOfficeAddress").val(),

                                    Customer_Address_Id: $("#hdn_Customer_shipping_Address_Id").val(),

                                    Customer_Id: $("#hdnCustomer_Id").val(),

                                    FaxNo: $("#txtShippingOfficeFaxNo").val(),

                                    Landline1: $("#txtShippingOfficeLandline1").val(),

                                    landline2: $("#txtShippingOfficeLandline2").val()
                                }

                        }
                }
        }

    return cViewModel;
}

function Bind_Shipping_Details(data) {

    var htmlText = "";


    if (data.Customer.Customer_Address_List.length > 0) {

        for (var i = 0; i < data.Customer.Customer_Address_List.length; i++) {
            if (data.Customer.Customer_Address_List[i].Customer_Address_Entity.Address_Type == 2) {
                htmlText += " <tr id='Ship_tr_"+data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id+"'>";

                htmlText += "<td>" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Addresss + "</td>";

                htmlText += "<td>";

                htmlText += "<input type='hidden' class='hdn_Customer_shipping_Address_Id' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id + "'>";

                htmlText += "<input type='hidden' class='shipping_Address' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Addresss + "'>";

                htmlText += "<input type='hidden' class='shipping_Landline1' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Landline1 + "'>";

                htmlText += "<input type='hidden' class='shipping_Landline2' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.landline2 + "'>";

                htmlText += "<input type='hidden' class='shipping_FaxNo' value='" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.FaxNo + "'>";

                htmlText += "<div class='btn-group pull-right'>";

                htmlText += "<button type='button' id='btnEdit' class='btn btn-info btn-sm btn-Shipping'><i class='fa fa-pencil-square-o'></i></button>";

                htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm ' onclick='RemoveShippingAddress(" + data.Customer.Customer_Address_List[i].Customer_Address_Entity.Customer_Address_Id + ")'><i class='fa fa-times'></i></button>";

                htmlText += "</div>";

                htmlText += "</td>";

                htmlText += " </tr>";
            }
        }
        $("#tblShipping_Details").find("tr:gt(0)").remove();


        $('#tblShipping_Details tr:first').after(htmlText);

        $("#hdn_Customer_shipping_Address_Id").val(0);

        $("#txtShippingOfficeAddress").val("");
        $("#txtShippingOfficeLandline1").val("");
        $("#txtShippingOfficeLandline2").val("");
        $("#txtShippingOfficeFaxNo").val("");

        $('.btn-Shipping').click(function () {
            $("#hdn_Customer_shipping_Address_Id").val($(this).parent().parent().find(".hdn_Customer_shipping_Address_Id").val());
            $("#txtShippingOfficeAddress").val($(this).parent().parent().find(".shipping_Address").val());
            $("#txtShippingOfficeLandline1").val($(this).parent().parent().find(".shipping_Landline1").val());
            $("#txtShippingOfficeLandline2").val($(this).parent().parent().find(".shipping_Landline2").val());
            $("#txtShippingOfficeFaxNo").val($(this).parent().parent().find(".shipping_FaxNo").val());

        });
    }



    Friendly_Message(data)
}


function RemoveShippingAddress(id) {
    $.ajax({
        url: '/crm/delete-customer',
        data: { customer_Address_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#Ship_tr_"+id).html("");
            Friendly_Message(data);
        }
    });
}
