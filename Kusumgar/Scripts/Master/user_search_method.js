
function SearchUser()
{

    var uViewModel =
        {
            Filter:
                {
                    FirstName: $("#txtEmployeeName").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/search-employee", "json", JSON.stringify(uViewModel), "POST", "application/json", false, Bind_User_Grid, "", null);

}

function Bind_User_Grid(data)
{

    $('#tblUserGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.UserList.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.UserList[i].UserEntity.UserId + "' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.UserList[i].UserEntity.First_Name == null ? "" : data.UserList[i].UserEntity.First_Name + " ";

        htmlText += data.UserList[i].UserEntity.First_Name == null ? "" : data.UserList[i].UserEntity.Middle_Name + " ";

        htmlText += data.UserList[i].UserEntity.First_Name == null ? "" : data.UserList[i].UserEntity.Last_Name + " ";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.UserList[i].UserEntity.Mobile_No1 == null ? "" : data.UserList[i].UserEntity.Mobile_No1 + ", ";

        htmlText += data.UserList[i].UserEntity.Mobile_No2 == null ? "" : data.UserList[i].UserEntity.Mobile_No2 + ", ";

        htmlText += data.UserList[i].UserEntity.Residence_Landline == null ? "" : data.UserList[i].UserEntity.Residence_Landline + ", ";

        htmlText += data.UserList[i].UserEntity.Office_Landline == null ? "" : data.UserList[i].UserEntity.Office_Landline + ", ";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.UserList[i].UserEntity.Personal_Email == null ? "" : data.UserList[i].UserEntity.Personal_Email + ", ";

        htmlText += data.UserList[i].UserEntity.Office_Email == null ? "" : data.UserList[i].UserEntity.Office_Email + ", ";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.UserList[i].UserEntity.Designtation;

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblUserGrid").find("tr:gt(0)").remove();

    $('#tblUserGrid tr:first').after(htmlText);

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
            $("#hdnUserId").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchUser();
    //var dViewModel = {

    //    Filter: {

    //        DefectName: $('#txtDefectName').val(),
    //        DefectTypeName: $('#drpDefectType').val(),
    //    },

    //    Pager: {

    //        IsPagingRequired: $('#hdfIsPagingRequired').val(),

    //        CurrentPage: $('#hdfCurrentPage').val(),

    //        PageSize: $('#hdfPageSize').val(),
    //    },

    //};

    //$("#divSearchGridOverlay").show();

    //CallAjax("/master/search-employee", "json", JSON.stringify(_userViewModel), "POST", "application/json", false, BindUserGrid, "", null);

}