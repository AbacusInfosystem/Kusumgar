
var InitializeMultiAutoComplete = function (elementObject) {


    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtFunctional_Parameters') {
                urlString = "/master/test-autocomplete/" + $('#txtFunctional_Parameters').val();
            }

            if ($(elementObject).attr("id") == 'txtVisual_Parameters') {
                urlString = "/ajax/defect-list/" + $('#txtVisual_Parameters').val();
            }

            if ($(elementObject).attr("id") == 'txtLot_No') {
                urlString = "/crm/get-lot-no/" + $('#txtLot_No').val();
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
            $(this).parent().find('input[type=hidden]').val(ui.item.value);

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




function Multiple_Autocomplete(elementObject, data, callback)
{
    var html = "";

    $(elementObject).parents('.form-group').find(".multiple-list").html("");

    html += "<ul class='todo-list ui-sortable'>";

    for (var i = 0 ; i < data.length ; i++) {

        html += "<li>";

        html += "<input type='hidden' value='" + data[i].Value +"'>";

        html += "<span class='text'>" + data[i].Label + "</span>";

        html += " <div class='tools'>";

        html += " <i class='fa fa-remove' ></i>";

        html += "</div>";

        html += "</li>";

    }

    html += "</ul>";

    $(elementObject).parents('.form-group').find(".multiple-list").html(html);

    $(elementObject).parents('.form-group').find('.fa-remove').click(function (event) {

        event.preventDefault();

        callback($(this).parents('li').find('input[type=hidden]').val());

        $(this).parents('li').remove();
    });
}