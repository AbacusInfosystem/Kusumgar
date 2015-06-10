
function Multiple_Autocomplete(elementObject, data, callback)
{
    var html = "";

    $(elementObject).parents('.form-group').find(".multiple-list").html("");

    html += "<ul class='todo-list ui-sortable'>";

    for (var i = 0 ; i < data.length ; i++) {

        html += "<li>";

        html += "<input type='hidden' value='" + data[i].key +"'>";

        html += "<span class='text'>" + data[i].label + "</span>";

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