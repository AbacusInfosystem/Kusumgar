$(function () {

    if($("#hdfpage_String").val() == "Contact")
    {
        $("#dvLoad_Printabel_View").load("/crm/print-view-contact",  {Contact_Id: $("#hdfId").val() },null );
    }
});