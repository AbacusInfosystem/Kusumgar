
$(function () {

    $("#frm_Billing").validate({

        rules: {
            "Addresss":
                {
                    required: true
                },
            "Landline1":
                {
                    required: true,
                    number: true
                },
            "Landline2":
               {
                   number: true
               },
            "FaxNo":
                {
                    number: true
                }

        },

        messages: {

            "Addresss":
               {
                   required: "Address is required"
               },
            "Landline1":
                {
                    required: "Landline is required"

                }
        },
    });
});
