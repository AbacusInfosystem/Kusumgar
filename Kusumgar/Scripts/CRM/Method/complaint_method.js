function Get_Lot_No(label, value) {
    var html = "";

    for (var i = 0; i < label.length; i++) {

        html += "<li>";

        html += "<input type='hidden' class='lot_no' value='" + value[i] + "'>";

        html += "<span class='text'>" + label[i] + "</span>";

        html += " <div class='tools'>";

        html += " <i class='fa fa-remove' ></i>";

        html += "</div>";

        html += "</li>";
    }

    return html;
}