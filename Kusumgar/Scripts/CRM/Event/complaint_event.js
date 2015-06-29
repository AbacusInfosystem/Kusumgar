$(document).ready(function () {
    
    InitializeAutoComplete($('#txtCustName'));


    $("#btnSave").click(function () {

        var Lot_Nos = "";

        $(".lot_no").each(function () {

            Lot_Nos += $(this).val() + ",";
        });

        $("#hdnLot_Nos").val(Lot_Nos);


        if ($("#frmComp").valid()) {

            if ($("#hdnComplaint_Id").val() == 0) {

                $("#frmComp").attr("action", "/crm/insert-complaint");

                $("#frmComp").attr("method", "POST");

                $("#frmComp").submit();
            }
            else {                

                $("#frmComp").attr("action", "/crm/update-complaint");

                $("#frmComp").attr("method", "POST");

                $("#frmComp").submit();
            }
        }
    });

    $("#btnAdd_Lot_No").click(function () {

        //if ($("#txtLot_No").val() != "") {

        //    var html = "";

        //    var label = $("#txtLot_No").val();

        //    var value = $("#hdnLot_No").val();

        //    html = Get_Lot_No(label, value);

        //    $("#txtLot_No").parents(".form-group").find(".todo-list").append(html);

        //    $("#txtLot_No").parents('.form-group').find(".todo-list").find('.fa-remove').click(function (event) {

        //        event.preventDefault();

        //        $(this).parents('li').remove();
        //    });

        //    $("#hdnLot_No").val("");

        //    $("#txtLot_No").val("");
        //}

        var label = new Array();

        var value = new Array();

        $("#lst_Available_Lot_No option:selected").each(function () {

            label.push($(this).text());
            value.push($(this).val());
            $(this).remove();
          
        });

        html = Get_Lot_No(label, value);

        $("#lst_Available_Lot_No").parents(".form-group").find(".todo-list").append(html);

        $("#lst_Available_Lot_No").parents('.form-group').find(".todo-list").find('.fa-remove').click(function (event) {
            event.preventDefault();

            var html = "<option value'" + $(this).parent().find('.lot_no').val() + "'>" + $(this).parent().find('.text').text() + "</option>";

            $("#lst_Available_Lot_No").append(html);

            $(this).parents('li').remove();
        });

    });

    $("#btnAdd_Lot_No").trigger("click");
});

