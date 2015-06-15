
$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));
    InitializeAutoComplete($('#txtCustomer_Sample_No'));

    if ($("#hdnCustomer_Quality_Id").val() == 0) {

        $("#tbCustomer_Specific_Information").hide();
        $("#tbAttachment").hide();
        $("#Spefic_Functional_Standerds").hide();
    }

    $("#btnSave_Primary").click(function () {

        if ($("#frmCustomer_Quality").valid()) {

            Save_Customer_Quality();
        }
    });

    $("#btnSave_Customer_Specific_Information").click(function () {

        //Save_Customer_Specific_Information();
        Save_Customer_Quality();

    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

   

});