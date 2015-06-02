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
            "Complaint.Complaint_Entity.Customer_Id":
            {
                customer_required: true,                
            },
            "Complaint.Complaint_Entity.Order_Id":
            {
                required: true,
            },
            "Complaint.Complaint_Entity.Order_Item_Id":
            {
                required: true,
            },
            "Complaint.Complaint_Entity.Challan_No":
            {
                required: true,
            },
            "Complaint.Complaint_Entity.CDescription":
            {
                required: true                
            }

        },
        messages: {

            "Complaint.Complaint_Entity.Customer_Id":
            {
                
            },
            "Complaint.Complaint_Entity.Order_Id":
            {
                required: "Order Id is required."
            },
            "Complaint.Complaint_Entity.Order_Item_Id":
            {
                required: "Order Item Id is required."
            },
            "Complaint.Complaint_Entity.Challan_No":
            {
                required: "Challan No is required."
            },
            "Complaint.Complaint_Entity.CDescription":
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