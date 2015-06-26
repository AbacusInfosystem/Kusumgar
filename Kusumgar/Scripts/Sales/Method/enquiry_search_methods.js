
function SearchEnquiry() {
    var eViewModel =
        {
            Filter:
                {
                    Quality_Id: $("#hdnQuality_Id").val(),
                    Quality_No: $("#hdnQuality_No").val(),
                    Customer_Id: $("#hdnCustomer_Id").val(),
                    Customer_Name: $("#hdnContact_Name").val(),
                    Status_Id: $("#hdfEnquiry_Status_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    if ($("#hdfEnquiry_Status_Id").val() != 0)
    {
        CallAjax("/sales/get-enquiries-by-status", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Enquiry_Grid, "", null);
    }
    else
    {
        CallAjax("/sales/enquiry-search", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Enquiry_Grid, "", null);
    }

    
}


function Bind_Enquiry_Grid(data) {



    var htmlText = "";

    if (data.Enquiries.length > 0) {

        for (i = 0; i < data.Enquiries.length; i++) {

            htmlText += "<tr>";

            if (data.Enquiries[i].Enquiry_Status == "Enquiry Arrived") {

                htmlText += "<td>";

                htmlText += "<input type='radio' name='r1' id='r1_" + data.Enquiries[i].Enquiry_Id + "' class='iradio_square-green'/>";

                htmlText += "</td>";
            }
            else
            {
                htmlText += "<td>";

                htmlText += "</td>";
            }

            htmlText += "<td>";

            htmlText += data.Enquiries[i].Enquiry_No == null ? "" : data.Enquiries[i].Enquiry_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquiries[i].Customer_Name == null ? "" : data.Enquiries[i].Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquiries[i].Quality_No == null ? "" : data.Enquiries[i].Quality_No;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText +=  " " ;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText +=  " ";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquiries[i].Enquiry_Status == null ? "" : data.Enquiries[i].Enquiry_Status;

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblEnquiry").find("tr:gt(0)").remove();

    $('#tblEnquiry tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Enquiries.length > 0) {
        $('#hdfCurrentPage').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    Friendly_Message(data);

    $("#divSearchGridOverlay").hide();

    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnEnquiry_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
            $("#btnView").show();
        }
    });

    $("#btnEdit").hide();

    $("#btnView").hide();
}

function PageMore(Id) {

    $("#btnEdit").hide();

    $("#btnView").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchEnquiry();
}
