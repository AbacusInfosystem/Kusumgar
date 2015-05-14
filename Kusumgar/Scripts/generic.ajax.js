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