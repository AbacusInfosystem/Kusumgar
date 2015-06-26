function SearchCArticle() {

    var Yarn_Type_Id = "";
    if ($("#drpYarnType").val() == "") {
        Yarn_Type_Id = 0;
    }
    else {
        Yarn_Type_Id = $("#drpYarnType").val().split('_')[0];
    }

    var cViewModel =
        {
            Filter:
                {
                    Full_Code: $("#txtFullCode").parents('.form-group').find('.text').html(),
                    Yarn_Type_Id: Yarn_Type_Id,
                    CArticle_Id: $("#hdnCArticle_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/c-articles/search/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_CArticle_Grid, "", null);
}


function Bind_CArticle_Grid(data) {

    var htmlText = "";

    if (data.CArticles.length > 0) {

        for (i = 0; i < data.CArticles.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.CArticles[i].C_Article_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CArticles[i].Full_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CArticles[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CArticles[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CArticles[i].Weave_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CArticles[i].Shade_Name;

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
    $("#tblCArticle").find("tr:gt(0)").remove();

    $('#tblCArticle tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.CArticles.length > 0) {
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
            $("#hdfC_Article_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

    $("#btnEdit").hide();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchCArticle();
}