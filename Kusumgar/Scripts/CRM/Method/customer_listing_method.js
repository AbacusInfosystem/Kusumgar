
function Bind_States(data) {

    $("#drpState_Id").html("");

    var htmltext = "";

    htmltext += "<option>-Select States-</option>";

    if (data.States.length > 0) {
        for (var i = 0; i < data.States.length ; i++) {

            htmltext += "<option value='" + data.States[i].StateId + "'>" + data.States[i].StateName + "</option>";
        }
    }
    $("#drpState_Id").html(htmltext);
}

function Remove_Bind_States() {
   
    $("#drpState_Id").html("");

    var htmltext = "";

    htmltext += "<option >-Select States-</option>";

    $("#drpState_Id").html(htmltext);
}

function SearchCustomer()
{
    var cViewModel =
        {
            Filter:
                {
                    Customer_Name: $("#txtCustomer_Name").val(),
                    Customer_Id: $("#hdnCustomer_Id").val(),
                    //Turnover: $("#txtTurnover").val(),
                    Nation_Id: $("#drpNation_Id").val(),
                    Pin_Code: $("#txtPin_Code").val(),
                    State_Id: $("#drpState_Id").val()

                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }
    
    $("#divSearchGridOverlay").show();
   
      CallAjax("/crm/search-customer", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Grid, "", null);
    
}

function SearchCustomerByStatus() {
    var cViewModel =
        {
            Filter:
                {
                    Status_Id: $("#hdfCustomer_Status_Id").val()
                },

            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();

       CallAjax("/crm/search-customers-by-status", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Grid, "", null);
    
}
function Bind_Customer_Grid(data) {


    $('#tblcustomer tr.subhead').html("");

    var htmlText = "";

    if (data.Customers.length > 0) {

        for (i = 0; i < data.Customers.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='r1_" + data.Customers[i].Customer_Id + "' class='iradio_square-green'/>";

            htmlText += "</td>";

            htmlText += "<td id='Cust_" + data.Customers[i].Customer_Id + "'>";

            htmlText += data.Customers[i].Customer_Name == null ? "" : data.Customers[i].Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customers[i].Company_Email == null ? "" : data.Customers[i].Company_Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Customers[i].Nation_Name == null ? "" : data.Customers[i].Nation_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            //htmlText += data.Customers[i].Is_Active == null ? "" : data.Customers[i].Is_Active;
            if (data.Customers[i].Is_Active == null)
            {
                htmlText += " ";
            }
            else if (data.Customers[i].Is_Active == true)
            {
            htmlText += "Active";
            }
            else
            {
                htmlText += "In Active";
            }

            htmlText += "</td>";

            htmlText += "<input type='hidden' id='btnBlock_Unblock_" + data.Customers[i].Customer_Id + "' class='Block_Unblock' value='" + data.Customers[i].Block_Order + "'>";

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


        if (data.Customers.length > 0) {
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
                $("#hdfCustomer_Id").val(this.id.replace("r1_", ""));
                $("#hdCustomer_Id").val(this.id.replace("r1_", ""));
                $("#hdfCustomer_Name").val($("#Cust_" + this.id.replace("r1_", "")).text());
                $("#btnView").show();
                $("#btnEdit").show();
                $("#btnViewContact").show();
                $("#btnPurchaseHistory").show();

               // alert("ïd "+ ($('#btnBlock_Unblock_'+ $("#hdfCustomer_Id").val()).val() == "true"));

                if ($('#btnBlock_Unblock_' + $("#hdfCustomer_Id").val()).val() == "true") {

                    $("#btnUnblock").show();
                    $("#btnBlock").hide();
                     
                    }
                if ($('#btnBlock_Unblock_' + $("#hdfCustomer_Id").val()).val() == "false")
                    {
                    $("#btnBlock").show();
                    $("#btnUnblock").hide();
                  
                }
              
                }
          
           
        });
    
}

function PageMore(Id) {

    $("#btnView").hide();
    $("#btnEdit").hide();
    $("#btnViewContact").hide();
    $("#btnPurchaseHistory").hide();
    $("#btnBlock").hide();
    $("#btnUnblock").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    
    SearchCustomer();
}

function Save_Customer_Order() {

    var cViewModel = Set_Customer_Order();

    if ($("#hdfCustomer_Id").val() != 0) {

        CallAjax("/customer/block-order/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Customer_CallBack, "", null);
    }

}

function Customer_CallBack(data) {
   
    $("#hdfCustomer_Id").val(data.Customer.Customer_Id);

    $("#btnBlock_Unblock_" + data.Customer.Customer_Id).val(data.Customer.Block_Order);

    Friendly_Message(data);

}

function Set_Customer_Order() {
    var cViewModel =
        {
            Customer:
                {

                    Customer_Id: $("#hdfCustomer_Id").val(),

                    Block_Order: $("#hdfBlockOrder").val(),

                }
        }

    return cViewModel;
}