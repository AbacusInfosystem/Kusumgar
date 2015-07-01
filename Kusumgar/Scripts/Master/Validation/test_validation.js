$(document).ready(function () {

    $("#frmTest").validate({
    
        rules: {
            "Test.Process_Id":
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

            "Test.Process_Id":
                {
                    required: "Select Process."

                },

            "Test.Test_Name":
                {
                    required: "Enter test name."

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