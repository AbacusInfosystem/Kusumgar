function SearchAttributeCodes() {

    var aViewModel = {

        Filter: {
            
          AttributeId: $("#hdfAttributeId").val(),

        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(1),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/GetAttributeCodes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function GetAllAttributeCodes() {

    var aViewModel = {

        Filter: {

            AttributeId: ""
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/GetAttributeCodes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function BindAttributeCodesInGrid(data, mode) {
   
    $('#tblSearchAttributeCode tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.AttributeCodeGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfAttributeCodeId_" + data.AttributeCodeGrid[i].AttributeCodeId + "' value='" + data.AttributeCodeGrid[i].AttributeCodeId + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.AttributeCodeGrid[i].AttributeCodeName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.AttributeCodeGrid[i].AttributeName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.AttributeCodeGrid[i].Code;

        htmlText += "</td>";

        if (data.AttributeCodeGrid[i].Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.AttributeCodeGrid[i].Status == false) {
            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }


    $("#tblSearchAttributeCode").find("tr:gt(0)").remove();

    $('#tblSearchAttributeCode tr:first').after(htmlText);

    $('#hdfPageSize').val(data.Pager.PageSize);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    $('#hdfIsPagingRequired').val(data.Pager.IsPagingRequired);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            alert("ID " + $(this).parents('tr').find('input[id^=hdfAttributeCodeId]').val())

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

            AttributeId: $("#hdfAttributeId").val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/GetAttributeCodes", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);

}