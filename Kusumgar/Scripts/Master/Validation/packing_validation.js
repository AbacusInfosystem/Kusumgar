$(function () {
    $("#frmPacking").validate({


        rules: {
            "Packing.Packing_Name":
            {
                required: true,
            }
        },
        messages: {

            "Packing.Packing_Name":
            {
                required: "Packing Name is required."
            }
        }
    });
});