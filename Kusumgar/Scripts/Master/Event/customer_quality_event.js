
$(function () {

    InitializeAutoComplete($('#txtCustomer_Name'));
    InitializeAutoComplete($('#txtCustomer_Sample_No'));

    if ($("#hdnCustomer_Quality_Id").val() == 0) {

        $("#tbCustomer_Specific_Information").hide();
        $("#tbAttachment").hide();
        $("#tabFuncational_Visual").hide();
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


    InitializeDragDrop($("#drag_drop_file"), "/ajax/attachments", Callback, { RefId: $('#hdnCustomer_Quality_Id'), RefType: $('#drpRef_Type'), Remark: $('#txtRemark')});
   

    $("#drpRef_Type").change(function ()
    {
        if ($("#drpRef_Type").val() != 0)
        {
            $("#drag_drop_file").show();

            //InitializeDragDrop($("#drag_drop_file"), "/ajax/attachments", Callback, { RefId: $('#hdnCustomer_Quality_Id'), RefType: $('#drpRef_Type'), Remark: $('#txtRemark') });
            Bind_Attachments();

        }
        else
        {
            $("#drag_drop_file").hide();
        }

    });

    InitializeMultiAutoComplete($("#txtFunctional_Parameters"));

    InitializeMultiAutoComplete($("#txtVisual_Parameters"));

    $("#btnAdd_Functional_Parameters").click(function () {

        if ($("#frmFunctional_Parameters").valid())
        {
            Save_Customer_Quality_Functional_Parameters();
        }
    });

    $("#btnAdd_Visual_Parameters").click(function () {

        if ($("#frmVisualParameters").valid())
        {
            Save_Customer_Quality_Visual_Parameters();
        }
    });

    Bind_Customer_Quality_Functional_Parameters();

    Bind_Customer_Quality_Visual_Parameters();


});