
$(function () {

    InitializeAutoComplete($("#txtCustomer_Approved_Sample"));

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

    $("#hdnQuality_Id").change(function () {

        if ($("#hdnQuality_Id").val() != "") {

            var Quality_Id = $("#hdnQuality_Id").val();

            Get_Quality_Details(Quality_Id);
        }
        else
        {
            $("#tblQuality_Details").html("");
        }
      
    });

    $("#hdnCustomer_Id").change(function () {

        if ($("#hdnCustomer_Id").val() != "") {

            var Customer_Id = $("#hdnCustomer_Id").val();

            Get_Nation_Details(Customer_Id);
        }
        else {
            $("#dvIs_Dosmistic").html("");
        }

    });

    $("#hdnQuality_Id").trigger("change");

    $("#hdnCustomer_Id").trigger("change");

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
        if ($("#frmTemp_Customer_Quality_Details").valid()) {
            Save_Temp_Customer_Quality_Details();
        }
    });

    // End Temp Customer Quality

    // Start : Attachments

    // Drag and Drop Initialization
    InitializeDragDrop($("#Enquiry_Attach_Emails_Files"), "/ajax/attachments", Callback, { RefType: $('#hdnRefType'), RefId: $('#hdnEnquiry_Id') });

    Bind_Attachments();

    // End : Attachments

    // Start : Temp Functional Visual paramenters

    InitializeMultiAutoComplete($("#txtFunctional_Parameters"));

    InitializeMultiAutoComplete($("#txtVisual_Parameters"));

    $("#btnAdd_Functional_Parameters").click(function () {

        if ($("#frmFunctional_Parameters").valid())
        {
            Save_Temp_Functional_Parameters();
        }

    });

    $("#btnAdd_Visual_Parameters").click(function () {

        if ($("#frmVisualParameters").valid()) {

            Save_Temp_Visual_Parameters();

        }
    });

    Bind_Temp_Functional_Parameters();

    Bind_Temp_Visual_Parameters();

    // End : Temp Functional Visual paramenters
});

