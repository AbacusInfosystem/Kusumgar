function SearchDefectTypeForTable() {
   
    var dViewModel = {

        Filter: {

            Process_Id: $('#drpProcessName').val(),

        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Grid_By_Process_Id", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {

    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";

    if (data.DefectGrid.length > 0) {

        for (i = 0; i < data.DefectGrid.length; i++) {

            htmlText += "<tr>";

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
    else {
        htmlText += "<tr>";
        htmlText += "<td colspan='4'>";

        htmlText += "No Records";

        htmlText += "</td>";
        htmlText += "</tr>";
       }
    $("#tblSearchDefect").find("tr:gt(0)").remove();

    $('#tblSearchDefect tr:first').after(htmlText);

}

