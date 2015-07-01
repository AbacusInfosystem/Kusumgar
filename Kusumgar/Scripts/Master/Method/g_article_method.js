

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

 
    if ($("#txtGrey_with_Cms").val() != 0) {
            
        $(".full-code").append($("#txtGrey_with_Cms").val());
    }

    if ($("#txtGSM").val() != 0) {

        $(".full-code").append($("#txtGSM").val());
    }

    if ($(".full-code").text() == "") {
        $(".full-code").text("- - - -");
    }
}

function Save_G_Article() {
    var gaViewModel = Set_G_Article();

    if ($("#hdnG_Article_Id").val() == 0) {
        CallAjax("/master/g-article/insert/", "json", JSON.stringify(gaViewModel), "POST", "application/json", false, G_Article_CallBack, "", null);
    }
    else {
        CallAjax("/master/g-article/update/", "json", JSON.stringify(gaViewModel), "POST", "application/json", false, G_Article_CallBack, "", null);
    }
}

function Set_G_Article() {
    var gaViewModel =
        {
            G_Article:
                {
                    G_Article_Id: $("#hdnG_Article_Id").val(),

                    Quality_Id: $("#drpQualityNo").val().split('_')[0],

                    Yarn_Type_Id: $("#drpYarn_type").val().split('_')[0],

                    Weave_Id: $("#drpWeave").val().split('_')[0],

                    Grey_with_Cms: $("#txtGrey_with_Cms").val(),   

                    GSM: $("#txtGSM").val(),                     

                    Full_Code: $(".full-code").text(),

                    Warp_1: $("#hdnWarp_1").val(),      

                   Warp_2: $("#hdnWarp_2").val(),     

                    Warp_3: $("#hdnWarp_3").val(),      

                    Warp_4: $("#hdnWarp_4").val(),      

                    Weft_1: $("#hdnWeft_1").val(),      

                    Weft_2: $("#hdnWeft_2").val(),      

                    Weft_3: $("#hdnWeft_3").val(),      

                    Weft_4: $("#hdnWeft_4").val(),      

                    Reed: $("#txtReed").val(),

                    Pick: $("#txtPick").val(),

                    R_S: $("#txtR_S").val(),

                    G_W: $("#txtG_W").val(),

                    Total_Ends: parseInt($("#txtTotal_Ends").val()),

                    Beam_Weight: $("#txtBeam_Weight").val(),

                    Beam_Roll: $("#txtBeam_Roll").val(),

                    Weave: $("#txtWeave").val(),

                    No_Of_Healds: $("#txtNo_Of_Healds").val(),

                    Drawing_Sequence_Body: $("#txtDrawing_Sequence_Body").val(),

                    Drawing_Sequence_Selvedge: $("#txtDrawing_Sequence_Selvedge").val(),

                    Roll_Size: parseInt($("#txtRoll_Size").val()),

                    Warp_Yarn_Vendor: $("#drpWarp_yarn_supplier").val(),

                    Weft_yarn_Vendor: $("#drpWeft_yarn_supplier").val(),

                    RSP: parseInt($("#txtRSP").val()),

                    Warping_Meters: parseInt($("#txtWarping_Meters").val()),

                    Draft: $("#txtDraft").val(),

                    Crimp_In_Percentage: parseInt($("#txtCrimp_in_Percentage").val()),

                    Peg_Plan_Rows: parseInt($("#txtPeg_Plan_Rows").val()),

                    Peg_Plan_Columns: parseInt($("#txtPeg_Plan_Columns").val()),

                    Is_Active: $("#hdnIs_Active").val(),

                   
                }
        }

    return gaViewModel;
}

function G_Article_CallBack(data) {

    $("#hdnG_Article_Id").val(data.G_Article.G_Article_Id);
    Friendly_Message(data);
}