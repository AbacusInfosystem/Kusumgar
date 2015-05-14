﻿
function SearchRole()
{


    var _roleViewModel =
        {
            Role_FilterVal:
                {
                    Role_Name: $("#txtRole_Name").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/search-role", "json", JSON.stringify(_roleViewModel), "POST", "application/json", false, BindRoleGrid, "", null);

}

function BindRoleGrid(data)
{

    $('#tblRoleGrid tr.subhead').html("");
  
    var htmlText = "";

    for (i = 0; i < data.RoleList.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.RoleList[i].RoleEntity.Role_Id + "' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.RoleList[i].RoleEntity.Role_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.RoleList[i].RoleEntity.Is_Active.toString();

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblRoleGrid").find("tr:gt(0)").remove();

    $('#tblRoleGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

   

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    $("#divSearchGridOverlay").hide();

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnRole_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchRole();

}