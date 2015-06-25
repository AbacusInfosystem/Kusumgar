function SearchQuality() {

    var qViewModel = {

        Filter: {

            Yarn_Type_Id: $('#drpYarnType').val(),
               },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),

        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Quality/Get_Qualities", "json", JSON.stringify(qViewModel), "POST", "application/json", false, BindQualityInGrid, "", null);
}

function GetQualities() {

    var qViewModel = {

        Filter: {

            Yarn_Type_Id: $('#drpYarnType').val(),
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Quality/Get_Qualities", "json", JSON.stringify(qViewModel), "POST", "application/json", false, BindQualityInGrid, "", null);
}

function BindQualityInGrid(data, mode) {

    $('#tblSearchQuality tr.subhead').html("");

    var htmlText = "";

    if (data.Quality_Grid.length > 0) {

        for (i = 0; i < data.Quality_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' id='hdfQualityId_" + data.Quality_Grid[i].Quality_Id + "' value='" + data.Quality_Grid[i].Quality_Id + "' />";

            htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Minimum_Order_Size;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Ideal_Roll_Length;

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
    $("#tblSearchQuality").find("tr:gt(0)").remove();

    $('#tblSearchQuality tr:first').after(htmlText);

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
          
            //alert("ID " + $(this).parents('tr').find('input[id^=hdfQualityId]').val())

            $("#hdfQualityId").val($(this).parents('tr').find('input[id^=hdfQualityId]').val());
            $("#btnView").show();
            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

}

 function PageMore(Id) {

     $("#btnView").hide();

     $('#hdfCurrentPage').val((parseInt(Id) - 1));

        var qViewModel = {

            Filter: {

                Yarn_Type_Id: $('#drpYarnType').val(),
            },

            Pager: {

                CurrentPage: $('#hdfCurrentPage').val(),
            },
        };

        $("#divSearchGridOverlay").show();

        CallAjax("/Quality/Get_Qualities", "json", JSON.stringify(qViewModel), "POST", "application/json", false, BindQualityInGrid, "", null);
    }


