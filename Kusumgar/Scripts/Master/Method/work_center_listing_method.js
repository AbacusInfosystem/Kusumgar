
function Bind_Work_Stations(data) {

    $("#drpWork_Station").html("");

    var htmltext = "";

    htmltext += "<option>-Select work center-</option>";

    if (data.Work_Center.Work_Stations.length > 0) {
        for (var i = 0; i < data.Work_Center.Work_Stations.length ; i++) {

            htmltext += "<option value='" + data.Work_Center.Work_Stations[i].Work_Station_Id + "'>" + data.Work_Center.Work_Stations[i].Work_Station_Name + "</option>";
        }
    }
    $("#drpWork_Station").html(htmltext);
}


function Search_Work_Station() {
    var wcViewModel =
        {
            Filter:
                {
                    Factory_Id: $("#drpFactory").val(),

                    Work_Station_Id: $("#drpWork_Station").val(),

                    Process_Id: $("#drpProcess").val(),
                },

            Pager: {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/work-center-search", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Bind_Work_Center_Grid, "", null);
}

function Bind_Work_Center_Grid(data) {

    $('#tblWork_Center tr.subhead').html("");

    var htmlText = "";

    if (data.Work_Centers.length > 0) {
       
        for (i = 0; i < data.Work_Centers.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Work_Centers[i].Work_Center_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Work_Station_Id == null ? "" : data.Work_Centers[i].Work_Station_Id;
            //htmlText += data.Work_Center.Work_Stations[i].Work_Station_Name == null ? "" : data.Work_Center.Work_Stations[i].Work_Station_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Work_Center_Code == null ? "" : data.Work_Centers[i].Work_Center_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Machine_Name == null ? "" : data.Work_Centers[i].Machine_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Machine_Properties == null ? "" : data.Work_Centers[i].Machine_Properties;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].TPM_Speed == null ? "" : data.Work_Centers[i].TPM_Speed;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Average_Order_Length == null ? "" : data.Work_Centers[i].Average_Order_Length;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Capacity == null ? "" : data.Work_Centers[i].Capacity;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Wastage == null ? "" : data.Work_Centers[i].Wastage;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Target_Efficiency == null ? "" : data.Work_Centers[i].Target_Efficiency;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Under_Maintainance == null ? "" : data.Work_Centers[i].Under_Maintainance;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Centers[i].Is_Active == null ? "" : data.Work_Centers[i].Is_Active;

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='8'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblWork_Center").find("tr:gt(0)").remove();

    $('#tblWork_Center tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Work_Centers.length > 0) {
        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);
        
        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    //Friendly_Message(data);

    $("#divSearchGridOverlay").hide();

    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {

            $("#hdnWork_Center_Id").val(this.id.replace("r1_", ""));
            $('#btnView').show();
            $("#btnEdit").show();

        }
    });


    $('#btnView').hide();
    $("#btnEdit").hide();
}

function PageMore(Id) {

    $("#btnEdit").hide();
    $('#hdfCurrent_Page').val((parseInt(Id) - 1));
    $(".selectAll").prop("checked", false);

    Search_Work_Station();
}