function SearchDefectTypes() {

    var dViewModel = {

        Filter: {
            Defect_Type_Id: $('#hdnDefectTypeId').val(),
           Defect_Type_Name: $('#txtDefectTypeName').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
        },
 };
    
$("#divSearchGridOverlay").show();

CallAjax("/DefectType/Get_Defect_Types", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
}

function GetAllDefectTypes() {
    
    var dViewModel = {

        Filter: {

                Defect_Type_Id:"",
                 Defect_Type_Name: ""
                },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
         },
};

$("#divSearchGridOverlay").show();

 CallAjax("/DefectType/Get_Defect_Types", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
}

function BindDefectTypeInGrid(data, mode) {
 
 $('#tblSearchDefectType tr.subhead').html("");

 var htmlText = "";
 if (data.DefectTypeGrid.length > 0) {
     for (i = 0; i < data.DefectTypeGrid.length; i++) {

         htmlText += "<tr>";

         htmlText += "<td>";

         htmlText += "<input type='hidden' id='hdfDefectTypeId_" + data.DefectTypeGrid[i].DefectTypeEntity.Defect_Type_Id + "' value='" + data.DefectTypeGrid[i].DefectTypeEntity.Defect_Type_Id + "' />";

         htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

         htmlText += "</td>";

         htmlText += "<td>";

         htmlText += data.DefectTypeGrid[i].DefectTypeEntity.Defect_Type_Name;

         htmlText += "</td>";

         if (data.DefectTypeGrid[i].DefectTypeEntity.Status == true) {

             htmlText += "<td>";

             htmlText += "Active";

             htmlText += "</td>";
         }
         if (data.DefectTypeGrid[i].DefectTypeEntity.Status == false) {
             htmlText += "<td>";

             htmlText += "Inactive";

             htmlText += "</td>";
         }

         htmlText += "</tr>";
     }
 }
 else {
     htmlText += "<tr>";

     htmlText += "<td colspan=3>";

     htmlText += "No record found.";

     htmlText += "</td>";

     htmlText += "</tr>";
 }

    $("#tblSearchDefectType").find("tr:gt(0)").remove();

    $('#tblSearchDefectType tr:first').after(htmlText);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    

    if (data.DefectTypeGrid.length > 0) {
        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else
    {
        $('.pagination').html("");
    }

 $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
 });

  $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $("#hdfDefectTypeId").val($(this).parents('tr').find('input[id^=hdfDefectTypeId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();
}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    var dViewModel = {

        Filter: {

            Defect_Type_Id: $('#hdnDefectTypeId').val(),
            Defect_Type_Name: $('#txtDefectTypeName').val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
        },

    };

    $("#divSearchGridOverlay").show();

    CallAjax("/DefectType/Get_Defect_Types", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectTypeInGrid, "", null);
}