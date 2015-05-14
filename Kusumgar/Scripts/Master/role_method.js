function Add(parentid, childid) {

    $("#" + parentid + "  option:selected").appendTo("#" + childid);

    sortHtml($("#" + childid));
}

function sortHtml(Obj) {
    arry = Obj.children().sort(function (a, b) {
        var valueA = $(a).attr('title').toLowerCase(), valueB = $(b).attr('title').toLowerCase();
        if (valueB > valueA)
            return -1;
        if (valueA > valueB)
            return 1;
        return 0;
    });

    Obj.empty();
    arry.each(function (index) {
        Obj.append(this);
    });
}

function sort(Obj) {
    arry = Obj.children().sort(function (a, b) {
        return a.value - b.value;
    });

    Obj.empty();
    arry.each(function (index) {
        Obj.append(this);
    });
}

