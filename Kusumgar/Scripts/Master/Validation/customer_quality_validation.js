
$(function () {
    $("#frmCustomer_Quality").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

        rules: {
            "Customer_Quality.Customer.Customer_Entity.Customer_Id":
                {
                    required: true
                },
            "Customer_Quality.Quality.Quality_No":
                {
                    required: true
                }
            
        },
        messages: {

            "Customer_Quality.Customer.Customer_Entity.Customer_Id":
                {
                required: "Customer name is required."
                },
            "Customer_Quality.Quality.Quality_No":
                {
                    required: "Quality number name is required"
                }
        }
    });
});