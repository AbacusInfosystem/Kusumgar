/*********************************************
	Author : Kaustubh 
   Date : 05052015
   Purpose : To Get Customer by Nation Id and Turnover
*********************************************/
Create procedure Get_Customer_by_Nation_Id_Turnover_Sp
(
@Nation_Id int,
@Turnover decimal
)
as
begin
	 select * from Customer  where Head_Office_Nation = @Nation_Id and Company_Turnover > @Turnover
end


select * from Customer  where Head_Office_Nation = 1