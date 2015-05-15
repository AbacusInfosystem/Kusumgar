$(document).ready(function () {

    $("#frmAttributeCode").validate({

        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

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
                required: "Enter Attribute Name.."

            },

            "Attribute_Code.AttributeCodeEntity.Attribute_Code_Name":
            {
                required: "Enter Name.."

            },

            "Attribute_Code.AttributeCodeEntity.Code":
            {
                required: "Enter Code.."

            },

        }
    });

});