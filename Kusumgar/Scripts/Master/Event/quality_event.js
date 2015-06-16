$(document).ready(function () {

    if ($("#hdnQualityId").val() == 0) {
        $("#tabApplication").hide();
        $("#tabSegment").hide();
       
    }

    $("#btnSave").click(function () {
        
        if ($("#frmQuality").valid()) {
            Save_Quality_Details();
        }
       
    });

    $('[name="Quality.Status"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnStatus").val(true);
        }
        else {
            $("#hdnStatus").val(false);
        }
    });


    $("#drpYarnType").change(function () {

        if ($(this).val() == "") {
            $('#tblQuality').hide();
        }
        else {
            $('#tblQuality').show();
            SearchQualityNo();
        }

    });


    if ($("drpYarnType").val() == "") {
        $('#tblQuality').hide();
    }
    else {
        $('#tblQuality').show();
        SearchQualityNo();
    }


    InitializeAutoComplete($('#txtMarketSegmentName'));

    $("#btnSaveSegment").click(function () {

        if ($("#frmSegment").valid()) {

        Save_Quality_Segment_Details();
        }

    });

    InitializeAutoComplete($('#txtApplicationName'));

    $("#btnApplicationSave").click(function () {

        if ($("#frmApplication").valid()) {

        Save_Quality_Application_Details();
        }

    });
});