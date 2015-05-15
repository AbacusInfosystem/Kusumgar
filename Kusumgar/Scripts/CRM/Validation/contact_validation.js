$(function () {
    $("#frmContact").validate({

        rules: {

            "contact.Customer_Name" :
            {
                required: true
            },
            "contact.contact_Entity.Customer_Id" :
            {
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

            "contact.Customer_Name":
           {
               required: "Customer name is required"
           },
            "contact.contact_Entity.Customer_Id":
            {
            },
            "contact.contact_Entity.Contact_Name":
            {
                required: "Contact Name is required"
            },
            "contact.contact_Entity.Designation":
            {
            },
            "contact.contact_Entity.Official_Email":
            {
                required: "office email is required"
            },
            "contact.contact_Entity.Personal_Email":
            {
                required: "Personal email is required."
            },
            "contact.contact_Entity.DMU_Status_Role":
            {
                required: "Please select DMU Status Role"
            },
            "contact.contact_Entity.DMU_Status_Influence":
            {
                required: "Please select DMU Status Influence"
            },
            "contact.contact_Entity.Office_Address":
            {
                required: "Office Address is required."
            },
            "contact.contact_Entity.Office_Landline1":
            {
                required: "office landline is required."
            },
            "contact.contact_Entity.Office_Landline2":
            {
                
            },
            "contact.contact_Entity.Mobile1":
            {
                required: "Mobile No. is required"
            },
            "contact.contact_Entity.Mobile2":
            {
            }
        }
    });
});