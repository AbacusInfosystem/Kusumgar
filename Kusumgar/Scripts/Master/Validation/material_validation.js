$(function () {
    $("#frmMaterial").validate({


        rules: {
            "Material.Material_Entity.Material_Code":
            {
                required: true,
            },
            "Material.Material_Entity.Material_Category_Id":
            {
                required: true,
            },
            "Material.Material_Entity.Material_SubCategory_Id":
            {
                required: true,
            },
            "Material.Material_Entity.Material_Name":
            {
                required: true,
            },
            "Material.Material_Entity.Size":
            {
                required: true,
            },
            "Material.Material_Entity.COD":
            {
                required: true,
            },
            "Material.Material_Entity.Material_Type":
            {
                required: true,
            },
            "Material.Material_Entity.Inspection_Facility":
            {
                required: true,
            },
            "Material.Material_Entity.Testing_Facility":
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

            "Material.Material_Entity.Material_Code":
            {
                required: "Material code is required."
            },
            "Material.Material_Entity.Material_Category_Id":
            {
                required: "Material category name is required."
            },
            "Material.Material_Entity.Material_SubCategory_Id":
            {
                required: "Material sub-category name is required."
            },
            "Material.Material_Entity.Material_Name":
            {
                required: "Material name is required."
            },
            "Material.Material_Entity.Size":
            {
                required: "Size is required."
            },
            "Material.Material_Entity.COD":
            {
                required: "COD is required."
            },
            "Material.Material_Entity.Material_Type":
            {
                required: "Material type is required."
            },            
            "Material.Material_Entity.Inspection_Facility":
            {
                required: "Inspection facility is required."
            },
            "Material.Material_Entity.Testing_Facility":
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