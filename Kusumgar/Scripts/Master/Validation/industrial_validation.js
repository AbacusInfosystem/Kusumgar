$(function () {
    $("#frmIndustrial").validate({


        rules: {
            "Industrial.Industrial_Category_Name":
            {
                required: true,
            },
            "Industrial.Industrial_Group_Name":
            {
                required: true,
            },
            "Industrial.Industrial_SubGrp_Name":
            {
                required: true,
            },
            "Industrial.Size":
            {
                required: true,
            },
            "Industrial.COD":
            {
                required: true,
            },
            "Industrial_Vendor.Vendor_Name":
            {
                required: true,
            },
            "Industrial_Vendor.Priority_Order":
            {
                required: true,
            },
        },
        messages: {

            "Industrial.Industrial_Category_Name":
            {
                required: "Industrial category name is required."
            },
            "Industrial.Industrial_Group_Name":
            {
                required: "Industrial group name is required."
            },
            "Industrial.Industrial_SubGrp_Name":
            {
                required: "Industrial sub-group name is required."
            },
            "Industrial.Size":
            {
                required: "Size is required."
            },
            "Industrial.COD":
            {
                required: "COD is required."               
            },
            "Industrial_Vendor.Vendor_Name":
            {
                required: "Vendor name is required."
            },
            "Industrial_Vendor.Priority_Order":
            {
                required: "Priority order is required.",
            },

        }
    });
});