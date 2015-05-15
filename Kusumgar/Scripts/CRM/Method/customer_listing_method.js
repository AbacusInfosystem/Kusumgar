
function SearchCustomer()
{
    var _customerViewModel =
        {
            Filter_Value:
                {
                    Customer_Name: $("#txtCustomerName").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/crm/search-customer", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, BindCustomerGrid, "", null);
}

function AdvanceSearch()
{
    var _customerViewModel =
            {
                Filter_Value:
                    {
                        Customer_Name: $("#txtCustomer_Name").val(),
                        Email: $("#txtEmailId").val(),
                        Turnover: $("#txtTurnover").val()
                    },

                Pager: {
                    CurrentPage: $('#hdfCurrentPage').val(),
                },
            }

    $("#divSearchGridOverlay").show();

    $("#myModal").toggle();

    CallAjax("/crm/search-customer", "json", JSON.stringify(_customerViewModel), "POST", "application/json", false, BindCustomerGrid, "", null);
}

function BindCustomerGrid(data) {


    $('#tblcustomer tr.subhead').html("");

    var htmlText = "";

    if (data.Customer_List.length > 0) {

        for (i = 0; i < data.Customer_List.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Customer_List[i].Customer_Entity.Company_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_List[i].Customer_Entity.Customer_Name == null ? "" : data.Customer_List[i].Customer_Entity.Customer_Name;

            htmlText += "</td>";



            htmlText += "<td>";

            htmlText += data.Customer_List[i].Customer_Entity.Company_Email == null ? "" : data.Customer_List[i].Customer_Entity.Company_Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_List[i].Customer_Entity.Head_Office_Landline1 == null ? "" : data.Customer_List[i].Customer_Entity.Head_Office_Landline1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_List[i].Customer_Entity.Head_Office_Landline2 == null ? "" : data.Customer_List[i].Customer_Entity.Head_Office_Landline2;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customer_List[i].Customer_Entity.Company_Turnover;

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
        $("#tblcustomer").find("tr:gt(0)").remove();

        $('#tblcustomer tr:first').after(htmlText);

  
        $('input').iCheck({
            radioClass: 'iradio_square-green',
            increaseArea: '20%' // optional
        });


        if (data.Customer_List.length > 0) {
            $('#hdfCurrentPage').val(data.Pager.CurrentPage);

            if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

                $('.pagination').html(data.Pager.PageHtmlString);
            }
        }
        else {
            $('.pagination').html("");
        }

        friendly_message(data);

        $("#divSearchGridOverlay").hide();

        //$('[id^="r1_"]').on('ifChanged', function (event) {
        $('[name="r1"]').on('ifChanged', function (event) {
            if ($(this).prop('checked')) {
                $("#hdfCompany_Id").val(this.id.replace("r1_", ""));
                $("#hdfCustomer_Id").val(this.id.replace("r1_", ""));
                $("#btnEdit").show();
                $("#btnViewContact").show();
                $("#btnPurchaseHistory").show();
            }
        });
    
}

function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnViewContact").hide();
    $("#btnPurchaseHistory").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchCustomer();
}