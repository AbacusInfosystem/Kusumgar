function validateDatePattern(value, element)
{
    var result = true;
    if ($('#' + element.id).val() != "") {
        var reg = new RegExp("^(1|2|3|4|5|6|7|8|9|01|02|03|04|05|06|07|08|09|10|11|12)/(0?[1-9]|[1-9]|[12][0-9]|3[01])/([0-9]{4}|[0-9]{2})$");
        //var reg = new RegExp("^(0?[1-9]|[1-9]|[12][0-9]|3[01])/(1|2|3|4|5|6|7|8|9|01|02|03|04|05|06|07|08|09|10|11|12)/([0-9]{4}|[0-9]{2})$");
        if (!reg.test($('#' + element.id).val())) {
            result = false;
        }
    }
    return result;
}

function validateOnBlur(controlObject, formObject) {
    if ($(controlObject).val() != "") {
        $(controlObject).rules("add", { ManualEntry: true });
        $(formObject).validate().element($(controlObject));
        $(controlObject).rules("remove", "ManualEntry");
    }
}

function validateManualEntry(value, element) {
    var result = true;
    var d;

    var selected = value.split("/");
    var month, day, year;

    var year = parseInt(selected[2], 10);
    var month = parseInt(selected[0], 10);
    var day = parseInt(selected[1], 10);
    //var month = parseInt(selected[1], 10);
    //var day = parseInt(selected[0], 10);

    if (selected[2].length == 2) {
        if (selected[2] >= '00' && selected[2] <= '20') {
            year = parseInt('20' + selected[2], 10);
        }
        else {
            year = parseInt('19' + selected[2], 10);
        }
    }
    else {
        year = parseInt(selected[2], 10);
    }

    d = new Date(year, month - 1, day);

    if (d.getFullYear() == year && d.getMonth() + 1 == month && d.getDate() == day) {
        if (selected[0].length == 1) {
            selected[0] = '0' + selected[0];
        }
        if (selected[1].length == 1) {
            selected[1] = '0' + selected[1];
        }
        if (selected[2].length == 2) {
            if (selected[2] >= '00' && selected[2] <= '20') {
                selected[2] = '20' + selected[2];
            }
            else {
                selected[2] = '19' + selected[2];
            }
        }

        $(element).val('' + selected[0] + '/' + selected[1] + '/' + selected[2]);
    }
    else {
        result = false;
    }

    return result;
}

function validateOnSelection(controlObject, formObject) {
    $(formObject).validate().element($(controlObject));
}