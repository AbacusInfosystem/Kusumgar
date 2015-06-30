$(function () {
    
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
    
    $('#txtReed_Space_Inch').keyup(function () {
       // if ((this.value.match(/^(\d{1,3}\.\d{1,2}|\d{4}\.\d|\d{1,5})$/))) {
            var val = this.value;
            if (val != "") {
                $(this).parent().parent().find('.attribute-code').text(val);
            }
            else {
                $(this).parent().parent().find('.attribute-code').text("-");
            }
            Get_Full_Code();
       // }
    });    

    $('#txtTotal_No_Ends').keyup(function () {
        //if ((this.value.match(/^(\d{1,3}\.\d{1,2}|\d{4}\.\d|\d{1,5})$/))) {
            var val = this.value;
            if (val != "") {
                $(this).parent().parent().find('.attribute-code').text(val);
            }
            else {
                $(this).parent().parent().find('.attribute-code').text("-");
            }
            Get_Full_Code();
       // }
    });    

    $('[name="chkIsActive"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).val(true);
        }
        else {
            $(this).val(false);
        }
    });

    $("#btnSave_WArticle").click(function () {

        if ($("#frmWArticle").valid()) {
            Save_WArticle();
        }
    });
});