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
                    required: "Select Yarn Type.."

                },

            "Quality.Quality_No":
           {

               required: "Enter Quality No.."
           },

            "Quality.Weave":
          {

              required: "Select Weave Type.."
          },

            "Quality.Minimum_Order_Size":
         {

             required: "Enter Minimum Order Size.."
         },

            "Quality.Ideal_Roll_Length":
           {

               required: "Enter Ideal Roll Length.."
           },

            "Quality.Our_Sample_No":
           {

               required: "Enter Our Sample No.."
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
                    required: "Enter Application Name.."

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
                    required: "Enter Segment Name.."

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

    }, "Quality No already exists.");

});





