$(function () {

    if($("#hdfpage_String").val() == "Contact")
    {
        $("#dvLoad_Printabel_View").load("/crm/print-view-contact",  {Contact_Id: $("#hdfId").val() },null );
    }

    if ($("#hdfpage_String").val() == "Vendor_Contact")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-vendor-contact", {Contact_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "Vendor")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-vendor", { Vendor_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "Material")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-material", { Material_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "Work_Center")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-work_center", { Work_Center_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "G_Article")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-g-article", { G_Article_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "P_Article")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-p-article", { P_Article_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "C_Article")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-c-article", { C_Article_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "Y_Article")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-y-article", { Y_Article_Id: $("#hdfId").val() }, null);
    }

    if ($("#hdfpage_String").val() == "W_Article")
    {
        $("#dvLoad_Printabel_View").load("/master/print-view-w-article", { W_Article_Id: $("#hdfId").val() }, null);
    }



    if ($("#hdfpage_String").val() == "Customer") {
        $("#dvLoad_Printabel_View").load("/crm/print-view-customer", { Customer_Id: $("#hdfId").val() }, null);
    }
});