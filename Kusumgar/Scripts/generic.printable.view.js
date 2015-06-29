$(function () {

    if($("#hdfpage_String").val() == "Contact")
    {
        $("#dvLoad_Printabel_View").load("/crm/print-view-contact",  {Contact_Id: $("#hdfId").val() },null );
    }

    if ($("#hdfpage_String").val() == "Quality") {
        $("#dvLoad_Printabel_View").load("/master/print-view-quality", { Quality_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "Customer") {
        $("#dvLoad_Printabel_View").load("/crm/print-view-customer", { Customer_Id: $("#hdfId").val() }, null);
    }
});