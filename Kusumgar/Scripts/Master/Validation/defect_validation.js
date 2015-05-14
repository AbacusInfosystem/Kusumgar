$(document).ready(function () {

    $("#frmDefect").validate({


        rules: {
            "Defect.DefectTypeName":
            {
                required: true
            },

            "Defect.DefectCode":
    {
        required: true
    },
            "Defect.DefectName":
            {
                required: true
            }


        },
        messages: {
            "Defect.DefectTypeName":
            {
                required: "Enter Defect Type.."

            },

            "Defect.DefectCode":
            {
                required: "Enter Defect Code.."

            },

            "Defect.DefectName":
            {
                required: "Enter Defect Name.."

            },

        }
    });

});