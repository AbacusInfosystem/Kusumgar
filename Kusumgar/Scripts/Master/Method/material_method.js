function Save_Material_Details() {
    var mViewModel = Set_Material();

    if ($("#hdnMaterial_Id").val() == 0) {
        CallAjax("/master/insert-material/", "json", JSON.stringify(mViewModel), "POST", "application/json", false, Bind_Material_Data_Callback, "", null);
    }
    else {
        CallAjax("/master/update-material/", "json", JSON.stringify(mViewModel), "POST", "application/json", false, Bind_Material_Data_Callback, "", null);
    }
}

function Bind_Material_Data_Callback(data) {
    $("#hdnMaterial_Id").val(data.Material.Material_Id);

    $("#tabMaterialVendor").show();

    Friendly_Message(data);
}

function Set_Material() {
    var mViewModel =
        {
            Material:
                {
                    Material_Entity:
                        {
                            Material_Id: $("#hdnMaterial_Id").val(),

                            Material_Code: $("#txtMaterialCode").val(),

                            Material_Category_Id: $("#drpProdCatName").val(),

                            Material_SubCategory_Id: $("#drpSubCatName").val(),

                            Material_Name: $("#txtMaterialName").val(),

                            Size: $("#txtSize").val(),

                            COD: $("#txtCOD").val(),

                            Material_Type: $("#drpProdType").val(),

                            Original_Manufacturer: $("#hdnIs_OrigMan").val(),

                            Inspection_Facility: $("#txtInspFacility").val(),

                            Testing_Facility: $("#txtTestFacility").val()
                        }
                }
        }
    return mViewModel;
}

function Bind_SubCategories(data) {
    $("#drpSubCatName").html("");

    var htmltext = "";

    htmltext += "<option>--Select--</option>";

    if (data.length > 0) {
        for (var i = 0; i < data.length ; i++) {
            htmltext += "<option value='" + data[i].Material_SubCategory_Entity.Material_SubCategory_Id + "'>" + data[i].Material_SubCategory_Entity.Material_SubCategory_Name + "</option>";
        }
    }
    $("#drpSubCatName").html(htmltext);
}

function Save_Material_Vendor()
{
    var mViewModel = Set_Material_Vendor();

    if ($("#hdnMaterial_Vendor_Id").val() == 0) {
        CallAjax("/master/insert-material-vendor/", "json", JSON.stringify(mViewModel), "POST", "application/json", false, Bind_Material_Vendor_Data_Callback, "", null);
    }
    //else {
    //    CallAjax("/master/update-industrial-master/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Data_Callback, "", null);
    //}
}

function Bind_Material_Vendor_Data_Callback(data)
{
    //$("#hdnMaterial_Vendor_Id").val(data.Material_Vendor.Material_Vendor_Entity.Material_Vendor_Id);    
    var htmlText = "";
    
    for (i = 0; i < data.Material_Vendors.length; i++) {
        
        htmlText += "<tr id='tr_pvendor_" + data.Material_Vendors[i].Material_Vendor_Entity.Material_Vendor_Id + "'>";
        
        htmlText += "<td>";

        htmlText += data.Material_Vendors[i].Vendor_Name;
        
        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Material_Vendors[i].Material_Vendor_Entity.Priority_Order;
        
        htmlText += "</td>";        

        htmlText += "<td>";

        htmlText += "<div class='btn-group pull-right'>";

        htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-xs' onclick='RemoveVendor(" + data.Material_Vendors[i].Material_Vendor_Entity.Material_Vendor_Id + ")'><i class='fa fa-times'></i></button>";

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

    $("#hdnMaterial_Vendor_Id").val(0);

    $("#txtVendorName").val("");
    $("#drpPriorityOrder").val("");

    $("#txt_auto_Vendor_Name").val("");

    $("#hdnVendor_Id").val(0);

    InitializeAutoComplete($('#txt_auto_Vendor_Name'));

    Friendly_Message(data);
}

function Set_Material_Vendor()
{
    var mViewModel =
        {
            Material_Vendor:
                {
                    Material_Vendor_Entity:
                        {
                            Material_Vendor_Id: $("#hdnMaterial_Vendor_Id").val(),

                            Material_Id: $("#hdnMaterial_Id").val(),

                            Vendor_Id: $("#hdnVendor_Id").val(),

                            Priority_Order: $("#drpPriorityOrder").val()
                            
                        }
                }
        }
    return mViewModel;
}

function RemoveVendor(id) {
    
    $.ajax({
        url: '/master/delete-material-vendor',
        data: { Material_Vendor_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            
            $("#tr_pvendor_" + id).html("");
            Friendly_Message(data);
        }        
    });
}