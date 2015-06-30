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
                required: "Quality no is required."
            },
           
            "PArticle.Yarn_Type_Id":
           {
               required: "Yarn type is required."
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
                required: "Chemical finish  is required."
            },
            "PArticle.Mechanical_Finish_Id":
            {
                required: "Mechanical finish is required."
            },
            "PArticle.P_Finish_width":
            {
                required: "P finish width is required."
            },
            "PArticle.Type_Id":
            {
                required: "Type is required."
            },
            "PArticle.Given_By_Id":
            {
                required: "Given by is required."

            },
            "PArticle.Validated_By_Id":
            {
                required: "Validated by required."

            },
            "PArticle.Developed_Under_Id":
            {
                required: "Developed under is required."

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