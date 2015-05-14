﻿function SearchDefects() {
   
 var dViewModel = {

        Filter: {

             Defect_Name: $('#txtDefectName').val(),

             Defect_Type_Id: $("#hdfDefectTypeId").val(),
   
               },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(1),
           },
 };

$("#divSearchGridOverlay").show();

CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function GetAllDefects() {
   
    var dViewModel = {

        Filter: {

            Defect_Type_Id: $("#hdfDefectTypeId").val()
        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
            },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
}

function BindDefectInGrid(data, mode) {
 
    $('#tblSearchDefect tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.DefectGrid.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='hidden' id='hdfDefectId_" + data.DefectGrid[i].DefectEntity.Defect_Id + "' value='" + data.DefectGrid[i].DefectEntity.Defect_Id + "' />";

        htmlText += "<input type='radio' name='r1' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].Defect_Type_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].DefectEntity.Defect_Code;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.DefectGrid[i].DefectEntity.Defect_Name;

        htmlText += "</td>";

        if (data.DefectGrid[i].DefectEntity.Status == true) {

            htmlText += "<td>";

            htmlText += "Active";

            htmlText += "</td>";
        }
        if (data.DefectGrid[i].DefectEntity.Status == false)
        {
            htmlText += "<td>";

            htmlText += "Inactive";

            htmlText += "</td>";
        }

        htmlText += "</tr>";
    }

   
    $("#tblSearchDefect").find("tr:gt(0)").remove();

    $('#tblSearchDefect tr:first').after(htmlText);

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

  if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

         $('.pagination').html(data.Pager.PageHtmlString);
}


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    $('[name="r1"]').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $("#hdfDefectId").val($(this).parents('tr').find('input[id^=hdfDefectId]').val());

            $('#btnEdit').show();
        }
    });

    $("#divSearchGridOverlay").hide();

    }

function PageMore(Id) {
    
    $('#hdfCurrentPage').val((parseInt(Id) - 1));
   
    var dViewModel = {

        Filter: {

            Defect_Name: $('#txtDefectName').val(),

            Defect_Type_Id: $("#hdfDefectTypeId").val(),

        },

        Pager: {

            CurrentPage: $('#hdfCurrentPage').val(),
           },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Defect/Get_Defects", "json", JSON.stringify(dViewModel), "POST", "application/json", false, BindDefectInGrid, "", null);
    
}