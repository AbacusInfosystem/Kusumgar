$(function () {

    $('.attribute-name').change(function () {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).closest('.row').find('.attribute-code').text(code);
        }
        else {
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



    $('#txtC_Finish_Width').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).closest('.row').find('.attribute-code').text(val);
        }
        else {
            $(this).closest('.row').find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('#txtCoat').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).parent().parent().find('.attribute-code').text(val);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('#txtC_gsm').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).parent().parent().find('.attribute-code').text(val);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('[name="rdbChemicalFinish_MechanicalFinish"]').on('ifChanged', function (event) {
        var id = this.id;
        if ($("#" + id).prop('checked')) {
            if (id == 'rdChemical_Finish') {                
                
                $("#lblMFinish").text("-");
                $("#drpMechanicalFinish").val("");

                $("#drpMechanicalFinish").attr('disabled', 'disabled');
                $("#drpChemicalFinish").removeAttr('disabled', 'disabled');               

                Get_Full_Code();
            }
            else {                
                
                $("#lblCFinish").text("-");
                $("#drpChemicalFinish").val("");

                $("#drpMechanicalFinish").removeAttr('disabled', 'disabled');
                $("#drpChemicalFinish").attr('disabled', 'disabled');                

                Get_Full_Code();
            }
        }
    });


    $('[name="rdbYarnType_Finish"]').on('ifChanged', function (event) {
        var id = this.id;
        if ($("#" + id).prop('checked')) {
            if (id == 'rdYarn_Type') {

                $("#lblCFinishWidth").text("-");
                $("#txtC_Finish_Width").val("");

                $("#drpYarnType").removeAttr('disabled', 'disabled');
                $("#txtC_Finish_Width").attr('disabled', 'disabled');

                $("#txtC_Finish_Width").val("");
                
                Get_Full_Code();
            }
            else {
                $("#lblYarnType").text("-");
                $("#drpYarnType").val("");

                $("#drpYarnType").attr('disabled', 'disabled');
                $("#txtC_Finish_Width").removeAttr('disabled', 'disabled');                

                Get_Full_Code();
            }

        }
    });

    $('[name="chkIsActive"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).val(true);
        }
        else {
            $(this).val(false);
        }
    });

    $("#btnSave_CArticle").click(function () {

        if ($("#frmCArticle").valid()) {
            Save_CArticle();
        }
    });
});