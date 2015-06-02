$(document).ready(function () {

    $("#frmTest").validate({

        rules: {
            "Test.TestEntity.Fabric_Type_Id":
            {
                required: true
            },
            "Test.TestEntity.Test_Name":
            {
                required: true

            },
            "Test.TestEntity.Test_Unit1":
            {
                required: true

            },
            "Test.TestEntity.Test_Unit2":
            {
                required: true

            },
            "Test.TestEntity.Test_Unit3":
            {
                required: true

            },

            "Test.TestEntity.Test_Unit4":
              {
                  required: true

              },
            "Test.TestEntity.Test_Unit5":
            {
                required: true

            },
            "Test.TestEntity.Test_Unit6":
            {
                required: true

            },

            "Test.TestEntity.Test_Unit7":
            {
                required: true

            },

            "Test.TestEntity.Test_Unit8":
            {
                required: true

            },
            "Test.TestEntity.Test_Unit9":
            {
                required: true

            },

            "Test.TestEntity.Test_Unit10":
            {
                required: true

            },

        },

        messages: {

            "Test.TestEntity.Fabric_Type_Id":
                {
                    required: "Fabric type is required."

                },

            "Test.TestEntity.Test_Name":
                {
                    required: "Test name is required."

                },
            "Test.TestEntity.Test_Unit1":
              {
                    required: "Test unit name is required."

              },
            "Test.TestEntity.Test_Unit2":
            {
                required: "Test unit name is required."

            },
            "Test.TestEntity.Test_Unit3":
            {
                required: "Test unit name is required."

            },

            "Test.TestEntity.Test_Unit4":
              {
                  required: "Test unit name is required."

              },
            "Test.TestEntity.Test_Unit5":
            {
                required: "Test unit name is required."

            },
            "Test.TestEntity.Test_Unit6":
            {
                required: "Test unit name is required."

            },

            "Test.TestEntity.Test_Unit7":
            {
                required: "Test unit name is required."

            },

            "Test.TestEntity.Test_Unit8":
            {
                required: "Test unit name is required."

            },
            "Test.TestEntity.Test_Unit9":
             {
                 required: "Test unit name is required."

             },

            "Test.TestEntity.Test_Unit10":
            {
                required: "Test unit name is required."

            },

        }
    });

});