function SearchPArticle() {

    var Yarn_Type_Id = "";
    if ($("#drpYarn_Type").val() == "") {
        Yarn_Type_Id = 0;
    }
    else {
        Yarn_Type_Id = $("#drpYarn_Type").val().split('_')[0];
    }

    var pViewModel =
        {
            Filter:
                {
                    Full_Code: $("#txtFull_Code").parents('.form-group').find('.text').html(),
                    Yarn_Type_Id: Yarn_Type_Id,
                    PArticle_Id: $("#hdnPArticle_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/p-articles/search/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_PArticle_Grid, "", null);
}

function Bind_PArticle_Grid(data) {

    var htmlText = "";

    if (data.PArticles.length > 0) {

        for (i = 0; i < data.PArticles.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.PArticles[i].P_Article_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.PArticles[i].Full_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.PArticles[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.PArticles[i].Quality_Nos;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.PArticles[i].Weave_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.PArticles[i].Shades_Name;

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
    $("#tblparticle").find("tr:gt(0)").remove();

    $('#tblparticle tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.PArticles.length > 0) {
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

            $("#hdfPArticleId").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchPArticle();
}