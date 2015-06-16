function Get_Full_Code() {


    $(".full-code").text("");

    $('.attribute-name').each(function (i) {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).parent().parent().find('.attribute-code').text(code);

            $(".full-code").append(code);
        }
    });

    if ($('#txtReed_Space_Inch').val() != 0) {
        $(".full-code").append($('#txtReed_Space_Inch').val());
    }

    if ($('#txtTotal_No_Ends').val() != 0) {
        $(".full-code").append($('#txtTotal_No_Ends').val());
    }    

    if ($(".full-code").text() == "") {
        $(".full-code").text("- - - -");
    }
}

function Save_WArticle() {
    var wViewModel = Set_WArticle();

    if ($("#hdnWArticle_Id").val() == 0) {
        CallAjax("/master/w-article/insert/", "json", JSON.stringify(wViewModel), "POST", "application/json", false, WArticle_CallBack, "", null);
    }
    else {
        CallAjax("/master/w-article/update/", "json", JSON.stringify(wViewModel), "POST", "application/json", false, WArticle_CallBack, "", null);
    }
}

function Set_WArticle() {
    var wViewModel =
        {
            WArticle:
                {

                    W_Article_Id: $("#hdnWArticle_Id").val(),

                    Quality_Id: $("#drpQualityNo").val().split('_')[0],

                    Yarn_Type_Id: $("#drpYarnType").val().split('_')[0],

                    Reed_Space_Inch: $("#txtReed_Space_Inch").val(),

                    Total_No_Of_Ends: $("#txtTotal_No_Ends").val(),                    

                    Full_Code: $(".full-code").text(),

                    Ideal_Beam: $("#txtIdealBeam").val(),
                    
                    Is_Active: $("#chkIsActive").val(),
                    
                }
        }

    return wViewModel;
}

function WArticle_CallBack(data) {

    $("#hdnWArticle_Id").val(data.WArticle.W_Article_Id);
    Friendly_Message(data);
}