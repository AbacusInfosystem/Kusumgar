function Save_Consumable_Details() {

    var ConsumableVM = Get_Consumable_values();
   
    //CallAjax("/master/insert-Consumable", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, Consumable_CallBack, "", null);
    if ($("#hdnConsumable_Id").val() == 0) {
     
        CallAjax("/master/insert-consumable", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, Consumable_CallBack, "", null);
    }
    else {
        CallAjax("/master/update-consumable", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, Consumable_CallBack, "", null);
    }
}
function Consumable_CallBack(data) {
   
    $("#hdnConsumable_Id").val(data.Consumable.Consumable_Id);

    $("#Vendor_Tab").show();
 
    Friendly_Message(data);
}
function Get_Consumable_values() {
   
    var ConsumableVM =
        {
            Consumable:
                {
                    Category_Id: $("#ddlCategoryName").val(),
                    SubCategory_Id: $("#ddlSubCategoryName").val(),

                    
                            Consumable_Id: $("#hdnConsumable_Id").val(),
                            Material_Name: $("#txtMaterialName").val(),
                            Material_Code: $("#txtMaterialCode").val(),
                            IsActive: $("#hdnIs_Active").val()

                        
                }
        }

    return ConsumableVM;
}

//For Vendor
function Save_Consumable_Vendor_Details() {

    var ConsumableVM = Get_Consumable_Vendor_values();
    
    if ($("#hdnConsumable_Vendor_Id").val() == 0) {
     
        CallAjax("/master/insert-consumable_vendor", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, Consumable_Vendor_CallBack, "", null);
    }
    else {
        CallAjax("/master/update-consumable_vendor", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, Consumable_Vendor_CallBack, "", null);
    }

}

function Consumable_Vendor_CallBack(data) {
   
    var htmlText = "";
    
    if (data.Consumable.Consumable_Vendors.length > 0) {
     
        for (var i = 0; i < data.Consumable.Consumable_Vendors.length; i++) {

            htmlText += " <tr id='tr_vendor_" + data.Consumable.Consumable_Vendors[i].Consumable_Vendor_Id + "'>";

            //htmlText += "<td>";
            //htmlText += data.Consumable.Consumable_Vendors[i].Consumable_Vendor_Id;
            //htmlText += "</td>";

            htmlText += "<td>";
            //htmlText += data.Consumable.Consumable_Vendors[i].Vendor_Id;
            htmlText += data.Consumable.Consumable_Vendors[i].Vendor_Name;
            htmlText += "</td>";

            //htmlText += "<td>";
            //htmlText += data.Consumable.Consumable_Vendors[i].Consumable_Id;
            //htmlText += "</td>";

            htmlText += "<td>";
            htmlText += data.Consumable.Consumable_Vendors[i].Priority_Order;
            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' class='hdn_Consumable_Vendor_Id' value='" + data.Consumable.Consumable_Vendors[i].Consumable_Vendor_Id + "'>";
            //htmlText += "<input type='hidden' class='Vendor_Id_By_Name' value='" + data.Consumable.Consumable_Vendors[i].Vendor_Id + "'>";
            htmlText += "<input type='hidden' class='Vendor_Id_By_Name' value='" + data.Consumable.Consumable_Vendors[i].Vendor_Name + "'>";
            htmlText += "<input type='hidden' class='Priority_Order' value='" + data.Consumable.Consumable_Vendors[i].Priority_Order + "'>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnEditVendor' class='btn btn-info btn-xs btn-Vendor' onclick='EditVendors(" + data.Consumable.Consumable_Vendors[i].Consumable_Vendor_Id + ")'><i class='fa fa-pencil-square-o'></i></button>";
            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-xs' onclick='RemoveVendor(" + data.Consumable.Consumable_Vendors[i].Consumable_Vendor_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";

        }

        $("#tblConsumable_Vendor").find("tr:gt(0)").remove();

        $('#tblConsumable_Vendor tr:first').after(htmlText);
       
        $("#hdnConsumable_Vendor_Id").val(0);

        $("#txtSupplierName").val("");
        $("#txtPriorityOrder").val(0);
       
        
    }

    Friendly_Message(data);

}

function Get_Consumable_Vendor_values() {

    var ConsumableVM =
        {
            Consumable:
                {
                    
                            Consumable_Id: $("#hdnConsumable_Id").val(),
                        
                    Consumable_Vendor:
                        {
                            Consumable_Vendor_Entity:
                            {
                                Consumable_Vendor_Id: $("#hdnConsumable_Vendor_Id").val(),
                            
                                Vendor_Id: $("#hdnVendor_Id").val(),
                                Priority_Order: $("#txtPriorityOrder").val()
                         
                            }
                        }
                }
        }

    return ConsumableVM;
}

function EditVendors(id) {
    $("#txtSupplierName").val($("#tr_vendor_" + id).find(".Vendor_Id_By_Name").val());
    $("#txtPriorityOrder").val($("#tr_vendor_" + id).find(".Priority_Order").val());
    $("#hdnConsumable_Vendor_Id").val($("#tr_vendor_" + id).find(".hdn_Consumable_Vendor_Id").val());
}

function RemoveVendor(id) {
    $.ajax({
        url: '/master/delete-vendor',
        data: { consumable_Vendor_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#tr_vendor_" + id).html("");
            Friendly_Message(data);
        }
    });
}