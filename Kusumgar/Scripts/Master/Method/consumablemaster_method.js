function Save_Consumable_Details() {

    var ConsumableMasterVM = Get_Consumable_values();
   
    //CallAjax("/master/insert-ConsumableMaster", "json", JSON.stringify(ConsumableMasterVM), "POST", "application/json", false, Consumable_CallBack, "", null);
    if ($("#hdnConsumable_Id").val() == 0) {
     
        CallAjax("/master/insert-ConsumableMaster", "json", JSON.stringify(ConsumableMasterVM), "POST", "application/json", false, Consumable_CallBack, "", null);
    }
    //else {
    //    CallAjax("/master/update-ConsumableMaster", "json", JSON.stringify(ConsumableMasterVM), "POST", "application/json", false, Customer_CallBack, "", null);
    //}
}
function Consumable_CallBack(data) {
    
    $("#hdnConsumable_Id").val(data.Consumable.ConsumableMaster_Entity.Consumable_Id);

    $("#Supplier_Tab").show();
 
}

function Get_Consumable_values() {
   
    var ConsumableMasterVM =
        {
            Consumable:
                {
                    Category_Id: $("#ddlCategoryName").val(),
                    SubCategory_Id: $("#ddlSubCategoryName").val(),

                    ConsumableMaster_Entity:
                        {
                            Consumable_Id: $("#hdnConsumable_Id").val(),
                            Material_Name: $("#txtMaterialName").val(),
                            Material_Code: $("#txtMaterialCode").val(),
                            IsActive: $("#chkIsActive").val()
                            //Consumable_Id: 10,

                        }
                }
        }

    return ConsumableMasterVM;
}