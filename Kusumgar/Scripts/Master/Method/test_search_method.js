function SearchTests() {

    var tViewModel = {

        Filter: {  

            FabricTypeName: $('#hdfFabricTypeId').val()
        },
    
        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(1),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/GetTests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);
}

function GetAllTests() {

    var tViewModel = {

        Filter: {

           FabricTypeName: ""
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/GetTests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);
}

function BindTestInGrid(data, mode) {

    $('#tblSearchTest tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.TestGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfTestId_" + data.TestGrid[i].TestId + "' value='" + data.TestGrid[i].TestId + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].FabricTypeName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName1;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName2;

        htmlText += "</td>";
        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName3;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName4;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName5;

        htmlText += "</td>";
        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName6;

        htmlText += "</td>";
        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName7;

        htmlText += "</td>";
        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName8;

        htmlText += "</td>";
        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName9;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestGrid[i].TestUnitName10;

        htmlText += "</td>";

        if (data.TestGrid[i].Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.TestGrid[i].Status == false) {

            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }

    $("#tblSearchTest").find("tr:gt(0)").remove();

    $('#tblSearchTest tr:first').after(htmlText);

   

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

            alert("ID " + $(this).parents('tr').find('input[id^=hdfTestId]').val())

            $("#hdfTestId").val($(this).parents('tr').find('input[id^=hdfTestId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();
}

function PageMore(Id) {


    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var tViewModel = {

        Filter: {

            FabricTypeName: $('#hdfFabricTypeId').val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/GetTests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);

}