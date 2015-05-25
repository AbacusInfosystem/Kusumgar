$(function () {

    $('#hdfCurrentPage').val(0);

    SearchIndustrial();

    $("#btnEdit").click(function () {

        $("#frmSearch_ind").attr("action", "/master/edit-industrial-master");

        $("#frmSearch_ind").attr("method", "POST");

        $("#frmSearch_ind").submit();
    });

    $("#drpIndCatName").change(function () {

        $.ajax({
            url: '/master/group-by-category-id',
            data: { industrial_Category_Id: $("#drpIndCatName").val() },
            method: 'GET',
            async: false,
            success: function (data) {

                if (data != null) {
                    Bind_Groups(data);
                }
            }
        });
    });

    $("#btnSearch").click(function () {

        $('#hdfCurrentPage').val(0);
        SearchIndustrial();
        
    });


});