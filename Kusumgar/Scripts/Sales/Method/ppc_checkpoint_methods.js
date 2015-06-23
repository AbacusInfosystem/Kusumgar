function Get_Quality_Details(Quality_Id) {
    $.ajax({
        url: '/sales/get-quality-by-id',
        data: { quality_Id: $("#hdnQuality_Id").val() },
        method: 'GET',
        async: false,
        success: function (data) {

            Bind_Quality_Details(data);
        }
    });
}

function Bind_Quality_Details(data) {
    $("#tblQuality_Details").html("");

    var htmlText = "";
    htmlText += "<tr>";
    htmlText += "<th>Quality Attributes</th>";
    htmlText += "<th>Values</th>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>Yarn Type</td>";
    htmlText += "<td>" + data.quality.Yarn_Type_Id + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Reed";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Reed + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Pick";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Pick + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Weave";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Weave + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Minimum Order Size";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Minimum_Order_Size + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Ideal Roll Length";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Ideal_Roll_Length + "</td>";
    htmlText += "</tr>";
    htmlText += "<tr>";
    htmlText += "<td>";
    htmlText += "Our Sample No";
    htmlText += "</td>";
    htmlText += "<td>" + data.quality.Our_Sample_No + "</td>";
    htmlText += "</tr>";

    $("#tblQuality_Details").html(htmlText);

    alert(Quality_Id);
}

function Save_Enquiry() {

    var eViewModel = Set_Enquiry();

    CallAjax("/sales/update-enquiry-ppc-checkpoint/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Enquiry_CallBack, "", null);
    
}

function Enquiry_CallBack(data) {
    Friendly_Message(data);
}


function Set_Enquiry() {

    var Article_Type = "";

    if ($("#rdbQualityNo").prop('checked')) {

        Article_Type = $("#drpExistingQualityArticleType").val();

        Quality_Id = $("#hdnQuality_Id").val();
    }
    else
    {
        Article_Type = $("#drpArticleType").val();

        Quality_Id = 0;
    }

    var eViewModel =
    {
        Enquiry:
            {
                Enquiry_Id: $("#hdnEnquiry_Id").val(),

                Enquiry_No: $("#hdnEnquiry_No").val(),

                Enquiry_Type_Id: $("#hdnEnquiry_Type_Id").val(),

                Enquiry_Status_Id: $("#hdnEnquiry_Status_Id").val(),

                Customer_Id: $("#hdnCustomer_Id").val(),

                Quality_Id: $("#hdnQuality_Id").val(),

                PPC_Article_Type_Id: Article_Type,

                Quality_Set_Id: Quality_Id,

                Is_Active: $("#hdnStatus").val()
            }
    }

    return eViewModel;
}


//function Get_Customer_Quality_Details(Enquiry_Id)
//{
//    $.ajax({
//        url: '/sales/get-customer-quality-details-by-Id',
//        data: { quality_Id: $("#hdnEnquiry_Id").val() },
//        method: 'GET',
//        async: false,
//        success: function (data) {

//            Bind_Customer_Quality_Details(data);
//        }
//    });
//}

//function Bind_Customer_Quality_Details(data)
//{

//}
