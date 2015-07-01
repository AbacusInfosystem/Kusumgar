
function Bind_Work_Centers(data) {
   
    $("#drpWork_Center").html("");

    var htmltext = "";

    htmltext += "<option>-Select Work Center-</option>";
   
    if (data.Work_Station.Work_Centers.length > 0) {
        for (var i = 0; i < data.Work_Station.Work_Centers.length ; i++) {

            htmltext += "<option value='" + data.Work_Station.Work_Centers[i].Work_Center_Id + "'>" + data.Work_Station.Work_Centers[i].Work_Center_Name + "</option>";
        }
    }
    $("#drpWork_Center").html(htmltext);
}


//function Save_Work_Station() {

//    var wcViewModel = Get_Work_Station_values();

//    if ($("#hdnWork_Station_Id").val() == 0) {

//        CallAjax("/master/insert-work-Station", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Work_Station_CallBack, "", null);
//    }
//    else {
//        CallAjax("/master/update-work-Station", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Work_Station_CallBack, "", null);
//    }
//}


//function Work_Station_CallBack(data) {
   
//    //$("#hdnWork_Station_Id").val(data.Work_Station.Work_Station_Id);
//    $("#hdnWork_Station_Id").val(0);

//    $("#drpFactory").val("");
//    $("#drpWork_Center").val("");
//    $("#txtWork_Station_Code").val("");
//    $("#txtMachine_Name").val("");
//    $("#txtMachine_Properties").val("");
//    $("#txtTPM_Speed").val("");
//    $("#txtAverage_Order_Length").val("");
//    $("#txtCapacity").val("");
//    $("#txtWastage").val("");
//    $("#txtTarget_Efficiency").val("");
   


//    Friendly_Message(data);
//}


//function Get_Work_Station_values() {

//    var wcViewModel =
//        {
//            Work_Station:
//                {
//                    Process:
//                       {
//                           Process_Ids: $("#hdnProcess_Id").val(),
//                       },

//                    Work_Center:
//                        {
                         
//                                Work_Center_Id: $("#drpWork_Center").val(),
                            
                         
//                        },
                   
//                            Work_Station_Id: $("#hdnWork_Station_Id").val(),

//                            Work_Station_Code: $("#txtWork_Station_Code").val(),

//                            Machine_Name: $("#txtMachine_Name").val(),

//                            Machine_Properties: $("#txtMachine_Properties").val(),

//                            TPM_Speed: $("#txtTPM_Speed").val(),

//                            Average_Order_Length: $("#txtAverage_Order_Length").val(),

//                            Capacity: $("#txtCapacity").val(),

//                            Wastage: $("#txtWastage").val(),

//                            Target_Efficiency: $("#txtTarget_Efficiency").val(),

//                            Under_Maintainance: $("#hdnUnder_Maintainance").val(),

//                            Is_Active: $("#hdnIs_Active").val(),
                          
//                }
//        }

//    return wcViewModel;
//}
