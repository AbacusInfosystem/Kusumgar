$(document).ready(function () {

    $("#frmDefect").validate({


        rules: {
            "Defect.Defect_Type_Id":
            {
                required: true
            },

            "Defect.Defect_Code":
    {
        required: true
    },
            "Defect.Defect_Name":
            {
                required: true
            }


        },
        messages: {
            "Defect.Defect_Type_Id":
            {
                required: "Defect type is required."

            },

            "Defect.Defect_Code":
            {
                required: "Defect code is required."

            },

            "Defect.Defect_Name":
            {
                required: "Defect name is required."

            },

        }
    });

});