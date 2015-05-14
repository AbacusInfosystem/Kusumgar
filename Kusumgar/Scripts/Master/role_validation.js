$(function () {
    $("#frmRole").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({'color':'#A94442','background-color':'#F2DEDE','border-color':'#A94442'});
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({  'color':'black','background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

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
                required: "Role Name is required."
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
