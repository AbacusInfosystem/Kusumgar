$(function () {

    InitializeAutoComplete($('#txtGiven_By'));

    InitializeAutoComplete($('#txtValidated_By'));

    InitializeAutoComplete($('#txtDeveloped_Under'));

    $("#drpQualityNo").change(function () {
        var val = this.value;
        if (val != "") {
            $(this).parent().parent().find('.attribute-code').text(val);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
    });

    $('.attribute-name').change(function () {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).closest('.row').find('.attribute-code').text(code);
        }
        else
        {
            $(this).closest('.row').find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('.attribute-name').each(function () {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).closest('.row').find('.attribute-code').text(code);
        }
        else {
            $(this).closest('.row').find('.attribute-code').text("-");
        }
    });

    $('#txtPFinishWidth').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).closest('.row').find('.attribute-code').text(val);
        }
        else {
            $(this).closest('.row').find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('[name="chkStatus"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).val(true);
        }
        else {
            $(this).val(false);
        }
    });

    $("#btnSavePArticle").click(function () {
     
        if($("#frmPArticle").valid())
        {
            Save_PArticle();
        }
    });

    $('[name="rdbChemicalFinish_MechanicalFinish"]').on('ifChanged', function (event) {
        var id = this.id;
        if ($("#" + id).prop('checked')) {
            if (id == 'rdChemical_Finish') {
                $("#drpMechanicalFinish").val("");
                $("#lblMechanical").text("-");
                //$("drpMechanicalFinish").closest('.row').find('.attribute-code').text("-");
                $("#drpMechanicalFinish").attr('disabled', 'disabled');
                $("#drpChemicalFinish").removeAttr('disabled', 'disabled');

                //$('#frmPArticle').validate();
                //$("#drpMechanicalFinish").rules("add","required");
                Get_Full_Code();
            }
            else {
                $("#drpChemicalFinish").val("");
                
                $("#lblChemical").text("-");
                //$("drpMechanicalFinish").closest('.row').find('.attribute-code').text("-");
                $("#drpMechanicalFinish").removeAttr('disabled', 'disabled');
                $("#drpChemicalFinish").attr('disabled', 'disabled');


                //$('#frmPArticle').validate();
                //$("#drpMechanicalFinish").rules("add", "required");
                Get_Full_Code();
            }
        }
    });
});