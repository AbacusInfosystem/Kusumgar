
function Search_G_Article() {

    var gaViewModel =
        {
            Filter:
                {
                    //Full_Code: $("#txtFull_Code").parents('.form-group').find('.text').html(),
                    //Yarn_Type_Id :Yarn_Type_Id,

                    Yarn_Type_Id: $("#drpYarn_type").val().split('_')[0],
                   
                    G_Article_Id: $("#hdfG_Article_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/g-articles-search/", "json", JSON.stringify(gaViewModel), "POST", "application/json", false, Bind_G_Article_Grid, "", null);
}

function Bind_G_Article_Grid(data) {
  
    var htmlText = "";

    if (data.G_Articles.length > 0) {

        for (i = 0; i < data.G_Articles.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.G_Articles[i].G_Article_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].Full_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].Weave_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].Grey_with_Cms;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.G_Articles[i].GSM;

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
    $("#tblG_Article").find("tr:gt(0)").remove();

    $('#tblG_Article tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.G_Articles.length > 0) {
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
            $("#hdnG_Article_Id").val(this.id.replace("r1_", ""));
            $("#btnView").show();
            $("#btnEdit").show();
        }
    });


    $('#btnEdit').hide();
}



function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Search_G_Article();
}