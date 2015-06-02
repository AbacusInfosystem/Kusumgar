$(document).ready(function () {

    $("#frmAttributeCode").validate({


        rules: {
            "Attribute_Code.AttributeCodeEntity.Attribute_Id":
            {
                required: true
            },

            "Attribute_Code.AttributeCodeEntity.Attribute_Code_Name":
            {
                required: true
            },
            "Attribute_Code.AttributeCodeEntity.Code":
            {
                required: true
            }

        },
        messages: {

            "Attribute_Code.AttributeCodeEntity.Attribute_Id":
            {
                required: "Attribute Name is required."

            },

            "Attribute_Code.AttributeCodeEntity.Attribute_Code_Name":
            {
                required: "Code name is required."

            },

            "Attribute_Code.AttributeCodeEntity.Code":
            {
                required: "Code is required."

            },

        }
    });

});