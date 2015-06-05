
$(function () {

    InitializeAutoComplete($('#txtQuality_No'));

    InitializeAutoComplete($('#txtCustomer_Name'));

    $("#btnSave_Enquiry").click(function () {

        Save_Enquiry();

    });
});
