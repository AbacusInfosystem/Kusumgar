function SearchComplaint() {


    var cViewModel =
        {            
            Filter: {
                Customer_Name: $("#txtCustName").val(),
                Customer_Id: $("#hdfCustomer_Id").val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }    

    $("#divSearchGridOverlay").show();
    CallAjax("/crm/search-complaint", "json", JSON.stringify(cViewModel), "POST", "application/json", false, BindCompGrid, "", null);

}

function BindCompGrid(data) {

    $('#tblComGrid tr.subhead').html("");

    var htmlText = "";

    if (data.Complaints.length > 0) {

    for (i = 0; i < data.Complaints.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Complaints[i].Complaint_Id + "' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Complaints[i].Customer_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Complaints[i].Order_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Complaints[i].Challan_No_Str;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Complaints[i].CDescription;

        htmlText += "</td>";

        htmlText += "</tr>";
    }

    }

    else {
        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "<tr>";
    }
    $("#tblComGrid").find("tr:gt(0)").remove();

    $('#tblComGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Complaints.length > 0) {

    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }
    }
    else
    {
        $('.pagination').html("");
    }

    $("#divSearchGridOverlay").hide();

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {            
            $("#hdnComplaint_Id").val(this.id.replace("r1_", ""));            
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchComplaint();

}
