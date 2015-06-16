$(function () {
    $("#frmContact").validate({

        rules: {

            //"contact.Customer_Name" :
            //{
            //    required: true
            //},
            "contact.Customer_Id" :
            {
                required:true
            },
            "contact.Contact_Name" :
            {
                required: true
            },
            "contact.Designation" :
            {
            },
            "contact.Official_Email" :
            {
                required: true,
                email:true
            },
            "contact.Personal_Email" :
            {
                required: true,
                email:true
            },
            "contact.DMU_Status_Role" :
            {
                required:true
            },
            "contact.DMU_Status_Influence" :
            {
                required: true
            },
            "contact.Office_Address" :
            {
                required: true
            },
            "contact.Office_Landline1" :
            {
                required: true,
                number: true
            },
            "contact.Office_Landline2" :
            {
                number:true
            },
            "contact.Mobile1" :
            {
                required: true,
                number: true,
                minlength: 10
            },
            "contact.Mobile2" :
            {
                number: true,
                minlength: 10
            }
        },
        messages: {

           // "contact.Customer_Name":
           //{
           //    required: "Customer name is required"
           //},
            "contact.Customer_Id":
            {
                required: "Customer name is required."
            },
            "contact.Contact_Name":
            {
                required: "Contact name is required."
            },
            "contact.Designation":
            {
            },
            "contact.Official_Email":
            {
                required: "Office email is required."
            },
            "contact.Personal_Email":
            {
                required: "Personal email is required."
            },
            "contact.DMU_Status_Role":
            {
                required: "Please select DMU status role."
            },
            "contact.DMU_Status_Influence":
            {
                required: "Please select DMU status influence."
            },
            "contact.Office_Address":
            {
                required: "Office address is required."
            },
            "contact.Office_Landline1":
            {
                required: "Office landline is required."
            },
            "contact.Office_Landline2":
            {
                
            },
            "contact.Mobile1":
            {
                required: "Mobile no. is required."
            },
            "contact.Mobile2":
            {
            }
        }
    });
});