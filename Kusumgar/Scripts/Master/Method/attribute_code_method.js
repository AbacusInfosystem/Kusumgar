function SearchAttributeCodeForTable() {

    var aViewModel = {

        Filter: {

            Attribute_Id: $("#drpAttributeCode").val(),

        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/AttributeCode/Get_Grid_By_Attribute_Name", "json", JSON.stringify(aViewModel), "POST", "application/json", false, BindAttributeCodesInGrid, "", null);
}

function BindAttributeCodesInGrid(data, mode) {

    $('#tblAttributeCode tr.subhead').html("");

    var htmlText = "";

    if (data.Attribute_Code_Grid.length > 0) {

        for (i = 0; i < data.Attribute_Code_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].AttributeCodeEntity.Attribute_Code_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].Attribute_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Attribute_Code_Grid[i].AttributeCodeEntity.Code;

            htmlText += "</td>";

            if (data.Attribute_Code_Grid[i].AttributeCodeEntity.Status == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.Attribute_Code_Grid[i].AttributeCodeEntity.Status == false) {

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

    $("#tblAttributeCode").find("tr:gt(0)").remove();

    $('#tblAttributeCode tr:first').after(htmlText);

}

