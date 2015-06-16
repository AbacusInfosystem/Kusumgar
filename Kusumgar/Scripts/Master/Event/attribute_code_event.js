$(document).ready(function () {

    $('#btnSave').click(function () {
        
        if ($('#hdfAttributeCodeId').val() == 0 || $('#hdfAttributeCodeId').val() == '' || $('#hdfAttributeCodeId').val() == undefined) {

            url = '/AttributeCode/Insert';
        }
        else {
            url = '/AttributeCode/Update';
        }

        $('#frmAttributeCode').attr("action", url);

        $('#frmAttributeCode').attr("method", "POST");

        $('#frmAttributeCode').submit();
    });

    $("#drpAttributeCode").change(function () {
        
        if ($(this).val() == "") {
            $('#tblAttributeCode').hide();
        }
        else {
            $('#tblAttributeCode').show();
            SearchAttributeCodeForTable();
        }

    });

    if ($("drpAttributeCode").val() == "") {
        $('#tblAttributeCode').hide();
    }
    else {
        $('#tblAttributeCode').show();
        SearchAttributeCodeForTable();
    }

    $('[name="chkIsActive"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            
            $("#hdnActive").val(true);
        }
        else {
            $("#hdnActive").val(false);
        }
    });

});
