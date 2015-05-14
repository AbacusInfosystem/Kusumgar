var InitializeAutoComplete = function (elementObject, callBack) {
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
            callBack(ui);
            return false;
        },
        open: function () {
            //$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
            $(this).removeClass("ui-corner-all").addClass("ui-sortable");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });
}

