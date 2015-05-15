$(document).ready(function () {

    $("#frmTest").validate({
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
            "Test.TestEntity.Fabric_Type_Id":
            {
                required: true
            },
            "Test.TestEntity.Test_Name":
            {
                required: true

            },
            "Test.Test_Unit_Name1":
            {
                required: true

            },
            "Test.Test_Unit_Name2":
            {
                required: true

            },
            "Test.Test_Unit_Name3":
            {
                required: true

            },

            "Test.Test_Unit_Name4":
              {
                  required: true

              },
            "Test.Test_Unit_Name5":
            {
                required: true

            },
            "Test.Test_Unit_Name6":
            {
                required: true

            },

            "Test.Test_Unit_Name7":
            {
                required: true

            },

            "Test.Test_Unit_Name8":
            {
                required: true

            },
            "Test.Test_Unit_Name9":
            {
                required: true

            },

            "Test.Test_Unit_Name10":
            {
                required: true

            },

        },

        messages: {

            "Test.TestEntity.Fabric_Type_Id":
                {
                    required: "Enter Fabric Type.."

                },

            "Test.TestEntity.Test_Name":
                {
                    required: "Enter TestName.."

                },
            "Test.Test_Unit_Name1":
              {
                    required: "Enter TestUnitName.."

              },
            "Test.Test_Unit_Name2":
            {
                required: "Enter TestUnitName.."

            },
            "Test.Test_Unit_Name3":
            {
                required: "Enter TestUnitName.."

            },

            "Test.Test_Unit_Name4":
              {
                  required: "Enter TestUnitName.."

              },
            "Test.Test_Unit_Name5":
            {
                required: "Enter TestUnitName.."

            },
            "Test.Test_Unit_Name6":
            {
                required: "Enter TestUnitName.."

            },

            "Test.Test_Unit_Name7":
            {
                required: "Enter TestUnitName.."

            },

            "Test.Test_Unit_Name8":
            {
                required: "Enter TestUnitName.."

            },
            "Test.Test_Unit_Name9":
             {
                required: "Enter TestUnitName.."

             },

            "Test.Test_Unit_Name10":
            {
                required: "Enter TestUnitName.."

            },

        }
    });

});