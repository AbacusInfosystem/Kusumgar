$(function () {
    $("#frmWork_Center").validate({
       
        rules: {
            "Work_Center.Factory_Id":
                {
                    required: true
                },
            "work_Center.Work_Station.Work_Station_Id":
                {
                    required: true
                },
            "Work_Center.Work_Center_Code":
                {
                    required: true
                },
            "Work_Center.Machine_Name":
                {
                    required: true
                },
            "Work_Center.Machine_Properties":
                {
                    required: true
                },
            "Work_Center.TPM_Speed":
                {
                    required: true,
                    number: true
                },
            "Work_Center.Average_Order_Length":
                {
                    required: true,
                    number: true
                },
            "Work_Center.Capacity":
               {
                   required: true
               },
            "Work_Center.Wastage":
                {
                    required: true,
                    number: true
                },
            "Work_Center.Target_Efficiency":
                {
                    required: true,
                    number: true
                }

        },
        messages: {

            "Work_Center.Factory_Id":
            {
                required: "Factory name is required."
            },
            "work_Center.Work_Station.Work_Station_Id":
                {
                    required: "Work station name is required"
                },
            "Work_Center.Work_Center_Code":
                {
                    required: "Work center code is required"
                },
            "Work_Center.Machine_Name":
                {
                    required: "Machine Name Email is required"
                },
            "Work_Center.Machine_Properties":
                {
                    required: " Machine Properties is required"
                },
            "Work_Center.TPM_Speed":
                {
                    required: " TPM Speed is required"
                },
            "Work_Center.Average_Order_Length":
                {
                    required: " Average Order Length is required"
                },
            "Work_Center.Capacity":
                {
                    required: " Capacity is required"
                },
            "Work_Center.Wastage":
                {
                    required: " Wastage is required"
                },
            "Work_Center.Target_Efficiency":
                {
                    required: " Target Efficiency is required"
                }

        }
    });
});