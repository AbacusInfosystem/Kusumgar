$(document).ready(function () {
    
    $("#frmQuality").validate({
       
        rules: {
            "Quality.Yarn_Type_Id":
            {
              
                required: true
            },
            
            "Quality.Quality_No":
          {
              required: true,

              quality_no_exists: true,

              number: true
          },

         "Quality.Weave":
           {
              
                  required: true
           },

         "Quality.Minimum_Order_Size":
        {

            required: true,
            number: true
        },

         "Quality.Ideal_Roll_Length":
        {

            required: true,
            number: true
        },

         "Quality.Our_Sample_No":
        {

            required: true,
            number: true
        }

        },

        messages: {

            "Quality.Yarn_Type_Id":
                {
                    required: "Select yarn type."

                },

            "Quality.Quality_No":
           {

               required: "Enter quality no."
           },

            "Quality.Weave":
          {

              required: "Select weave type.."
          },

            "Quality.Minimum_Order_Size":
         {

             required: "Enter minimum order size."
         },

            "Quality.Ideal_Roll_Length":
           {

               required: "Enter ideal roll length."
           },

            "Quality.Our_Sample_No":
           {

               required: "Enter sample no."
           }
    }
 });

    $("#frmApplication").validate({
       
        rules: {
            "Application.Application_Id":
            {
              
                required: true
            }
  },

        messages: {

            "Application.Application_Id":
                {
                    required: "Enter application name."

                }
        }
        
    });

    $("#frmSegment").validate({
       
        rules: {
            "Market_Segment.Market_Segment_Id":
            {
              
                required: true
            }

        },

        messages: {

            "Market_Segment.Market_Segment_Id":
                {
                    required: "Enter segment name."

                }
        }
        
    });

    jQuery.validator.addMethod("quality_no_exists", function (value, element) {
        var result = true;

        if ($("#txtQualityNo").val() != "" && $("#hdnQualityNo").val() != $("#txtQualityNo").val()) {
            $.ajax({
                url: '/master/check-quality-no',
                data: { quality_No: $("#txtQualityNo").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Quality no already exists.");

});





