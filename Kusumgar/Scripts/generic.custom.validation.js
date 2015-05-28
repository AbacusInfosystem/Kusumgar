$(function () {
    $.validator.setDefaults({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
            // 
            $(element).parent().addClass('has-error');
            //
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            // 
            $(element).parent().removeClass('has-error');
            //
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            }
                //
            else if (element.parent('.auto-complete').length)
            {
                if (element.parent('.auto-complete').parent('.input-group').length) {
                    error.insertAfter(element.parent('.auto-complete').parent());
                }
                else
                {
                    error.insertAfter(element.parent('.auto-complete'));
                }
            }
             //
            else {
                error.insertAfter(element);
            }
        }
    });
});