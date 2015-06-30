function SearchWArticle() {

    var Yarn_Type_Id = "";
    if ($("#drpYarnType").val() == "") {
        Yarn_Type_Id = 0;
    }
    else {
        Yarn_Type_Id = $("#drpYarnType").val().split('_')[0];
    }

    var wViewModel =
        {
            Filter:
                {
                    Full_Code: $("#txtFullCode").parents('.form-group').find('.text').html(),
                    Yarn_Type_Id: Yarn_Type_Id,
                    WArticle_Id: $("#hdnWArticle_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/w-articles/search/", "json", JSON.stringify(wViewModel), "POST", "application/json", false, Bind_WArticle_Grid, "", null);
}


function Bind_WArticle_Grid(data) {

    var htmlText = "";

    if (data.WArticles.length > 0) {

        for (i = 0; i < data.WArticles.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.WArticles[i].W_Article_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Full_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Reed_Space_Inch;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Total_No_Of_Ends;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.WArticles[i].Ideal_Beam;

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
    $("#tblWArticle").find("tr:gt(0)").remove();

    $('#tblWArticle tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.WArticles.length > 0) {
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
            $("#hdfW_Article_Id").val(this.id.replace("r1_", ""));

            $("#btnEdit").show();
            $("#btnView").show();
        }
    });

}

function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnView").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchWArticle();
}