$(document).ready(function () {

    $("#frmDefect").validate({


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
                required: "Defect type is required."

            },

            "Defect.DefectEntity.Defect_Code":
            {
                required: "Defect code is required."

            },

            "Defect.DefectEntity.Defect_Name":
            {
                required: "Defect name is required."

            },

        }
    });

});