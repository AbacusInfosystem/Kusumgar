$(function () {
    $("#frmIndustrial").validate({


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
                required: "Industrial category name is required."
            },
            "Industrial.Industrial_Entity.Industrial_Group_Name":
            {
                required: "Industrial group name is required."
            },
            "Industrial.Industrial_Entity.Industrial_SubGrp_Name":
            {
                required: "Industrial sub-group name is required."
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
                required: "Vendor name is required."
            },
            "Industrial_Vendor.Industrial_Vendor_Entity.Priority_Order":
            {
                required: "Priority order is required.",
            },

        }
    });
});