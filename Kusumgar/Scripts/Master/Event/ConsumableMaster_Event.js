$(document).ready(function () {

    if ($("#hdnConsumable_Id").val() == 0) {
        $("#Supplier_Tab").hide();
        
    }

    //$('#btnSave').click(function () {

    //    url = '/master/insert-ConsumableMaster';
         
    //        $('#frmConsumableMaster').attr("action", url);

    //        $('#frmConsumableMaster').attr("method", "POST");

    //        $('#frmConsumableMaster').submit();
    //});
    $("#btnSave").click(function () {

        if ($("#frmConsumableMaster").valid()) {

            Save_Consumable_Details();
        }
    });

});