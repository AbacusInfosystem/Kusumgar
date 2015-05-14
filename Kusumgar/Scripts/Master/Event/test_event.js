$(document).ready(function () {
   
    InitializeAutoComplete($('#txtTestUnit1'), autoTestUnit1Callback);
    InitializeAutoComplete($('#txtTestUnit2'), autoTestUnit2Callback);
    InitializeAutoComplete($('#txtTestUnit3'), autoTestUnit3Callback);
    InitializeAutoComplete($('#txtTestUnit4'), autoTestUnit4Callback);
    InitializeAutoComplete($('#txtTestUnit5'), autoTestUnit5Callback);
    InitializeAutoComplete($('#txtTestUnit6'), autoTestUnit6Callback);
    InitializeAutoComplete($('#txtTestUnit7'), autoTestUnit7Callback);
    InitializeAutoComplete($('#txtTestUnit8'), autoTestUnit8Callback);
    InitializeAutoComplete($('#txtTestUnit9'), autoTestUnit9Callback);
    InitializeAutoComplete($('#txtTestUnit10'), autoTestUnit10Callback);

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

});
