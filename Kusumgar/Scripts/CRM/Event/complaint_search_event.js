$(document).ready(function () {
    
    InitializeAutoComplete($('#txtCustName'), autoComplaintSCallback);

});

$(function () {

    $('#hdfCurrentPage').val(0);

    SearchComplaint();

    $("#btnEdit").click(function () {

        $("#frmSearch_comp").attr("action", "/crm/edit-complaint");

        $("#frmSearch_comp").attr("method", "POST");

        $("#frmSearch_comp").submit();
    });

    $("#btnSearch").click(function () {
        SearchComplaint();
    });


});