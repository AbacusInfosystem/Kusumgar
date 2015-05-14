$(function () {
    $("#frmSearch_customer").validate({
        rules: {
            "Email":
                {
                        email:true
                },
            "Turnover":
        {
            number:true
        },
        },
       

    });
});