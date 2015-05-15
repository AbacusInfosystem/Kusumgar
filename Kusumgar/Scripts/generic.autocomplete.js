//var InitializeAutoComplete = function (elementObject, callBack) {
var InitializeAutoComplete = function (elementObject) {

   
    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtCustomer_Name') {
                urlString = "/ajax/customer-list/" + $('#txtCustomer_Name').val();
            }
         
            $.ajax({
                url: urlString,
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Value
                        }
                    }));
                }
            });
        },
        minLength: 2,
        focus: function (event, ui) {
            $(this).val(ui.item.label);
            return false;
        },
        select: function (event, ui) {

            $(this).val(ui.item.label);
            $(this).parent().find('input[type=hidden]').addClass('auto-val');
            $(this).parent().find('input[type=text]').addClass('auto-lbl');

            $(this).parent().find('.auto-lbl').val(ui.item.label);
            $(this).parent().find('.auto-val').val(ui.item.value);

            if ($(this).parent().find(".todo-list")[0]) {
                $(this).parent().find('.todo-list').remove();
            }

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parent().find(".ui-menu")[0]) {

                $(this).parent().find('.text').html(ui.item.label);
            } else {

                $(this).parent().append(htmlText);
            }

            $('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parent().parent().parent().parent().find('.auto-lbl').val("");
                $(this).parent().parent().parent().parent().find('.auto-val').val("");
                $(this).parent().parent().parent().parent().find('.todo-list').remove();
            });
            //callBack(ui);
            
            $('.ui-autocomplete').html("");
            return false;
        },
        open: function () {
            //$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
            $(this).removeClass("ui-corner-all").addClass("ui-sortable");
        },
        close: function (event, ui) {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
           
        }
    });
}




