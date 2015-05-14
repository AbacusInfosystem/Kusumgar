$(document).ready(function () {

    $('#btnSave').click(function () {
       
         if ($('#hdfDefectTypeId').val() == 0 || $('#hdfDefectTypeId').val() == '' || $('#hdfDefectTypeId').val() == undefined) {

            url = '/DefectType/Insert';
        }
        else {

            url = '/DefectType/Update';
        } 

         $('#frmDefectType').attr("action", url);

         $('#frmDefectType').attr("method", "POST");
         
         $('#frmDefectType').submit();
    });      
});


