function SearchDefects() {
   
 var dViewModel = {

        Filter: {

             Defect_Id: $('#hdnDefectId').val(),

             Process_Id: $("#hdfProcessId").val(),
   
               },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
           },
 };

$("#divSearchGridOverlay").show();

CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function GetAllDefects() {
   
    var dViewModel = {

        Filter: {

            Defect_Id :"",
            Process_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val()
            },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {
 
    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";
    if (data.DefectGrid.length > 0) {
        for (i = 0; i < data.DefectGrid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='hidden' id='hdfDefectId_" + data.DefectGrid[i].Defect_Id + "' value='" + data.DefectGrid[i].Defect_Id + "' />";

            htmlText += "<input type='radio' name='r1' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].Process_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].Defect_Major;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].Defect_Minor;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].Defect_Name;

            htmlText += "</td>";

            if (data.DefectGrid[i].Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.DefectGrid[i].Status == false) {
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

        htmlText += "<td colspan=5>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

   
    $("#tblSearchDefect").find("tr:gt(0)").remove();

    $('#tblSearchDefect tr:first').after(htmlText);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);


    if (data.DefectGrid.length > 0) {
        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else
    {
        $('.pagination').html("");
    }


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $("#hdfDefectId").val($(this).parents('tr').find('input[id^=hdfDefectId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

    $('#btnEdit').hide();

    }

function PageMore(Id) {
    
    $('#btnEdit').hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));
   
    var dViewModel = {

        Filter: {

            Defect_Id: $('#hdnDefectId').val(),

            Process_Id: $("#hdfProcessId").val(),

        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
           },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
    
}