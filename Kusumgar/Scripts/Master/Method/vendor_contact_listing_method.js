
function Search_Vendor_Contact() {
    var vcViewModel =
        {
            Filter:
                {
                    Vendor_Id: $("#hdnVendor_Id").val(),
                    Vendor_Name: $("#txtVendor_Name").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/master/vendor-contact-search", "json", JSON.stringify(vcViewModel), "POST", "application/json", false, Bind_Vendor_Contact_Grid, "", null);
}

function Bind_Vendor_Contact_Grid(data) {

    $('#tblcontact tr.subhead').html("");

    var htmlText = "";
    
    if (data.Vendor_Contacts.length > 0) {

        for (i = 0; i < data.Vendor_Contacts.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Vendor_Contacts[i].Contact_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Vendor_Contacts[i].Vendor_Name == null ? "" : data.Vendor_Contacts[i].Vendor_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Vendor_Contacts[i].Contact_Name == null ? "" : data.Vendor_Contacts[i].Contact_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Vendor_Contacts[i].Official_Email == null ? "" : data.Vendor_Contacts[i].Official_Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Vendor_Contacts[i].Office_Landline1 == null ? "" : data.Vendor_Contacts[i].Office_Landline1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Vendor_Contacts[i].Office_Landline2 == null ? "" : data.Vendor_Contacts[i].Office_Landline2;

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
    $("#tblcontact").find("tr:gt(0)").remove();

    $('#tblcontact tr:first').after(htmlText);


    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });


    if (data.Vendor_Contacts.length > 0) {
        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    Friendly_Message(data);

    $("#divSearchGridOverlay").hide();

    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {

            $("#hdfContact_Id").val(this.id.replace("r1_", ""));
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
    $('#hdfCurrent_Page').val((parseInt(Id) - 1));
    $(".selectAll").prop("checked", false);

    Search_Vendor_Contact();
}

