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
