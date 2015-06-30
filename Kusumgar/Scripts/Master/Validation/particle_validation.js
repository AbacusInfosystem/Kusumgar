$(function () {
    $("#frmPArticle").validate({

        rules: {
           
            "PArticle.Quality_No":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Weave_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Shade_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Chemical_Finish_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Mechanical_Finish_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.P_Finish_width":
            {
                required: true,
                number: true
               
            },
            "PArticle.Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "PArticle.Given_By_Id":
            {
                required: true,
               
            },
            "PArticle.Validated_By_Id":
            {
                required: true,
                
            },
            "PArticle.Developed_Under_Id":
            {
                required: true,
               
            },
        },
        messages: {

           
            "PArticle.Quality_No":
            {
                required: "Quality No is required."
            },
           
            "PArticle.Yarn_Type_Id":
           {
               required: "Yarn Type is required."
           },
            "PArticle.Weave_Id":
            {
                required: "Weave  is required."
            },
            "PArticle.Shade_Id":
            {
                required: "Shade  is required."
            },
            "PArticle.Chemical_Finish_Id":
            {
                required: "Chemical Finish  is required."
            },
            "PArticle.Mechanical_Finish_Id":
            {
                required: "Mechanical Finish is required."
            },
            "PArticle.P_Finish_width":
            {
                required: "P Finish Width is required."
            },
            "PArticle.Type_Id":
            {
                required: "Type  is required."
            },
            "PArticle.Given_By_Id":
            {
                required: "required field"

            },
            "PArticle.Validated_By_Id":
            {
                required: "required field."

            },
            "PArticle.Developed_Under_Id":
            {
                required: "required field."

            },
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