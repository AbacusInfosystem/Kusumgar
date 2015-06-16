
function SearchUser()
{

    var _userViewModel = 
        {
            Filter:
                {
                    FirstName: $("#txtEmployeeName").val(),
                    User_Id: $("#txtUser_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/search-employee", "json", JSON.stringify(_userViewModel), "POST", "application/json", false, BindUserGrid, "", null);

}

function BindUserGrid(data)
{

    $('#tblUserGrid tr.subhead').html("");

    var htmlText = "";

    if (data.Users.length > 0) {

        for (i = 0; i < data.Users.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Users[i].UserId + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Users[i].First_Name == null ? "" : data.Users[i].First_Name + " ";

            htmlText += data.Users[i].First_Name == null ? "" : data.Users[i].Middle_Name + " ";

            htmlText += data.Users[i].First_Name == null ? "" : data.Users[i].Last_Name + " ";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Users[i].Mobile_No1 == null ? "" : data.Users[i].Mobile_No1 + ", ";

            htmlText += data.Users[i].Mobile_No2 == null ? "" : data.Users[i].Mobile_No2 + ", ";

            htmlText += data.Users[i].Residence_Landline == null ? "" : data.Users[i].Residence_Landline + ", ";

            htmlText += data.Users[i].Office_Landline == null ? "" : data.Users[i].Office_Landline + ", ";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Users[i].Personal_Email == null ? "" : data.Users[i].Personal_Email + ", ";

            htmlText += data.Users[i].Office_Email == null ? "" : data.Users[i].Office_Email + ", ";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Users[i].Designtation;

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else
    {
        htmlText += "<tr>";

        htmlText += "<td colspan = '5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblUserGrid").find("tr:gt(0)").remove();

    $('#tblUserGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

   
    if (data.Users.length > 0) {
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