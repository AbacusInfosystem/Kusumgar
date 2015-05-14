$(document).ready(function () {

    $("#frmDefectType").validate({


        rules: {
            "DefectType.DefectTypeName":
            {
                required: true
            }
        },
        messages: {
            "DefectType.DefectTypeName":
            {
                required: "Enter Defect Type.."

            }
        }
    });

});