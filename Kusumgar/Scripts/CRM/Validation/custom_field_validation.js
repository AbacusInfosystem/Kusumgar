$(function () {

    $("#frmCustom_Fields").validate({
        rules: {
            "Field_Name":
                {
                    required :true
                },
            "Field_Value":
                {
                    required: true
                }
        },
        messages: {
            "Field_Name":
                {
                    required: "Field name is required."
                },
            "Field_Value":
                {
                    required: "Field value is required."
                }
        }
    });
});