function Save_Quality_Details() {

    var qViewModel = Set_Quality();

    if ($("#hdnQualityId").val() == 0) {

        CallAjax("/master/insert-quality/", "json", JSON.stringify(qViewModel), "POST", "application/json", false, Bind_Quality_Data_Callback, "", null);
    }
    else {
        
        CallAjax("/master/update-quality/", "json", JSON.stringify(qViewModel), "POST", "application/json", false, Bind_Quality_Data_Callback, "", null);
    }
}

function Bind_Quality_Data_Callback(data) {

   // alert("id" + data.Quality.Quality_Id);

    $("#hdnQualityId").val(data.Quality.Quality_Id);

    $("#tabApplication").show();

    $("#tabSegment").show();
   
    Friendly_Message(data);
}

function Set_Quality() {

    var qViewModel =
        {
            Quality:
                {
                        
                            Quality_Id: $("#hdnQualityId").val(),

                            Yarn_Type_Id: $("#drpYarnType").val(),

                            Quality_No: $("#txtQualityNo ").val(),

                            Minimum_Order_Size: parseInt($("#txtMinimumOrderSize").val()),

                            Ideal_Roll_Length: parseInt($("#txtIdealRollLength").val()),

                            Our_Sample_No: parseInt($("#txtSampleNo").val()),

                            Reed: $("#txtReedName").val(),

                            Pick: $("#txtPickName").val(),

                            Weave: $("#drpWeaveType").val(),

                            Status: $("#hdnStatus").val(),
                       
                },

           
        }

    return qViewModel;
}

function SearchQualityNo() {

    var qViewModel = {

        Filter: {

            Yarn_Type_Id: $('#drpYarnType').val(),

        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Quality/Get_Grid_By_Yarn_Type", "json", JSON.stringify(qViewModel), "POST", "application/json", false, BindQualityInGrid, "", null);
}

function BindQualityInGrid(data, mode) {

    $('#tblQuality tr.subhead').html("");

    var htmlText = "";

    if (data.Quality_Grid.length > 0) {

        for (i = 0; i < data.Quality_Grid.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Yarn_Type_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Minimum_Order_Size;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Quality_Grid[i].Ideal_Roll_Length;

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
    $("#tblQuality").find("tr:gt(0)").remove();

    $('#tblQuality tr:first').after(htmlText);

}

function Save_Quality_Application_Details() {

    var qViewModel = Set_Quality_Applications();

    if ($("#hdnQualityApplicationId").val() == 0) {

        CallAjax("/master/insert-quality-application/", "json", JSON.stringify(qViewModel), "POST", "application/json", false, Bind_Quality_Application_Details, "", null);
    }

}

function Set_Quality_Applications() {
    var qViewModel =
        {
            Quality_Application_Mapping:
                {
                    Quality_Application_Id: $("#hdnQualityApplicationId").val(),
                    Quality_Id: $("#hdnQualityId").val(),
                    Application_Name_Id: $("#hdfApplicationId").val(),
                }
        }
    return qViewModel;
}

function Bind_Quality_Application_Details(data) {

    var htmlText = "";

    if (data.Quality_Application_Mapping_Grid.length > 0) {

        for (var i = 0; i < data.Quality_Application_Mapping_Grid.length; i++) {

            htmlText += "<tr id='tr_iquality_" + data.Quality_Application_Mapping_Grid[i].Quality_Application_Id + "'>";

            htmlText += "<td>";

            htmlText += data.Quality_Application_Mapping_Grid[i].Application_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveQualityApplication(" + data.Quality_Application_Mapping_Grid[i].Quality_Application_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";

        }
    }
    $("#tblQualityApplication").find("tr:gt(0)").remove();

    $('#tblQualityApplication tr:first').after(htmlText);

    $("#hdnQualityApplicationId").val(0);

    $("#hdfApplicationId").val("");

    Friendly_Message(data)
}

function RemoveQualityApplication(id) {
    $.ajax({
        url: '/master/delete-quality_application',
        data: { quality_Application_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#tr_iquality_" + id).html("");

            Friendly_Message(data);
        }
    });
}

function Save_Quality_Segment_Details() {

    var qViewModel = Set_Quality_Segments();

    if ($("#hdnQualityMarketSegmentId").val() == 0) {

        CallAjax("/master/insert-quality-segemnt/", "json", JSON.stringify(qViewModel), "POST", "application/json", false, Bind_Quality_Segment_Details, "", null);
    }

}

function Set_Quality_Segments() {
    var qViewModel =
        {
            Quality_Market_Segment_Mapping:
                {
                    Quality_Market_Segment_Id: $("#hdnQualityMarketSegmentId").val(),
                    Quality_Id: $("#hdnQualityId").val(),
                    Market_Segment_Id: $("#hdfMarketSegmentId").val(),
                }
        }
    return qViewModel;
}

function Bind_Quality_Segment_Details(data) {

    var htmlText = "";

    if (data.Quality_Market_Segment_Mapping_Grid.length > 0) {

        for (var i = 0; i < data.Quality_Market_Segment_Mapping_Grid.length; i++) {

            htmlText += "<tr id='tr_iqualitysegment_" + data.Quality_Market_Segment_Mapping_Grid[i].Quality_Market_Segment_Id + "'>";

            htmlText += "<td>";

            htmlText += data.Quality_Market_Segment_Mapping_Grid[i].Segment_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<div class='btn-group pull-right'>";

            htmlText += "<button type='button' id='btnRemove' class='btn btn-danger btn-sm' onclick='RemoveQualitySegment(" + data.Quality_Market_Segment_Mapping_Grid[i].Quality_Market_Segment_Id + ")'><i class='fa fa-times'></i></button>";

            htmlText += "</div>";

            htmlText += "</td>";

            htmlText += "</tr>";

        }
    }
    $("#tblQualitySegment").find("tr:gt(0)").remove();


    $('#tblQualitySegment tr:first').after(htmlText);

    $("#hdnQualityMarketSegmentId").val(0);

    $("#hdfMarketSegmentId").val("");

    Friendly_Message(data)
}

function RemoveQualitySegment(id) {
    $.ajax({
        url: '/master/delete-quality_segment',
        data: { quality_Market_Segment_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            $("#tr_iqualitysegment_" + id).html("");

            Friendly_Message(data);
        }
    });
}