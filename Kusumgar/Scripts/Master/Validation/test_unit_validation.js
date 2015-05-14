$(document).ready(function () {

    $("#frmTestUnit").validate({

        rules: {
            "TestUnit.TestUnitName":
            {
                required: true
            }
        },
        messages: {
            "TestUnit.TestUnitName":
            {
                required: "Enter Test Unit.."

            }
        }
    });

});