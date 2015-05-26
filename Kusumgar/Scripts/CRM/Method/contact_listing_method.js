
function SearchContact() {
    var cViewModel =
        {
            Filter:
                {
                    Customer_Id: $("#hdnCustomer_Id").val(),
                    Customer_Name: $("#txtCustomer_Name").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/crm/contact-search", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Contact_Grid, "", null);
}


function Bind_Contact_Grid(data) {

   // $("#txtCustomer_Name").val(data.Filter_Val.Customer_Name);
    $('#tblcontact tr.subhead').html("");

    var htmlText = "";

    if (data.Contacts.length > 0) {

        for (i = 0; i < data.Contacts.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Contacts[i].contact_Entity.Contact_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Contacts[i].Customer_Name == null ? "" : data.Contacts[i].Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Contacts[i].contact_Entity.Contact_Name == null ? "" : data.Contacts[i].contact_Entity.Contact_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Contacts[i].contact_Entity.Official_Email == null ? "" : data.Contacts[i].contact_Entity.Official_Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Contacts[i].contact_Entity.Office_Landline1 == null ? "" : data.Contacts[i].contact_Entity.Office_Landline1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Contacts[i].contact_Entity.Office_Landline2 == null ? "" : data.Contacts[i].contact_Entity.Office_Landline2;

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


    if (data.Contacts.length > 0) {
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
            $("#hdfContact_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
            $("#btnViewCompany").show();
            $("#btnSellProduct").show();
        }
    });

}

function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnViewCompany").hide();
    $("#btnSellProduct").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchContact();
}

//var autoCustomerCallback = function (paramObj) {

//    BindCustomerTags(paramObj.item.label, paramObj.item.value);
//}

//function BindCustomerTags(label, value) {
//    $('#hdnCustomer_Id').val(value);

//    $('#txtCustomer_Name').val(label);
//}