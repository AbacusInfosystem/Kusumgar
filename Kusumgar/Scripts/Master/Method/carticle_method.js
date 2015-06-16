function Get_Full_Code() {


    $(".full-code").text("");    

    $('.attribute-code').each(function (i) {        
        var code = $(this).text();
        if (code != "" && code != '-') {
            $(".full-code").append(code);
        }
       
    });    

    if ($(".full-code").text() == "") {
        $(".full-code").text("- - - -");
    }
}

function Save_CArticle() {
    var cViewModel = Set_CArticle();

    if ($("#hdnCArticle_Id").val() == 0) {
        CallAjax("/master/c-article/insert/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, CArticle_CallBack, "", null);
    }
    else {
        CallAjax("/master/c-article/update/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, CArticle_CallBack, "", null);
    }
}

function Set_CArticle() {
    var cViewModel =
        {
            CArticle:
                {

                    C_Article_Id: $("#hdnCArticle_Id").val(),

                    Quality_Id: $("#drpQualityNo").val().split('_')[0],

                    Yarn_Type_Id: $("#drpYarnType").val().split('_')[0],

                    Weave_Id: $("#drpWeave").val().split('_')[0],

                    Shade_Id: $("#drpShade").val().split('_')[0],

                    Chemical_Finish_Id: $("#drpChemicalFinish").val().split('_')[0],

                    Mechanical_Finish_Id: $("#drpMechanicalFinish").val().split('_')[0],

                    Type_Id: $("#drpType").val().split('_')[0],

                    C_Finish_Width: $("#txtC_Finish_Width").val(),

                    Coat: $("#txtCoat").val(),

                    C_gsm: $("#txtC_gsm").val(),

                    Full_Code: $(".full-code").text(),

                    Batch: $("#txtBatch").val(),

                    Is_Active: $("#chkIsActive").val(),

                }
        }

    return cViewModel;
}

function CArticle_CallBack(data) {

    $("#hdnCArticle_Id").val(data.CArticle.C_Article_Id);
    Friendly_Message(data);
}