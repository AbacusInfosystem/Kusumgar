$(function () {
    $("#frmComp").validate({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({'color':'#A94442','background-color':'#F2DEDE','border-color':'#A94442'});
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('.input-group-addon').css({  'color':'black','background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },

        rules: {
            "Complaint.CustomerName":
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

            "Complaint.CustomerName":
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