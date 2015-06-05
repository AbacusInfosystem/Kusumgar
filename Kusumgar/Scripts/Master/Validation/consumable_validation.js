$(function () {
    $("#frmConsumableMaster").validate({


        rules: {
            "Consumable.Category_Name":
                 {
                     required: true
                 },
            "Consumable.SubCategory_Name":
                {
                    required: true
                },
            "Consumable.Consumable_Entity.Material_Name":
                {
                    required: true
                },
            "Consumable.Consumable_Entity.Material_Code":
                {
                    required: true
                }

        },
        messages: {

            "Consumable.Category_Name":
             {
                 required: "Please select category Name"
             },
            "Consumable.SubCategory_Name":
                {
                    required: "Please select subcategory Name "
                },
            "Consumable.Consumable_Entity.Material_Name":
                {
                    required: " Material name is required"
                },
            "Consumable.Consumable_Entity.Material_Code":
                {
                    required: "Material code is required"
                }
            

        }
    });
});