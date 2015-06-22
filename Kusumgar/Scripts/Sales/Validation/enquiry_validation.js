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
                    number: true,
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
                    required: true,
                    number: true
                },
            "Enquiry.Supporting_Details.Customer_Roll_Length":
                {
                    required: true,
                    number: true
                },
            "Enquiry.Supporting_Details.Packing":
                {
                    required: true
                },
            "Enquiry.Supporting_Details.Dispatch":
                {
                    required: true
                },
            "Enquiry.Supporting_Details.Additional_Customer_Prop":
                {
                    required: true
                },
            "Enquiry.Supporting_Details.Source_Of_Enquiry":
                {
                    required: true
                },
            "Enquiry.Supporting_Details.Two_Part":
                {
                    number: true
                },
            "Enquiry.Supporting_Details.Piece_Length_Min":
                {
                    number: true
                },
            "Enquiry.Supporting_Details.Piece_Length_Max":
                {
                    number: true
                }

        },
        messages: {

            "Enquiry.Supporting_Details.Rate":
               {
                   required: "Rate is required."
               },
            "Enquiry.Supporting_Details.Customer_Roll_Length":
                {
                    required: "Customer roll length is required."
                },
            "Enquiry.Supporting_Details.Packing":
                {
                    required: "Packing is required."
                },
            "Enquiry.Supporting_Details.Dispatch":
                {
                    required: "Dispatch is required."
                },
            "Enquiry.Supporting_Details.Additional_Customer_Prop":
                {
                    required: "Additional customer property is required."
                },
            "Enquiry.Supporting_Details.Source_Of_Enquiry":
                {
                    required: "Source of enquiry is required."
                }
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

    $("#frmTemp_Customer_Quality_Details").validate({

        rules: {

            "Enquiry.Temp_Customer_Quality_Details.Applications":
                {
                    required: true
                },

            "Enquiry.Temp_Customer_Quality_Details.Market_Segment":
                {
                    required: true
                },
            "Enquiry.Temp_Customer_Quality_Details.Wrap_Count":
            {
                number:true
            },

            "Enquiry.Temp_Customer_Quality_Details.Weft_Count":
            {
                number:true
            },

            "Enquiry.Temp_Customer_Quality_Details.Ends_Per_Inch":
            {
                number:true
            },
            "Enquiry.Temp_Customer_Quality_Details.Pick_Per_Inch":
            {
                number:true
            }

        },
        messages: {
            "Enquiry.Temp_Customer_Quality_Details.Applications":
                {
                    required: "Application is required."
                },

            "Enquiry.Temp_Customer_Quality_Details.Market_Segment":
                {
                    required: "Market segment is required."
                }
        }
    });

});
    