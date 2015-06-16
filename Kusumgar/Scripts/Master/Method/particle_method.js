function Get_Full_Code() {

    $(".full-code").text("");

    $('.attribute-code').each(function (i) {
        var code = $(this).text()
        if (code != "" && code !='-') {
            
            $(".full-code").append(code);
        }
    });

    if ($(".full-code").text() == "") {
        $(".full-code").text("- - - -");
    }
}

function Save_PArticle() {

    var pViewModel = Set_PArticle();

    if ($("#hdnPArticleId").val() == 0) {

        CallAjax("/master/p-article/insert/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, PArticle_CallBack, "", null);
    }
    else {
        CallAjax("/master/p-article/update/", "json", JSON.stringify(pViewModel), "POST", "application/json", false, PArticle_CallBack, "", null);
    }
}

function Set_PArticle() {

    var pViewModel =
        {
            PArticle:
                {
                    P_Article_Id: $("#hdnPArticleId").val(),

                    Quality_No: $("#drpQualityNo").val().split('_')[0],

                    Yarn_Type_Id: $("#drpYarnType").val().split('_')[0],

                    Weave_Id: $("#drpWave").val().split('_')[0],
                    
                    Shade_Id: $("#drpShades").val().split('_')[0],

                    Chemical_Finish_Id: $("#drpChemicalFinish").val().split('_')[0],

                    Mechanical_Finish_Id: $("#drpMechanicalFinish").val().split('_')[0],

                    P_Finish_width: $("#txtPFinishWidth").val(),

                    Type_Id: $("#drpType").val().split('_')[0],

                    Developed_Under_Id: $("#hdnDeveloped_Under").val(),

                    Full_Code: $(".full-code").text(),

                    Given_By_Id: $("#hdnGiven_by").val(),

                    Is_Active: $("#chkStatus").val(),

                    Validated_By_Id: $("#hdnValidated_by").val(),

                    Batch: $("#txtBatch").val(),
            }
       }

    return pViewModel;
}

function PArticle_CallBack(data) {

    $("#hdnPArticleId").val(data.PArticle.P_Article_Id);
    Friendly_Message(data);
}
