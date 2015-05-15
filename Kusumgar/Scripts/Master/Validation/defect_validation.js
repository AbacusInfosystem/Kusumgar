$(document).ready(function () {

    $("#frmDefect").validate({

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
            "Defect.DefectEntity.Defect_Type_Id":
            {
                required: true
            },

            "Defect.DefectEntity.Defect_Code":
    {
        required: true
    },
            "Defect.DefectEntity.Defect_Name":
            {
                required: true
            }


        },
        messages: {
            "Defect.DefectEntity.Defect_Type_Id":
            {
                required: "Enter Defect Type.."

            },

            "Defect.DefectEntity.Defect_Code":
            {
                required: "Enter Defect Code.."

            },

            "Defect.DefectEntity.Defect_Name":
            {
                required: "Enter Defect Name.."

            },

        }
    });

});