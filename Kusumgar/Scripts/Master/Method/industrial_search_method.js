function SearchIndustrial() {

    var iViewModel =
        {
            Filter: {
                Industrial_Category_Id: $('#drpIndCatName').val(),
                Industrial_Group_Id: $('#drpIndGroupName').val(),
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    CallAjax("/master/search-industrial-master", "json", JSON.stringify(iViewModel), "POST", "application/json", false, Bind_Industrial_Grid, "", null);
}

function Bind_Industrial_Grid(data) {
    
    $('#tblIndGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.Industrials.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Industrials[i].Industrial_Master_Id + "' class='iradio-list'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrials[i].Industrial_Category_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrials[i].Industrial_Group_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrials[i].Industrial_SubGrp_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrials[i].Size;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Industrials[i].COD;

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblIndGrid").find("tr:gt(0)").remove();

    $('#tblIndGrid tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });



    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    Friendly_Message(data);

    $("#divSearchGridOverlay").hide();

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {            
            $("#hdnIndustrial_Id").val(this.id.replace("r1_", ""));            
            $("#btnEdit").show();
        }
    });

    $('#btnEdit').hide();

}

function PageMore(Id) {

    $('#btnEdit').hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchIndustrial();

}

function Bind_Groups(data) {
    $("#drpIndGroupName").html("");

    var htmltext = "";

    htmltext += "<option>--Select--</option>";

    if (data.length > 0) {
        for (var i = 0; i < data.length ; i++) {
            htmltext += "<option value='" + data[i].Industrial_Group_Id + "'>" + data[i].Industrial_Group_Name + "</option>";
        }
    }
    $("#drpIndGroupName").html(htmltext);
}
