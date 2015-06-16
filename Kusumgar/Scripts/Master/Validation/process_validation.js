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
                required: "Process Name is required."
            }            
        }
    });
});