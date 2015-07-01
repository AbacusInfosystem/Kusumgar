function Save_Industrial_Details() {
    var iViewModel = Set_Industrial();

    if ($("#hdnIndustrial_Id").val() == 0) {
        CallAjax("/master/insert-industrial-master/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Data_Callback, "", null);
    }
    else
    {
        CallAjax("/master/update-industrial-master/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Data_Callback, "", null);
    }
}

function Bind_Industrial_Data_Callback(data)
{    
    $("#hdnIndustrial_Id").val(data.Industrial.Industrial_Master_Id);

    $("#tabIndustrialVendor").show();
    
    Friendly_Message(data);
}

function Set_Industrial()
{
    var iViewModel =
        {
            Industrial:
                {
                    
                            Industrial_Master_Id: $("#hdnIndustrial_Id").val(),

                            Industrial_Category_Id: $("#drpIndCatName").val(),

                            Industrial_Group_Id: $("#drpIndGroupName").val(),

                            Industrial_SubGrp_Name: $("#txtSubGroupName").val(),

                            Size: $("#txtSize").val(),

                            COD: $("#txtCOD").val()
                        
                }
        }
    return iViewModel;
}

function Bind_Groups(data)
{
    $("#drpIndGroupName").html("");

    var htmltext = "";

    htmltext += "<option>--Select--</option>";

    if (data.length > 0)
    {
        for (var i = 0; i < data.length ; i++)
        {
            htmltext += "<option value='" + data[i].Industrial_Group_Id + "'>" + data[i].Industrial_Group_Name + "</option>";            
        }
    }
    $("#drpIndGroupName").html(htmltext);
}

function Save_Industrial_Vendor()
{
    var iViewModel = Set_Industrial_Vendor();

    if ($("#hdnIndustrial_Vendor_Id").val() == 0) {
        CallAjax("/master/insert-industrial-vendor/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Vendor_Data_Callback, "", null);
    }
    //else {
    //    CallAjax("/master/update-industrial-master/", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Data_Callback, "", null);
    //}
}

function Bind_Industrial_Vendor_Data_Callback(data)
{
    //$("#hdnIndustrial_Vendor_Id").val(data.Industrial_Vendor.IndustrialVendorId);    
    var htmlText = "";
    
    for (i = 0; i < data.Industrial_Vendors.length; i++) {
        
        htmlText += "<tr id='tr_ivendor_" + data.Industrial_Vendors[i].Industrial_Vendor_Id + "'>";

        htmlText += "<td>";

        htmlText += data.Industrial_Vendors[i].Vendor_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrial_Vendors[i].Priority_Order;

        htmlText += "</td>";        

        htmlText += "<td>";

        htmlText += "<div class='btn-group pull-right'>";

        htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveVendor(" + data.Industrial_Vendors[i].Industrial_Vendor_Id + ")'><i class='fa fa-times'></i></button>";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblIndVenGrid").find("tr:gt(0)").remove();

    $('#tblIndVenGrid tr:first').after(htmlText);    

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    $("#divSearchGridOverlay").hide();

    $("#hdnIndustrial_Vendor_Id").val(0);

    $("#txtVendorName").val("");
    $("#drpPriorityOrder").val("");

    Friendly_Message(data);
}

function Set_Industrial_Vendor()
{
    var iViewModel =
        {
            Industrial_Vendor:
                {
                    
                            Industrial_Vendor_Id: $("#hdnIndustrial_Vendor_Id").val(),

                            Industrial_Master_Id: $("#hdnIndustrial_Id").val(),

                            Vendor_Id: $("#hdnVendor_Id").val(),

                            Priority_Order: $("#drpPriorityOrder").val()
                            
                        
                }
        }
    return iViewModel;
}

function RemoveVendor(id) {
    
    $.ajax({
        url: '/master/delete-industrial-vendor',
        data: { industrial_Vendor_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            
            $("#tr_ivendor_" + id).html("");
            Friendly_Message(data);
        }        
    });
}