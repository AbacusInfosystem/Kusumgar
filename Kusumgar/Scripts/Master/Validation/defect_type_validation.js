$(document).ready(function () {

    $("#frmDefectType").validate({

        rules: {
            "DefectType.Defect_Type_Name":
            {
                required: true
            }
        },
        messages: {
            "DefectType.Defect_Type_Name":
            {
                required: "Defect type is required."

            }
        }
    });

});