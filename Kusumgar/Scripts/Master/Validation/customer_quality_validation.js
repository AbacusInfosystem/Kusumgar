
$(function () {
    $("#frmCustomer_Quality").validate({
 
        rules: {
            "Customer_Quality.Customer.Customer_Entity.Customer_Id":
                {
                    required: true
                },
            "Customer_Quality.Quality.Quality_No":
                {
                    required: true
                },
            "Customer_Quality.Sample.Sample_Id":
                {
                    number: true
                }
            
        },
        messages: {

            "Customer_Quality.Customer.Customer_Entity.Customer_Id":
                {
                required: "Customer name is required."
                },
            "Customer_Quality.Quality.Quality_No":
                {
                    required: "Quality number name is required."
                }
        }
    });
});