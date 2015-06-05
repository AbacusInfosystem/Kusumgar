$(function () {
    $("#frmWork_Center").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

        rules: {
            "Work_Center.Factory_Entity.Factory_Id":
                {
                    required: true
                },
            "Work_Center.Work_Station_Name":
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

            "Work_Center.Factory_Entity.Factory_Id":
            {
                required: "Factory name is required."
            },
            "Work_Center.Work_Station_Name":
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