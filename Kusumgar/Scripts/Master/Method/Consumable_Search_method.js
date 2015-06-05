

function SearchAllConsumable() {

    var ConsumableVM =
        {
            Filter:
                {
                    
                    Category_Id: $("#ddlCategoryName").val(),
                    Material_Name: $('#txtMaterial_Name').val(),
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            }
        }

    $("#divSearchGridOverlay").show();
    
    CallAjax("/master/search-consumable", "json", JSON.stringify(ConsumableVM), "POST", "application/json", false, BindConsumableGrid, "", null);
   
}

function BindConsumableGrid(data) {

    $('#tblConsumableMasterGrid tr.subhead').html("");

    var htmlText = "";

    if (data.Consumables.length > 0) {

        for (i = 0; i < data.Consumables.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Consumables[i].Consumable_Entity.Consumable_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            //htmlText += "<td>";

            //htmlText += data.Consumables[i].Consumable_Entity.Consumable_Id;

            //htmlText += "</td>";

            htmlText += "<td>";

            //htmlText += data.Consumables[i].Consumable_Entity.Category_Id;
            htmlText += data.Consumables[i].Category_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            //htmlText += data.Consumables[i].Consumable_Entity.SubCategory_Id;
            htmlText += data.Consumables[i].SubCategory_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Consumables[i].Consumable_Entity.Material_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Consumables[i].Consumable_Entity.Material_Code;

            htmlText += "</td>";

            if (data.Consumables[i].Consumable_Entity.IsActive == true)
            {
                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            else
            {
                htmlText += "<td>";

                htmlText += "InActive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }
    }
    else
    {
        htmlText += "<tr>";

        htmlText += "<td colspan='6'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

    $("#tblConsumableMasterGrid").find("tr:gt(0)").remove();

    $('#tblConsumableMasterGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Consumables.length > 0) {
        $('#hdfCurrentPage').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    Friendly_Message(data);


    $("#divSearchGridOverlay").hide();

    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnConsumable_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {
   
    $("#btnEdit").hide();
    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchAllConsumable();

}