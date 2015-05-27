
//var InitializeAutoComplete = function (elementObject, callBack) {
var InitializeAutoComplete = function (elementObject) {

   
    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtCustomer_Name') {
                urlString = "/ajax/customer-list/" + $('#txtCustomer_Name').val();
            }
            if ($(elementObject).attr("id") == 'txtVendorName') {
                urlString = "/master/get-vendor-id-by-vendorname/" + $('#txtVendorName').val();
            }
         
            if ($(elementObject).attr("id") == 'txtSupplierName') {
                urlString = "/master/vendor-list/" + $('#txtSupplierName').val();
            }

            if ($(elementObject).attr("id") == 'txtVendorName') {
                urlString = "/ajax/vendor-list/" + $('#txtVendorName').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit1') {

                urlString = "/ajax/test/" + $('#txtTestUnit1').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit2') {
                urlString = "/ajax/test/" + $('#txtTestUnit2').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit3') {
                urlString = "/ajax/test/" + $('#txtTestUnit3').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit4') {
                urlString = "/ajax/test/" + $('#txtTestUnit4').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit5') {
                urlString = "/ajax/test/" + $('#txtTestUnit5').val();
            }

            if ($(elementObject).attr("id") == 'txtTestUnit6') {
                urlString = "/ajax/test/" + $('#txtTestUnit6').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit7') {
                urlString = "/ajax/test/" + $('#txtTestUnit7').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit8') {

                urlString = "/ajax/test/" + $('#txtTestUnit8').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit9') {
                urlString = "/ajax/test/" + $('#txtTestUnit9').val();
            }
            if ($(elementObject).attr("id") == 'txtTestUnit10') {
                urlString = "/ajax/test/" + $('#txtTestUnit10').val();
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

            $(this).parent().find('input[type=text]').val("");
            $(this).parent().find('input[type=hidden]').val(ui.item.value);

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
                $(this).parent().parent().parent().parent().find('input[type=text]').val("");
                $(this).parent().parent().parent().parent().find('input[type=hidden]').val("");
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

    $('.auto-complete').each(function () {

        if ($(this).find('input[type=hidden]').val() != 0) {
            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + $(this).find('input[type=text]').val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).find(".ui-menu")[0]) {

                $(this).find('.text').html(ui.item.label);
            } else {

                $(this).append(htmlText);
            }

            $(this).find('input[type=text]').val("");

            $('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parent().parent().parent().parent().find('input[type=text]').val("");
                $(this).parent().parent().parent().parent().find('input[type=hidden]').val("");
                $(this).parent().parent().parent().parent().find('.todo-list').remove();
            });
        }
    });

    $('.auto-complete').each(function () {

        if ($(this).find('input[type=hidden]').val() != 0) {
            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + $(this).find('input[type=text]').val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).find(".ui-menu")[0]) {

                $(this).find('.text').html(ui.item.label);
            } else {

                $(this).append(htmlText);
}

            $(this).find('input[type=text]').val("");

            $('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parent().parent().parent().parent().find('input[type=text]').val("");
                $(this).parent().parent().parent().parent().find('input[type=hidden]').val("");
                $(this).parent().parent().parent().parent().find('.todo-list').remove();
            });
        }
    });
}