$(function () {
    $("#frmMaterial").validate({


        rules: {
            "Material.Material_Code":
            {
                required: true,
            },
            "Material.Material_Category_Id":
            {
                required: true,
            },
            "Material.Material_SubCategory_Id":
            {
                required: true,
            },
            "Material.Material_Name":
            {
                required: true,
            },
            "Material.Size":
            {
                required: true,
            },
            "Material.COD":
            {
                required: true,
            },
            "Material.Material_Type":
            {
                required: true,
            },
            "Material.Inspection_Facility":
            {
                required: true,
            },
            "Material.Testing_Facility":
            {
                required: true,
            },
            "Material_Vendor.Vendor_Name":
            {
                required: true,
            },
            "Material_Vendor.Material_Vendor_Entity.Priority_Order":
            {
                required: true,
            },
        },
        messages: {

            "Material.Material_Code":
            {
                required: "Material code is required."
            },
            "Material.Material_Category_Id":
            {
                required: "Material category name is required."
            },
            "Material.Material_SubCategory_Id":
            {
                required: "Material sub-category name is required."
            },
            "Material.Material_Name":
            {
                required: "Material name is required."
            },
            "Material.Size":
            {
                required: "Size is required."
            },
            "Material.COD":
            {
                required: "COD is required."
            },
            "Material.Material_Type":
            {
                required: "Material type is required."
            },            
            "Material.Inspection_Facility":
            {
                required: "Inspection facility is required."
            },
            "Material.Testing_Facility":
            {
                required: "Testing facility is required.",
            },
            "Material_Vendor.Vendor_Name":
            {
                required: "Vendor name is required."
            },
            "Material_Vendor.Material_Vendor_Entity.Priority_Order":
            {
                required: "Priority order is required."
            },
        }
    });


    $("#frmMaterial_Vendors").validate({


        rules: {
            "Material_Vendor.Material_Vendor_Entity.Vendor_Id":
            {
                required: true,
            },
            "Material_Vendor.Material_Vendor_Entity.Priority_Order":
                {
                    required: true,
                }
        },
        messages: {

            "Material_Vendor.Material_Vendor_Entity.Vendor_Id":
            {
                required: "Vendor is required."
            },
            "Material_Vendor.Material_Vendor_Entity.Priority_Order":
                {
                    required :"Priority order is required"
                }
        }
    });

});