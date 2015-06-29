
function SearchRole()
{


    var rViewModel =
        {
            Filter:
                {
                    Role_Name: $("#txtRole_Name").val(),
                    Role_Id: $("#hdRole_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/search-role", "json", JSON.stringify(rViewModel), "POST", "application/json", false, BindRoleGrid, "", null);

}

function BindRoleGrid(data)
{

  //  $('#tblRoleGrid tr.subhead').html("");
  
    var htmlText = "";

    if (data.Roles.length > 0) {
        for (i = 0; i < data.Roles.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Roles[i].Role_Id + "' class='iradio-list'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Roles[i].Role_Name;

        htmlText += "</td>";

            if (data.Roles[i].Is_Active == true) {

                htmlText += "<td>";

                htmlText +="Active";

                htmlText += "</td>";
            }
            else
            {
        htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }
    }
    else
    {
        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblRoleGrid").find("tr:gt(0)").remove();

    $('#tblRoleGrid tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

   
    if (data.Roles.length > 0) {
    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }
    }
    else
    {
        $('.pagination').html("");
    }

    $("#divSearchGridOverlay").hide();

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnRole_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

    $("#btnEdit").hide();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchRole();

}