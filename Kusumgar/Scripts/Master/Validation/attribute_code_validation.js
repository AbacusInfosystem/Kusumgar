$(document).ready(function () {

    $("#frmAttributeCode").validate({


        rules: {
            "Attribute_Code.Attribute_Id":
            {
                required: true
            },

            "Attribute_Code.Attribute_Code_Name":
            {
                required: true
            },
            "Attribute_Code.Code":
            {
                required: true
            }

        },
        messages: {

            "Attribute_Code.Attribute_Id":
            {
                required: "Attribute name is required."

            },

            "Attribute_Code.Attribute_Code_Name":
            {
                required: "Code name is required."

            },

            "Attribute_Code.Code":
            {
                required: "Code is required."

            },

        }
    });

});