$(document).ready(function () {

    $('#btnSave').click(function () {

        if ($('#hdfDefectId').val() == 0 || $('#hdfDefectId').val() == '' || $('#hdfDefectId').val() == undefined) {

            url = '/Defect/Insert';
        }
        else {
            url = '/Defect/Update';
            }  
      
        $('#frmDefect').attr("action", url);

        $('#frmDefect').attr("method", "POST");

        $('#frmDefect').submit();
    });

    $("#drpDefectTypeName").change(function () {
        
        if ($(this).val() == "") {
            $('#tblSearchDefect').hide();
        }
        else {
            $('#tblSearchDefect').show();
            SearchDefectTypeForTable();
        }
    });

    if ($("drpDefectTypeName").val() == "") {
        $('#tblSearchDefect').hide();
    }
    else {
        $('#tblSearchDefect').show();
        SearchDefectTypeForTable();
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
