$(document).ready(function () {

    $("#frmTestUnit").validate({

        rules: {
            "Test_Unit.Test_Unit_Name":
            {
                required: true
            }
        },
        messages: {
            "Test_Unit.Test_Unit_Name":
            {
                required: "Test unit is required."

            }
        }
    });

});