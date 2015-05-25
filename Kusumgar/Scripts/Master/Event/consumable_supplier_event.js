$(document).ready(function () {

    InitializeAutoComplete($('#txtSupplierName'), autoSupplierNameCallback);


});


$('#txtSupplierName').keyup(function () {
    alert("Ooo")
    if ($(this).val() == "") {
        $('#hdnSupplierName').val('0');
    }
});