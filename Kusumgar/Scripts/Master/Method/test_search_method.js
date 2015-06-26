function SearchTests() {

    var tViewModel = {

        Filter: {  

            Process_Id: $('#hdfProcessId').val()
        },
    
        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
            },
 };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/Get_Tests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);
}

function GetAllTests() {

    var tViewModel = {

        Filter: {

            Process_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
           },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/Get_Tests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);
}

function BindTestInGrid(data, mode) {

    $('#tblSearchTest tr.subhead').html("");

    var htmlText = "";

    if (data.Test_Grid.length > 0) {
        for (i = 0; i < data.Test_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' id='hdfTestId_" + data.Test_Grid[i].Test_Id + "' value='" + data.Test_Grid[i].Test_Id + "' />";

            htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Process_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name2;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name3;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name4;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name5;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name6;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name7;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name8;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name9;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Grid[i].Test_Unit_Name10;

            htmlText += "</td>";

            if (data.Test_Grid[i].Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.Test_Grid[i].Status == false) {

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

        htmlText += "<td colspan='10'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

    $("#tblSearchTest").find("tr:gt(0)").remove();

    $('#tblSearchTest tr:first').after(htmlText);

    if (data.Test_Grid.length > 0) {

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

            //alert("ID " + $(this).parents('tr').find('input[id^=hdfTestId]').val())

            $("#hdfTestId").val($(this).parents('tr').find('input[id^=hdfTestId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

    $('#btnEdit').hide();
}

function PageMore(Id) {

    $('#btnEdit').hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var tViewModel = {

        Filter: {

            Process_Id: $('#hdfProcessId').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
   
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Test/Get_Tests", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestInGrid, "", null);
}