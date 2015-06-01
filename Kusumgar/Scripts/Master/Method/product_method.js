function Save_Product_Details() {
    var pViewModel = Set_Product();

    if ($("#hdnProduct_Id").val() == 0) {
        CallAjax("/master/insert-product/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Product_Data_Callback, "", null);
    }
    else {
        CallAjax("/master/update-product/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Product_Data_Callback, "", null);
    }
}

function Bind_Product_Data_Callback(data) {
    $("#hdnProduct_Id").val(data.Product.Product_Entity.Product_Id);

    $("#tabProductVendor").show();

    Friendly_Message(data);
}

function Set_Product() {
    var pViewModel =
        {
            Product:
                {
                    Product_Entity:
                        {
                            Product_Id: $("#hdnProduct_Id").val(),

                            Product_Code: $("#txtProductCode").val(),

                            Product_Category_Id: $("#drpProdCatName").val(),

                            Product_SubCategory_Id: $("#drpSubCatName").val(),

                            Product_Name: $("#txtProductName").val(),

                            Size: $("#txtSize").val(),

                            COD: $("#txtCOD").val(),

                            Product_Type: $("#drpProdType").val(),

                            Original_Manufacturer: $("#hdnIs_OrigMan").val(),

                            Inspection_Facility: $("#txtInspFacility").val(),

                            Testing_Facility: $("#txtTestFacility").val()
                        }
                }
        }
    return pViewModel;
}

function Bind_SubCategories(data) {
    $("#drpSubCatName").html("");

    var htmltext = "";

    htmltext += "<option>--Select--</option>";

    if (data.length > 0) {
        for (var i = 0; i < data.length ; i++) {
            htmltext += "<option value='" + data[i].Product_SubCategory_Entity.Product_SubCategory_Id + "'>" + data[i].Product_SubCategory_Entity.Product_SubCategory_Name + "</option>";
        }
    }
    $("#drpSubCatName").html(htmltext);
}

function Save_Product_Vendor()
{
    var pViewModel = Set_Product_Vendor();

    if ($("#hdnProduct_Vendor_Id").val() == 0) {
        CallAjax("/master/insert-product-vendor/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Product_Vendor_Data_Callback, "", null);
    }
    //else {
    //    CallAjax("/master/update-industrial-master/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Data_Callback, "", null);
    //}
}

function Bind_Product_Vendor_Data_Callback(data)
{
    //$("#hdnProduct_Vendor_Id").val(data.Product_Vendor.Product_Vendor_Entity.Product_Vendor_Id);    
    var htmlText = "";
    
    for (i = 0; i < data.Product_Vendors.length; i++) {
        
        htmlText += "<tr id='tr_pvendor_" + data.Product_Vendors[i].Product_Vendor_Entity.Product_Vendor_Id + "'>";
        
        htmlText += "<td>";

        htmlText += data.Product_Vendors[i].Vendor_Name;
        
        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Product_Vendors[i].Product_Vendor_Entity.Priority_Order;
        
        htmlText += "</td>";        

        htmlText += "<td>";

        htmlText += "<div class='btn-group pull-right'>";

        htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveVendor(" + data.Product_Vendors[i].Product_Vendor_Entity.Product_Vendor_Id + ")'><i class='fa fa-times'></i></button>";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblProdVenGrid").find("tr:gt(0)").remove();

    $('#tblProdVenGrid tr:first').after(htmlText);    

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    $("#divSearchGridOverlay").hide();

    $("#hdnProduct_Vendor_Id").val(0);

    $("#txtVendorName").val("");
    $("#drpPriorityOrder").val("");

    Friendly_Message(data);
}

function Set_Product_Vendor()
{
    var pViewModel =
        {
            Product_Vendor:
                {
                    Product_Vendor_Entity:
                        {
                            Product_Vendor_Id: $("#hdnProduct_Vendor_Id").val(),

                            Product_Id: $("#hdnProduct_Id").val(),

                            Vendor_Id: $("#hdnVendor_Id").val(),

                            Priority_Order: $("#drpPriorityOrder").val()
                            
                        }
                }
        }
    return pViewModel;
}

function RemoveVendor(id) {
    
    $.ajax({
        url: '/master/delete-product-vendor',
        data: { product_Vendor_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            
            $("#tr_pvendor_" + id).html("");
            Friendly_Message(data);
        }        
    });
}