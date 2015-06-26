function Initialize_ICheck() {
    var html = "";
    html += "<script> $('input:not(.non-iCheck input:checkbox,.iradio-list)').iCheck({";
    html += "    checkboxClass: 'icheckbox_square-green',";
    html += "   radioClass: 'iradio_square-green',";
    html += "  increaseArea: '20%' ";
    html += "  });";


    html += " $('.iCheck').on('ifChanged', function (event) {";
    html += "   if ($(this).prop('checked')) {";
    html += "      $(this).parent().parent().find('.iCheck-hidden').val(true);";
    html += "     }";
    html += "    else {";
    html += "         $(this).parent().parent().find('.iCheck-hidden').val(false);";
    html += "    }";
    html += " });";

    html += "</script>";

    return html;
}