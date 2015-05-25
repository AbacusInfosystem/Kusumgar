function SearchComplaint() {


    var _complaintViewModel =
        {            
            Complaint_FilterVal: {
                CustomerName: $("#txtCustName").val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }    

    $("#divSearchGridOverlay").show();
    CallAjax("/crm/search-complaint", "json", JSON.stringify(_complaintViewModel), "POST", "application/json", false, BindCompGrid, "", null);

}

function BindCompGrid(data) {

    $('#tblComGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.ComplaintList.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.ComplaintList[i].ComplaintEntity.ComplaintId + "' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.ComplaintList[i].CustomerName;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.ComplaintList[i].ComplaintEntity.OrderId;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.ComplaintList[i].ComplaintEntity.OrderItemId;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.ComplaintList[i].ComplaintEntity.ChallanNo;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.ComplaintList[i].ComplaintEntity.CDescription;

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblComGrid").find("tr:gt(0)").remove();

    $('#tblComGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });



    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
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

var autoComplaintSCallback = function (paramObj) {

    BindCompSTags(paramObj.item.label, paramObj.item.value);

}

function BindCompSTags(label, value) {

    $('#hdnCustId').val(value);

    $('#txtCustName').val(label);

}