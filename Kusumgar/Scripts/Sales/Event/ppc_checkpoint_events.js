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
                if ($("#hdnQuality_Id").val() == 0) {
                    $("#hdnQuality_Id").val("");
                }
            }
            else {
                $("#drpArticleType").removeAttr('disabled', 'disabled');

                $("#txtQuality_No").attr('disabled', 'disabled');
                $("#drpExistingQualityArticleType").attr('disabled', 'disabled');

                $('.Customer_Quality').show();
                if ($("#hdnQuality_Id").val() == "") {
                    $("#hdnQuality_Id").val(0);
                }
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

        if ($("#rdbQualityNo").prop('checked') && $("#hdnQuality_Id").val() != "") {

            var Quality_Id = $("#hdnQuality_Id").val();

            Get_Quality_Details(Quality_Id);
        }
        else {
            $("#tblQuality_Details").html("");
        }

    });

    $("#hdnQuality_Id").trigger("change");

    $("#btnSave_PPC_Checkpoint").click(function(){

        if ($("#frmPPC_Checkpoint").valid()) {
            Save_Enquiry();
        }

    });

});