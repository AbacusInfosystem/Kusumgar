function SearchPacking() {

    var pViewModel =
        {
            Filter: {
                Packing_Name: $('#txtPackingName').val(),
                Packing_Id: $('#hdfPacking_Id').val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    CallAjax("/master/search-packing", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Packing_Grid, "", null);
}

function Bind_Packing_Grid(data) {

    $('#tblPackGrid tr.subhead').html("");

    var htmlText = "";

    if (data.Packings.length > 0) {

        for (i = 0; i < data.Packings.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Packings[i].Packing_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Packings[i].Packing_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Packings[i].Is_Active;

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
    $("#tblPackGrid").find("tr:gt(0)").remove();

    $('#tblPackGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Packings.length > 0) {

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

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPacking_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchPacking();

}