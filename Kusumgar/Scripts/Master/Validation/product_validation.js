$(function () {
    $("#frmProduct").validate({
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
            "Product.Product_Entity.Product_Code":
            {
                required: true,
            },
            "Product.Product_Entity.Product_Category_Id":
            {
                required: true,
            },
            "Product.Product_Entity.Product_SubCategory_Id":
            {
                required: true,
            },
            "Product.Product_Entity.Product_Name":
            {
                required: true,
            },
            "Product.Product_Entity.Size":
            {
                required: true,
            },
            "Product.Product_Entity.COD":
            {
                required: true,
            },
            "Product.Product_Entity.Product_Type":
            {
                required: true,
            },
            "Product.Product_Entity.Inspection_Facility":
            {
                required: true,
            },
            "Product.Product_Entity.Testing_Facility":
            {
                required: true,
            },
            "Product_Vendor.Vendor_Name":
            {
                required: true,
            },
            "Product_Vendor.Product_Vendor_Entity.Priority_Order":
            {
                required: true,
            },
        },
        messages: {

            "Product.Product_Entity.Product_Code":
            {
                required: "Product Code is required."
            },
            "Product.Product_Entity.Product_Category_Id":
            {
                required: "Product Category Name is required."
            },
            "Product.Product_Entity.Product_SubCategory_Id":
            {
                required: "Product Sub-Category Name is required."
            },
            "Product.Product_Entity.Product_Name":
            {
                required: "Product Name is required."
            },
            "Product.Product_Entity.Size":
            {
                required: "Size is required."
            },
            "Product.Product_Entity.COD":
            {
                required: "COD is required."
            },
            "Product.Product_Entity.Product_Type":
            {
                required: "Product Type is required."
            },            
            "Product.Product_Entity.Inspection_Facility":
            {
                required: "Inspection Facility is required."
            },
            "Product.Product_Entity.Testing_Facility":
            {
                required: "Testing Facility is required.",
            },
            "Product_Vendor.Vendor_Name":
            {
                required: "Vendor Name is required."
            },
            "Product_Vendor.Product_Vendor_Entity.Priority_Order":
            {
                required: "Priority Order is required."
            },
        }
    });
});