
function Bind_Work_Stations(data) {
   
    $("#drpWork_Station").html("");

    var htmltext = "";

    htmltext += "<option>-Select Work Station-</option>";
   
    if (data.Work_Center.Work_Stations.length > 0) {
        for (var i = 0; i < data.Work_Center.Work_Stations.length ; i++) {

            htmltext += "<option value='" + data.Work_Center.Work_Stations[i].Work_Station_Id + "'>" + data.Work_Center.Work_Stations[i].Work_Station_Name + "</option>";
        }
    }
    $("#drpWork_Station").html(htmltext);
}


//function Save_Work_Center() {

//    var wcViewModel = Get_Work_Center_values();

//    if ($("#hdnWork_Center_Id").val() == 0) {

//        CallAjax("/master/insert-work-center", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Work_Center_CallBack, "", null);
//    }
//    else {
//        CallAjax("/master/update-work-center", "json", JSON.stringify(wcViewModel), "POST", "application/json", false, Work_Center_CallBack, "", null);
//    }
//}


//function Work_Center_CallBack(data) {
   
//    //$("#hdnWork_Center_Id").val(data.Work_Center.Work_Center_Id);
//    $("#hdnWork_Center_Id").val(0);

//    $("#drpFactory").val("");
//    $("#drpWork_Station").val("");
//    $("#txtWork_Center_Code").val("");
//    $("#txtMachine_Name").val("");
//    $("#txtMachine_Properties").val("");
//    $("#txtTPM_Speed").val("");
//    $("#txtAverage_Order_Length").val("");
//    $("#txtCapacity").val("");
//    $("#txtWastage").val("");
//    $("#txtTarget_Efficiency").val("");
   


//    Friendly_Message(data);
//}


//function Get_Work_Center_values() {

//    var wcViewModel =
//        {
//            Work_Center:
//                {
//                    Process:
//                       {
//                           Process_Ids: $("#hdnProcess_Id").val(),
//                       },

//                    Work_Station:
//                        {
                         
//                                Work_Station_Id: $("#drpWork_Station").val(),
                            
                         
//                        },
                   
//                            Work_Center_Id: $("#hdnWork_Center_Id").val(),

//                            Work_Center_Code: $("#txtWork_Center_Code").val(),

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
