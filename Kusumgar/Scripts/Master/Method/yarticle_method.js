

function Get_Full_Code()
{


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

    if($(".full-code").text()=="")
    {
        $(".full-code").text("- - - -");
    }
}

function Save_YArticle()
{
    var yViewModel = Set_YArticle();

    if ($("#hdnYArticle_Id").val() == 0) {
        CallAjax("/master/y-article/insert/", "json", JSON.stringify(yViewModel), "POST", "application/json", false, YArticle_CallBack, "", null);
    }
    else {
        CallAjax("/master/y-article/update/", "json", JSON.stringify(yViewModel), "POST", "application/json", false, YArticle_CallBack, "", null);
    }
}

function Set_YArticle()
{
    var yViewModel =
        {
            YArticle:
                {
                    YArticle_Entity:
                        {

                            Chemical_Treatment_Id: $("#drpChemical_Treatment").val().split('_')[0],

                            Colour_Id: $("#drpColour").val().split('_')[0],

                            Denier_Id: $("#drpDenier").val().split('_')[0],

                            Developed_Under_Id: $("#hdnDeveloped_Under").val(),

                            Filaments_Id: $("#drpFilaments").val().split('_')[0],

                            Full_Code: $(".full-code").text(),

                            Given_By_Id: $("#hdnGiven_by").val(),

                            Is_Active: $("#chkStatus").val(),

                            Lead_Time_To_Purchase: $("#txtLead_Time_To_Purchase").val(),

                            Origin_Id: $("#drpOrigin").val().split('_')[0],

                            Ply_Id: $("#drpPly").val().split('_')[0],

                            Shade_Id: $("#drpShade").val().split('_')[0],

                            Shrinkage_Id: $("#drpShrinkage").val().split('_')[0],

                            Supplier_Id: $("#drpSupplier").val().split('_')[0],

                            Tenasity_Id: $("#drpTenasity").val().split('_')[0],

                            Twist_Mingle_Id: $("#drpTwist_Mingle").val().split('_')[0],

                            Twist_Type_Id: $("#drpTwist_type").val().split('_')[0],

                            Validated_By_Id: $("#hdnValidated_by").val(),

                            Work_Center_Code: $("#txtWork_Center").parents('.form-group').find('.text').html(),

                            Y_Article_Id: $("#hdnYArticle_Id").val(),

                            Yarn_Type_Id: $("#drpYarn_type").val().split('_')[0],
                        }
                }
        }
   
    return yViewModel;
}

function YArticle_CallBack(data)
{
  
    $("#hdnYArticle_Id").val(data.YArticle.YArticle_Entity.Y_Article_Id);
    Friendly_Message(data);
}

