
function Search_Customer_Quality() {
    var vcViewModel =
        {
            Filter:
                {
                    Customer_Id: $("#hdnCustomer_Id").val(),
                    Quality_Id: $("#drpQuality_No").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/customer-quality-search", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Bind_Customer_Quality_Grid, "", null);
}

function Bind_Customer_Quality_Grid(data) {

    $('#tblCustomer_Quality tr.subhead').html("");

    var htmlText = "";

    if (data.Customer_Qualities.length > 0) {

        for (i = 0; i < data.Customer_Qualities.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Customer_Qualities[i].Customer_Quality_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_Qualities[i].Customer.Customer_Entity.Customer_Name == null ? "" : data.Customer_Qualities[i].Customer.Customer_Entity.Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_Qualities[i].Quality.Quality_No == null ? "" : data.Customer_Qualities[i].Quality.Quality_No;

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
    $("#tblCustomer_Quality").find("tr:gt(0)").remove();

    $('#tblCustomer_Quality tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Customer_Qualities.length > 0) {
        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

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

            $("#hdnCustomer_Quality_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();

        }
    });

}

function PageMore(Id) {

    $("#btnEdit").hide();
    $('#hdfCurrent_Page').val((parseInt(Id) - 1));
    $(".selectAll").prop("checked", false);

    Search_Customer_Quality();
}

