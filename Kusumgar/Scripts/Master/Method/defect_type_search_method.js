function SearchDefectTypes() {
   
    var dViewModel = {

        Filter: {

            DefectTypeName: $('#txtDefectTypeName').val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(1),

            PageSize: $('#hdfPageSize').val(),
        },

    };
    
    $("#divSearchGridOverlay").show();

    CallAjax("/DefectType/GetDefectTypes", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
}

function GetAllDefectTypes() {

    var dViewModel = {

        Filter: {

            DefectTypeName: ""
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/DefectType/GetDefectTypes", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
}

function BindDefectTypeInGrid(data, mode) {
 
 $('#tblSearchDefectType tr.subhead').html("");

 var htmlText = "";

    for (i = 0; i < data.DefectTypeGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfDefectTypeId_" + data.DefectTypeGrid[i].DefectTypeId + "' value='" + data.DefectTypeGrid[i].DefectTypeId + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectTypeGrid[i].DefectTypeName;

        htmlText += "</td>";

        if (data.DefectTypeGrid[i].Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.DefectTypeGrid[i].Status == false)
        {
            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }

   
    $("#tblSearchDefectType").find("tr:gt(0)").remove();

    $('#tblSearchDefectType tr:first').after(htmlText);

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

            alert("ID " + $(this).parents('tr').find('input[id^=hdfDefectTypeId]').val())

            $("#hdfDefectTypeId").val($(this).parents('tr').find('input[id^=hdfDefectTypeId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();
}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var dViewModel = {

        Filter: {

            DefectTypeName: $('#txtDefectTypeName').val()
        },

        Pager: {

            IsPagingRequired: $('#hdfIsPagingRequired').val(),

            CurrentPage: $('#hdfCurrentPage').val(),

            PageSize: $('#hdfPageSize').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/DefectType/GetDefectTypes", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
   
}