$(function () {
    $("#frmContact").validate({

        rules: {

            //"contact.Customer_Name" :
            //{
            //    required: true
            //},
            "contact.contact_Entity.Customer_Id" :
            {
                required:true
            },
            "contact.contact_Entity.Contact_Name" :
            {
                required: true
            },
            "contact.contact_Entity.Designation" :
            {
            },
            "contact.contact_Entity.Official_Email" :
            {
                required: true,
                email:true
            },
            "contact.contact_Entity.Personal_Email" :
            {
                required: true,
                email:true
            },
            "contact.contact_Entity.DMU_Status_Role" :
            {
                required:true
            },
            "contact.contact_Entity.DMU_Status_Influence" :
            {
                required: true
            },
            "contact.contact_Entity.Office_Address" :
            {
                required: true
            },
            "contact.contact_Entity.Office_Landline1" :
            {
                required: true,
                number: true
            },
            "contact.contact_Entity.Office_Landline2" :
            {
                number:true
            },
            "contact.contact_Entity.Mobile1" :
            {
                required: true,
                number: true,
                minlength: 10
            },
            "contact.contact_Entity.Mobile2" :
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
            "contact.contact_Entity.Customer_Id":
            {
                required: "Customer name is required."
            },
            "contact.contact_Entity.Contact_Name":
            {
                required: "Contact name is required."
            },
            "contact.contact_Entity.Designation":
            {
            },
            "contact.contact_Entity.Official_Email":
            {
                required: "Office email is required."
            },
            "contact.contact_Entity.Personal_Email":
            {
                required: "Personal email is required."
            },
            "contact.contact_Entity.DMU_Status_Role":
            {
                required: "Please select DMU status role."
            },
            "contact.contact_Entity.DMU_Status_Influence":
            {
                required: "Please select DMU status influence."
            },
            "contact.contact_Entity.Office_Address":
            {
                required: "Office address is required."
            },
            "contact.contact_Entity.Office_Landline1":
            {
                required: "Office landline is required."
            },
            "contact.contact_Entity.Office_Landline2":
            {
                
            },
            "contact.contact_Entity.Mobile1":
            {
                required: "Mobile no. is required."
            },
            "contact.contact_Entity.Mobile2":
            {
            }
        }
    });
});