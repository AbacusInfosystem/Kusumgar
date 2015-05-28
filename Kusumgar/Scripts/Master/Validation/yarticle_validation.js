$(function () {
    $("#frmYArticle").validate({

        rules: {
            "YArticle.YArticle_Entity.Work_Center_Code":
            {
                work_Center_required: true
            },
            "YArticle.YArticle_Entity.Lead_Time_To_Purchase":
            {
                required: true
            },
            "YArticle.YArticle_Entity.Developed_Under_Id":
            {
                required: true
            },
            "YArticle.YArticle_Entity.Validated_By_Id":
            {
                required: true
            },
            "YArticle.YArticle_Entity.Given_By_Id":
            {
                required: true
            },
            "YArticle.YArticle_Entity.Supplier_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Colour_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Chemical_Treatment_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Tenasity_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Shrinkage_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Origin_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Filaments_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Shade_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Ply_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Twist_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Twist_Mingle_Id":
            {
                required: true,
                full_code_validator: true
            },
            "YArticle.YArticle_Entity.Denier_Id":
            {
                required: true,
                full_code_validator: true
            }
        },
        messages: {

            "YArticle.YArticle_Entity.Work_Center_Code":
             {
                 //required: "Work center is required."
             },
            "YArticle.YArticle_Entity.Lead_Time_To_Purchase":
            {
                required: "Lead time to purchase is required."
            },
            "YArticle.YArticle_Entity.Developed_Under_Id":
            {
                required: "Developed under is required."
            },
            "YArticle.YArticle_Entity.Validated_By_Id":
            {
                required: "Validated by is required."
            },
            "YArticle.YArticle_Entity.Given_By_Id":
            {
                required: "Given by is requied."
            },
            "YArticle.YArticle_Entity.Supplier_Id":
            {
                required: "Supplier is required."
            },
            "YArticle.YArticle_Entity.Colour_Id":
            {
                required: "Colour is required."
            },
            "YArticle.YArticle_Entity.Chemical_Treatment_Id":
            {
                required: "Chemical treatment is required."
            },
            "YArticle.YArticle_Entity.Tenasity_Id":
            {
                required: "Tenasity is required."
            },
            "YArticle.YArticle_Entity.Shrinkage_Id":
            {
                required: "Shrinkage is required."
            },
            "YArticle.YArticle_Entity.Origin_Id":
            {
                required: "Origin is required"
            },
            "YArticle.YArticle_Entity.Filaments_Id":
            {
                required: "Filaments is required"
            },
            "YArticle.YArticle_Entity.Shade_Id":
            {
                required: "Shade is required"
            },
            "YArticle.YArticle_Entity.Yarn_Type_Id":
            {
                required: "Yarn type is required"
            },
            "YArticle.YArticle_Entity.Ply_Id":
            {
                required: "Ply is required"
            },
            "YArticle.YArticle_Entity.Twist_Type_Id":
            {
                required: "Twist type is required"
            },
            "YArticle.YArticle_Entity.Twist_Mingle_Id":
            {
                required: "Twist mingle is required"
            },
            "YArticle.YArticle_Entity.Denier_Id":
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
    