$(document).ready(function () {

    $("#frmAttributeCode").validate({


        rules: {
            "Filter.AttributeId":
            {
                required: true
            },

            "AttributeCode.AttributeCodeName":
    {
        required: true
    },
            "AttributeCode.Code":
            {
                required: true
            }


        },
        messages: {
            "Filter.AttributeId":
            {
                required: "Enter Attribute Name.."

            },

            "AttributeCode.AttributeCodeName":
            {
                required: "Enter Name.."

            },

            "AttributeCode.Code":
            {
                required: "Enter Code.."

            },

        }
    });

});