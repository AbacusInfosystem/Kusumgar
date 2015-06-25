function SearchVendors() {
   
    var vViewModel = {

        Filter: {

             Vendor_Id: $('#hdnVendorId').val(),
             Vendor_Name: $('#txtVendorName').val(),
             Material_Id: $('#hdfMaterial_Id').val(),
             Material_Name: $('#txtMaterialName').val()
            
               },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
        },
    };

    $("#divSearchGridOverlay").show();
    
    CallAjax("/Vendor/Get_Vendors", "json", JSON.stringify(vViewModel), "POST", "application/json", false,BindVendorInGrid, "", null);
}

function GetAllVendors() {

    var vViewModel = {

        Filter: {
           //Vendor_Id:"",
            //Vendor_Name :""
            Material_Id: $('#hdfMaterial_Id').val(),
            Material_Name: $('#txtMaterialName').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Vendor/Get_Vendors", "json", JSON.stringify(vViewModel), "POST", "application/json", false,BindVendorInGrid, "", null);
}

function BindVendorInGrid(data, mode) {

    $('#tblSearchVendor tr.subhead').html("");

    var htmlText = "";
    if (data.Vendor_Grid.length > 0) {

        for (i = 0; i < data.Vendor_Grid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfVendorId_" + data.Vendor_Grid[i].Vendor_Id + "' value='" + data.Vendor_Grid[i].Vendor_Id + "' />";
        htmlText += "<input type='hidden' id='hdfVendor_Name_" + data.Vendor_Grid[i].Vendor_Name + "' value='" + data.Vendor_Grid[i].Vendor_Name + "' />";
           
        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        //htmlText += "<td>";

        htmlText += "<td id='Vendor_" + data.Vendor_Grid[i].Vendor_Id + "'>";     //

        htmlText += data.Vendor_Grid[i].Vendor_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Vendor_Grid[i].Email;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Vendor_Grid[i].HeadOfficeAddress;

        htmlText += "</td>";

        htmlText += "</tr>";
    }

    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblSearchVendor").find("tr:gt(0)").remove();

    $('#tblSearchVendor tr:first').after(htmlText);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {
           
            $("#hdfVendorId").val($(this).parents('tr').find('input[id^=hdfVendorId]').val());
            
            $("#hdVendor_Id").val($(this).parents('tr').find('input[id^=hdfVendorId]').val());
            $("#hdfVendor_Name").val($(this).parents('tr').find('input[id^=hdfVendor_Name]').val());

            $('#btnView').show();
            $('#btnEdit').show(); 
            $('#btnView_Material').show();
        }
    });

    $("#divSearchGridOverlay").hide();

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var vViewModel = {

        Filter: {

            Vendor_Id: $('#hdnVendorId').val(),
            Vendor_Name: $('#txtVendorName').val()

        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Vendor/Get_Vendors", "json", JSON.stringify(vViewModel), "POST", "application/json", false, BindVendorInGrid, "", null);

}


