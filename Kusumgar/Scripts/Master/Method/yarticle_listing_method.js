
function SearchYArticle() {


    var Yarn_Type_Id = "";
    if ($("#drpYarn_Type").val() == "")
    {
        Yarn_Type_Id = 0;
    }
    else
    {
        Yarn_Type_Id = $("#drpYarn_Type").val().split('_')[0];
    }

    var yViewModel =
        {
            Filter:
                {
                    Full_Code: $("#txtFull_Code").parents('.form-group').find('.text').html(),
                    Yarn_Type_Id: Yarn_Type_Id
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/y-articles/search/", "json", JSON.stringify(yViewModel), "POST", "application/json", false, Bind_YArticle_Grid, "", null);
}


function Bind_YArticle_Grid(data) {

    var htmlText = "";

    if (data.YArticles.length > 0) {

        for (i = 0; i < data.YArticles.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.YArticles[i].Y_Article_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Full_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Denier_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Twist_Mingle_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Twist_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Ply_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Shade_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Filaments_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Origin_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Shrinkage_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Tenasity_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Chemical_Treatment_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Colour_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.YArticles[i].Supplier_Name;

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
    $("#tblYArticle").find("tr:gt(0)").remove();

    $('#tblYArticle tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.YArticles.length > 0) {
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
            $("#hdfY_Article_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchYArticle();
}