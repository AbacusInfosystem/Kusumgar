$(function () {
    $("#frmConsumableMaster").validate({
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
                 required: "Please select Category Name"
             },
            "Consumable.SubCategory_Name":
                {
                    required: "Please select SubCategory Name "
                },
            "Consumable.Consumable_Entity.Material_Name":
                {
                    required: " Material Name is required"
                },
            "Consumable.Consumable_Entity.Material_Code":
                {
                    required: "Material Code is required"
                }
            

        }
    });
});