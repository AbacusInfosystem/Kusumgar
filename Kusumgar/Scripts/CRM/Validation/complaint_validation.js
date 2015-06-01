$(function () {
    $("#frmComp").validate({

        rules: {
            "Complaint.ComplaintEntity.CustomerId":
            {
                required: true,                
            },
            "Complaint.ComplaintEntity.OrderId":
            {
                required: true,
            },
            "Complaint.ComplaintEntity.OrderItemId":
            {
                required: true,
            },
            "Complaint.ComplaintEntity.ChallanNo":
            {
                required: true,
            },
            "Complaint.ComplaintEntity.CDescription":
            {
                required: true,
                maxlength: 1000
            }

        },
        messages: {

            "Complaint.ComplaintEntity.CustomerId":
            {
                required: "Customer Name is required."
            },
            "Complaint.ComplaintEntity.OrderId":
            {
                required: "Order Id is required."
            },
            "Complaint.ComplaintEntity.OrderItemId":
            {
                required: "Order Item Id is required."
            },
            "Complaint.ComplaintEntity.ChallanNo":
            {
                required: "Challan No is required."
            },
            "Complaint.ComplaintEntity.CDescription":
            {
                required: "Complaint Description is required.",
                maxlength: "No more than 1000 characters."
            }

        }
    });
});