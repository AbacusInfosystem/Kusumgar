function SearchTestUnits() {
 
    var tViewModel = {

        Filter: {

            TestUnitName: $('#txtTestUnitName').val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(1),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/GetTestUnits", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);
}

function GetAllTestUnits() {

    var tViewModel = {

        Filter: {

            TestUnitName: ""
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/GetTestUnits", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);
}

function BindTestUnitInGrid(data, mode) {

    $('#tblSearchTestUnit tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.TestUnitGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfTestUnitId_" + data.TestUnitGrid[i].TestUnitId + "' value='" + data.TestUnitGrid[i].TestUnitId + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.TestUnitGrid[i].TestUnitName;

        htmlText += "</td>";

        if (data.TestUnitGrid[i].Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.TestUnitGrid[i].Status == false) {
            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }
    $("#tblSearchTestUnit").find("tr:gt(0)").remove();

    $('#tblSearchTestUnit tr:first').after(htmlText);

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

            alert("ID " + $(this).parents('tr').find('input[id^=hdfTestUnitId]').val())

            $("#hdfTestUnitId").val($(this).parents('tr').find('input[id^=hdfTestUnitId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();
}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var tViewModel = {

        Filter: {

            TestUnitName: $('#txtTestUnitName').val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/GetTestUnits", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);

}