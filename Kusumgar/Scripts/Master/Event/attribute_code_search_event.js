$(document).ready(function () {

   GetAllAttributeCodes();

    $("#btnSearch").click(function () {
        SearchAttributeCodes();
    });

    $('#btnEdit').click(function () {

        $("#frmAttributeCodeSearch").attr("action", "/AttributeCode/GetAttributeCodeById");

        $("#frmAttributeCodeSearch").attr("method", "post");

        $("#frmAttributeCodeSearch").submit();
    });

    $("#divSearchGridOverlay").hide();
   
    $('#drpAttributeName').change(function () {

        $('#hdfAttributeId').val($('#drpAttributeName :selected').val());

    })
     
    
});