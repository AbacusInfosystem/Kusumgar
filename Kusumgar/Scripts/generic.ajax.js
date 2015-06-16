function UnAuthorizeAccess() {
    var messageText = "";

    messageText += "<div class='Exception'>You do not have access to use this functionality</div>";
   
    $('#message').append(messageText);
}

function CallAjax(param_url, param_dataType, param_data, param_method, param_contentType, param_cache, param_callbackMethod, param_mode, param_divLoadingObject) {



    //$('#divLoadingCompanyListing').css("display", "block");
    if (param_divLoadingObject != null) {

        param_divLoadingObject.css("display", "block");
    }
    

    $.ajax({
        url: param_url,

        dataType: param_dataType,

        data: param_data,

        method: param_method,

        contentType: param_contentType,

        cache: param_cache,

        success: function (data) {

            if (param_mode == "") {

                param_callbackMethod(data);
            }
            else {

                param_callbackMethod(data, param_mode);
            }

            if (param_divLoadingObject != null) {

                param_divLoadingObject.css("display", "none");
            }
            
        },

        error: function () {

            UnAuthorizeAccess();

            if (param_divLoadingObject != null) {

                param_divLoadingObject.css("display", "none");
            }
        }
    });

}


function ToJavaScriptDate(value) {
    if (value != "null" && value != null && value != "") {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));

        var dtDate = dt.getDate();
        if (dtDate.toString().length == 1) {
            dtDate = "0" + dtDate;
        }

        var dtMonth = dt.getMonth() + 1;
        if (dtMonth.toString().length == 1) {
            dtMonth = "0" + dtMonth;
        }

        // return (dt.getMonth() + 1) + "/" + dtDate + "/" + dt.getFullYear();
        //return dtMonth + "/" + dtDate + "/" + dt.getFullYear();
        return dtDate + "/" + dtMonth + "/" + dt.getFullYear();
    }
    else {
        return "";
    }
}