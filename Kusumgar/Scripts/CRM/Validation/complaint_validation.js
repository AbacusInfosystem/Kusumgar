$(function () {
    $("#frmComp").validate({

        rules: {
            "Complaint.Customer_Id":
            {
                customer_required: true,                
            },
            "Complaint.Order_Id":
            {
                required: true,
            },
            "Complaint.Order_Item_Id":
            {
                required: true,
            },
            "Complaint.Challan_No":
            {
                required: true,
            },
            "Complaint.CDescription":
            {
                required: true                
            }

        },
        messages: {

            "Complaint.Customer_Id":
            {
                
            },
            "Complaint.Order_Id":
            {
                required: "Order Id is required."
            },
            "Complaint.Order_Item_Id":
            {
                required: "Order Item Id is required."
            },
            "Complaint.Challan_No":
            {
                required: "Challan No is required."
            },
            "Complaint.CDescription":
            {
                required: "Complaint Description is required."                
            }

        }
    });

    jQuery.validator.addMethod("customer_required", function (value, element) {
        if ($(element).parents('.form-group').find('.text').length) {
            if ($(element).parents('.form-group').find('.text').html() != "") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }, "Customer Name is required.");
});