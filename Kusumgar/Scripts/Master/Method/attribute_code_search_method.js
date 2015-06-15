function SearchAttributeCodes() {

    var aViewModel = {

        Filter: {
            
          Attribute_Id: $("#hdfAttributeId").val(),
                },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
               },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/Get_Attribute_Codes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function GetAllAttributeCodes() {

    var aViewModel = {

        Filter: {

            Attribute_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
             },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/Get_Attribute_Codes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function BindAttributeCodesInGrid(data, mode) {
   
    $('#tblSearchAttributeCode tr.subhead').html("");

    var htmlText = "";

    if (data.Attribute_Code_Grid.length > 0) {
        for (i = 0; i < data.Attribute_Code_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' id='hdfAttributeCodeId_" + data.Attribute_Code_Grid[i].Attribute_Code_Id + "' value='" + data.Attribute_Code_Grid[i].Attribute_Code_Id + "' />";

            htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].Attribute_Code_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].Attribute_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].Code;

            htmlText += "</td>";

            if (data.Attribute_Code_Grid[i].Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.Attribute_Code_Grid[i].Status == false) {

                htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }
    }
    else
    {
        htmlText += "<tr>";

        htmlText += "<td colspan ='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }


    $("#tblSearchAttributeCode").find("tr:gt(0)").remove();

    $('#tblSearchAttributeCode tr:first').after(htmlText);

    if (data.Attribute_Code_Grid.length > 0) {

        $('#hdfCurrentPage').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else
    {
        $('.pagination').html("");
    }

   $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            //alert("Id"+$(this).parents('tr').find('input[id^=hdfAttributeCodeId]').val());

            $("#hdfAttributeCodeId").val($(this).parents('tr').find('input[id^=hdfAttributeCodeId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var aViewModel = {

        Filter: {

            Attribute_Id: $("#hdfAttributeId").val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
              },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/Get_Attribute_Codes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);

}