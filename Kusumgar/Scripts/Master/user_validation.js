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
                check_online_user: true,
                check_user_name_exists: true
            },
            "User.UserEntity.Password":
            {
                check_password: true
            },
            "User.UserEntity.ConformPassword":
            {
                check_password: true
            },
            "User.Role_Ids":
            {
                required: true
            }

        },
        messages: {

            "User.UserEntity.First_Name":
            {
                required: "User Name is required."
            },
            "User.UserEntity.Birth_Date":
            {
                required: "Birth Date is required."
            },
            "User.UserEntity.Gender":
            {
                required: "Gender is required."
            },
            "User.UserEntity.Date_Of_Joining":
            {
                required: "Date Of Joining is required."
            },
            "User.UserEntity.Personal_Email":
            {
                required: "Personal Email is required."
            },
            "User.UserEntity.Mobile_No1":
            {
                required: "Mobile No1 is required."
            },
            "User.UserEntity.Last_Name":
            {
                required: "Last Name is required."
            },
            "User.Role_Ids":
            {
                required: "Role is required."
            },

        }
    });


    jQuery.validator.addMethod("check_online_user", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtUser_Name").val() =='') {
                result = false;
            }
        }
        return result;

    }, "User Name required.");

    jQuery.validator.addMethod("check_password", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtPassword").val() != $("#txtConform_Password").val()) {
                result = false;
            }
        }
        return result;

    }, "Password not matched.");

    jQuery.validator.addMethod("check_user_name_exists", function (value, element) {
        var result = true;

        if ($("#txtUser_Name").val() != "" && $("#hdnUser_Name").val() != $("#txtUser_Name").val()) {
            $.ajax({
                url: '/master/check-user',
                data: { user_Name: $("#txtUser_Name").val() },
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
