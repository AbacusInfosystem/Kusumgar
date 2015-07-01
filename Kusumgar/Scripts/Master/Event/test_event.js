$(document).ready(function () {
   
    InitializeAutoComplete($('#txtTestUnit1'));
    InitializeAutoComplete($('#txtTestUnit2'));
    InitializeAutoComplete($('#txtTestUnit3'));
    InitializeAutoComplete($('#txtTestUnit4'));
    InitializeAutoComplete($('#txtTestUnit5'));
    InitializeAutoComplete($('#txtTestUnit6'));
    InitializeAutoComplete($('#txtTestUnit7'));
    InitializeAutoComplete($('#txtTestUnit8'));
    InitializeAutoComplete($('#txtTestUnit9'));
    InitializeAutoComplete($('#txtTestUnit10'));

    $('#btnSave').click(function () {

        if ($('#hdfTestId').val() == 0 || $('#hdfTestId').val() == '' || $('#hdfTestId').val() == undefined) {

            url = '/Test/Insert';
        }
        else {

            url = '/Test/Update';
        }  

        $('#frmTest').attr("action", url);

        $('#frmTest').attr("method", "POST");

        $('#frmTest').submit();
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
