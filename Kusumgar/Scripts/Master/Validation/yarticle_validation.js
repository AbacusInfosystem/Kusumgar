$(function () {
    $("#frmYArticle").validate({

        rules: {
            "YArticle.Work_Station_Id":
            {
                work_Center_required: true
            },
            "YArticle.Lead_Time_To_Purchase":
            {
                required: true
            },
            "YArticle.Developed_Under_Id":
            {
                required: true
            },
            "YArticle.Validated_By_Id":
            {
                required: true
            },
            "YArticle.Given_By_Id":
            {
                required: true
            },
            "YArticle.Supplier_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Colour_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Chemical_Treatment_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Tenasity_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Shrinkage_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Origin_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Filaments_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Shade_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Ply_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Twist_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Twist_Mingle_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.Denier_Id":
            {
                required: true,
                full_code_validator: true
            }
        },
        messages: {

            "YArticle.Work_Station_Id":
             {
                 //required: "Work center is required."
             },
            "YArticle.Lead_Time_To_Purchase":
            {
                required: "Lead time to purchase is required."
            },
            "YArticle.Developed_Under_Id":
            {
                required: "Developed under is required."
            },
            "YArticle.Validated_By_Id":
            {
                required: "Validated by is required."
            },
            "YArticle.Given_By_Id":
            {
                required: "Given by is requied."
            },
            "YArticle.Supplier_Id":
            {
                required: "Supplier is required."
            },
            "YArticle.Colour_Id":
            {
                required: "Colour is required."
            },
            "YArticle.Chemical_Treatment_Id":
            {
                required: "Chemical treatment is required."
            },
            "YArticle.Tenasity_Id":
            {
                required: "Tenasity is required."
            },
            "YArticle.Shrinkage_Id":
            {
                required: "Shrinkage is required."
            },
            "YArticle.Origin_Id":
            {
                required: "Origin is required"
            },
            "YArticle.Filaments_Id":
            {
                required: "Filaments is required"
            },
            "YArticle.Shade_Id":
            {
                required: "Shade is required"
            },
            "YArticle.Yarn_Type_Id":
            {
                required: "Yarn type is required"
            },
            "YArticle.Ply_Id":
            {
                required: "Ply is required"
            },
            "YArticle.Twist_Type_Id":
            {
                required: "Twist type is required"
            },
            "YArticle.Twist_Mingle_Id":
            {
                required: "Twist mingle is required"
            },
            "YArticle.Denier_Id":
            {
                required: "Denier is required"
            }

        }
    });

    jQuery.validator.addMethod("work_Center_required", function (value, element) {
        if ($(element).parents('.form-group').find('.text').length) {
            if ($(element).parents('.form-group').find('.text').html() != "") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    },"Work center is required.");

    jQuery.validator.addMethod("full_code_validator", function (value, element) {
        if( $(".full-code").text() == "- - - -")
        {
            return false;
        }
        else {
            return true;
        }
    }, "Select atleast one.");
    
});
    