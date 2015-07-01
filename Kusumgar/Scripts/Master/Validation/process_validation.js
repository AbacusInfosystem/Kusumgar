$(function () {
    $("#frmProcess").validate({


        rules: {
            "Process.Process_Name":
            {
                required: true,
            }            
        },
        messages: {

            "Process.Process_Name":
            {
                required: "Process name is required."
            }            
        }
    });
});