$(document).ready(function () {
  
    $("#hdnStatus").val(true);

    $("#hdnApprovedByDirector").val(true);
    alert("M");

   //if ($("#hdnVendorId").val() == 0) {
   //     $("#tabProductServices").hide();
   //     $("#tabCertificates").hide();
   //     $("#tabCentralExciseRegistrationDetails").hide();
   //     $("#tabOtherDetails").hide();
   // }

   $("#btnSave").click(function () {
       alert("q");
       
        if ($("#frmVendor").valid()) {

            Save_Vendors_Details();
     }
 });

    $("#btnSaveOtherDetails").click(function () {

        if ($("#frmOtherDetails").valid()) {
            Save_Vendors_Details();
        }
    });

    $("#btnSaveCertificationDetails").click(function () {

        if ($("#frmCertificationDetails").valid()) {
            Save_Vendors_Details();
        }
    });

    $("#btnCentralRegistrationDetails").click(function () {

        if ($("#frmCentralRegistrationDetails").valid()) {
            Save_Vendors_Details();
        }
    });
    

    $('[name="Vendor.Vendor_Entity.Block_Payment"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnBlockPayment").val(true);
        }
        else {
            $("#hdnBlockPayment").val(false);
        }
    });

    $('[name="Vendor.Vendor_Entity.Is_Approved_By_Director"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnApprovedByDirector").val(true);
        }
        else {
            $("#hdnApprovedByDirector").val(false);
        }
    });

    $('[name="Vendor.Vendor_Entity.Is_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnStatus").val(true);
        }
        else {
            $("#hdnStatus").val(false);
        }
    });


    $("#drpHeadOfficeNation").change(function () {

        $.ajax({
            url: '/crm/state-by-nation-id',
            data: { Nation_Id: $("#drpHeadOfficeNation").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data != null) {
                    Bind_State_Data(data);
                }
            }
        });
    });

});