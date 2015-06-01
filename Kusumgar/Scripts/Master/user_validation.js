$(function () {
    $("#frmUser").validate({


        rules: {
            "User.UserEntity.First_Name":
            {
                required: true
            },
            "User.UserEntity.Last_Name":
            {
                required: true
            },
            "User.UserEntity.Birth_Date":
            {
                required: true
            },
            "User.UserEntity.Gender":
            {
                required: true
            },
            "User.UserEntity.Date_Of_Joining":
            {
                required: true
            },
            "User.UserEntity.Personal_Email":
            {
                required: true,
                email :true
            },
            "User.UserEntity.Mobile_No1":
            {
                required: true,
                number: true,
                minlength: 10
            },
            "User.UserEntity.Last_Name":
            {
                required: true
            },
            "User.UserEntity.Mobile_No2":
            {
                number: true,
                minlength: 10
            },
            "User.UserEntity.Fax_No":
            {
                number: true
            },
            "User.UserEntity.Office_Email":
            {
                email: true
            },
            "User.UserEntity.Residence_PinCode":
            {
                number: true
            },
            "User.UserEntity.Office_PinCode":
            {
                number: true
            },
            "User.UserEntity.Office_Landline":
            {
                number: true
            },
            "User.UserEntity.Residence_Landline":
            {
                number: true
            },
            "User.UserEntity.User_Name":
            {
                validate_Online_User: true,
                validate_username : true
            },
            "User.UserEntity.Password":
            {
                validate_password: true
            },
            "User.UserEntity.ConformPassword":
            {
                validate_password: true
            },
            "User.Role_Ids":
            {
                required: true
            }

        },
        messages: {

            "User.UserEntity.First_Name":
            {
                required: "User name is required."
            },
            "User.UserEntity.Birth_Date":
            {
                required: "Birth date is required."
            },
            "User.UserEntity.Gender":
            {
                required: "Gender is required."
            },
            "User.UserEntity.Date_Of_Joining":
            {
                required: "Date of joining is required."
            },
            "User.UserEntity.Personal_Email":
            {
                required: "Personal email is required."
            },
            "User.UserEntity.Mobile_No1":
            {
                required: "Mobile no1 is required."
            },
            "User.UserEntity.Last_Name":
            {
                required: "Last name is required."
            },
            "User.Role_Ids":
            {
                required: "Role is required."
            },

        }
    });


    jQuery.validator.addMethod("validate_Online_User", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtUser_Name").val() =='') {
                result = false;
            }
        }
        return result;

    }, "User Name required.");

    jQuery.validator.addMethod("validate_password", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtPassword").val() != $("#txtConform_Password").val()) {
                result = false;
            }
        }
        return result;

    }, "Password not matched.");

    jQuery.validator.addMethod("validate_username", function (value, element) {
        var result = true;

        if ($("#txtUser_Name").val() != "" && $("#hdnUser_Name").val() != $("#txtUser_Name").val()) {
            $.ajax({
                url: '/master/check-user',
                data: { User_Name: $("#txtUser_Name").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "User name is already exists.");
});
