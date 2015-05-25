$(function () {
    $("#frmRole").validate({
        rules: {
            "Role.RoleEntity.Role_Name":
            {
                required: true,
                Check_Role_name: true
            }

        },
        messages: {

            "Role.RoleEntity.Role_Name":
            {
                required: "Role Name is required."
            },
            

        }
    });


   

    jQuery.validator.addMethod("Check_Role_name", function (value, element) {
        var result = true;

        if ($("#txtRole_Name").val() != "" && $("#hdnRole_Name").val() != $("#txtRole_Name").val()) {
            $.ajax({
                url: '/master/check-role',
                data: { role_Name: $("#txtRole_Name").val() },
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
