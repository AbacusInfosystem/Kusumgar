function SearchDefectTypeForTable() {
   
    var dViewModel = {

        Filter: {

            Defect_Type_Id: $('#drpDefectTypeName').val(),

        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Grid_By_Defect_Type", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {

    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";

    if (data.DefectGrid.length > 0) {

        for (i = 0; i < data.DefectGrid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].Defect_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].DefectEntity.Defect_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.DefectGrid[i].DefectEntity.Defect_Name;

            htmlText += "</td>";

            if (data.DefectGrid[i].DefectEntity.Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.DefectGrid[i].DefectEntity.Status == false) {

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

