var autoComplaintCallback = function (paramObj) {
    
    BindCompTags(paramObj.item.label, paramObj.item.value);

}

function BindCompTags(label, value) {    

    $('#hdnCustId').val(value);

    $('#txtCustName').val(label);
    
}