function SearchProduct() {

    var pViewModel =
        {
            Filter: {
                Product_Name: $('#txtProductName').val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    CallAjax("/master/search-product", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Product_Grid, "", null);
}

function Bind_Product_Grid(data) {
    
    $('#tblProdGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.Products.length; i++) {
        
        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Products[i].Product_Entity.Product_Id + "' class='iradio_square-green'/>";
        
        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Products[i].Product_Entity.Product_Code;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Products[i].Product_Category_Name;

        htmlText += "</td>";        

        htmlText += "<td>";
        
        htmlText += data.Products[i].Product_Entity.Product_Name;

        htmlText += "</td>";
        
        htmlText += "<td>";
        
        htmlText += data.Products[i].Product_Entity.Product_Type;

        htmlText += "</td>";        
        
        htmlText += "</tr>";
    }
    $("#tblProdGrid").find("tr:gt(0)").remove();
    
    $('#tblProdGrid tr:first').after(htmlText);

    $('input').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });



    $('#hdfCurrentPage').val(data.Pager.CurrentPage);

    if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

        $('.pagination').html(data.Pager.PageHtmlString);
    }

    Friendly_Message(data);

    $("#divSearchGridOverlay").hide();
    
    //$('[id^="r1_"]').on('ifChanged', function (event) {
    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnProduct_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchProduct();

}

//function Bind_SubCategories(data) {
//    $("#drpSubCatName").html("");

//    var htmltext = "";

//    htmltext += "<option>--Select--</option>";

//    if (data.length > 0) {
//        for (var i = 0; i < data.length ; i++) {
//            htmltext += "<option value='" + data[i].Product_SubCategory_Entity.Product_SubCategory_Id + "'>" + data[i].Product_SubCategory_Entity.Product_SubCategory_Name + "</option>";
//        }
//    }
//    $("#drpSubCatName").html(htmltext);
//}