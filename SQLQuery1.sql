/*********************************************
	Author : Kaustubh 
   Date : 05252015
   Purpose : To Get Y_Article by full code
*********************************************/

create procedure Get_Y_Articles_By_Yarn_Type_Id_sp
(
@Yarn_Type_Id int
)
as
begin
	
	Select * from M_Y_Article where Yarn_Type_Id = @Yarn_Type_Id
end