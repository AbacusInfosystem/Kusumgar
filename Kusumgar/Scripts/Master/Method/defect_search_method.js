function SearchDefects() {
   
 var dViewModel = {

        Filter: {

             DefectName: $('#txtDefectName').val(),

             DefectTypeName: $("#hdfDefectTypeId").val(),
   
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(1),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/GetDefects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function GetAllDefects() {
   
    var dViewModel = {

        Filter: {

            DefectTypeName: $("#hdfDefectTypeId").val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/GetDefects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {
 
    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.DefectGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfDefectId_" + data.DefectGrid[i].DefectId + "' value='" + data.DefectGrid[i].DefectId + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].DefectTypeName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].DefectCode;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].DefectName;

        htmlText += "</td>";

        if (data.DefectGrid[i].Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.DefectGrid[i].Status == false)
        {
            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }

   
    $("#tblSearchDefect").find("tr:gt(0)").remove();

    $('#tblSearchDefect tr:first').after(htmlText);

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

            alert("ID " + $(this).parents('tr').find('input[id^=hdfDefectId]').val())
 
            $("#hdfDefectId").val($(this).parents('tr').find('input[id^=hdfDefectId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

    }

function PageMore(Id) {
    
    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var dViewModel = {

        Filter: {

                DefectName : $('#txtDefectName').val(),
                DefectTypeName: $('#drpDefectTypeName').val(),
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/GetDefects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
   
}