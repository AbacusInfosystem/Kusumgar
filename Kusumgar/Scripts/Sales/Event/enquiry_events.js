
$(function () {

    $(".datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

    //Start : Enquiry 
    
    InitializeAutoComplete($('#txtQuality_No'));

    InitializeAutoComplete($('#txtCustomer_Name'));

    if ($("#hdnEnquiry_Id").val() == 0)
    {
        $("#tabStaggered").hide();
        $("#tabCustomer_Quality").hide();
        $("#tabQuality_Supporting").hide();
        $("#tabFuncational_Visual").hide();
    }

    if ($("#hdnQuality_Id").val() != 0)
    {
        $("#tabCustomer_Quality").hide();
    }

    $("#btnSave_Enquiry").click(function () {

        if ($("#frmEnquiry_Prerequisites").valid()) {
            Save_Enquiry();
        }
    });

    $('[name="Enquiry_Type"]').on('ifChanged', function (event) {
        if($(this).prop("checked"))
        {
            $("#hdnEnquiry_Type_Id").val($(this).val());
        }
    });

    // End : Enquiry 

    // Start : Staggered Order 

    Get_Staggered_Order();

    $('#DtDelivery_Date').datepicker();

    $("#btnSave_Staggered_Order").click(function () {

        if ($("#frmStaggered_Order").valid()) {
            Save_Staggered_Order();
        }
    });


    // End : Staggered Order

    // Start : Supporting Details

    $("#btnSave_Supporting_Details").click(function () {
        
        if($("#frmSupporting_Details").valid())
        {
            Save_Supporting_Details();
        }
    });

    // End : Supporting Details

    // Start : Temp Customer Quality
    $("#btnSave_Temp_Customer_Quality").click(function () {
       // if ($("#frmTemp_Customer_Quality_Details").valid()) {
            Save_Temp_Customer_Quality_Details();
        //}
    });

    // End Temp Customer Quality

    // Start : Attachments

    // Drag and Drop Initialization
    InitializeDragDrop($("#Enquiry_Attach_Emails_Files"), "/ajax/attachments", Callback, { RefType: $('#hdnRefType').val(), RefId: $('#hdnEnquiry_Id').val() });

    Bind_Attachments();

    // End : Attachments
});

