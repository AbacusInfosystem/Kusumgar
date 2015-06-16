$(function () {
    $("#frmPPC_Checkpoint").validate({

        rules: {

            "Enquiry.PPC_Article_Type_Id":
                {
                    required: true
                },

            "Enquiry.PPC_Existing_Article_Type_Id":
                {
                    required: true
                },

            "Enquiry.Quality_Id":
                {
                    required: true
                }
        },
        messages: {

            "Enquiry.PPC_Article_Type_Id":
                {
                    required: "PPC article type is required."
                },

            "Enquiry.PPC_Existing_Article_Type_Id":
                {
                    required: "PPC article type is required."
                },
            "Enquiry.Quality_Id":
                {
                    required: "Quality is required."
                }
           
        }
    });


});