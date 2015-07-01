$(document).ready(function () {

   GetAllAttributeCodes();

    $("#btnSearch").click(function () {
        SearchAttributeCodes();
    });

    $('#btnEdit').click(function () {

        $("#frmAttributeCodeSearch").attr("action", "/AttributeCode/Get_Attribute_Code_By_Id");

        $("#frmAttributeCodeSearch").attr("method", "post");

        $("#frmAttributeCodeSearch").submit();
    });

    $("#divSearchGridOverlay").hide();
   
    if ($("#hdfDefectTypeId").val() != 0) {

        $('#drpDefectTypeName').val($("#hdfDefectTypeId").val());
    }

    $('#drpAttributeName').change(function () {

        $('#hdfAttributeId').val($('#drpAttributeName :selected').val());

    })
    
});