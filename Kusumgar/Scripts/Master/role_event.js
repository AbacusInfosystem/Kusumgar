$(function () {

    $('#lst_Available_Access_Function').dblclick(function () {
        Add('lst_Available_Access_Function', 'lst_Selected_Access_Function');

    });

    $('#lst_Selected_Access_Function').dblclick(function () {
        Add('lst_Selected_Access_Function', 'lst_Available_Access_Function');
    });


    $("#hdnActive").val(true);


    $("#btnSave").click(function () {

        for (var i = 0; i < document.getElementById("lst_Selected_Access_Function").options.length; i++) {
            document.getElementById("lst_Selected_Access_Function").options[i].selected = true;
        }

        if ($("#frmRole").valid()) {

            if ($("#hdnRole_Id").val() == 0) {
                $("#frmRole").attr("action", "/master/insert-role");

                $("#frmRole").attr("method", "POST");

                $("#frmRole").submit();
            }
            else
            {
                $("#frmRole").attr("action", "/master/update-role");

                $("#frmRole").attr("method", "POST");

                $("#frmRole").submit();
            }
       }
    });

});