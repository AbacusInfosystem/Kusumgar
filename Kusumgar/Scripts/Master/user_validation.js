$(function () {
    $("#frmUser").validate({


        rules: {
            "User.First_Name":
            {
                required: true
            },
            "User.Last_Name":
            {
                required: true
            },
            "User.Birth_Date":
            {
                required: true
            },
            "User.Gender":
            {
                required: true
            },
            "User.Date_Of_Joining":
            {
                required: true
            },
            "User.Personal_Email":
            {
                required: true,
                email :true
            },
            "User.Mobile_No1":
            {
                required: true,
                number: true,
                minlength: 10
            },
            "User.Last_Name":
            {
                required: true
            },
            "User.Mobile_No2":
            {
                number: true,
                minlength: 10
            },
            "User.Fax_No":
            {
                number: true
            },
            "User.Office_Email":
            {
                email: true
            },
            "User.Residence_PinCode":
            {
                number: true
            },
            "User.Office_PinCode":
            {
                number: true
            },
            "User.Office_Landline":
            {
                number: true
            },
            "User.Residence_Landline":
            {
                number: true
            },
            "User.User_Name":
            {
                validate_Online_User: true,
                validate_username : true
            },
            "User.Password":
            {
                validate_password: true,
                password_required: true
            },
            "User.ConformPassword":
            {
                validate_password: true,
                conform_password_required: true
            },
            "User.Role_Ids":
            {
                required: true
            }

        },
        messages: {

            "User.First_Name":
            {
                required: "User name is required."
            },
            "User.Birth_Date":
            {
                required: "Birth date is required."
            },
            "User.Gender":
            {
                required: "Gender is required."
            },
            "User.Date_Of_Joining":
            {
                required: "Date of joining is required."
            },
            "User.Personal_Email":
            {
                required: "Personal email is required."
            },
            "User.Mobile_No1":
            {
                required: "Mobile no. is required."
            },
            "User.Last_Name":
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

    jQuery.validator.addMethod("password_required", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtPassword").val() == "") {
                result = false;
            }
        }
        return result;

    }, "Password is required.");

    jQuery.validator.addMethod("conform_password_required", function (value, element) {
        var result = true;

        if ($("#ChkSystem_User_Flag").is(':checked')) {

            if ($("#txtConform_Password").val() == "") {
                result = false;
            }
        }
        return result;

    }, "Conform password is required.");

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
