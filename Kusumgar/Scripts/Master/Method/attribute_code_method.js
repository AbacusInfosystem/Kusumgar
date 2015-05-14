function SearchAttributeCodeForTable() {

    var aViewModel = {

        Filter: {

            AttributeId: $("#drpAttributeCode").val(),

        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/GetGridByAttributeName", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function BindAttributeCodesInGrid(data, mode) {

    $('#tblAttributeCode tr.subhead').html("");

    var htmlText = "";

    if (data.AttributeCodeGrid.length > 0) {

        for (i = 0; i < data.AttributeCodeGrid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.AttributeCodeGrid[i].AttributeCodeName;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.AttributeCodeGrid[i].AttributeName;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.AttributeCodeGrid[i].Code;

            htmlText += "</td>";

            if (data.AttributeCodeGrid[i].Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.AttributeCodeGrid[i].Status == false) {

                htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }

    }

 else {
        alert("GG");
        htmlText += "<tr>";
        htmlText += "<td colspan='4'>";

        htmlText += "No Records";

        htmlText += "</td>";
        htmlText += "</tr>";
        }

    $("#tblAttributeCode").find("tr:gt(0)").remove();

    $('#tblAttributeCode tr:first').after(htmlText);

}

