$(document).ready(function () {
  
    $("#btnSaveOtherDetails").click(function () {
       
        if ($("#frmOtherDetails").valid()) {
            Save_Vendors_Other_Details();
        }
    });

    $("#btnSaveCertificationDetails").click(function () {
      
        if ($("#frmCertificationDetails").valid()) {
            Save_Vendors_Certificate();
        }
    });

    $("#btnCentralRegistrationDetails").click(function () {

        if ($("#frmCentralRegistrationDetails").valid()) {
            Save_Vendors_Central_Excise();
        }
    });
    
    $('[name="Vendor.Block_Payment"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnBlockPayment").val(true);
        }
        else {
            $("#hdnBlockPayment").val(false);
        }
    });

    $('[name="Vendor.Is_Approved_By_Director"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnApprovedByDirector").val(true);
        }
        else {
            $("#hdnApprovedByDirector").val(false);
        }
    });
 
});