$(document).ready(function () {

    if ($("#hdnIndustrial_Id").val() == 0) {
        $("#tabIndustrialVendor").hide();
    }

    $("#btnSave").click(function () {
        
        if ($("#frmIndustrial").valid()) {

            Save_Industrial_Details();
            
        }
    });

    $("#drpIndCatName").change(function () {
        
        $.ajax({
            url: '/master/group-by-category-id',
            data: { industrial_Category_Id: $("#drpIndCatName").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                
                if (data != null) {
                    Bind_Groups(data);
                }
            }
        });        
    });

    InitializeAutoComplete($('#txtVendorName'));

    $("#btnSaveIV").click(function () {

        if ($("#frmIndustrial").valid()) {

            Save_Industrial_Vendor();
        }
    });
});