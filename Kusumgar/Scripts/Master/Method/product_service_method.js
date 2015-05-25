function Save_Product_Service_Details() {
    var vViewModel = Set_Product_Service();

    if ($("#hdnProductVendorId").val() == 0) {

        CallAjax("/master/insert-product-service/", "json", JSON.stringify(vViewModel), "POST", "application/json", false, Bind_Product_Service_Details, "", null);
    }
    else {
        CallAjax("/master/update-product-service/", "json", JSON.stringify(vViewModel), "POST", "application/json", false, Bind_Product_Service_Details, "", null);
    }

}

function Set_Product_Service() {
    var vViewModel =
        {
            Product_Vendor:
                {
                    Product_Vendor_Entity:
                        {
                            Product_Vendor_Id: $("#hdnProductVendorId").val(),
                            Vendor_Id :$("#hdnVendorId").val(),
                            Product_Type :$("#drpProductType").val(),
                            Name :$("#txtProductServicesName").val(),
                            Original_Manufacturer:$("#hdnOriginalManufacture").val(),
                           
                            Inspection_Facility:$("#txtInspectionFacility").val(),
                            Testing_Facility: $("#txtTestingFacility").val()
                        }
                }
        }
    return vViewModel;
}

function Bind_Product_Service_Details(data) {

    var htmlText = "";

    if (data.Product_Vendor_Grid.length > 0) {

        for (var i = 0; i < data.Product_Vendor_Grid.length; i++) {

            htmlText += "<tr id='tr_ivendor_" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Product_Vendor_Id + "'>";

            htmlText += "<td>";

            htmlText += data.Product_Vendor_Grid[i].Product_Vendor_Entity.Name;
             
            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Vendor_Grid[i].Product_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' class='hdn_Product_Vendor_Id' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Product_Vendor_Id + "'>";

            htmlText += "<input type='hidden' class='Product_Service_Name' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Name + "'>";

            htmlText += "<input type='hidden' class='Product_Type' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Product_Type + "'>";

            htmlText += "<input type='hidden' class='Testing_Facility' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Testing_Facility + "'>";

            htmlText += "<input type='hidden' class='Inspection_Facility' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Inspection_Facility + "'>";

            htmlText += "<input type='hidden' class='Original_Manufacture' value='" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Original_Manufacturer + "'>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnEdit' class='btn btn-info btn-sm btn-product-service'><i class='fa fa-pencil-square-o'></i></button>";

            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveProductService(" + data.Product_Vendor_Grid[i].Product_Vendor_Entity.Product_Vendor_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";

        }
    }
        $("#tblProductServiceDetails").find("tr:gt(0)").remove();


        $('#tblProductServiceDetails tr:first').after(htmlText);

       $("#hdnProductVendorId").val(0);

        $("#txtProductServicesName").val("");

        $("#drpProductType").val("");

        $("#txtTestingFacility").val("");
     
        $("#txtInspectionFacility").val("");
     
        $("#hdnOriginalManufacture").val("");

        $('.btn-product-service').click(function () {

            $("#hdnProductVendorId").val($(this).parent().parent().find(".hdn_Product_Vendor_Id").val());
            $("#txtProductServicesName").val($(this).parent().parent().find(".Product_Service_Name").val());
            $("#txtTestingFacility").val($(this).parent().parent().find(".Testing_Facility").val());
            $("#txtInspectionFacility").val($(this).parent().parent().find(".Inspection_Facility").val());
            $("#drpProductType").val($(this).parent().parent().find(".Product_Type").val());

            if ($(this).parent().parent().find(".Original_Manufacture").val() == "true") {

                $("#rdOriginalManufacturer").parent().addClass("checked");
                $("#rdNotOriginalManufacturer").parent().removeClass("checked");
                   }

            else {
                
                $("#rdOriginalManufacturer").parent().removeClass("checked");
                $("#rdNotOriginalManufacturer").parent().addClass("checked");
            }
        });

     
      Friendly_Message(data)
}

function RemoveProductService(id) {
    $.ajax({
        url: '/master/delete-product-service',
        data: { Product_Vendor_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#tr_ivendor_"+ id).html("");
            Friendly_Message(data);
        }
    });
}


