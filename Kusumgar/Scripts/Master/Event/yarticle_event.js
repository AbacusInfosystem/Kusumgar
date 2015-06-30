$(function () {

    InitializeAutoComplete($('#txtGiven_By'));

    InitializeAutoComplete($('#txtValidated_By'));

    InitializeAutoComplete($('#txtDeveloped_Under'));

    InitializeAutoComplete($('#txtWork_Center'));

    $('.attribute-name').change(function () {
        if ($(this).val() != "") {
            var value = $(this).val();
            var id = value.split('_')[0];
            var code = value.split('_')[1];
            $(this).parent().parent().find('.attribute-code').text(code);
        }
        else
        {
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

    $('[name="chkStatus"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).val(true);
        }
        else {
            $(this).val(false);
        }
    });

    $("#btnSave_YArticle").click(function () {
     
        if($("#frmYArticle").valid())
        {
            Save_YArticle();
        }
    });
});