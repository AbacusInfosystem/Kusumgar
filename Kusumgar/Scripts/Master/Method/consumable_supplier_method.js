
var autoSupplierNameCallback = function (paramObj) {

    BindSupplierName(paramObj.item.label, paramObj.item.value);
}

function BindSupplierName(label, value) {

    $('#hdnSupplierName').val(value);

    $('#txtSupplierName').val(label);
}