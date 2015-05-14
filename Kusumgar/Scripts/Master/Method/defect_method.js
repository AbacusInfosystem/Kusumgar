function SearchDefectTypeForTable() {
   
    var dViewModel = {

        Filter: {

            DefectTypeName: $('#drpDefectTypeName').val(),

                },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/GetGridByDefectType", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {

    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";

    if (data.DefectGrid.length > 0) {
        for (i = 0; i < data.DefectGrid.length; i++) {

            htmlText += "<tr>";

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
            if (data.DefectGrid[i].Status == false) {
                htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }

    }
    else {

        htmlText += "<td colspan='4'>";

        htmlText += "No Records";

        htmlText += "</td>";
        
    }
    $("#tblSearchDefect").find("tr:gt(0)").remove();

    $('#tblSearchDefect tr:first').after(htmlText);

}