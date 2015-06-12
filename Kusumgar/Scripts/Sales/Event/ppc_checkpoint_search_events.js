$(function () {

    SearchEnquiry();

    $("#btnEdit_Enquiry_PPC").click(function () {

        $("#frmSearch_PPC_Checkpoint").attr("action", "/ppc/enquiry-check-point");

        $("#frmSearch_PPC_Checkpoint").attr("method", "POST");

        $("#frmSearch_PPC_Checkpoint").submit();

    });
});