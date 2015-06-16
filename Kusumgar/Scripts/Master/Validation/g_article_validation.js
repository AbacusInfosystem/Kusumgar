$(function () {
    $("#frmG_Article").validate({

        rules: {
            "G_Article.Quality_Id":
            {
                required: true,
                full_code_validator: true
            },

            "G_Article.Yarn_Type_Id":
            {
                required: true,
                full_code_validator: true
            },
            "G_Article.Weave_Id":
            {
                required: true,
                full_code_validator: true
            },
            "G_Article.Grey_with_Cms":
            {
                required: true,
                number:true
            },
            "G_Article.GSM":
            {
                required: true,
                number:true
            },

                //Warp_1 to Weft_4
            //"G_Article.Warp_1":
            //{
            //    required: true
            //},
            //"G_Article.Warp_2":
            //{
            //    required: true
            //},
            //"G_Article.Warp_3":
            //{
            //    required: true
            //},
            //"G_Article.Warp_4":
            //{
            //    required: true
            //},
            //"G_Article.Weft_1":
            //{
            //    required: true
            //},
            //"G_Article.Weft_2":
            //{
            //    required: true
            //},
            //"G_Article.Weft_3":
            //{
            //    required: true
            //},
            //"G_Article.Weft_4":
            //{
            //    required: true
            //},
            
            "G_Article.Reed":
            {
                required: true
            },
            "G_Article.Pick":
            {
                required: true
            },
            "G_Article.Total_Ends":
            {
                required: true,
                number: true
            },
            "G_Article.Beam_Weight":
            {
                required: true,
                number: true
            },
            "G_Article.Beam_Roll":
            {
                required: true,
                number: true
            },
            "G_Article.Warp_Yarn_Vendor":
           {
               required: true
           },
            "G_Article.Weft_Yarn_Vendor":
           {
               required: true
           },
            "G_Article.RSP":
           {
               required: true,
               number: true
           },
            "G_Article.Draft":
          {
              required: true
          },
            "G_Article.Crimp_In_Percentage":
          {
              required: true,
              number :true
          },
            "G_Article.R_S":
          {
              required: true
          },
            "G_Article.G_W":
         {
             required: true
         },
            "G_Article.Weave":
         {
             required: true,
             number: true
         },
            "G_Article.No_Of_Healds":
         {
             required: true,
             number: true
         },
            "G_Article.Drawing_Sequence_Body":
         {
             required: true
         },
            "G_Article.Drawing_Sequence_Selvedge":
         {
             required: true
         },
            "G_Article.Roll_Size":
         {
             required: true,
             number: true
         },
            "G_Article.Warping_Meters":
         {
             required: true,
             number: true
         },
            "G_Article.Peg_Plan_Rows":
        {
            required: true,
            number: true
        },
            "G_Article.Peg_Plan_Columns":
        {
            required: true,
            number: true
        }

        },
        messages: {

            "G_Article.Quality_Id":
             {
                 required: "Quality Number is required."
             },
            "G_Article.Yarn_Type_Id":
            {
                required: "Yarn type is required"
            },
            "G_Article.Weave_Id":
            {
                required: "Weave is required"
            },
            "G_Article.Grey_with_Cms":
            {
                required: "Grey with Cms is required"
            },
            "G_Article.GSM":
            {
                required: "GSM is required"
            },
            //
            "G_Article.Warp_1":
            {
                required: "Warp 1 is required"
            },
            "G_Article.Warp_2":
            {
                required: "Warp 2 is required"
            },
            "G_Article.Warp_3":
            {
                required: "Warp 3 is required"
            },
            "G_Article.Warp_4":
            {
                required: "Warp 4 is required"
            },
            "G_Article.Weft_1":
            {
                required: "Weft 1 is required"
            },
            "G_Article.Weft_2":
            {
                required: "Weft 2 is required"
            },
            "G_Article.Weft_3":
            {
                required: "Weft 3 is required"
            },
            "G_Article.Weft_4":
            {
                required: "Weft 4 is required"
            },
            //

            "G_Article.Reed":
            {
                required: "Reed is required"
            },
            "G_Article.Pick":
            {
                required: "Pick is required"
            },
            "G_Article.Total_Ends":
            {
                required: "Total Ends is required"
            },
            "G_Article.Beam_Weight":
            {
                required: "Beam Weight is required"
            },
            "G_Article.Beam_Roll":
            {
                required: "Beam Roll is required"
            },
            "G_Article.Warp_Yarn_Vendor":
            {
                required: "Warp Yarn Vendor is required"
            },
            "G_Article.Weft_Yarn_Vendor":
            {
                required: "Weft Yarn Vendor is required"
            },
            "G_Article.RSP":
            {
                required: "RSP is required"
            },
            "G_Article.Draft":
            {
                required: "Draft is required"
            },
            "G_Article.Crimp_In_Percentage":
            {
                required: "Crimp In Percentage is required"
            },
            "G_Article.R_S":
            {
                required: "R/S is required"
            },
            "G_Article.G_W":
            {
                required: "G.W is required"
            },
            "G_Article.Weave":
            {
                required: "Weave is required"
            },
            "G_Article.No_Of_Healds":
            {
                required: "No Of Healds is required"
            },
            "G_Article.Drawing_Sequence_Body":
            {
                required: "Drawing Sequence Body is required"
            },
            "G_Article.Drawing_Sequence_Selvedge":
            {
                required: "Drawing Sequence Selvedge is required"
            },
            "G_Article.Roll_Size":
            {
                required: "Roll Size is required"
            },
            "G_Article.Warping_Meters":
            {
                required: "Warping Meters is required"
            },
            "G_Article.Peg_Plan_Rows":
            {
                required: "Peg Plan Rows is required"
            },
            "G_Article.Peg_Plan_Columns":
            {
                required: "Peg Plan Columns is required"
            }

        }
    });

    
    jQuery.validator.addMethod("full_code_validator", function (value, element) {
        if ($(".full-code").text() == "- - - -") {
            return false;
        }
        else {
            return true;
        }
    }, "Select atleast one.");

});
