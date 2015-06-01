$(document).ready(function () {

    $("#frmDefectType").validate({

        rules: {
            "DefectType.DefectTypeEntity.Defect_Type_Name":
            {
                required: true
            }
        },
        messages: {
            "DefectType.DefectTypeEntity.Defect_Type_Name":
            {
                required: "Defect type is required."

            }
        }
    });

});