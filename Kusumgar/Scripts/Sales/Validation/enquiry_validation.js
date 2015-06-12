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

    $("#frmSupporting_Details").validate({

        rules: {

            "Enquiry.Supporting_Details.Rate":
                {
                    number:true
                },
            "Enquiry.Supporting_Details.Customer_Roll_Length":
                {
                    number: true
                }

        },
        messages: {

        }

    });

    $("#frmFunctional_Parameters").validate({

        rules: {
        
            "Functional_Parameters":
                {
                    required:true
                }

        },
        messages: {
            "Functional_Parameters":
                {
                    required: "Enter valid functional parameter."
                }
         }
    });

    $("#frmVisualParameters").validate({

        rules: {

            "Visual_Parameters":
                {
                    required: true
                }

        },
        messages: {
            "Visual_Parameters":
                {
                    required: "Enter valid visual parameter."
                }
        }
    });



});
    