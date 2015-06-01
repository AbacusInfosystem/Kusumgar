$(function () {
    $("#frmProduct").validate({


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
                required: "Product code is required."
            },
            "Product.Product_Entity.Product_Category_Id":
            {
                required: "Product category name is required."
            },
            "Product.Product_Entity.Product_SubCategory_Id":
            {
                required: "Product sub-category name is required."
            },
            "Product.Product_Entity.Product_Name":
            {
                required: "Product name is required."
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
                required: "Product type is required."
            },            
            "Product.Product_Entity.Inspection_Facility":
            {
                required: "Inspection facility is required."
            },
            "Product.Product_Entity.Testing_Facility":
            {
                required: "Testing facility is required.",
            },
            "Product_Vendor.Vendor_Name":
            {
                required: "Vendor name is required."
            },
            "Product_Vendor.Product_Vendor_Entity.Priority_Order":
            {
                required: "Priority order is required."
            },
        }
    });
});