function SearchMaterial() {

    var mViewModel =
        {
            Filter: {
                Material_Name: $('#txtMaterialName').val(),
                Material_Id: $('#hdfMaterial_Id').val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    CallAjax("/master/search-material", "json", JSON.stringify(mViewModel), "POST", "application/json", false, Bind_Material_Grid, "", null);
}

function Bind_Material_Grid(data) {
    
    $('#tblProdGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.Materials.length; i++) {
        
        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Materials[i].Material_Id + "' class='iradio_square-green'/>";
        
        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Materials[i].Material_Code;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Materials[i].Material_Category_Name;

        htmlText += "</td>";        

        htmlText += "<td>";
        
        htmlText += data.Materials[i].Material_Name;

        htmlText += "</td>";
        
        htmlText += "<td>";
        
        htmlText += data.Materials[i].Material_Type_Str;

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
            $("#hdnMaterial_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

}

function PageMore(Id) {

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchMaterial();

}

//function Bind_SubCategories(data) {
//    $("#drpSubCatName").html("");

//    var htmltext = "";

//    htmltext += "<option>--Select--</option>";

//    if (data.length > 0) {
//        for (var i = 0; i < data.length ; i++) {
//            htmltext += "<option value='" + data[i].Material_SubCategory_Id + "'>" + data[i].Material_SubCategory_Name + "</option>";
//        }
//    }
//    $("#drpSubCatName").html(htmltext);
//}