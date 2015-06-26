function SearchProcess() {

    var pViewModel =
        {
            Filter: {
                Process_Name: $('#txtProcessName').val(),
                Process_Id: $('#hdfProcess_Id').val()
            },
            Pager: {
                CurrentPage: $('#hdfCurrentPage').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    CallAjax("/master/search-process", "json", JSON.stringify(pViewModel), "POST", "application/json", false, Bind_Process_Grid, "", null);
}

function Bind_Process_Grid(data) {

    $('#tblProcGrid tr.subhead').html("");

    var htmlText = "";

    for (i = 0; i < data.Processes.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += "<input type='radio' name='r1' id='r1_" + data.Processes[i].Process_Id + "' class='iradio_square-green'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Processes[i].Process_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Processes[i].Is_Active;

        htmlText += "</td>";
        
        htmlText += "</tr>";
    }
    $("#tblProcGrid").find("tr:gt(0)").remove();

    $('#tblProcGrid tr:first').after(htmlText);

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
            $("#hdnProcess_Id").val(this.id.replace("r1_", ""));
            $("#btnEdit").show();
        }
    });

    $("#btnEdit").hide();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    SearchProcess();

}