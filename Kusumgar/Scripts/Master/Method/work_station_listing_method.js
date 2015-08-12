
function Bind_Work_Centers(data) {

    $("#drpWork_Center").html("");

    var htmltext = "";

    htmltext += "<option>-Select work Station-</option>";

    if (data.Work_Station.Work_Centers.length > 0) {
        for (var i = 0; i < data.Work_Station.Work_Centers.length ; i++) {

            htmltext += "<option value='" + data.Work_Station.Work_Centers[i].Work_Center_Id + "'>" + data.Work_Station.Work_Centers[i].Work_Center_Name + "</option>";
        }
    }
    $("#drpWork_Center").html(htmltext);
}


function Search_Work_Center() {
    var wcViewModel =
        {
            Filter:
                {
                    Factory_Id: $("#drpFactory").val(),

                    Work_Center_Id: $("#drpWork_Center").val(),

                    Process_Id: $("#drpProcess").val(),
                },

            Pager: {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/work-station-search", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Bind_Work_Station_Grid, "", null);
}

function Bind_Work_Station_Grid(data) {

    $('#tblWork_Station tr.subhead').html("");

    var htmlText = "";

    if (data.Work_Stations.length > 0) {
       
        for (i = 0; i < data.Work_Stations.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Work_Stations[i].Work_Station_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>"; 
            
            htmlText += data.Work_Stations[i].Work_Center.Work_Center_Name ;
            //htmlText += data.Work_Station.Work_Centers[i].Work_Center_Name == null ? "" : data.Work_Station.Work_Centers[i].Work_Center_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Work_Station_Code == null ? "" : data.Work_Stations[i].Work_Station_Code;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Machine_Name == null ? "" : data.Work_Stations[i].Machine_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Machine_Properties == null ? "" : data.Work_Stations[i].Machine_Properties;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].TPM_Speed == null ? "" : data.Work_Stations[i].TPM_Speed;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Average_Order_Length == null ? "" : data.Work_Stations[i].Average_Order_Length;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Capacity == null ? "" : data.Work_Stations[i].Capacity;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Wastage == null ? "" : data.Work_Stations[i].Wastage;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Work_Stations[i].Target_Efficiency == null ? "" : data.Work_Stations[i].Target_Efficiency;

            htmlText += "</td>";

            //if (data.Work_Stations[i].Under_Maintainance == true) {

            //htmlText += data.Work_Centers[i].Under_Maintainance == null ? "" : data.Work_Centers[i].Under_Maintainance;

            //htmlText += "</td>";

            if (data.Work_Stations[i].Under_Maintainance == true) {

                htmlText += "<td>";

                htmlText += "Yes";

                htmlText += "</td>";
            }
            if (data.Work_Stations[i].Under_Maintainance == false) {

                htmlText += "<td>";

                htmlText += "No";

                htmlText += "</td>";
            }

            //htmlText += "<td>";

            //htmlText += data.Work_Centers[i].Is_Active == null ? "" : data.Work_Centers[i].Is_Active;

            //htmlText += "</td>";

            if (data.Work_Stations[i].Is_Active == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            if (data.Work_Stations[i].Is_Active == false) {

                htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='8'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblWork_Station").find("tr:gt(0)").remove();

    $('#tblWork_Station tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Work_Stations.length > 0) {
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

            $("#hdnWork_Station_Id").val(this.id.replace("r1_", ""));
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

    Search_Work_Center();
}