$(function () {
    $("#frmCArticle").validate({

        rules: {
            "CArticle.Quality_Id":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Weave":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Shade":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Chemical_Finish":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Mechanical_Finish":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Type":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.C_Finish_Width":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Coat":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.C_gsm":
            {
                required: true,
                full_code_validator: true
            },
            "CArticle.Batch":
            {
                required: true
            }
        },
        messages: {

            "CArticle.Quality_Id":
            {
                required: "Quality no. is required."                
            },
            "CArticle.Yarn_Type_Id":
            {
                required: "Yarn type is required."                
            },
            "CArticle.Weave":
            {
                required: "Weave is required."                
            },
            "CArticle.Shade":
            {
                required: "Shade is required."                
            },
            "CArticle.Chemical_Finish":
            {
                required: "Chemical finish is required."
            },
            "CArticle.Chemical_Finish":
            {
                required: "Mechanical finish is required."
            },
            "CArticle.Type":
            {
                required: "Type is required."
            },
            "CArticle.C_Finish_Width":
            {
                required: "C finish width is required."
            },
            "CArticle.Coat":
            {
                required: "Coat is required."
            },
            "CArticle.C_gsm":
            {
                required: "C gsm is required."
            },
            "CArticle.Batch":
            {
                required: "Batch is required."
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