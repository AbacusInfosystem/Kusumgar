$(function () {

    $('#txtDate_of_Joing').datepicker();

    $('#txtBirthDate').datepicker();

    $("#hdnActive").val(true);

    $('#ChkSystem_User_Flag').on('ifChanged', function (event) {

        if ($("#ChkSystem_User_Flag").prop('checked')) {
            $("#dvUser").show();
            $("#hdnSystem_User_Flag").val(true);
        }
        else {
            $("#dvUser").hide();
            $("#hdnSystem_User_Flag").val(false);
        }

    });

   
    $('#ChkSystem_User_Flag').on('ifChanged', function (event) {
       
        if ($("#ChkSystem_User_Flag").prop('checked')) {
            $("#dvUser").show();
            $("#hdnSystem_User_Flag").val(true);

            $("#txtUser_Name").rules("add", {
                required: true,
                validate_username : true,
                messages: {
                    required: "User Name is required"
                }
            });

            $("#txtPassword").rules("add", {
                required: true,
                validate_password: true,
                messages: {
                    required: "Password is required"
                }
            });

            $("#txtConform_Password").rules("add", {
                required: true,
                validate_password: true,
                messages: {
                    required: "Conform Password is required"
                }
            });
        }
        else
        {
            $("#dvUser").hide();
            $("#hdnSystem_User_Flag").val(false);

            $("#txtUser_Name").rules("remove");

            $("#txtPassword").rules("remove");

            $("#txtConform_Password").rules("remove");

            $("#dvUser").find('.form-group').removeClass("has-error");
            $("#dvUser").find('.form-group').find('.help-block').html('');
            
        }

    });

    $('[name="rdGender"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).parent().addClass("checked");
            $("#hdnGender").val($(this).val());
        }
    });

    $('[name="chkStatus"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $(this).parent().addClass("checked");
            $("#hdnActive").val(true);
        }
        else {
            $("#hdnActive").val(false);
        }
    });
 



    $("#btnSave").click(function () {

        var Role_Ids = "";

        $('[name="Chk_User_Role"]').each(function (i) {

            if ($(this).prop('checked')) {

                Role_Ids += $(this).val() + ",";
            }
        });

        Role_Ids = Role_Ids.slice(0, Role_Ids.length - 1);

        $("#hdnRole_Ids").val(Role_Ids);

        if ($("#frmUser").valid()) {

           

            if ($("#hdnUserId").val() == 0) {
                $("#frmUser").attr("action", "/master/insert-employee");

                $("#frmUser").attr("method", "POST");

                $("#frmUser").submit();
            }
            else
            {
                $("#frmUser").attr("action", "/master/update-employee");

                $("#frmUser").attr("method", "POST");

                $("#frmUser").submit();
            }
       }
    });

});