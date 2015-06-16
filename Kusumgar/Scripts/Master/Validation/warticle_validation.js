$(function () {
    $("#frmWArticle").validate({

        rules: {
            "WArticle.Quality_Id":
            {
                required: true,
                full_code_validator: true
            },
            "WArticle.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "WArticle.Reed_Space_Inch":
            {
                required: true,
                full_code_validator: true
            },
            "WArticle.Total_No_Of_Ends":
            {
                required: true,
                full_code_validator: true
            },
            "WArticle.Ideal_Beam":
            {
                required: true
            }
        },
        messages: {

            "WArticle.Quality_Id":
            {
                required: "Quality No. is required."                
            },
            "WArticle.Yarn_Type_Id":
            {
                required: "Yarn Type is required."                
            },
            "WArticle.Reed_Space_Inch":
            {
                required: "Reed Space Inch is required."                
            },
            "WArticle.Total_No_Of_Ends":
            {
                required: "Total No. of Ends is required."                
            },
            "WArticle.Ideal_Beam":
            {
                required: "Ideal Beam is required"
            }
            
        }
    });    

    jQuery.validator.addMethod("full_code_validator", function (value, element) {
        if ($(".full-code").text() == "- - - -") {
            return false;
        }
        else {
            return true;
        }
    }, "Select atleast one.");

});
