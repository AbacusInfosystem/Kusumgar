$(function () {
    $("#frmEnquiry_Prerequisites").validate({

        rules: {

            "Enquiry.Enquiry_Type_Id":
                {
                    required:true
                },

            "Enquiry.Customer_Id":
                {
                    required: true
                },
        },
        messages: {

            "Enquiry.Enquiry_Type_Id":
                {
                    required:"Enquiry type is required."
                },

            "Enquiry.Customer_Id":
                {
                    required: "Customer is required."
                },
        }
    });

    $("#frmStaggered_Order").validate({

        rules: {

            "Enquiry.Staggered_Order.Quantity":
                {
                    required:true
                },
            "Enquiry.Staggered_Order.Delivery_Date":
                {
                    required: true
                }
        },
        messages: {

            "Enquiry.Staggered_Order.Quantity":
                {
                    required: "Quality is required."
                },
            "Enquiry.Staggered_Order.Delivery_Date":
                {
                    required: "Delivery date is required."
                }
        }
    });



});
    