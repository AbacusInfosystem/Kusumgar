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
            "Test.Fabric_Type_Id":
            {
                required: true
            },
            "Test.Test_Name":
            {
                required: true

            },
            "Test.Test_Unit1":
            {
                test_unit_required: true

            }
            //"Test.Test_Unit2":
            //{
            //    required: true

            //},
            //"Test.Test_Unit3":
            //{
            //    required: true

            //},

            //"Test.Test_Unit4":
            //  {
            //      required: true

            //  },
            //"Test.Test_Unit5":
            //{
            //    required: true

            //},
            //"Test.Test_Unit6":
            //{
            //    required: true

            //},

            //"Test.Test_Unit7":
            //{
            //    required: true

            //},

            //"Test.Test_Unit8":
            //{
            //    required: true

            //},
            //"Test.Test_Unit9":
            //{
            //    required: true

            //},

            //"Test.Test_Unit10":
            //{
            //    required: true

            //},

        },

        messages: {

            "Test.Fabric_Type_Id":
                {
                    required: "Enter Fabric Type.."

                },

            "Test.Test_Name":
                {
                    required: "Enter TestName.."

                },
            "Test.Test_Unit1":
              {
                  //required: "Enter TestUnitName.."

              }

        }
        //"Test.Test_Unit2":
        //{
        //    required: "Enter TestUnitName.."

        //},
        //"Test.Test_Unit3":
        //{
        //    required: "Enter TestUnitName.."

        //},

        //"Test.Test_Unit4":
        //  {
        //      required: "Enter TestUnitName.."

        //  },
        //"Test.Test_Unit5":
        //{
        //    required: "Enter TestUnitName.."

        //},
        //"Test.Test_Unit6":
        //{
        //    required: "Enter TestUnitName.."

        //},

        //"Test.Test_Unit7":
        //{
        //    required: "Enter TestUnitName.."

        //},

        //"Test.Test_Unit8":
        //{
        //    required: "Enter TestUnitName.."

        //},
        //"Test.Test_Unit9":
        // {
        //    required: "Enter TestUnitName.."

        // },

        //"Test.Test_Unit10":
        //{
        //    required: "Enter TestUnitName.."

        //},
    });

    jQuery.validator.addMethod("test_unit_required", function (value, element) {
        if ($(element).parents('.form-group').find('.text').length) {
            if ($(element).parents('.form-group').find('.text').html() != "") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }, "Test Unit is required.");



});