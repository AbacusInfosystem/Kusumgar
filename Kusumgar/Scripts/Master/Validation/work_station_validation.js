$(function () {
    $("#frmWork_Station").validate({
       
        rules: {
            "Work_Station.Factory_Id":
                {
                    required: true
                },
            "work_Station.Work_Center.Work_Center_Id":
                {
                    required: true
                },
            "Work_Station.Work_Station_Code":
                {
                    required: true
                },
            "Work_Station.Machine_Name":
                {
                    required: true
                },
            "Work_Station.Machine_Properties":
                {
                    required: true
                },
            "Work_Station.TPM_Speed":
                {
                    required: true,
                    number: true
                },
            "Work_Station.Average_Order_Length":
                {
                    required: true,
                    number: true
                },
            "Work_Station.Capacity":
               {
                   required: true
               },
            "Work_Station.Wastage":
                {
                    required: true,
                    number: true
                },
            "Work_Station.Target_Efficiency":
                {
                    required: true,
                    number: true
                }

        },
        messages: {

            "Work_Station.Factory_Id":
            {
                required: "Factory name is required."
            },
            "work_Station.Work_Center.Work_Center_Id":
                {
                    required: "Work Center name is required"
                },
            "Work_Station.Work_Station_Code":
                {
                    required: "Work Station code is required"
                },
            "Work_Station.Machine_Name":
                {
                    required: "Machine name email is required"
                },
            "Work_Station.Machine_Properties":
                {
                    required: " Machine properties is required"
                },
            "Work_Station.TPM_Speed":
                {
                    required: " TPM speed is required"
                },
            "Work_Station.Average_Order_Length":
                {
                    required: " Average order length is required"
                },
            "Work_Station.Capacity":
                {
                    required: " Capacity is required"
                },
            "Work_Station.Wastage":
                {
                    required: " Wastage is required"
                },
            "Work_Station.Target_Efficiency":
                {
                    required: " Target efficiency is required"
                }

        }
    });
});