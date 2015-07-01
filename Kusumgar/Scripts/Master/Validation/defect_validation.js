$(document).ready(function () {

    $("#frmDefect").validate({


        rules: {
            "Defect.Process_Id":
            {
                required: true
            },

            "Defect.Defect_Major":
           {
              required: true
           },
           
            "Defect.Defect_Minor":
         {
             required: true
         },

            "Defect.Defect_Name":
            {
                required: true
            }


        },
        messages: {
            "Defect.Process_Id":
            {
                required: "Process is required."

            },

            "Defect.Defect_Major":
            {
                required: "Defect major is required."

            },

            "Defect.Defect_Minor":
            {
                required: "Defect minor is required."
            },

            "Defect.Defect_Name":
            {
                required: "Defect name is required."

            },

        }
    });

});