function SearchTestUnits() {
 
    var tViewModel = {

        Filter: {
            Test_Unit_Id: $('#hdnTestUnitId').val(),
            Test_Unit_Name: $('#txtTestUnitName').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
       },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/Get_Test_Units", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);
}

function GetAllTestUnits() {
   
    var tViewModel = {

        Filter: {
            Test_Unit_Id:"",
            Test_Unit_Name: ""
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
         },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/Get_Test_Units", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);
}

function BindTestUnitInGrid(data, mode) {

    $('#tblSearchTestUnit tr.subhead').html("");

    var htmlText = "";

    if (data.Test_Unit_Grid.length > 0) {

        for (i = 0; i < data.Test_Unit_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' id='hdfTestUnitId_" + data.Test_Unit_Grid[i].TestUnitEntity.Test_Unit_Id + "' value='" + data.Test_Unit_Grid[i].TestUnitEntity.Test_Unit_Id + "' />";

            htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Test_Unit_Grid[i].TestUnitEntity.Test_Unit_Name;

            htmlText += "</td>";

            if (data.Test_Unit_Grid[i].TestUnitEntity.Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.Test_Unit_Grid[i].TestUnitEntity.Status == false) {

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

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblSearchTestUnit").find("tr:gt(0)").remove();

    $('#tblSearchTestUnit tr:first').after(htmlText);

    if (data.Test_Unit_Grid.length > 0) {

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
            Test_Unit_Id: $('#hdnTestUnitId').val(),
            Test_Unit_Name: $('#txtTestUnitName').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
         },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/TestUnit/Get_Test_Units", "json", JSON.stringify(tViewModel), "POST", "application/json", false, BindTestUnitInGrid, "", null);
}