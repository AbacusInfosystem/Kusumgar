$(function () {
    $("#frmRole").validate({
       

        rules: {
            "Role.RoleEntity.Role_Name":
            {
                required: true,
                validate_rolename : true
            }

        },
        messages: {

            "Role.RoleEntity.Role_Name":
            {
                required: "Role name is required."
            },
            

        }
    });


   

    jQuery.validator.addMethod("validate_rolename", function (value, element) {
        var result = true;

        if ($("#txtRole_Name").val() != "" && $("#hdnRole_Name").val() != $("#txtRole_Name").val()) {
            $.ajax({
                url: '/master/check-role',
                data: { Role_Name: $("#txtRole_Name").val() },
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

    }, "Role name is already exists.");
});
