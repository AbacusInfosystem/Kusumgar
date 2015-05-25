$(function () {
    $("#frmIndustrial").validate({
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
            "Industrial.Industrial_Entity.Industrial_Category_Name":
            {
                required: true,
            },
            "Industrial.Industrial_Entity.Industrial_Group_Name":
            {
                required: true,
            },
            "Industrial.Industrial_Entity.Industrial_SubGrp_Name":
            {
                required: true,
            },
            "Industrial.Industrial_Entity.Size":
            {
                required: true,
            },
            "Industrial.Industrial_Entity.COD":
            {
                required: true,
            },
            "Industrial_Vendor.Vendor_Name":
            {
                required: true,
            },
            "Industrial_Vendor.Industrial_Vendor_Entity.Priority_Order":
            {
                required: true,
            },
        },
        messages: {

            "Industrial.Industrial_Entity.Industrial_Category_Name":
            {
                required: "Industrial Category Name is required."
            },
            "Industrial.Industrial_Entity.Industrial_Group_Name":
            {
                required: "Industrial Group Name is required."
            },
            "Industrial.Industrial_Entity.Industrial_SubGrp_Name":
            {
                required: "Industrial Sub-Group Name is required."
            },
            "Industrial.Industrial_Entity.Size":
            {
                required: "Size is required."
            },
            "Industrial.Industrial_Entity.COD":
            {
                required: "COD is required."               
            },
            "Industrial_Vendor.Vendor_Name":
            {
                required: "Vendor Name is required."
            },
            "Industrial_Vendor.Industrial_Vendor_Entity.Priority_Order":
            {
                required: "Priority Order is required.",
            },

        }
    });
});