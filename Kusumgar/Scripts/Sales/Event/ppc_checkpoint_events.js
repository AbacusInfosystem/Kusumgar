$(function () {

    InitializeAutoComplete($('#txtQuality_No'));


    $('[name="r1"]').on('ifChanged', function (event) {
        var id = this.id;
        if ($("#" + id).prop('checked')) {
            if (id == 'rdbQualityNo') {
                $("#drpArticleType").attr('disabled', 'disabled');
                $("#txtQuality_No").removeAttr('disabled', 'disabled');
                $("#drpExistingQualityArticleType").removeAttr('disabled', 'disabled');

                $('.Customer_Quality').hide();
            }
            else {
                $("#drpArticleType").removeAttr('disabled', 'disabled');
                $("#txtQuality_No").attr('disabled', 'disabled');
                $("#drpExistingQualityArticleType").attr('disabled', 'disabled');

                $('.Customer_Quality').show();
            }
        }
    });


    if($("#hdnQuality_Id").val() != "")
    {
        $("#rdbQualityNo").attr("checked", "checked");

        $('[name="r1"]').trigger("ifChanged");
    }
    else
    {
        $("#rdbPPCCheckpoint").attr("checked", "checked");

        $('[name="r1"]').trigger("ifChanged");
    }


    $("#hdnQuality_Id").change(function () {

        if ($("#hdnQuality_Id").val() != "") {

            var Quality_Id = $("#hdnQuality_Id").val();

            Get_Quality_Details(Quality_Id);
        }
        else {
            $("#tblQuality_Details").html("");
        }

    });

    $("#hdnQuality_Id").trigger("change");

});