
/*********************************************
	Author : Kaustubh 
   Date : 05112015
   Purpose : To Delete Delete Contact Custom Fields By Id
*********************************************/

create procedure Delete_Contact_Custom_Fields_By_Id
(
@Contact_Custom_Field_Id int
)
as
begin

	Delete from Contact_Custom_Fields where Contact_Custom_Field_Id = @Contact_Custom_Field_Id

end