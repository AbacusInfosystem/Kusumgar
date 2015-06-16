
$(function () {

    SearchEnquiry();

    $("#btnCreate_Article").click(function () {

        $("#frmSearch_W_Manager_Checkpoint").attr("action", "/sales/qualityset-checkpoint");

        $("#frmSearch_W_Manager_Checkpoint").attr("method", "POST");

        $("#frmSearch_W_Manager_Checkpoint").submit();

    });

});