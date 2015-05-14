$(document).ready(function () {

    $("#frmTest").validate({
        rules: {
            "Test.FabricType":
            {
                required: true
            },
            "Test.TestName":
            {
                required: true

            },
            "Test.TestUnitName1":
            {
                required: true

            },
            "Test.TestUnitName2":
            {
                required: true

            },
            "Test.TestUnitName3":
            {
                required: true

            },

            "Test.TestUnitName4":
              {
                  required: true

              },
            "Test.TestUnitName5":
            {
                required: true

            },
            "Test.TestUnitName6":
            {
                required: true

            },

            "Test.TestUnitName7":
            {
                required: true

            },

            "Test.TestUnitName8":
            {
                required: true

            },
            "Test.TestUnitName9":
            {
                required: true

            },

            "Test.TestUnitName10":
            {
                required: true

            },

        },

        messages: {

            "Test.FabricType":
                {
                    required: "Enter Fabric Type.."

                },

            "Test.TestName":
                {
                    required: "Enter TestName.."

                },
            "Test.TestUnitName1":
              {
                    required: "Enter TestUnitName.."

              },
            "Test.TestUnitName2":
            {
                required: "Enter TestUnitName.."

            },
            "Test.TestUnitName3":
            {
                required: "Enter TestUnitName.."

            },

            "Test.TestUnitName4":
              {
                  required: "Enter TestUnitName.."

              },
            "Test.TestUnitName5":
            {
                required: "Enter TestUnitName.."

            },
            "Test.TestUnitName6":
            {
                required: "Enter TestUnitName.."

            },

            "Test.TestUnitName7":
            {
                required: "Enter TestUnitName.."

            },

            "Test.TestUnitName8":
            {
                required: "Enter TestUnitName.."

            },
            "Test.TestUnitName9":
             {
                required: "Enter TestUnitName.."

             },

            "Test.TestUnitName10":
            {
                required: "Enter TestUnitName.."

            },

        }
    });

});