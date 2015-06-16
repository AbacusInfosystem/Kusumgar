$(document).ready(function () {

    $('#btnSave').click(function () {

        if ($('#hdfTestUnitId').val() == 0 || $('#hdfTestUnitId').val() == '' || $('#hdfTestUnitId').val() == undefined) {

            url = '/TestUnit/Insert';
        }
        else {

            url = '/TestUnit/Update';
        }  
       
        $('#frmTestUnit').attr("action", url);

        $('#frmTestUnit').attr("method", "POST");

        $('#frmTestUnit').submit();
    });

    $('[name="chkIsActive"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {

            $("#hdnActive").val(true);
        }
        else {
            $("#hdnActive").val(false);
        }
    });
});

