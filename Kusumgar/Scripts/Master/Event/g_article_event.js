$(function () {

    InitializeAutoComplete($('#txtWarp_1'));
    InitializeAutoComplete($('#txtWarp_2'));
    InitializeAutoComplete($('#txtWarp_3'));
    InitializeAutoComplete($('#txtWarp_4'));

    InitializeAutoComplete($('#txtWeft_1'));
    InitializeAutoComplete($('#txtWeft_2'));
    InitializeAutoComplete($('#txtWeft_3'));
    InitializeAutoComplete($('#txtWeft_4'));

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
            $(this).parent().parent().find('.attribute-code').text(code);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('.attribute-name').each(function () {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).parent().parent().find('.attribute-code').text(code);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
    });

    $('#txtGrey_with_Cms').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).parent().parent().find('.attribute-code').text(val);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('#txtGSM').keyup(function () {
        var val = this.value;
        if (val != "") {
            $(this).parent().parent().find('.attribute-code').text(val);
        }
        else {
            $(this).parent().parent().find('.attribute-code').text("-");
        }
        Get_Full_Code();
    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $("#btnSave_G_Article").click(function () {

        if ($("#frmG_Article").valid()) {
            Save_G_Article();
        }
    });


});